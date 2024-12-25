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
    public partial class work_history : Form
    {
        string ps = ConfigurationManager.ConnectionStrings["DBC1"].ConnectionString;
        public string username { get; set; }
        public string password { get; set; }
        public string id { get; set; }

        public work_history()
        {
            InitializeComponent();
        }

        private void work_history_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ps))
            {
                con.Open();

                // Select worker's ID based on username and password (use parameterized query)
                string idSelect = "SELECT wId FROM worker WHERE wName = @username AND wPass = @password";
                SqlCommand idSelector = new SqlCommand(idSelect, con);
                idSelector.Parameters.AddWithValue("@username", username);
                idSelector.Parameters.AddWithValue("@password", password);

                // Execute the command and read the ID
                using (SqlDataReader idReader = idSelector.ExecuteReader())
                {
                    if (idReader.Read()) // Check if there are rows
                    {
                        id = idReader["wId"].ToString();
                    }
                }

                // Select hiring history using the obtained ID (use parameterized query)
                string hiringHistory = "SELECT * FROM hiring_history WHERE wId = @id";
                SqlCommand hiringcmd = new SqlCommand(hiringHistory, con);
                hiringcmd.Parameters.AddWithValue("@id", id);

                // Fill DataGridView with the hiring history data
                SqlDataAdapter sda = new SqlDataAdapter(hiringcmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

                con.Close();   
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
