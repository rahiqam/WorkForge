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
    public partial class Hiring_History : Form
    {
        string ps = ConfigurationManager.ConnectionStrings["DBC1"].ConnectionString;
        public string username { get; set; }
        public string password { get; set; }
        public string id { get; set; }

        public Hiring_History()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Hiring_History_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ps))
            {
                con.Open();

                // Select customer's ID based on username and password (use parameterized query)
                string idSelect = "SELECT cId FROM customer WHERE cName = @name AND cPass = @pass";
                SqlCommand idSelector = new SqlCommand(idSelect, con);
                idSelector.Parameters.AddWithValue("@name", username);
                idSelector.Parameters.AddWithValue("@pass", password);

                // Execute the command and read the ID
                using (SqlDataReader idReader = idSelector.ExecuteReader())
                {
                    if (idReader.Read()) // Check if there are rows
                    {
                        id = idReader["cId"].ToString(); // Assuming it's cId
                    }
                }
                
                // Select hiring history using the obtained ID (use parameterized query)
                string hiringHistory = "SELECT * FROM hiring_history WHERE cId = '"+id+"'";
                SqlCommand hiringcmd = new SqlCommand(hiringHistory, con);

                // Fill DataGridView with the hiring history data
                SqlDataAdapter sda = new SqlDataAdapter(hiringcmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

                con.Close();
            }
        }

    }
}
