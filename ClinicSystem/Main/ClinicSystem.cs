using System;
using System.Drawing;
using System.Windows.Forms;
using ClinicSystem.LoginForm;
using ClinicSystem.Main;


namespace ClinicSystem
{
    public partial class ClinicSystem : Form
    {
        private FrontDesk frontdesk;
        private Button lastClickedButton;
        public ClinicSystem(FrontDesk frontdesk)
        {
            this.frontdesk = frontdesk;
            InitializeComponent();
            lastClickedButton = Dashboard;
            loadForm(new Dashboard(this, frontdesk));
            editButton(Dashboard);
            editButton(RegisterPatientB);
            editButton(OperationB);
            editButton(ViewPatients);
            editButton(Doctors);


        }

        public void loadForm(object form)
        {
            if (mainpanel.Controls.Count > 0)
            {
                mainpanel.Controls.RemoveAt(0);
            }
            Form f = form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            mainpanel.Controls.Add(f);
            mainpanel.Tag = f;
            f.Show();
        }

        private void editButton(Button button)
        {
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = FlatStyle.Flat;
            button.MouseEnter += Button_MouseEnter;
            button.MouseLeave += Button_MouseLeave;
            button.MouseClick += Button_MouseClicked;
        }
        public void buttonIsClicked(Button btn)
        {
           
            btn.BackColor = Color.FromArgb(132, 132, 132);           
            lastClickedButton.BackColor = Color.FromArgb(255, 255, 255);
            lastClickedButton = btn;
        }
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != lastClickedButton)
            {
                btn.BackColor = Color.FromArgb(200, 200, 200);
            }


        }


        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != lastClickedButton)
            {
                btn.BackColor = Color.FromArgb(255, 255, 255);
            }
        }

        private void Button_MouseClicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != lastClickedButton)
            {
                btn.BackColor = Color.FromArgb(132, 132, 132);
                lastClickedButton.BackColor = Color.FromArgb(255, 255, 255);
            }
            lastClickedButton = btn;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login loginForm = new Login();
            loginForm.Show();
        }

        private void Dashboard_Click(object sender, EventArgs e)
        {
            buttonIsClicked(Dashboard);
            loadForm(new Dashboard(this, frontdesk));
        }

        private void RegisterPatientB_Click(object sender, EventArgs e)
        {
            buttonIsClicked(RegisterPatientB);
            loadForm(new RegisterPatient(this, frontdesk));
        }

        private void Services_Click(object sender, EventArgs e)
        {
            buttonIsClicked(OperationB);
            loadForm(new OperationForm( frontdesk));
        }

        private void ViewPatients_Click(object sender, EventArgs e)
        {
            buttonIsClicked(ViewPatients);
            loadForm(new ViewPatientsForm(frontdesk));
        }

        private void Doctors_Click(object sender, EventArgs e)
        {
            buttonIsClicked(Doctors);
            loadForm(new DoctorPanel(frontdesk));
        }
    }
}
