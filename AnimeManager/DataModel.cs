using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace AnimeManager
{
    class DataModel
    {
        static DBConnection DBCon = DBConnection.Instance();

        public static void newFileName(string filename)
        {
            string newFileName = "";
            if(DBCon.IsConnect())
            {
                string query = "select realname from tblanime where filename = '" + filename +"'";
                using (MySqlDataAdapter data = new MySqlDataAdapter(query, DBCon.GetConnection()))
                {
                    DataTable t = new DataTable();
                    data.Fill(t);
                    MessageBox.Show(t.Rows[0].ItemArray[0].ToString());
                }

            }


            //return newFileName;
        }
    }
}
