namespace ESGI.DesignPattern.Projet
{
    public class PostgresBdd : Bdd
    {
        public override void OpenConnection(string databaseName, string user, string pass)
        {
            throw new System.NotImplementedException();
        }

        public override void CloseConnection()
        {
            throw new System.NotImplementedException();
        }

        public override void Execute(Receipt receipt)
        {
            throw new System.NotImplementedException();
        }
    }
}