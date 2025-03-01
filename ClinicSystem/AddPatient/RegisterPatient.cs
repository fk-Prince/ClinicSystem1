using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ClinicSystem
{
    public partial class RegisterPatient : Form
    {


        private double bill;
        private Doctor doctorAssigned;
        private FrontDesk frontDesk;
        public RegisterPatient(ClinicSystem clinicSystem, FrontDesk frontDesk)
        {
            this.frontDesk = frontDesk;
            InitializeComponent();
            FirstName.BorderStyle = BorderStyle.None;
            MiddleName.BorderStyle = BorderStyle.None;
            LastName.BorderStyle = BorderStyle.None;
            Age.BorderStyle = BorderStyle.None;
            Address.BorderStyle = BorderStyle.None;
            Birthdate.BorderStyle = BorderStyle.None;
            ContactNumber.BorderStyle = BorderStyle.None;
            DateAdmitted.BorderStyle = BorderStyle.None;
            Bill.BorderStyle = BorderStyle.None;

            DateTime date = DateTime.Now;
            date = date.Date;
            DateAdmitted.Text = date.ToString(date.ToString("yyyy-MM-dd"));

            getOperation();
            getRoomNo();
        }

        private void getRoomNo()
        {
            try
            {
                ComboRoomNo.Items.Clear();
                string driver = "server=localhost;username=root;password=root;database=clinicdb";
                MySqlConnection conn = new MySqlConnection(driver);
                conn.Open();
                string query = "SELECT RoomNo FROM rooms WHERE Occupation != 'Occupied'";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ComboRoomNo.Items.Add(reader["RoomNo"].ToString());
                }

                if (ComboRoomNo.Items.Count != 0) ComboRoomNo.SelectedIndex = 0;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getOperation()
        {
           try
            {

                string driver = "server=localhost;username=root;password=root;database=clinicdb";
                MySqlConnection conn = new MySqlConnection(driver);
                conn.Open();
                string query = "SELECT * FROM operations";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

               while(reader.Read())
                {
                    ComboOperation.Items.Add(reader["OperationName"].ToString());
                }
                conn.Close();


            }
            catch (MySqlException ex)
            {
              MessageBox.Show(ex.Message);
            }
        }

        private void ComboOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboDoctor.Items.Clear();
            ComboDoctor.SelectedIndex = -1;
            ComboDoctor.Text = "";
            Bill.Text = "";
            string operationname = "";
            if (ComboOperation.SelectedItem == null)
            {
                return;
            }
            operationname = ComboOperation.SelectedItem.ToString();
            if (string.IsNullOrEmpty(operationname))
            {
                return;
            }
            try
            {
                int operationCode = getOprationId(operationname);
                string driver = "server=localhost;username=root;password=root;database=clinicdb";
                MySqlConnection conn = new MySqlConnection(driver);
                conn.Open();
                string query = "SELECT * FROM doctors " +
                                "LEFT JOIN doctoroperations " +
                                "ON doctors.DoctorID = doctoroperations.DoctorID " +
                                "WHERE doctoroperations.OperationCode = @OperationCode";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@OperationCode", operationCode);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    ComboDoctor.Items.Clear();
                    ComboDoctor.Items.Add("No Doctor Available");
                    ComboDoctor.SelectedIndex = 0;
                }
                else
                {

                    while (reader.Read())
                    {
                        this.doctorAssigned = new Doctor(
                                int.Parse(reader["DoctorID"].ToString()),
                                int.Parse(reader["OperationCode"].ToString()),
                                reader["FirstName"].ToString(),
                                reader["MiddleName"].ToString(),
                                reader["LastName"].ToString(),
                                int.Parse(reader["Age"].ToString()),
                                reader["Address"].ToString(),
                                reader["Gender"].ToString(),
                                reader["ContactNumber"].ToString(),
                                DateTime.Parse(reader["Date-Hired"].ToString()),
                                reader["PIN"].ToString()
                            );
                     

                        string doctor = reader["DoctorID"] + "  -  " + doctorAssigned.getDoctorLName() + ", " + doctorAssigned.getDoctorFName() + " " + doctorAssigned.getDoctorMName();
                        ComboDoctor.Items.Add(doctor.ToString());
                    }
                    ComboDoctor.SelectedIndex = 0;
                }
                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message+ "dgdfgdfg");
            }
        }

        private int getOprationId(string operationname)
        {
            try
            {
                string driver = "server=localhost;username=root;pwd=root;database=clinicdb";
                MySqlConnection conn = new MySqlConnection(driver);
                conn.Open();    
                string qry = "SELECT OperationCode, Price FROM operations WHERE OperationName = @OperationName";
                MySqlCommand command = new MySqlCommand(qry, conn);
                command.Parameters.AddWithValue("@OperationName", operationname);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    bill = double.Parse(reader["Price"].ToString());
                    return int.Parse(reader["OperationCode"].ToString());
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message + "Xdasvd");
            }
            return 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (frontDesk == null)
            {
                MessageBox.Show("This user is not permitted to add patient !!", "Permission", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Patient patient = getPatient();

            if (patient == null)
            {   
                return;
            }

            try
            {
                string driver = "server=localhost;username=root;pwd=root;database=clinicdb";
                MySqlConnection conn = new MySqlConnection(driver);
                conn.Open();
                string query = "INSERT INTO patients (" +
                                    "RoomNo, FrontDeskID, DoctorID, OperationCode, FirstName, MiddleName, LastName, Age," +
                                    "Address, Gender, PatientCondition, BirthDate, ContactNumber, Bill, Status) VALUES (" +
                                    "@RoomNo, @FrontDeskID, @DoctorID, @OperationCode, @FirstName, @MiddleName, @LastName, @Age, @Address, " +
                                    "@Gender, @PatientCondition, @BirthDate, @ContactNumber, @Bill, @Status)";

                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@RoomNo", patient.getRoomNo());
                command.Parameters.AddWithValue("@FrontDeskID", patient.getFrontdeskId());
                command.Parameters.AddWithValue("@DoctorID", patient.doctorId());
                command.Parameters.AddWithValue("@OperationCode", patient.getOperationCode());
                command.Parameters.AddWithValue("@FirstName", patient.getFname());
                command.Parameters.AddWithValue("@MiddleName", patient.getMname());
                command.Parameters.AddWithValue("@LastName", patient.getLname());
                command.Parameters.AddWithValue("@Age", patient.getAge());
                command.Parameters.AddWithValue("@Address", patient.getAddress());
                command.Parameters.AddWithValue("@Gender", patient.getGender());
                command.Parameters.AddWithValue("@PatientCondition", patient.getCondition());
                command.Parameters.AddWithValue("@BirthDate", patient.getBirthDate());
                command.Parameters.AddWithValue("@ContactNumber", patient.getContactNumber());
                command.Parameters.AddWithValue("@Bill", patient.getBill());
                command.Parameters.AddWithValue("@Status", "Admitted");
                command.ExecuteNonQuery();
                MessageBox.Show("Patient Registered Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                MySqlCommand xf = new MySqlCommand("SELECT LAST_INSERT_ID()", conn);
                int patientID = Convert.ToInt32(xf.ExecuteScalar());
                occupyRoom(patient.getRoomNo(), conn, command); 
                conn.Close();
                addToClinicHistory(patientID, patient.getDateAdmitted());
                resetFields();
                getRoomNo();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("DB ERROR: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void addToClinicHistory(int getPatientId, DateTime dateTime)
        {
            try
            {
                string driver = "server=localhost;username=root;pwd=root;database=clinicdb";
                MySqlConnection conn = new MySqlConnection(driver);
                conn.Open();
                string query = "INSERT INTO clinichistory (PatientID, DateAdmitted) VALUES (@PatientID, @DateAdmitted)";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@PatientID", getPatientId);
                command.Parameters.AddWithValue("@DateAdmitted",   dateTime.ToString("yyyy-MM-dd")  );
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("DB ERROR: " + ex.Message);
            }
        }

        private void occupyRoom(int roomNo, MySqlConnection conn, MySqlCommand command)
        {
            try
            {
                string query = "UPDATE rooms SET Occupation = 'Occupied' WHERE RoomNo = @RoomNo";
                command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@RoomNo", roomNo);
                command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERRdfgdfgOR: " + ex.Message);
            }
        }

        private void resetFields()
        {

            FirstName.Text = "";
            MiddleName.Text = "";
            LastName.Text = "";
            Address.Text = "";
            RadioMale.Checked = false;
            RadioFemale.Checked = false;
            Age.Text = "";
            Birthdate.Text = "";
            ContactNumber.Text = "";
            PatientCondition.Text = "";
            ComboOperation.SelectedIndex = -1;
            ComboDoctor.SelectedIndex = -1;
            Bill.Text = "";
        }
        private Patient getPatient()
        {
            if (ComboRoomNo.SelectedIndex == -1)
            {
                MessageBox.Show("There is no room available.");
                return null;
            }
            int roomNo = int.Parse(ComboRoomNo.SelectedItem.ToString());
            string firstName = FirstName.Text.Trim();
            string middleName = MiddleName.Text.Trim(); ;
            string lastName = LastName.Text.Trim(); ;
            string address = Address.Text.Trim();
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(middleName)
                || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(address)
                || string.IsNullOrWhiteSpace(Age.Text.Trim()) || string.IsNullOrWhiteSpace(Birthdate.Text.Trim())
                || string.IsNullOrWhiteSpace(DateAdmitted.Text.Trim()))
            {
                MessageBox.Show("Please Fill the fields.");
                return null;
            }
            string gender = "";
            if (!RadioMale.Checked && !RadioFemale.Checked)
            {
                MessageBox.Show("Please Select Gender");
                return null;
            }
            else if (RadioMale.Checked)
            {
                gender = "Male";
            }
            else if (RadioFemale.Checked)
            {
                gender = "Female";
            }
            ;
            int age;
            if (!int.TryParse(Age.Text.Trim(), out age))
            {
                MessageBox.Show("Enter age");
                return null;
            } 
            if (age > 100 || age < 0)
            {
                MessageBox.Show("Invalid Age");
                return null;
            }

            DateTime birthDate;
            if (!DateTime.TryParse(Birthdate.Text.Trim(), out birthDate))
            {
                MessageBox.Show("Invalid date!1! Please enter a valid date (yyyy-MM-dd).");
                return null;
            }
            birthDate = birthDate.Date;
          
            string contactNumber = ContactNumber.Text.Trim();
            if (!string.IsNullOrWhiteSpace(ContactNumber.Text) && !long.TryParse(ContactNumber.Text.Trim(),out long contactNumber1))
            {
                MessageBox.Show("Enter Valid Contact Number.");
                return null;
            }

            if (!Regex.IsMatch(contactNumber, @"^09\d{9}$"))
            {
                MessageBox.Show("Invalid Number");
                return null;
            }


            DateTime dateAdmitted;
            if (!DateTime.TryParse(DateAdmitted.Text.Trim(), out dateAdmitted))
            {
                MessageBox.Show("Invalid date!1! Please enter a valid date (yyyy-MM-dd).");
                return null;
            }

            string condition = PatientCondition.Text.Trim();
            if (ComboOperation.SelectedIndex == -1)
            {
                MessageBox.Show("Enter Operation.");
                return null;
            }

            string operationName = ComboOperation.SelectedItem.ToString();
            int oeprationCode = getOprationId(operationName);
            if (oeprationCode == 0)
            {
                MessageBox.Show("Invalid Operation.");
                return null;
            }

            string doctor = ComboDoctor.SelectedItem.ToString();
            if (doctor.Equals("No Doctor Available", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("No Doctor Available");
                return null;
            }

            if (ComboDoctor.SelectedIndex == -1)
            {
                MessageBox.Show("Enter Doctor Assigned.");
                return null;
            }
           
            double bill = double.Parse(Bill.Text.Trim());

            return new Patient(
                roomNo,
                frontDesk.getId(),
                doctorAssigned.getDoctorID(),
                oeprationCode,
                firstName.Trim(),
                middleName.Trim(),
                lastName.Trim(),
                age,
                address.Trim(),
                gender.Trim(),
                condition.Trim(),
                birthDate,
                dateAdmitted,
                contactNumber,
                bill
                );
        }

        private void ComboDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bill.Text = bill.ToString();
        }
    }
}
        