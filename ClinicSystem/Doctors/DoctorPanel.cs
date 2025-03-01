using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
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
                FlowPanel.Controls.Clear();
                doctorList.Clear();
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
                    string contactNumber = reader["ContactNumber"].ToString();
                    DateTime dateHired = Convert.ToDateTime(reader["Date-Hired"]);

                    List<string> operationNames = getOperationName(id);

                    Doctor doctor = new Doctor(
                        id,fname,mname,lname,age,address,
                        gender,contactNumber,dateHired,operationNames);


                    doctorList.Add(doctor);

                }


                displayDoctors(doctorList);
                conn.Close();

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


                Label label = createLabel("Doctor ID", doctor.getDoctorID().ToString(), 10, 10);
                panel.Controls.Add(label);

                string fullname = $"{doctor.getDoctorLName()},  {doctor.getDoctorFName()} {doctor.getDoctorMName()}";
                Label label1 = createLabel("Doctor FullName", fullname, 10, 30);
                panel.Controls.Add(label1);

                Label label2 = createLabel("Age", doctor.getDoctorAge().ToString(), 10, 50);
                panel.Controls.Add(label2);

                Label label3 = createLabel("Gender", doctor.getDoctorGender(), 10, 70);
                panel.Controls.Add(label3);

                Label label4 = createLabel("ContactNumber", doctor.getDoctorContactNumber().ToString(), 10, 90);
                panel.Controls.Add(label4);

                Label label5 = createLabel("Date-Hired", doctor.getDoctorDateHired().ToString("yyyy-MM-dd"), 10, 110);
                panel.Controls.Add(label5);



                String address = System.Text.RegularExpressions.Regex.Replace(doctor.getDoctorAddress(), ".{30}", "$0\n");
                Label label6 = createLabel("Address", address, 10, 130);
                panel.Controls.Add(label6);

                Label label7 = new Label();
                label7.AutoSize = true;
                label7.Text = $"Operation Specialized";
                label7.Location = new Point(10, 175);
                label7.Font = new Font("Arial", 9, FontStyle.Bold);
                panel.Controls.Add(label7);

                TextBox textBox = new TextBox();
                foreach (String operationName in doctor.getOperationNames())
                {
                    textBox.Text = operationName + "\n";
                }
                textBox.ReadOnly = true;
                textBox.Multiline = true;
                textBox.Location = new Point(15, 190);
                textBox.Size = new Size(235, 90);
                panel.Controls.Add(textBox);

                FlowPanel.Controls.Add(panel);
            }


        }
        private Label createLabel(string title, string value,int x,int y)
        {
            Label label = new Label();
            label.AutoSize = true;
            label.Text = $"{title}: {value}";
            label.Location = new Point(x, y);
            label.Font = new Font("Arial", 9, FontStyle.Bold);
            return label;
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
            conn.Close();
            return operation;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchDoctor = textBox1.Text.Trim();
            List<Doctor> filteredDoctor = new List<Doctor>();

            if (string.IsNullOrEmpty(searchDoctor))
            {
                filteredDoctor = doctorList;
            }
            else
            {
                foreach (Doctor doctor in doctorList)
                {
                    if (int.TryParse(searchDoctor, out int doctorId))
                    {
                        if (doctor.getDoctorID() == doctorId)
                        {
                            filteredDoctor.Add(doctor);
                        }
                    }
                    else if (doctor.getDoctorFName().StartsWith(searchDoctor) ||
                            doctor.getDoctorLName().StartsWith(searchDoctor))   
                    {
                        filteredDoctor.Add(doctor);
                    }
                }
            }
            displayDoctors(filteredDoctor);
        }
    }
}
