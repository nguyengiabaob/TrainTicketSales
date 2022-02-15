
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainTicketSales.ModelsViews;

namespace TrainTicketSales.Interfaces
{
    public interface IUsersService
    {
        TokenModel EncodeToken(string username, string password);
        UsersModel DecodeToken(string token);
        
    }
}