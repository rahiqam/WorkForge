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
    public partial class Join_as : Form
    {
        public Join_as()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Join_as_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            create_account_customer c = new create_account_customer();
            c.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Create_labor_account c = new Create_labor_account();
            c.Show();
            this.Hide();
        }
    }
}
