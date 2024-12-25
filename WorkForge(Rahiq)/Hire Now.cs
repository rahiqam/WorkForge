using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace WorkForge_Rahiq_
{
    public partial class Form1 : Form
    {
        string ps = ConfigurationManager.ConnectionStrings["DBC1"].ConnectionString;
        public string catag { get; set; }
        public DateTime date { get; set; }
        public string dateString { get; set; }
        public string workerID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string cId { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        public void updateData()
        {
            using (SqlConnection con = new SqlConnection(ps))
            {
                con.Open();
                string query = "SELECT wId, wName, wPhone, wCatag, avFrom, avTo FROM dbo.worker WHERE wStat = 'Available' AND wCatag = @catag AND @dateString BETWEEN avFrom AND avTo"; 
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@catag", catag);
              
                if (!string.IsNullOrEmpty(dateString))
                {
                    cmd.Parameters.AddWithValue("@dateString", dateString);
                }
                else
                {                 
                    cmd.Parameters.AddWithValue("@dateString", DateTime.Now.ToString("yyyy-MM-dd"));
                }

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                catag = comboBox1.SelectedItem.ToString();
                updateData();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            date = dateTimePicker1.Value;
            dateString = date.ToString("yyyy-MM-dd");
            updateData();
        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please fill in all the fields.");
                return;
            }

            SqlConnection con = new SqlConnection(ps);
            con.Open();
            string Cquery = "SELECT cId FROM customer WHERE cName = @name and cPass = @pass";
            SqlCommand Ccmd = new SqlCommand(Cquery, con);
            Ccmd.Parameters.AddWithValue("@name", username);
            Ccmd.Parameters.AddWithValue("@pass", password);
            using(SqlDataReader reader = Ccmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    cId = reader["cId"].ToString();
                }
            }


            string query = "INSERT INTO hiring_history (wId, cId, hDate, category) VALUES (@wId, @cId, @hDate, @category)";
            SqlCommand cmd = new SqlCommand(query, con);
            
            
            date = dateTimePicker1.Value;
            dateString = date.ToString("yyyy-MM-dd");

            
            cmd.Parameters.AddWithValue("@wId", textBox1.Text);
            cmd.Parameters.AddWithValue("@cId", cId);
            cmd.Parameters.AddWithValue("@hDate", dateString);
            cmd.Parameters.AddWithValue("@category", catag  );

            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Worker Hired!");
        }
    }
}
