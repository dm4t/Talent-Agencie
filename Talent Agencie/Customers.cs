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
    public partial class Customers : Form
    {

        // Since the database is located in our application file this will be use for find the location  to the database
        //even if we change the folder location.
        static string conString = System.IO.Directory.GetCurrentDirectory().ToString() + "\\database1.mdb";

        string sql;
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+ conString + ";Persist Security Info=False;");
        OleDbDataAdapter addapter;
        OleDbCommand com;
        DataTable dt;
        string id;
        public Customers()
        {
            InitializeComponent();
        }

        private void Customers_Load(object sender, EventArgs e)
        {

            //Filling the datagride while loading the form 

            sql = "SELECT ID as ID, firstname as FirstName , lastname as LastName, email as Email , phone as Phone from costumer";
            OleDbDataAdapter addapter = new OleDbDataAdapter(sql, con);
            dt = new DataTable();
            addapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }


        // We are using this button clikc for adding new data into the database
        private void button1_Click(object sender, EventArgs e)
        {
            //opening conenction 
            con.Open();
            //query for inserting data 
            sql = "INSERT INTO costumer (firstname,lastname,email,phone) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
            com = new OleDbCommand(sql, con);
            com.ExecuteNonQuery();
            sql = "SELECT ID as ID, firstname as FirstName , lastname as LastName, email as Email , phone as Phone from costumer";
            addapter = new OleDbDataAdapter(sql, con);
            dt = new DataTable();
            addapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

            //Clearing the textboxes 
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

        }


        //Clearing the textboxs 
        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            id = null;
        }


        // We are using a event (Double click )so we can read the data from a selected row and use at after to change the data from the database
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index2 = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index2];
            id = selectedRow.Cells["ID"].Value.ToString();

            textBox1.Text = selectedRow.Cells["FirstName"].Value.ToString();
            textBox2.Text = selectedRow.Cells["LastName"].Value.ToString();
            textBox3.Text = selectedRow.Cells["Email"].Value.ToString();
            textBox4.Text = selectedRow.Cells["Phone"].Value.ToString();

            

           

            //id = Int32.Parse(selectedRow.Cells["ID"].Value.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //When id is not declare we are unable to chagnge any data into the database.
            if (id != null)
            {
                con.Open();
                //Query for updating the data
                sql = "UPDATE costumer SET firstname = '" + textBox1.Text + "',lastname = '" + textBox2.Text + "',email = '" + textBox3.Text + "',phone = '" + textBox4.Text + "' WHERE ID = " + id;
                com = new OleDbCommand(sql, con);
                com.ExecuteNonQuery();
                sql = "SELECT ID as ID, firstname as FirstName , lastname as LastName, email as Email , phone as Phone from costumer";
                addapter = new OleDbDataAdapter(sql, con);
                dt = new DataTable();
                addapter.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
                id = null; //Seting the id to be null
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (id != null)
            {

                con.Open();
                //Query for deleting a data from our database
                sql = "DELETE FROM costumer WHERE ID = " + id;
                com = new OleDbCommand(sql, con);
                com.ExecuteNonQuery();
                sql = "SELECT ID as ID, firstname as FirstName , lastname as LastName, email as Email , phone as Phone from costumer";
                addapter = new OleDbDataAdapter(sql, con);
                dt = new DataTable();
                addapter.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
                id = null; //Seting the id to be null

            }
        }
    }
}
