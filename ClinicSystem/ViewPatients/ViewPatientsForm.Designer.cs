namespace ClinicSystem
{
    partial class ViewPatientsForm
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.searchPatientName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.FlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxAdmitted = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.searchPatientName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 47);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(55, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(185, 2);
            this.panel2.TabIndex = 1;
            // 
            // searchPatientName
            // 
            this.searchPatientName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchPatientName.Location = new System.Drawing.Point(55, 23);
            this.searchPatientName.Name = "searchPatientName";
            this.searchPatientName.Size = new System.Drawing.Size(185, 13);
            this.searchPatientName.TabIndex = 2;
            this.searchPatientName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search Patient Name";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::ClinicSystem.Properties.Resources.search;
            this.pictureBox1.Location = new System.Drawing.Point(9, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FlowPanel
            // 
            this.FlowPanel.AutoScroll = true;
            this.FlowPanel.Location = new System.Drawing.Point(86, 107);
            this.FlowPanel.Name = "FlowPanel";
            this.FlowPanel.Size = new System.Drawing.Size(877, 532);
            this.FlowPanel.TabIndex = 1;
            // 
            // checkBoxAdmitted
            // 
            this.checkBoxAdmitted.AutoSize = true;
            this.checkBoxAdmitted.Checked = true;
            this.checkBoxAdmitted.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAdmitted.Location = new System.Drawing.Point(86, 84);
            this.checkBoxAdmitted.Name = "checkBoxAdmitted";
            this.checkBoxAdmitted.Size = new System.Drawing.Size(111, 17);
            this.checkBoxAdmitted.TabIndex = 2;
            this.checkBoxAdmitted.Text = "Currently Admitted";
            this.checkBoxAdmitted.UseVisualStyleBackColor = true;
            this.checkBoxAdmitted.CheckedChanged += new System.EventHandler(this.checkBoxAdmitted_CheckedChanged);
            // 
            // ViewPatientsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1041, 651);
            this.Controls.Add(this.checkBoxAdmitted);
            this.Controls.Add(this.FlowPanel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ViewPatientsForm";
            this.Text = "ViewPatientsForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchPatientName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel FlowPanel;
        private System.Windows.Forms.CheckBox checkBoxAdmitted;
    }
}