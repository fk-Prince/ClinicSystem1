using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicSystem.LoginForm;
using ClinicSystem.Main;

namespace ClinicSystem
{
    public partial class Dashboard : Form
    {
        private ClinicSystem clinicSystem;
        private FrontDesk frontDesk;
        public Dashboard(ClinicSystem clinicSystem, FrontDesk frontDesk)
        {
            this.clinicSystem = clinicSystem;
            this.frontDesk = frontDesk;
            InitializeComponent();
        }
       


        private void RegisterPatient_Click(object sender, EventArgs e)
        {
            clinicSystem.buttonIsClicked(clinicSystem.RegisterPatientB);
            clinicSystem.loadForm(new RegisterPatient(clinicSystem, frontDesk));  
        }

        private void button1_Click(object sender, EventArgs e) 
        {
            clinicSystem.buttonIsClicked(clinicSystem.RegisterPatientB);
            clinicSystem.loadForm(new RegisterPatient(clinicSystem, frontDesk));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clinicSystem.buttonIsClicked(clinicSystem.OperationB);
            clinicSystem.loadForm(new OperationForm(frontDesk));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clinicSystem.buttonIsClicked(clinicSystem.OperationB);
            clinicSystem.loadForm(new OperationForm( frontDesk));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clinicSystem.buttonIsClicked(clinicSystem.ViewPatients);
            clinicSystem.loadForm(new ViewPatientsForm(frontDesk));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            clinicSystem.buttonIsClicked(clinicSystem.ViewPatients);
            clinicSystem.loadForm(new ViewPatientsForm(frontDesk));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            clinicSystem.buttonIsClicked(clinicSystem.Doctors);
            clinicSystem.loadForm(new DoctorPanel(frontDesk));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            clinicSystem.buttonIsClicked(clinicSystem.Doctors);
            clinicSystem.loadForm(new DoctorPanel(frontDesk));

        }
    }
}
