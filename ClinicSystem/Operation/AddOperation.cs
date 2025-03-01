using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ClinicSystem.Main
{
    public partial class AddOperation : Form
    {
        private FrontDesk frontDesk;
        private bool isDuplicateName = false;
        public AddOperation(FrontDesk frontDesk)
        {
            this.frontDesk = frontDesk;
            InitializeComponent();
            getLastID();

            OperationName.Leave += Name_Leave;
            OperationPrice.Leave += Price_Leave;
        }
        private void Price_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(OperationPrice.Text))
            {
                isExist.Visible = false;
                return;
            }
            double price = 0;
            if (!double.TryParse(OperationPrice.Text.Trim(), out price))
            {
                isPriceValid.Image = Properties.Resources.errorx;
                isPriceValid.Visible = true;
            }
            else
            {
                isPriceValid.Image = Properties.Resources.valid;
                isPriceValid.Visible = true;
            }
        }
        private void Name_Leave(object sender, EventArgs e)
        {
            try
            {
                string name = OperationName.Text.Trim();
                if (string.IsNullOrWhiteSpace(OperationName.Text))
                {
                    isExist.Visible = false;
                    return;
                }
                string driver = "server=localhost;username=root;pwd=root;database=clinicdb";
                MySqlConnection conn = new MySqlConnection(driver);
                conn.Open();

                string query = "SELECT OperationName FROM operations WHERE OperationName = @OperationName";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@OperationName", name);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    isExist.Image = Properties.Resources.errorx;
                    isExist.Visible = true;
                    isDuplicateName = true;
                }
                else
                {
                    isExist.Image = Properties.Resources.valid;
                    isExist.Visible = true;
                    isDuplicateName = false;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERRORDB: " + ex.Message);
            }
        }

        private void getLastID()
        {
            try
            {
                string driver = "server=localhost;username=root;pwd=root;database=clinicdb";
                MySqlConnection conn = new MySqlConnection(driver);
                conn.Open();
                string query = "SELECT OperationCode FROM operations ORDER BY OperationCode DESC LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    int operatonCode = int.Parse(reader["OperationCode"].ToString()) + 1;
                    OperationID.Text = operatonCode.ToString();
                }
                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERRORDB: " + ex.Message);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (frontDesk == null)
            {
                MessageBox.Show("This user is not permitted to add operation !!", "Permission", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {


                Operation operation = getInputs();
                if (operation == null) return;

                string driver = "server=localhost;username=root;pwd=root;database=clinicdb";
                MySqlConnection conn = new MySqlConnection(driver);
                conn.Open();
                string query = "INSERT INTO operations(OperationCode, FrontDeskID, OperationName, DateAdded, Price, Description) " +
                    "VALUES (@OperationCode, @FrontDeskID, @OperationName, @DateAdded, @Price, @Description)";

    
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@OperationCode", operation.getCode());
                cmd.Parameters.AddWithValue("@FrontDeskID", frontDesk.getId());
                cmd.Parameters.AddWithValue("@OperationName", operation.getName());
                cmd.Parameters.AddWithValue("@DateAdded", operation.getDateAdded().ToString("yyyy-MM-dd"));  
                cmd.Parameters.AddWithValue("@Price", operation.getPrice());
                cmd.Parameters.AddWithValue("@Description", operation.getDescription());
                cmd.ExecuteNonQuery();


                MessageBox.Show("Operation Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                int idx = operation.getCode() + 1;
                OperationID.Text = idx.ToString();
                resetFields();
                conn.Close();
            }
            catch (MySqlException ex) 
            { 
                MessageBox.Show("ERRORDB: " + ex.Message);
            }
        }

        private void resetFields()
        {
            OperationName.Text = "";
            OperationPrice.Text = "";
            isPriceValid.Visible = false;
            isExist.Visible = false;
            OperationDescription.Text = "";
        }

        private Operation getInputs()
        {
            if (string.IsNullOrWhiteSpace(OperationName.Text)
                || string.IsNullOrWhiteSpace(OperationPrice.Text)
                || string.IsNullOrWhiteSpace(OperationDescription.Text))
            {
                MessageBox.Show("Empty Input","Wrong Input",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }


       
            double price = 0;
            if (!double.TryParse(OperationPrice.Text.Trim(), out price))
            {
                MessageBox.Show("Invalid Price", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            if (isDuplicateName)
            {
                MessageBox.Show("Operation Name Already Exist", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            int id = int.Parse(OperationID.Text);
            string name = OperationName.Text.Trim();
            DateTime dateAdded = DateTime.Now.Date;
            string description = OperationDescription.Text.Trim();
            price = double.Parse(OperationPrice.Text.Trim());




            return new Operation(id,name,dateAdded,price,description);

        }

        private void OperationName_TextChanged(object sender, EventArgs e)
        {
            isExist.Visible = false;
        }

        private void OperationPrice_TextChanged(object sender, EventArgs e)
        {
           isExist.Visible = false;     
        }
    }
}
