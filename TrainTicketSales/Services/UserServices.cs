
using System;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Xml;

using System.Net;
using System.IO;

using System.Text;
using System.Security.Claims;
using System.Data;

using TrainTicketSales.Helpers;
using TrainTicketSales.ModelsViews;
using TrainTicketSales.Interfaces;
using TrainTicketSales.Models.Entity;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace API_CRM.Services.UserManagementServices.UserServices
{
    public class UserServices : IUsersService
    {
        private readonly AppSettings _appSettings;
        private readonly string _connStr;
        
        private readonly IConfiguration _configuration;

        private readonly IGeneral _general;

        private readonly IDapper _dapper;

        public UserServices(DsvnContext context, IConfiguration configuration,  IOptions<AppSettings> appSettings, IDapper dapper, IGeneral general)
        {
            _appSettings = appSettings.Value;
            _configuration = configuration;
            
            //_connStr = _configuration.GetConnectionString("TicketConnectionGetUser");

            _connStr = _configuration.GetConnectionString("DefaultConnection");
            _dapper = dapper;
            _general = general;
        }
       
       
        UsersModel clsUser;

        public TokenModel EncodeToken(string username, string password)
        {
            TokenModel token1 = new TokenModel();
            var param = new DynamicParameters();
            param.Add("@userID", username);
            param.Add("@Pass", password);
            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                try
                {
                    //var clsUser1 = connection.Query<UsersModel>(_commandText.Ticket_GetUserInfo, param, commandType: CommandType.StoredProcedure);
                    var clsUser1 = connection.Query<UsersModel>("User_GetByUserID", param, commandType: CommandType.StoredProcedure);
                    if (clsUser1.Any())
                    {
                        clsUser = clsUser1.ToList()[0];
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {

                    string a = ex.ToString();
                }
            }
            
            if (clsUser.ID.ToString() != "")
            {
                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserName", clsUser.Username),
                        new Claim("ID", clsUser.ID.ToString()),
                        new Claim(ClaimTypes.Role, ""),
                    }),
                    Expires = DateTime.UtcNow.AddDays(30),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                //clsUser.Token = tokenHandler.WriteToken(token);
                //var jwtToken = tokenHandler.ReadToken(clsUser.Token) as JwtSecurityToken;
                //clsUser.exp = Convert.ToInt64(jwtToken.Claims.First(claim => claim.Type == "exp").Value) * 1000;
                //clsUser.iat = (Convert.ToInt64(jwtToken.Claims.First(claim => claim.Type == "exp").Value) * 1000) - 2592000000;

                //DeclareSystem.UserName = clsUser.Username;
                token1.Token = tokenHandler.WriteToken(token);
            }
            return token1;
        }
        public UsersModel DecodeToken(string token)
        {
            try
            {
                token = token.Replace("Bearer ", "");
                Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII = true;
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
                var role = jwtToken.Claims.First(claim => claim.Type == "role").Value;
                if (jwtToken == null)
                    return null;

                var symmetricKey = Encoding.ASCII.GetBytes(_appSettings.Secret);

                var validationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricKey),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = true,
                };

                var principal = tokenHandler.ValidateToken(token, validationParameters, out var securityToken);

                clsUser.role = role;

                return clsUser;
            }
            catch (Exception)
            {

                return null;
            }
        }

    }
}
