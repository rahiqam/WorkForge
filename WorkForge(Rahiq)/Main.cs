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
    public partial class Main : Form
    {
        string ps = ConfigurationManager.ConnectionStrings["DBC1"].ConnectionString;
        
        public string username { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string address { get; set; }

        public Main()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        public void showThisForm(object form)
        {
            panel2.Controls.Clear();
            Form frm = form as Form;
            frm.TopLevel = false;
            panel2.Controls.Add(frm);
            panel2.Tag = frm;
            frm.Show();
        }

        public void showFormWithData()
        {
            panel2.Controls.Clear();
            Customer_Info cf = new Customer_Info();
            cf.TopLevel = false;
            panel2.Controls.Add(cf);
            panel2.Tag = cf;
            cf.username = username;
            cf.password = password;
            cf.phone = phone;
            cf.address = address;
            cf.Show();

        }

        private void label2_Click(object sender, EventArgs e)
        {
            showThisForm(new Hiring_History());
        }

        private void label3_Click(object sender, EventArgs e)
        {
            showThisForm(new Form1());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
          
        }

        private void panel2_MouseHover(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            showFormWithData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            Hiring_History hh = new Hiring_History();
            hh.TopLevel = false;
            panel2.Controls.Add(hh);
            panel2.Tag = hh;
            hh.username = username;
            hh.password = password;
            hh.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            Form1 hn = new Form1();
            hn.TopLevel = false;
            panel2.Controls.Add(hn);
            panel2.Tag = hn;
            hn.username = username;
            hn.password = password;
            hn.Show();
        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {
            /*textBox1.Text = username;
            textBox2.Text = password;
            textBox3.Text = phone;
            textBox4.Text = address;*/
            showThisForm(new About__customer_());
        }

        private void update_Btn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ps);
            con.Open();
            string query = "UPDATE customer SET cname = @name, cPass = @pass, cPhone = @phone, cAdd = @add WHERE cName = @name";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@pass", textBox2.Text);
            cmd.Parameters.AddWithValue("@phone", textBox3.Text);
            cmd.Parameters.AddWithValue("@add", textBox4.Text);
           
            cmd.ExecuteNonQuery();
            if(cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Updated");
            }
            else
            {
                MessageBox.Show("Not Updated");
            }
            con.Close();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //   showThisForm(new About__customer_());
           
            showThisForm(new About__customer_());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();

        }
    }
}
