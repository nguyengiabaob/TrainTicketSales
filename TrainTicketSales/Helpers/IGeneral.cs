using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace TrainTicketSales.Helpers
{
    public interface IGeneral
    {

        /// <summary>
        /// Summary:
        ///         Get code from table in database
        /// Parameters:
        ///         value: 
        ///             tableName : "Customers.Customer"
        ///             Codestr: "CU"
        ///             len: 3 (lenght of string number [example: "CU0001" leght is 4])
        ///             columnName: "CustomerCode" (column name get code)
        /// Returns:       
        ///         string of code
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="Codestr"></param>
        /// <param name="len"></param>
        /// <param name="columnName"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        string GetCode(string tableName, string Codestr, int len, string columnName, string type);

        string Encrypt(string value,bool hash);
        string Decrypt(string value,bool hash);
    }
}
