using models;
using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace lib.Data
{
    public class DatabaseAccessMethodes(IDatabaseInitMethodes _databaseInitMethodes) : IDatabaseAccessMethodes
    {
        public async Task<Response<TEntity>> CallDatabaseResponseAsync<TEntity>(DatabaseAccessModel accessModel)
        {
			try
			{
                Response<TEntity> result = new();
                using (IDbConnection db = new SqliteConnection(_databaseInitMethodes.DatabasePath))
                {

                    if (accessModel.ResultType == ResultType.Single)
                    {
                        result.Result = (await db.QueryFirstOrDefaultAsync<TEntity>(accessModel.CommandText, accessModel.Parameters));
                        result.IsSuccess = true;
                    }
                    else if (accessModel.ResultType == ResultType.Multiple)
                    {
                        result.Results = (await db.QueryAsync<TEntity>(accessModel.CommandText, accessModel.Parameters));
                        result.IsSuccess = true;
                    }
                }
                return result;
            }
            catch (Exception)
			{

				throw;
			}
        }
    }
}
