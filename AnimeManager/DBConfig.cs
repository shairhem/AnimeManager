using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AnimeManager
{
    class DBconfig
    {
        public static void writeConfig(string server, string port)
        {
            if (!File.Exists("db.config"))
            {
                File.Create("db.config");
            }
            string[] text = new string[]
            {
                "server:",
                server,
                "port:",
                port
            };
            File.WriteAllLines("db.config", text);
        }
        public static void writeConfig(string server)
        {
            if (!File.Exists("db.config"))
            {
                File.Create("db.config");
            }
            string[] text = new string[]
            {
                "server:",
                server
            };
            File.WriteAllLines("db.config", text);
        }
        public static string getServer()
        {
            //string temp = "";
            string[] lines = File.ReadAllLines("db.config");
            string[] temp = null;
            string server = null;
            foreach (string line in lines)
            {
                temp = line.Split(':');
                if (temp[0] == "server")
                    server = temp[1];
            }
            return server;
        }

        public static string getPort()
        {
            string[] temp = null;
            string[] lines = File.ReadAllLines("db.config");
            string port = null;
            foreach (string line in lines)
            {
                temp = line.Split(':');
                if (temp[0] == "port")
                    port = temp[1];
            }
            return port;
        }
    }
}
