namespace ClinicSystem
{
    partial class ClinicSystem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.Doctors = new System.Windows.Forms.Button();
            this.ViewPatients = new System.Windows.Forms.Button();
            this.OperationB = new System.Windows.Forms.Button();
            this.RegisterPatientB = new System.Windows.Forms.Button();
            this.Dashboard = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Label();
            this.mainpanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Doctors);
            this.panel1.Controls.Add(this.ViewPatients);
            this.panel1.Controls.Add(this.OperationB);
            this.panel1.Controls.Add(this.RegisterPatientB);
            this.panel1.Controls.Add(this.Dashboard);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(244, 720);
            this.panel1.TabIndex = 0;
            // 
            // Doctors
            // 
            this.Doctors.BackColor = System.Drawing.Color.White;
            this.Doctors.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Doctors.Location = new System.Drawing.Point(0, 300);
            this.Doctors.Name = "Doctors";
            this.Doctors.Size = new System.Drawing.Size(244, 50);
            this.Doctors.TabIndex = 4;
            this.Doctors.Text = "Doctors";
            this.Doctors.UseVisualStyleBackColor = false;
            this.Doctors.Click += new System.EventHandler(this.Doctors_Click);
            // 
            // ViewPatients
            // 
            this.ViewPatients.BackColor = System.Drawing.Color.White;
            this.ViewPatients.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewPatients.Location = new System.Drawing.Point(0, 253);
            this.ViewPatients.Name = "ViewPatients";
            this.ViewPatients.Size = new System.Drawing.Size(244, 50);
            this.ViewPatients.TabIndex = 3;
            this.ViewPatients.Text = "View Patients";
            this.ViewPatients.UseVisualStyleBackColor = false;
            this.ViewPatients.Click += new System.EventHandler(this.ViewPatients_Click);
            // 
            // OperationB
            // 
            this.OperationB.BackColor = System.Drawing.Color.White;
            this.OperationB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OperationB.Location = new System.Drawing.Point(0, 207);
            this.OperationB.Name = "OperationB";
            this.OperationB.Size = new System.Drawing.Size(244, 50);
            this.OperationB.TabIndex = 2;
            this.OperationB.Text = "Operations";
            this.OperationB.UseVisualStyleBackColor = false;
            this.OperationB.Click += new System.EventHandler(this.Services_Click);
            // 
            // RegisterPatientB
            // 
            this.RegisterPatientB.BackColor = System.Drawing.Color.White;
            this.RegisterPatientB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterPatientB.Location = new System.Drawing.Point(0, 160);
            this.RegisterPatientB.Name = "RegisterPatientB";
            this.RegisterPatientB.Size = new System.Drawing.Size(244, 50);
            this.RegisterPatientB.TabIndex = 1;
            this.RegisterPatientB.Text = "Patient";
            this.RegisterPatientB.UseVisualStyleBackColor = false;
            this.RegisterPatientB.Click += new System.EventHandler(this.RegisterPatientB_Click);
            // 
            // Dashboard
            // 
            this.Dashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(132)))), ((int)(((byte)(132)))));
            this.Dashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dashboard.Location = new System.Drawing.Point(0, 114);
            this.Dashboard.Name = "Dashboard";
            this.Dashboard.Size = new System.Drawing.Size(244, 50);
            this.Dashboard.TabIndex = 0;
            this.Dashboard.Text = "Dashboard";
            this.Dashboard.UseVisualStyleBackColor = false;
            this.Dashboard.Click += new System.EventHandler(this.Dashboard_Click);
            // 
            // exit
            // 
            this.exit.AutoSize = true;
            this.exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit.Location = new System.Drawing.Point(1268, 0);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(16, 16);
            this.exit.TabIndex = 1;
            this.exit.Text = "X";
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // mainpanel
            // 
            this.mainpanel.Location = new System.Drawing.Point(244, 30);
            this.mainpanel.Name = "mainpanel";
            this.mainpanel.Size = new System.Drawing.Size(1040, 651);
            this.mainpanel.TabIndex = 2;
            // 
            // ClinicSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1284, 681);
            this.Controls.Add(this.mainpanel);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ClinicSystem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClinicSystem";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button Dashboard;
        public System.Windows.Forms.Button Doctors;
        public System.Windows.Forms.Button ViewPatients;
        public System.Windows.Forms.Button OperationB;
        public System.Windows.Forms.Button RegisterPatientB;
        private System.Windows.Forms.Label exit;
        private System.Windows.Forms.Panel mainpanel;
    }
}