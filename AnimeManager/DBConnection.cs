using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace AnimeManager
{
    class DBConnection
    {

        private DBConnection() { }
        private string databaseName = string.Empty;
        private string serverName = string.Empty;

        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }

        public string ServerName
        {
            get { return serverName; }
            set { serverName = value; }
        }


        public string Password { get; set; }
        private MySqlConnection Connection = null;
        private static DBConnection _instance = null;

        public static DBConnection Instance()
        {
            if (_instance == null)
                _instance = new DBConnection();
            return _instance;

        }

        public bool IsConnect()
        {
            bool result = true;
            if (Connection == null)
            {
                if (databaseName == string.Empty)
                    result = false;
                //string StrCon = string.Format("Server=localhost; database={0}; UID=root; password=root", 
                //    databaseName);
                string StrCon = string.Format("Server={0};Port={1}; database={2}; UID=root; password=root", DBconfig.getServer(), DBconfig.getPort(),
                        databaseName);
                Console.WriteLine(StrCon);
                Connection = new MySqlConnection(StrCon);
                Connection.Open();
                result = true;
            }

            return result;
        }

        public MySqlConnection GetConnection()
        {
            return Connection;
        }

        public void Close()
        {
            Connection.Close();
        }

    }
}
