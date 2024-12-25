using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkForge_Rahiq_
{
    public partial class payouts : Form
    {
        string con = ConfigurationManager.ConnectionStrings["DBC1"].ConnectionString;

        public string username { get; set; }
        public string password { get; set; }

        protected int rate = 500;
        public string wId { get; set; }

        public payouts()
        {
            InitializeComponent();
        }

        private void payouts_Load(object sender, EventArgs e)
        {
            using(SqlConnection sql = new SqlConnection(con))
            {
                sql.Open();
                string wquery="SELECT wId from worker WHERE wName = @username and wPass=@password";
                using(SqlCommand cmd = new SqlCommand(wquery, sql))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            wId = reader["wId"].ToString();
                        }
                    }
                }
                string query= "SELECT COUNT(*) FROM hiring_history WHERE wId = @id";
                using(SqlCommand cmd = new SqlCommand(query, sql))
                {
                    cmd.Parameters.AddWithValue("@id", wId);
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            int count = Convert.ToInt32(reader[0]) * rate;
                            label1.Text = reader[0].ToString();
                            label3.Text = "$"+count.ToString();
                        }
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
