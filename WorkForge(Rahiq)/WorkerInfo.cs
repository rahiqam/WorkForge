using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkForge_Rahiq_
{
    public partial class WorkerInfo : Form
    {

        public string username { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string address { get; set; }

        public WorkerInfo()
        {
            InitializeComponent();
        }

        private void WorkerInfo_Load(object sender, EventArgs e)
        {
            textBox1.Text = username;
            textBox2.Text = password;
            textBox3.Text = phone;
            textBox4.Text = address;
        }
    }
}
