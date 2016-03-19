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
    public partial class Form1 : Form
    {
        DBConnection DBCon = DBConnection.Instance();
        public Form1()
        {
            InitializeComponent();
            DBCon.DatabaseName = "animedb";
            if(DBCon.IsConnect())
            {
                string query = "select * from tblAnime";
                using (MySqlDataAdapter data = new MySqlDataAdapter(query, DBCon.GetConnection()))
                {
                    DataTable t = new DataTable();
                    data.Fill(t);
                    dataGridView1.DataSource = t;
                }
            }
        }

        private void addAnimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }
    }
}
