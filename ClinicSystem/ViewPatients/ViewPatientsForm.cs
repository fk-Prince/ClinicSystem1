using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicSystem.Main;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace ClinicSystem
{
    public partial class ViewPatientsForm : Form
    {
        private FrontDesk frontDesk;
        private List<Patient> patientList = new List<Patient>();
        public ViewPatientsForm(FrontDesk frontDesk)
        {
            this.frontDesk = frontDesk;
            InitializeComponent();
            getPatients("Select * FROM patients", null);
        }
        private void DischargeButton_Click(object sender, EventArgs e)
        {
            try
            {
                
                Button button = sender as Button;
                int patientId = Convert.ToInt32(button.Tag);
                string driver = "server=localhost;username=root;pwd=root;database=clinicdb";
                MySqlConnection conn = new MySqlConnection(driver);
                conn.Open();
                DateTime now = DateTime.Now;
                string date = now.ToString("yyyy-MM-dd");
                string query = "UPDATE patients SET Status = 'Discharged' WHERE patientId = @patientId";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@patientId", patientId);
                command.Parameters.AddWithValue("@DateDischarged", date);
                command.ExecuteNonQuery();

                setDischarged(patientId) ;

                string query2 = "SELECT RoomNo FROM patients WHERE patientId = @patientId";
                command = new MySqlCommand(query2, conn);
                command.Parameters.AddWithValue("@patientId", patientId);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    updateRoomUsed(reader["RoomNo"].ToString());
                }

                getPatients("Select * FROM patients", null);
                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error DB: " + ex.Message);
            }
        }

        private void setDischarged(int patientId)
        {
            try
            {
                string driver = "server=localhost;username=root;pwd=root;database=clinicdb";
                MySqlConnection conn = new MySqlConnection(driver);
                conn.Open();
                string query = "UPDATE clinichistory SET DateDischarged = @DateDischarged WHERE PatientId = @PatientId";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@PatientId", patientId);
                command.Parameters.AddWithValue("@DateDischarged", DateTime.Now.ToString("yyyy-MM-dd"));
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch( MySqlException ex)
            {
                MessageBox.Show("vasdvasdas" + ex.Message);
            }

        }

        private void getPatients(string query, string patientName)
        {
            try
            {
                FlowPanel.Controls.Clear();
                patientList.Clear();
                string driver = "server=localhost;username=root;password=root;database=clinicdb";
                MySqlConnection conn = new MySqlConnection(driver);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (!string.IsNullOrWhiteSpace(searchPatientName.Text))
                {
                    cmd.Parameters.AddWithValue("@FirstName", searchPatientName.Text + "%");
                    cmd.Parameters.AddWithValue("@LastName", searchPatientName.Text + "%");
                }
                while (reader.Read())
                {
                    int patientId = int.Parse(reader["PatientId"].ToString());
                    getDateAdmitted(patientId);
                    string fname = reader["FirstName"].ToString();
                    string mname = reader["MiddleName"].ToString();
                    string lname = reader["LastName"].ToString();
                    int age = int.Parse(reader["Age"].ToString());
                    int frontdesk = int.Parse(reader["FrontDeskID"].ToString());
                    string address = reader["Address"].ToString();
                    string gender = reader["Gender"].ToString();
                    DateTime bday = Convert.ToDateTime(reader["BirthDate"]);
                    string contact = reader["ContactNumber"].ToString();
                    string status = reader["Status"].ToString();
                    string condition = reader["PatientCondition"].ToString();
                    DateTime dateAdmitted = getDateAdmitted(patientId);
                    //DateTime dateDischarged = reader["DateDischarged"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["DateDischarged"]);
                    DateTime dateDischarged = getDateDischarged(patientId);
                    //dateDischarged = dateDischarged DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["DateDischarged"]);
                    int roomNo = int.Parse(reader["RoomNo"].ToString());
                    double bill = double.Parse(reader["Bill"].ToString());
                    int doctorId = int.Parse(reader["DoctorID"].ToString());
                    int operationCode = int.Parse(reader["OperationCode"].ToString());

                    Patient patient = new Patient(
                        patientId,
                        roomNo,
                        frontdesk,
                        doctorId,
                        operationCode,
                        fname,
                        mname,
                        lname,
                        age,
                        address,
                        gender,
                        condition,
                        bday,
                        dateAdmitted,
                        contact,
                        bill,
                        status,
                        dateDischarged
                    );
                    getDoctorName(patient);

                    patientList.Add(patient);
                }
                displayPatient(patientList);
                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error DB: " + ex.Message);
            }
        }

        private DateTime getDateAdmitted(int patientId)
        {
            string driver = "server=localhost;username=root;pwd=root;database=clinicdb";
            MySqlConnection conn = new MySqlConnection(driver);
            conn.Open();

            string query = "SELECT DateAdmitted FROM clinichistory WHERE PatientID = @PatientID";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@PatientID", patientId.ToString());
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                return Convert.ToDateTime(reader["DateAdmitted"]);
            }
            conn.Close();
            return DateTime.MinValue;
        }
        private DateTime getDateDischarged(int patientId)
        {
            string driver = "server=localhost;username=root;pwd=root;database=clinicdb";
            MySqlConnection conn = new MySqlConnection(driver);
            conn.Open();

            string query = "SELECT DateDischarged FROM clinichistory WHERE PatientID = @PatientID";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@PatientID", patientId.ToString());
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                //return Convert.ToDateTime(reader["DateDischarged"]);
                return reader["DateDischarged"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["DateDischarged"]);

            }
            conn.Close();
            return DateTime.MinValue;
        }


        private void displayPatient(List<Patient> patientList)
        {
            FlowPanel.Controls.Clear();
            string check = radioAdmitted.Checked ? "Admitted" : "Discharged";
            foreach (Patient patient in patientList)
            {
                if (patient.getStatus().Equals(check, StringComparison.OrdinalIgnoreCase))
                {
                    Panel panel = new Panel();
                    panel.Size = new Size(800, 200);
                    panel.BackColor = Color.FromArgb(255, 255, 255);
                    panel.Margin = new Padding(10, 10, 10, 60);
                    panel.BorderStyle = BorderStyle.FixedSingle;

                    Label fullname = createLabel("Patient FullName", patient.getFname() + "    " + patient.getMname() + "    " + patient.getLname(), 10, 10);
                    panel.Controls.Add(fullname);

                    Label age = createLabel("Age", patient.getAge().ToString(), 10, 40);
                    panel.Controls.Add(age);

                    Label address = createLabel("Address", patient.getAddress(), 10, 70);
                    panel.Controls.Add(address);

                    Label gender = createLabel("Gender", patient.getGender(), 10, 100);
                    panel.Controls.Add(gender);

                    Label bday = createLabel("Birth-Date", patient.getBirthDate().ToString("yyyy-MM-dd"), 10, 130);
                    panel.Controls.Add(bday);

                    Label number = createLabel("Contact Number",  patient.getContactNumber().ToString(), 10, 160);
                    panel.Controls.Add(number);

                    Label dr = createLabel("Doctor Assigned", patient.getDoctorName(), 400, 10);
                    panel.Controls.Add(dr);

                    Label operationname = createLabel("Operation Name", patient.getOperationName().ToString(), 400, 40);
                    panel.Controls.Add(operationname);


                    Label status = createLabel("Status", patient.getStatus(), 400, 70);
                    panel.Controls.Add(status);

                    Label dateAdmitted = createLabel("Date-Admitted", patient.getDateAdmitted().ToString("yyyy-MM-dd"), 400, 100);
                    panel.Controls.Add(dateAdmitted);


                    if (patient.getDischargedDate() == DateTime.MinValue)
                    {
                        Label title = createLabel("Date-Discharged", "", 400, 130);
                        panel.Controls.Add(title);
                        Button button = new Button();
                        button.Text = "Discharge";
                        button.FlatStyle = FlatStyle.Flat;
                        button.Location = new Point(530, 128);
                        button.Click += new EventHandler(DischargeButton_Click);
                        button.Tag = patient.getPatientId();
                        panel.Controls.Add(button);
                    }
                    else
                    {
                        Label dateDischarge = createLabel("Date-Discharged", patient.getDischargedDate().ToString("yyyy-MM-dd"), 400, 130);
                        panel.Controls.Add(dateDischarge);
                    }

                    Label room = createLabel("Room Used", patient.getRoomNo().ToString(), 400, 160);
                    panel.Controls.Add(room);

                    Label bill = createLabel("Bill", patient.getBill().ToString(), 650, 160);
                    bill.Font = new Font("Arial", 10, FontStyle.Bold);
                    panel.Controls.Add(bill);
                    FlowPanel.Controls.Add(panel);
                }
            }
        }

        private void updateRoomUsed( string RoomNo)
        {
            try
            {
                string driver = "server=localhost;username=root;pwd=root;database=clinicdb";
                MySqlConnection conn = new MySqlConnection(driver);
                conn.Open();
                string query = "UPDATE rooms SET Occupation = 'Not Occupied' WHERE RoomNo = @RoomNo";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@RoomNo", RoomNo);
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error DB: " + ex.Message);
            }
        }

     

        private void getDoctorName(Patient patient)
        {
            try
            {
                string driver = "server=localhost;username=root;pwd=root;database=clinicdb";
                MySqlConnection conn = new MySqlConnection(driver);
                conn.Open();
                string query = "SELECT FirstName, MiddleName, LastName, " +
                        "doctoroperations.OperationCode,OperationName " +
                        "FROM doctors " +
                        "LEFT JOIN doctoroperations ON doctors.DoctorID = doctoroperations.DoctorID " +
                        "LEFT JOIN operations ON doctoroperations.OperationCode = operations.OperationCode " +
                        "WHERE doctors.DoctorID = @DoctorID AND doctoroperations.OperationCode = @OperationCode";

                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@DoctorID", patient.doctorId());
                command.Parameters.AddWithValue("@OperationCode", patient.getOperationCode());

                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    patient.setDoctorName(reader["FirstName"].ToString() + "    " + reader["MiddleName"].ToString() + "    " + reader["LastName"].ToString());
                    patient.setOperationName(reader["OperationName"].ToString());
                }
                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error DB: " + ex.Message);
            }
        }

        private Label createLabel(string title,string value, int x,int y)
        {
            Label label = new Label();
            label.Text = $"{title}:  {value}";
            label.Location = new Point(x, y);
            label.AutoSize = true;
            label.Font = new Font("Arial", 10, FontStyle.Regular);
            return label;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            searchPatient();
        }
        private void searchPatient()
        {
            List<Patient> filteredPatients = new List<Patient>();
            string choice = radioAdmitted.Checked ? "Admitted" : "Discharged";
            if (string.IsNullOrWhiteSpace(searchPatientName.Text))
            {
              
                foreach (Patient patient in patientList)
                {
                    if (patient.getStatus().Equals(choice, StringComparison.OrdinalIgnoreCase))
                    {
                        filteredPatients.Add(patient);
                    }
                }
            }
            else
            {
                foreach (Patient patient in patientList)
                {
                    
                    if (patient.getStatus() == choice && ( patient.getFname().StartsWith(searchPatientName.Text.Trim(), StringComparison.OrdinalIgnoreCase) 
                                                        || patient.getMname().StartsWith(searchPatientName.Text.Trim(), StringComparison.OrdinalIgnoreCase) 
                                                        || patient.getLname().StartsWith(searchPatientName.Text.Trim(), StringComparison.OrdinalIgnoreCase) ) )
                    {
                        filteredPatients.Add(patient);
                    }
                }
            }

            displayPatient(filteredPatients);
        }

        private void radioAdmitted_CheckedChanged(object sender, EventArgs e)
        {
            searchPatient();
        }

        private void radioDischarge_CheckedChanged(object sender, EventArgs e)
        {
            searchPatient();
        }
    }
}
