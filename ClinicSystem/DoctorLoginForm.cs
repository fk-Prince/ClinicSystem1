using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ClinicSystem.LoginForm
{
    public partial class DoctorLoginForm : Form
    {
        public DoctorLoginForm()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(DoctorID.Text) || string.IsNullOrWhiteSpace(DoctorPIN.Text))
                {
                    MessageBox.Show("Incorrect PIN or ID", "Wrong Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }   
                string driver = "server=localhost;username=root;password=root;database=clinicdb";
                MySqlConnection conn = new MySqlConnection(driver);
                conn.Open();
                string query = "SELECT * FROM doctors WHERE DoctorID = @DoctorID AND PIN = @PIN";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@DoctorID", DoctorID.Text);
                command.Parameters.AddWithValue("@PIN", DoctorPIN.Text);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    this.Hide();
                    ClinicSystem clinicSystem = new ClinicSystem(null);
                    clinicSystem.Show();
                    MessageBox.Show("Successfully Login", "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else
                {
                    MessageBox.Show("Incorrect PIN or ID", "Wrong Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                conn.Close();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
