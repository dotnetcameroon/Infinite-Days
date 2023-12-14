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
            Response<TEntity> result = new();

            try
            {
                var sqliteConnectionBuilder = new SqliteConnectionStringBuilder()
                {
                    DataSource = _databaseInitMethodes.DatabasePath
                };
                using (IDbConnection connection = new SqliteConnection(sqliteConnectionBuilder.ToString()))
                {
                    //connection.Open();

                    if (accessModel.ResultType == ResultType.Single)
                    {
                        result.Result = (await connection.QueryFirstOrDefaultAsync<TEntity>(accessModel.CommandText, accessModel.Parameters));
                        result.IsSuccess = true;
                    }
                    else if (accessModel.ResultType == ResultType.Multiple)
                    {
                        result.Results = (await connection.QueryAsync<TEntity>(accessModel.CommandText, accessModel.Parameters));
                        result.IsSuccess = true;
                    }
                    else if (accessModel.ResultType == ResultType.NoResult)
                    {
                        await connection.ExecuteAsync(accessModel.CommandText, accessModel.Parameters);
                        result.IsSuccess = true;
                    }
                }
                return result;
            }
            catch (Exception ex)
			{

				Console.WriteLine(ex.Message);
                return result;

            }
        }

        public async Task<Response<TEntity>> CallDatabasetransactionAsync<TEntity>(DatabaseAccessModel accessModel, DatabaseAccessModel accessModel1)
        {
            Response<TEntity> result = new();

            try
            {
                var sqliteConnectionBuilder = new SqliteConnectionStringBuilder()
                {
                    DataSource = _databaseInitMethodes.DatabasePath
                };
                using (IDbConnection connection = new SqliteConnection(sqliteConnectionBuilder.ToString()))
                {
                    SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());
                    SQLitePCL.Batteries.Init();
                    connection.Open();

                    using (IDbTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            var orderId = await connection.QueryFirstOrDefaultAsync<int>(accessModel.CommandText, accessModel.Parameters, transaction);

                            List<ProductsOrder> productsOrders = new List<ProductsOrder>();
                            var param = (Product[])accessModel1.Parameters;
                            foreach (var item in param)
                            {
                                //productsOrders.Add(new() { OrderId = orderId, ProductId = item.Id });
                                connection.Execute(accessModel1.CommandText, new { OrderId = orderId, ProductId = item.Id }, transaction);

                            }
                           // connection.Execute(accessModel1.CommandText, productsOrders, transaction);

                            transaction.Commit();
                            result.IsSuccess = true;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            return result;
                        }
                    }

                }
                return result;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return result;

            }
        }
    }
}
