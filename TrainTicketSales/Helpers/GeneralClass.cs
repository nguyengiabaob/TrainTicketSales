

using Dapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TrainTicketSales.Helpers
{
    public class GeneralClass : IGeneral
    {
        private readonly IConfiguration _configuration;
        private readonly string _connStr;
        private readonly AppSettings _appSettings;

        //public GeneralClass(string str)
        //{           
        //    _connStr = str;
        //}
        public GeneralClass(IConfiguration configuration, IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _configuration = configuration;
            _connStr = _configuration.GetConnectionString("DefaultConnection");
        }

        public string GetCode(string tableName, string Codestr, int len, string columnName, string type)
        {
            string code = "";
            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@tableName", tableName);
                parameters.Add("@codeStr", Codestr);
                parameters.Add("@len", len);
                parameters.Add("@ColumnName", columnName);
                parameters.Add("@type", type);
                var result = connection.Query<string>("General_GetCode", parameters, commandType: CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    code = result.ToList()[0].ToString().Trim();
                }
                else
                {
                    code = Codestr.Trim() + DateTime.Now.Year.ToString().Substring(2, 2) + ("A00" + DateTime.Now.Month.ToString()).Substring(("A00" + DateTime.Now.Month.ToString()).Length - 2) + "000001".Substring("000001".Length - len, len);
                }
            }
            return code;
        }

        /// <summary>
        /// Encrypt a string using dual encryption method. Return a encrypted cipher Text
        /// </summary>
        /// <param name="toEncrypt">string to be encrypted</param>
        /// <param name="useHashing">use hashing? send to for extra secirity</param>
        /// <returns></returns>
        public string Encrypt(string toEncrypt, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Encoding.UTF8.GetBytes(toEncrypt);
            var key = _appSettings.KeyCrypt;
            //System.Windows.Forms.MessageBox.Show(key);
            if (useHashing)
            {
                var hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = Encoding.UTF8.GetBytes(key);

            var tdes = new TripleDESCryptoServiceProvider{ Key = keyArray, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 };

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        /// <summary>
        /// DeCrypt a string using dual encryption method. Return a DeCrypted clear string
        /// </summary>
        /// <param name="cipherString">encrypted string</param>
        /// <param name="useHashing">Did you use hashing to encrypt this data? pass true is yes</param>
        /// <returns></returns>
        public string Decrypt(string cipherString, bool useHashing)
        {
            if (string.IsNullOrWhiteSpace(cipherString))
                return string.Empty;
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            //Get your key from config file to open the lock!

            var key = _appSettings.KeyCrypt;
            if (useHashing)
            {
                var hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = Encoding.UTF8.GetBytes(key);

            var tdes = new TripleDESCryptoServiceProvider { Key = keyArray, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 };

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            tdes.Clear();
            return Encoding.UTF8.GetString(resultArray);
        }
    }
}
