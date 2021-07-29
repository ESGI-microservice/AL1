using System;

namespace ESGI.DesignPattern.Projet
{
    public abstract class Bdd
    {
        public abstract void OpenConnection(string databaseName, string user, string pass);
        public abstract void CloseConnection();
        public abstract void Execute(Receipt receipt);

        public static Bdd Create(string config)
        {
            if (config == "Myslq")
                return new MySQLBdd();
            else if (config == "Postgres")
                return new PostgresBdd();
            else
                throw new Exception("Config doesn't exist");
        }
    }
}