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
    public partial class Booking : Form
    {

        static string conString = System.IO.Directory.GetCurrentDirectory().ToString() + "\\database1.mdb";

        string sql;
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + conString + ";Persist Security Info=False;");
        OleDbDataAdapter addapter;
        OleDbCommand com;
        DataTable dt;
        string id;
        public Booking()
        {
            InitializeComponent();
        }

        private void Booking_Load(object sender, EventArgs e)
        {
            sql = "SELECT ID as ID, firstname as FirstName , lastname as LastName, email as Email , phone as Phone from costumer";
            OleDbDataAdapter addapter = new OleDbDataAdapter(sql, con);
            dt = new DataTable();
            addapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

            listView1.SmallImageList = imageList1;
            listView1.Items.Add("Singer", "singer");
            listView1.Items.Add("Dancer", "dance");
            listView1.Items.Add("Clown", "clown");
            listView1.Items.Add("Magician", "magician");
            listView1.Items.Add("Juggler", "juggler");

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index2 = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index2];
            id = selectedRow.Cells["ID"].Value.ToString();

            label7.Text = id;
            label8.Text = selectedRow.Cells["FirstName"].Value.ToString();
            label9.Text = selectedRow.Cells["LastName"].Value.ToString();
            label10.Text = selectedRow.Cells["Email"].Value.ToString();
            label11.Text = selectedRow.Cells["Phone"].Value.ToString();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                sql = "INSERT INTO sales (buyer,cost,data,talent) VALUES ('" + label8.Text + "','" + textBox1.Text + "','" + monthCalendar1.SelectionRange.Start.ToShortDateString() + "','" + listView1.SelectedItems[0].Text.ToString() + "')";
                com = new OleDbCommand(sql, con);
                com.ExecuteNonQuery();


                label7.Text = "";
                label8.Text = "";
                label9.Text = "";
                label10.Text = "";
                label11.Text = "";
                con.Close();
                //MessageBox.Show(listView1.SelectedItems[0].Text.ToString());
            } catch (Exception ma) { }

        }
    }
}
