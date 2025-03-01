using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicSystem.LoginForm
{
    public partial class DoctorPanel: Form
    {

        private List<Doctor> doctorList = new List<Doctor>();
        public DoctorPanel(FrontDesk frontDesk)
        {
            InitializeComponent();

            getDoctors();
        }

        private void getDoctors()
        {
            try
            {
                string driver = "server=localhost;username=root;pwd=root;database=clinicdb";
                MySqlConnection conn = new MySqlConnection(driver);
                conn.Open();
                MySqlCommand command = new MySqlCommand("SELECT * from Doctors", conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = int.Parse(reader["DoctorID"].ToString());
                    string fname = reader["FirstName"].ToString();
                    string mname = reader["MiddleName"].ToString();
                    string lname = reader["Lastname"].ToString();
                    int age = int.Parse(reader["Age"].ToString());
                    string address = reader["Address"].ToString();
                    string gender = reader["Gender"].ToString();
                    long contactNumber = long.Parse(reader["ContactNumber"].ToString());
                    DateTime dateHired = Convert.ToDateTime(reader["Date-Hired"]);


                    //string operationname = getOperationName(id);
                    List<string> operationNames = getOperationName(id);

                    Doctor doctor = new Doctor(
                        id,fname,mname,lname,age,address,
                        gender,contactNumber,dateHired,operationNames);


                    doctorList.Add(doctor);

                }


                displayDoctors(doctorList);
                

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("DB : ERROR" + ex.Message);
            }
        }

        private void displayDoctors(List<Doctor> doctorList)
        {
            FlowPanel.Controls.Clear();
            foreach (Doctor doctor in doctorList)
            {
                Panel panel = new Panel();
                panel.Size = new Size(270, 300);
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.BackColor = Color.White;
                panel.Margin = new Padding(10, 10, 10, 20);


                Label label = new Label();
                label.AutoSize = true;
                label.Text = $"Doctor ID: {doctor.getDoctorID()}";
                label.Location = new Point(10, 10);
                label.Font = new Font("Arial", 9, FontStyle.Bold);
                panel.Controls.Add(label);

                Label label1 = new Label();
                label1.AutoSize = true;
                label1.Text = $"Doctor FullName: {doctor.getDoctorFName()} " +
                    $" {doctor.getDoctorMName()}  {doctor.getDoctorLName()}";
                label1.Location = new Point(10, 30);
                label1.Font = new Font("Arial", 9, FontStyle.Bold);
                panel.Controls.Add(label1);

                Label label2 = new Label();
                label2.AutoSize = true;
                label2.Text = $"Age: {doctor.getDoctorAge()}";
                label2.Location = new Point(10, 50);
                label2.Font = new Font("Arial", 9, FontStyle.Bold);
                panel.Controls.Add(label2);

                Label label4 = new Label();
                label4.AutoSize = true;
                label4.Text = $"Gender: {doctor.getDoctorGender()}";
                label4.Location = new Point(10, 70);
                label4.Font = new Font("Arial", 9, FontStyle.Bold);
                panel.Controls.Add(label4);


                Label label3 = new Label();
                label3.AutoSize = true;
                label3.Text = $"Address: {doctor.getDoctorAddress()}";
                label3.Location = new Point(10, 110);
                label3.Font = new Font("Arial", 9, FontStyle.Bold);
                panel.Controls.Add(label3);

                Labal label1 = createLabel("Doctor FullName");

                FlowPanel.Controls.Add(panel);
            }


        }
        private void createLabel(string title, string value,int x,int y)
        {

        }

        private List<string> getOperationName(int id)
        {
            List<string> operation = new List<string>();
            string driver = "server=localhost;username=root;pwd=root;database=clinicdb";
            MySqlConnection conn = new MySqlConnection(driver);
            conn.Open();
            string query = "SELECT doctoroperations.OperationCode, operations.OperationName " +
                "FROM doctoroperations " +
                "LEFT JOIN operations on doctoroperations.OperationCode = operations.OperationCode " +
                "WHERE  DoctorID = @DoctorID";
            MySqlCommand command = new MySqlCommand(query,conn);
            command.Parameters.AddWithValue("@DoctorID", id);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                operation.Add(reader["OperationName"].ToString());
            }

            return operation;
        }
    }
}
