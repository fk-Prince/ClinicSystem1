namespace ClinicSystem.Main
{
    partial class AddOperation
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.OperationID = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.OperationName = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.OperationPrice = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.OperationDescription = new System.Windows.Forms.TextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.isPriceValid = new System.Windows.Forms.PictureBox();
            this.isExist = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.isPriceValid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.isExist)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(136, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Operation";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.OperationID);
            this.panel1.Location = new System.Drawing.Point(51, 102);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 29);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(102, 23);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(186, 2);
            this.panel3.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Operation ID  :";
            // 
            // OperationID
            // 
            this.OperationID.BackColor = System.Drawing.Color.White;
            this.OperationID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OperationID.Location = new System.Drawing.Point(102, 7);
            this.OperationID.Name = "OperationID";
            this.OperationID.ReadOnly = true;
            this.OperationID.Size = new System.Drawing.Size(186, 13);
            this.OperationID.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(115, 363);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 41);
            this.button1.TabIndex = 0;
            this.button1.Text = "ADD OPERATION";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.OperationName);
            this.panel2.Location = new System.Drawing.Point(51, 137);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 29);
            this.panel2.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Black;
            this.panel6.Location = new System.Drawing.Point(102, 23);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(186, 2);
            this.panel6.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Operation Name  :";
            // 
            // OperationName
            // 
            this.OperationName.BackColor = System.Drawing.Color.White;
            this.OperationName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OperationName.Location = new System.Drawing.Point(102, 7);
            this.OperationName.Name = "OperationName";
            this.OperationName.Size = new System.Drawing.Size(186, 13);
            this.OperationName.TabIndex = 2;
            this.OperationName.TextChanged += new System.EventHandler(this.OperationName_TextChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.OperationPrice);
            this.panel4.Location = new System.Drawing.Point(51, 172);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(300, 29);
            this.panel4.TabIndex = 4;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Black;
            this.panel7.Location = new System.Drawing.Point(102, 23);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(186, 2);
            this.panel7.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Operation Price :";
            // 
            // OperationPrice
            // 
            this.OperationPrice.BackColor = System.Drawing.Color.White;
            this.OperationPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OperationPrice.Location = new System.Drawing.Point(102, 7);
            this.OperationPrice.Name = "OperationPrice";
            this.OperationPrice.Size = new System.Drawing.Size(186, 13);
            this.OperationPrice.TabIndex = 3;
            this.OperationPrice.TextChanged += new System.EventHandler(this.OperationPrice_TextChanged);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.OperationDescription);
            this.panel5.Location = new System.Drawing.Point(51, 218);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(300, 98);
            this.panel5.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Description";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Operation ";
            // 
            // OperationDescription
            // 
            this.OperationDescription.Location = new System.Drawing.Point(102, 6);
            this.OperationDescription.Multiline = true;
            this.OperationDescription.Name = "OperationDescription";
            this.OperationDescription.Size = new System.Drawing.Size(186, 89);
            this.OperationDescription.TabIndex = 4;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.isPriceValid);
            this.panel8.Controls.Add(this.isExist);
            this.panel8.Controls.Add(this.label4);
            this.panel8.Controls.Add(this.button1);
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(384, 451);
            this.panel8.TabIndex = 7;
            // 
            // isPriceValid
            // 
            this.isPriceValid.Location = new System.Drawing.Point(350, 178);
            this.isPriceValid.Name = "isPriceValid";
            this.isPriceValid.Size = new System.Drawing.Size(16, 16);
            this.isPriceValid.TabIndex = 5;
            this.isPriceValid.TabStop = false;
            this.isPriceValid.Visible = false;
            // 
            // isExist
            // 
            this.isExist.Location = new System.Drawing.Point(350, 142);
            this.isExist.Name = "isExist";
            this.isExist.Size = new System.Drawing.Size(16, 16);
            this.isExist.TabIndex = 4;
            this.isExist.TabStop = false;
            this.isExist.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(363, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "X";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // AddOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(384, 451);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddOperation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddOperation";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.isPriceValid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.isExist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox OperationID;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox OperationName;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox OperationPrice;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox OperationDescription;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox isExist;
        private System.Windows.Forms.PictureBox isPriceValid;
    }
}