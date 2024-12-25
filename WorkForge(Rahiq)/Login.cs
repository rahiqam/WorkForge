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
    public partial class Login : Form
    {
        string ps = ConfigurationManager.ConnectionStrings["DBC1"].ConnectionString;


        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Join_as j = new Join_as();
            j.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                string username = textBox1.Text;
                string password = textBox2.Text;

                using (SqlConnection con = new SqlConnection(ps))
                {
                    con.Open();

                    // Check in the customer table
                    string customerQuery = "SELECT * FROM customer WHERE cName = @user AND cPass = @pass";
                    using (SqlCommand customerCmd = new SqlCommand(customerQuery, con)) // query command and connection
                    {
                        customerCmd.Parameters.AddWithValue("@user", username);
                        customerCmd.Parameters.AddWithValue("@pass", password);

                        using (SqlDataReader customerReader = customerCmd.ExecuteReader())
                        {
                            if (customerReader.Read()) 
                            {
                                Main mainForm = new Main();
                                mainForm.username = customerReader["cName"].ToString();
                                mainForm.password = customerReader["cPass"].ToString();
                                mainForm.phone = customerReader["cPhone"].ToString();
                                mainForm.address = customerReader["cAdd"].ToString();
                                mainForm.Show();
                                this.Hide();
                                return;
                            }
                            
                        }
                    }

                    // Check in the worker table
                    string workerQuery = "SELECT * FROM worker WHERE wName = @user AND wPass = @pass";
                    using (SqlCommand workerCmd = new SqlCommand(workerQuery, con))
                    {
                        workerCmd.Parameters.AddWithValue("@user", username);
                        workerCmd.Parameters.AddWithValue("@pass", password);

                        using (SqlDataReader workerReader = workerCmd.ExecuteReader())
                        {
                            if (workerReader.Read()) 
                            {
                                Main_Labor main_Labor = new Main_Labor();
                                main_Labor.username = workerReader["wName"].ToString();
                                main_Labor.password = workerReader["wPass"].ToString();
                                main_Labor.phone = workerReader["wPhone"].ToString();
                                main_Labor.address = workerReader["wAdd"].ToString();
                                main_Labor.Show();
                                this.Hide();
                                return;
                            }
                            
                        }
                    }

                    // Check if admin login
                    if (username == "admin" && password == "admin")
                    {
                        Main_admin adminForm = new Main_admin();
                        adminForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid user");
                    }
                }
            }
            else
            {
                MessageBox.Show("Enter Fields", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool status = checkBox1.Checked;
            switch (status)
            {
                case true:
                    textBox2.UseSystemPasswordChar = false;
                    break;
                default:
                    textBox2.UseSystemPasswordChar = true;
                    break;

            }
        }

    }
}
