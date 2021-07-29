using MySql.Data.MySqlClient;

namespace ESGI.DesignPattern.Projet
{
    public class MySQLBdd : Bdd
    {
        private MySqlConnection _connection;
        public override void OpenConnection(string databaseName, string user, string pass)
        {
            this._connection = new MySqlConnection
            {
                ConnectionString = $"Database={databaseName};Data Source=localhost;User Id={user};Password={pass}"
            };
            
                _connection.Open();

                //throw new System.NotImplementedException();
            }

        public override void CloseConnection()
        {
            throw new System.NotImplementedException();
        }

        public override void Execute(Receipt receipt)
        {
            var command = new MySqlCommand("insert into RECEIPT (AMOUNT, TAX, TOTAL)"
                                           + "values(@amount, @tax, @total);", _connection);
            command.Parameters.AddWithValue("@amount", receipt.Amount.AsDecimal());
            command.Parameters.AddWithValue("@tax", receipt.Tax.AsDecimal());
            command.Parameters.AddWithValue("@total", receipt.Total.AsDecimal());
            command.Prepare();
            command.ExecuteNonQuery();
            throw new System.NotImplementedException();
        }
    }
}