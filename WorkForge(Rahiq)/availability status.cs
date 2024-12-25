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
    public partial class availability_status : Form
    {
        string ps = ConfigurationManager.ConnectionStrings["DBC1"].ConnectionString;
        public string username { get; set; }
        public string status { get; set; }
        public availability_status()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
       

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBC1"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "UPDATE worker SET AvFrom = @from, AvTo = @to WHERE wName = @name and wPass = @pass";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@name", textBox3.Text);
                    cmd.Parameters.AddWithValue("@pass", textBox4.Text);
                    

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Updated");
                    }
                    else
                    {
                        MessageBox.Show("No changes made or Worker not found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            status = "Available";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            status = "Not Available";
        }

        private void availability_status_Load(object sender, EventArgs e)
        {
            
           textBox3.Text = username; // not working
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlConnection con = new SqlConnection(ps);
            con.Open();
            string query = "UPDATE worker SET wStat = @status, AvFrom = @from, AvTo = @to WHERE wName = @name and wPass = @Pass";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@name", textBox3.Text);
            cmd.Parameters.AddWithValue("@pass", textBox4.Text);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@from", dateTimePicker3.Value);
            cmd.Parameters.AddWithValue("@to", dateTimePicker4.Value);


            cmd.ExecuteNonQuery();
            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Updated");
            }
            else
            {
                MessageBox.Show("Invalid Username or password");
            }
            con.Close();
        }
    }

   
    
}
