using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace TrainTicketSales.Helpers
{
    public class Dapper : IDapper
    {
        private readonly IConfiguration _config;
        private string _conn = "DefaultConnection";

        public Dapper(IConfiguration config)
        {
            _config = config;
            _conn = _config.GetConnectionString("DefaultConnection");
        }
        public void Dispose()
        {

        }
        public DbConnection GetDbconnection(string conStr)
        {
            _conn = conStr;
            return new SqlConnection(conStr);
        }

        public T GetByQueryString<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text)
        {
            using IDbConnection db = GetDbconnection(_conn);
            return db.Query<T>(sp, parms, commandType: commandType).FirstOrDefault();
        }
        public async Task<T> GetByStoreProcedureAsync<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = GetDbconnection(_conn);
            return (await db.QueryAsync<T>(sp, parms, commandType: commandType)).FirstOrDefault();
        }
        public IEnumerable<T> GetMultiByStringQuery<T>(string strQuery, DynamicParameters parms, CommandType commandType = CommandType.Text)
        {
            using IDbConnection db = GetDbconnection(_conn);
            return db.Query<T>(strQuery, parms, commandType: commandType);
        }
        public IEnumerable<T> GetMultiByStoreProcedure<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = GetDbconnection(_conn);
            return db.Query<T>(sp, parms, commandType: commandType);
        }

        public async Task<IEnumerable<T>> GetMultiByStoreProcedureAsync<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = GetDbconnection(_conn);
            return await db.QueryAsync<T>(sp, parms, commandType: commandType);
        }
        public T ExecuteTransaction<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;
            using IDbConnection db = GetDbconnection(_conn);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();
                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                    throw;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return result;
        }





        public async Task<T> ExecuteTransactionAsync<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;
            using IDbConnection db = GetDbconnection(_conn);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    result = (await db.QueryAsync<T>(sp, parms, commandType: commandType, transaction: tran)).FirstOrDefault();
                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                    throw;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return result;

        }

    }
}
