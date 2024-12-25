using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkForge_Rahiq_
{
    public partial class Main_admin : Form
    {
        string ps = ConfigurationManager.ConnectionStrings["DBC1"].ConnectionString;
        public Main_admin()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection(ps);
            con.Open();
            string query = "SELECT * FROM customer";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateData("customer");
            label5.Text = "Customer Info";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            updateData("worker");
            label5.Text = "Worker Info";
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            updateData("hiring_history");
            label5.Text = "Hiring History";
        }

        public void updateData(string dType)
        {
            SqlConnection con = new SqlConnection(ps);
            con.Open();
            string query = "SELECT * FROM " + dType;
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Main_admin_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void deleteBTN_Click(object sender, EventArgs e)
        {
            string id = id_TB.Text;

            using (SqlConnection con = new SqlConnection(ps))
            {
                con.Open();

                // For Customer
                string query = "DELETE FROM customer WHERE cId = @id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Customer Deleted");
                        updateData("customer");
                        id_TB.Text = "";
                    }
                }

                // For Worker
                query = "DELETE FROM worker WHERE wId = @id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Worker Deleted");
                        updateData("worker");
                        id_TB.Text = "";
                    }
                }

                // For Hiring History
                query = "DELETE FROM hiring_history WHERE hId = @id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Hiring History Deleted");
                        updateData("hiring_history");
                        id_TB.Text = "";
                    }
                }
            }
        }
    }
}
