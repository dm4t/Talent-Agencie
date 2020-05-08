using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Talent_Agencie
{
    public partial class Welcome : Form

    {

        // Since the database is located in our application file this will be use for find the location  to the database
        //even if we change the folder location.
        static string conString = System.IO.Directory.GetCurrentDirectory().ToString() + "\\database1.mdb";

        Dashboard d;

        public Welcome()
        {
            InitializeComponent();
             d = new Dashboard();


        }

        private void button1_Click(object sender, EventArgs e)

        {
            // We are using this to find the user/password that metch in our database
            string login = "SELECT * FROM admin where username='" + textBox1.Text + "' and password= '" + textBox2.Text + "' ";
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + conString + ";Persist Security Info=False;"); 
            OleDbDataAdapter addapter = new OleDbDataAdapter(login, con);
            DataTable dt = new DataTable();
            addapter.Fill(dt);
            //MessageBox.Show(dt.Columns.Count.ToString());

            try
            {

                // if we have onc recored we can singin else we get a error.
                if (dt.Rows[0][0].ToString() == "1")
                {
                    
                    
                    
                    con.Close();

                    d.Show();

                }
                

            }
            catch { MessageBox.Show("Error"); }

            con.Close();
        }
    }
}
