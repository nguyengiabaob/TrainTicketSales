using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TrainTicketSales.ModelsViews
{
    public class UsersModel
    {
        public string ID { get; set; }        
        public string Username { get; set; }
        public string FullName { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        public string Token { get; set; }

        public object role { get; set; }
        public long exp { get; set; }
        public long iat { get; set; }
    }
}
