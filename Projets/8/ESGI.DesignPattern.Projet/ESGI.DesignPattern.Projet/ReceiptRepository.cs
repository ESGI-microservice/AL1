using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ESGI.DesignPattern.Projet
{
    public class ReceiptRepository
    {
        private static readonly string databaseName = "myshop";
        private static readonly string user = "store";
        private static readonly string pass = "123456";
        private static Bdd _bdd = null;
        
        public static void CreateBdd(string config)
        {
            _bdd = Bdd.Create(config);
        }
        
        public static void Store(Receipt receipt)
        {
            _bdd.OpenConnection(databaseName, user, pass);
            _bdd.Execute(receipt);
            /*using (var connection = new MySqlConnection
            {
                ConnectionString = $"Database={databaseName};Data Source=localhost;User Id={user};Password={pass}"
            })
            {
                connection.Open();*/
                /*var command = new MySqlCommand("insert into RECEIPT (AMOUNT, TAX, TOTAL)"
                        + "values(@amount, @tax, @total);", connection);
                command.Parameters.AddWithValue("@amount", receipt.Amount.AsDecimal());
                command.Parameters.AddWithValue("@tax", receipt.Tax.AsDecimal());
                command.Parameters.AddWithValue("@total", receipt.Total.AsDecimal());
                command.Prepare();
                command.ExecuteNonQuery();
            }*/
        }
        
    }
}
