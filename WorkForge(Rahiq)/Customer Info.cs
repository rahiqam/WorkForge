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
    public partial class Customer_Info : Form
    {
        string ps = ConfigurationManager.ConnectionStrings["DBC1"].ConnectionString;
        public string username { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string address { get; set; }

        public Customer_Info()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Customer_Info_Load(object sender, EventArgs e)
        {
            textBox1.Text = username;
            textBox2.Text = password;
            textBox3.Text = phone;
            textBox4.Text = address;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            

           
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        public void showThisForm(object form)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ps);
            con.Open();

            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Please fill in all the fields.");
                con.Close();
                return;
            }

            string query = "UPDATE customer SET cname = @name, cPass = @pass, cPhone = @phone, cAdd = @add WHERE cName = @name";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@pass", textBox2.Text);
            cmd.Parameters.AddWithValue("@phone", textBox3.Text);
            cmd.Parameters.AddWithValue("@add", textBox4.Text);

            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Updated");
            }
            else
            {
                MessageBox.Show("Not Updated");
            }

            con.Close();
        }
    }
}
