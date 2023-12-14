using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.IO;
using SQLitePCL;


namespace lib.Data;

public class DatabaseInitMethodes : IDatabaseInitMethodes
{

    public string DatabasePath { get => $"{Environment.CurrentDirectory}\\Infinite-database.db"; }

    public async void CreateDatabase()
    {

        SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());
        SQLitePCL.Batteries.Init();

        using (IDbConnection connection = new SqliteConnection($"Data Source={DatabasePath}"))
        {
            connection.Open();
            try
            {
                var CommandText = @"CREATE TABLE IF NOT EXISTS Products (
                                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                            Name TEXT NOT NULL,
                                            Price DECIMAL NOT NULL
                                        )";
                await connection.ExecuteAsync(CommandText, CommandType.Text);

                var CommandText1 = @"CREATE TABLE IF NOT EXISTS Orders (
                                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                                TotalPrice DECIMAL NOT NULL
                                            )";

                await connection.ExecuteAsync(CommandText1, CommandType.Text);

                var CommandText2 = @"CREATE TABLE IF NOT EXISTS ProductsOrder (
                                                OrderId INTEGER,
                                                ProductId INTEGER,
                                                FOREIGN KEY (OrderId) REFERENCES Orders(Id),
                                                FOREIGN KEY (ProductId) REFERENCES Products(Id)
                                            )";
                await connection.ExecuteAsync(CommandText2, CommandType.Text);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
    }

    public void InitializeDatabase()
    {
        if (!File.Exists(DatabasePath))
        {
            CreateDatabase();
        }
    }
}
