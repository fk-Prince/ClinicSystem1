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

namespace ClinicSystem.Main
{
    public partial class OperationForm : Form
    {
        private FrontDesk frontDesk;
        private List<Operation> operationList = new List<Operation>(); 
        public OperationForm( FrontDesk frontDesk)
        {
            this.frontDesk = frontDesk;
            InitializeComponent();

            getServices("SELECT * FROM operations", null);
        }

        private void getServices(string query,string searchOperation)
        {
            try
            {
                FlowPanel.Controls.Clear();
                string driver = "server=localhost;username=root;password=root;database=clinicdb";
                MySqlConnection conn = new MySqlConnection(driver);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, conn);
                if (!string.IsNullOrWhiteSpace(searchOperation))
                {
                    cmd.Parameters.AddWithValue("@OperationCode", searchOperation + "%");
                    cmd.Parameters.AddWithValue("@OperationName", searchOperation + "%");
                }
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DateTime date = Convert.ToDateTime(reader["DateAdded"].ToString());
                    Operation operation = new Operation(
                        int.Parse(reader["OperationCode"].ToString()),
                        reader["OperationName"].ToString(),
                        date,
                        Convert.ToDouble(reader["Price"].ToString()),
                        reader["Description"].ToString()
                    );
                    operationList.Add(operation);
                   
                }
                displayOperations(operationList);
                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void displayOperations(List<Operation> operationList)
        {
            FlowPanel.Controls.Clear();
            foreach (Operation operation in operationList)
            {
                Panel panel = new Panel();
                panel.Size = new Size(400, 200);
                panel.BackColor = Color.FromArgb(255, 255, 255);
                panel.Margin = new Padding(10, 10, 10, 10);
                panel.BorderStyle = BorderStyle.FixedSingle;

                Label operationID = new Label();
                operationID.Text = $"Operation Code:  {operation.getCode()}";
                operationID.Location = new Point(10, 10);
                operationID.AutoSize = true;
                operationID.Font = new Font("Arial", 9, FontStyle.Bold);
                panel.Controls.Add(operationID);


                Label operationName = new Label();
                operationName.Text = $"Operation Name:  {operation.getName()}";
                operationName.Location = new Point(10, 30);
                operationName.AutoSize = true;
                operationName.Font = new Font("Arial", 9, FontStyle.Bold);
                panel.Controls.Add(operationName);

                Label operationPrice = new Label();
                operationPrice.Text = $"Operation Price: {operation.getPrice()}";
                operationPrice.Location = new Point(10, 50);
                operationPrice.Font = new Font("Arial", 9, FontStyle.Bold);
                operationPrice.AutoSize = true;
                panel.Controls.Add(operationPrice);

                Label operationDate = new Label();
                DateTime date = operation.getDateAdded();
                date = date.Date;
                operationDate.Text = $"Operation Date-Added: {date.ToString("yyyy-MM-dd")}";
                operationDate.Location = new Point(10, 70);
                operationDate.Font = new Font("Arial", 9, FontStyle.Bold);
                operationDate.AutoSize = true;
                panel.Controls.Add(operationDate);

                Label operationDescription = new Label();
                operationDescription.Text = "Operation Description";
                operationDescription.Location = new Point(10, 90);
                operationDescription.AutoSize = true;
                operationDescription.Font = new Font("Arial", 9, FontStyle.Bold);
                panel.Controls.Add(operationDescription);

                TextBox textBox = new TextBox();
                textBox.Text = operation.getDescription().ToString();
                textBox.Multiline = true;
                textBox.Location = new Point(20, 110);
                textBox.Size = new Size(350, 75);
                textBox.BorderStyle = BorderStyle.FixedSingle;
                textBox.ReadOnly = true;
                panel.Controls.Add(textBox);


                FlowPanel.Controls.Add(panel);
            }
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            List<Operation> filteredOperation = new List<Operation>();
            string query = "";
            if (string.IsNullOrWhiteSpace(SearchBox.Text.Trim()))
            {
                filteredOperation = operationList; 
            } 
            else
            {
                string searchbox = SearchBox.Text.Trim();
                foreach (Operation operation in operationList)
                {
                    if (operation.getName().StartsWith(searchbox,StringComparison.OrdinalIgnoreCase) || operation.getCode().ToString().StartsWith(searchbox, StringComparison.OrdinalIgnoreCase))
                    {
                        filteredOperation.Add(operation);
                    }
                }
            }
            displayOperations(filteredOperation);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddOperation add = new AddOperation(frontDesk);
            add.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SearchBox.Text = "";
            getServices("SELECT * FROM operations", null);
        }
    }
}
