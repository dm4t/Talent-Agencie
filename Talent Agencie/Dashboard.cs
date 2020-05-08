using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Talent_Agencie
{
    public partial class Dashboard : Form
    {

        static string conString = System.IO.Directory.GetCurrentDirectory().ToString() + "\\database1.mdb";

        string sql;
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + conString + ";Persist Security Info=False;");
        OleDbDataAdapter addapter;
        OleDbCommand com;
        DataTable dt;
        string id;

        public Dashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Customers s = new Customers();
            s.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Booking b = new Booking();
            b.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {


            con.Open();

                var sql = "SELECT SUM(cost) FROM sales";
                using (var cmd = new OleDbCommand(sql, con))
                {
                    MessageBox.Show(cmd.ExecuteScalar().ToString() + "$ in Sales");
                }

            con.Close();
                       





        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }
    }
}
