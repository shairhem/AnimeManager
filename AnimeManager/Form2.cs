using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace AnimeManager
{
    public partial class Form2 : Form
    {
        DBConnection DBCon = DBConnection.Instance();

        public Form2()
        {
            InitializeComponent();
            DBCon.DatabaseName = "animedb";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string expectedTitle = textBox1.Text;
            string realTitle = textBox2.Text;
            if (checkIfExist(expectedTitle, 1) || checkIfExist(realTitle, 0))
            {
                MessageBox.Show("anime already exist");
            }
            else
                insertToDB(expectedTitle,realTitle);

        }

        private void insertToDB(string x, string y)
        {
            string query = "Insert into tblanime values (@filename, @realname)";
            if (DBCon.IsConnect())
            {
                MySqlCommand cmd = new MySqlCommand(query, DBCon.GetConnection());
                cmd.Parameters.AddWithValue("@filename",x);
                cmd.Parameters.AddWithValue("@realname", y);
                int z = cmd.ExecuteNonQuery();
                MessageBox.Show("Succesful");
            }
        }

        private bool checkIfExist(string name, int type)
        {
            int count = 0;
            string query;
            if(type == 1)
                query = "select filename from tblanime where filename = '" + name + "';";
            else
                query = "select realname from tblanime where realname = '" + name + "';";

            using (MySqlDataAdapter data = new MySqlDataAdapter(query, DBCon.GetConnection()))
            {
                DataTable t = new DataTable();
                data.Fill(t);
                count = t.Rows.Count;
            }
            if (count > 0)
                return true;

            return false;
        }
    }
}
