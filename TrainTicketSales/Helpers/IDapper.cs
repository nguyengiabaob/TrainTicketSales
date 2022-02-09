using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace TrainTicketSales.Helpers
{
    public interface IDapper:IDisposable
    {
        DbConnection GetDbconnection(string conStr);
        T GetByQueryString<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        IEnumerable<T> GetMultiByStoreProcedure<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);        
        T ExecuteTransaction<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        IEnumerable<T> GetMultiByStringQuery<T>(string strQuery, DynamicParameters parms, CommandType commandType = CommandType.Text);
        Task<T> GetByStoreProcedureAsync<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        Task<IEnumerable<T>> GetMultiByStoreProcedureAsync<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);       
        Task<T> ExecuteTransactionAsync<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);        
    }
}
