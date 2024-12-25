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
    public partial class create_account_customer : Form
    {
        string ps = ConfigurationManager.ConnectionStrings["DBC1"].ConnectionString;
        public create_account_customer()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Login c = new Login();
            c.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Please fill in all the fields.");
                return;
            }

            SqlConnection con = new SqlConnection(ps);
            con.Open();

            string query = "INSERT INTO customer (cName, cPass, cPhone, cAdd) VALUES (@cName, @cPass, @cPhone, @cAdd)";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@cName", textBox1.Text);
            cmd.Parameters.AddWithValue("@cPass", textBox2.Text);
            cmd.Parameters.AddWithValue("@cPhone", textBox3.Text);
            cmd.Parameters.AddWithValue("@cAdd", textBox4.Text);

            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Registration Completed! Please Proceed to login");
        }
    }
}
