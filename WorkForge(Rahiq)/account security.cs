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
    public partial class account_security : Form
    {
        string ps = ConfigurationManager.ConnectionStrings["DBC1"].ConnectionString;

        public string username { get; set; }
        public account_security()
        {
            InitializeComponent();
        }

        private void account_security_Load(object sender, EventArgs e)
        {
            textBox1.Text = username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ps))
            {
                con.Open();

                string name = textBox3.Text;
                string pass = textBox1.Text;
                string phone = textBox2.Text;
                string add = textBox4.Text;
                string catag = comboBox1.Text;

                if (string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(add) || string.IsNullOrEmpty(catag))
                {
                    MessageBox.Show("Password, Phone, Address, and Category cannot be empty or null.");
                    return;
                }

                string query = "UPDATE worker SET wPass = @pass, wPhone = @phone, wAdd = @add, wCatag = @catag WHERE wName = @name";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@pass", pass);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@add", add);
                cmd.Parameters.AddWithValue("@catag", catag);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Updated");
                }
                else
                {
                    MessageBox.Show("Invalid username or password!");
                }
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
