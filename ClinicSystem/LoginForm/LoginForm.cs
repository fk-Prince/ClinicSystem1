using System;
using System.Windows.Forms;
using ClinicSystem.LoginForm;
using MySql.Data.MySqlClient;

namespace ClinicSystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            LoginButton.FlatAppearance.BorderSize = 0;
            LoginButton.FlatStyle = FlatStyle.Flat;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = Username.Text.Trim();
            string password = Password.Text.Trim();

            try
            {

                string driver = "server=localhost;username=root;password=root;database=clinicdb";
                MySqlConnection conn = new MySqlConnection(driver);
                conn.Open();

                string query = "SELECT Username, Password, FrontDeskID FROM FRONTDESK WHERE USERNAME = @USERNAME AND PASSWORD = @PASSWORD";
                MySqlCommand command = new MySqlCommand(query, conn);

                command.Parameters.AddWithValue("@USERNAME", username);
                command.Parameters.AddWithValue("@PASSWORD", password);

                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows == false)
                {
                    MessageBox.Show("Wrong Username or Password", "Incorrect Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                while (reader.Read())
                {
                    FrontDesk frontDesk = new FrontDesk(reader["Username"].ToString(), reader["Password"].ToString(), int.Parse(reader["FrontDeskID"].ToString()));
                    MessageBox.Show("Successfully Login", "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    ClinicSystem clinicSystem = new ClinicSystem(frontDesk);
                    clinicSystem.Show();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Doctor_Click(object sender, EventArgs e)
        {
            DoctorLoginForm doctorLoginForm = new DoctorLoginForm();
            doctorLoginForm.Show();
        }
    }

}
