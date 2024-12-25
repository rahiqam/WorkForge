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
    public partial class Main_Labor : Form
    {
        string ps = ConfigurationManager.ConnectionStrings["DBC1"].ConnectionString;

        public string username { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string address { get; set; }

        public Main_Labor()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Close();
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

        

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            WorkerInfo wf = new WorkerInfo();
            wf.TopLevel = false;
            panel2.Controls.Add(wf);
            panel2.Tag = wf;
            wf.username = username;
            wf.password = password;
            wf.phone = phone;
            wf.address = address;
            wf.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            showThisForm(new account_security());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            showThisForm(new availability_status());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            work_history wh = new work_history();
            wh.TopLevel = false;
            panel2.Controls.Add(wh);
            panel2.Tag = wh;
            wh.username = username;
            wh.password = password;
            
            wh.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            payouts po = new payouts();
            po.TopLevel = false;
            panel2.Controls.Add(po);
            panel2.Tag = po;
            po.username = username;
            po.password = password;

            po.Show();
        }

        private void Main_Labor_Load(object sender, EventArgs e)
        {
            /*textBox1.Text = username;
            textBox2.Text = password;
            textBox3.Text = phone;
            textBox4.Text = address; */
            showThisForm(new About__worker_());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            showThisForm(new About__worker_());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }
    }
}
