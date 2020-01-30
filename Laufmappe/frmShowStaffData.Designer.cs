namespace Laufmappe
{
    partial class frmShowStaffData
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
            this.grpbUsernames = new System.Windows.Forms.GroupBox();
            this.lstbUsers = new System.Windows.Forms.ListBox();
            this.grpbPersonalData = new System.Windows.Forms.GroupBox();
            this.pcbUserImage = new System.Windows.Forms.PictureBox();
            this.dtpBirthdate = new System.Windows.Forms.DateTimePicker();
            this.tbxJob = new System.Windows.Forms.TextBox();
            this.tbxGender = new System.Windows.Forms.TextBox();
            this.tbxLastname = new System.Windows.Forms.TextBox();
            this.tbxFirstname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.grpbUsernames.SuspendLayout();
            this.grpbPersonalData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbUserImage)).BeginInit();
            this.SuspendLayout();
            // 
            // grpbUsernames
            // 
            this.grpbUsernames.Controls.Add(this.lstbUsers);
            this.grpbUsernames.Location = new System.Drawing.Point(12, 12);
            this.grpbUsernames.Name = "grpbUsernames";
            this.grpbUsernames.Size = new System.Drawing.Size(203, 160);
            this.grpbUsernames.TabIndex = 0;
            this.grpbUsernames.TabStop = false;
            this.grpbUsernames.Text = "Benutzer";
            // 
            // lstbUsers
            // 
            this.lstbUsers.FormattingEnabled = true;
            this.lstbUsers.Location = new System.Drawing.Point(6, 21);
            this.lstbUsers.Name = "lstbUsers";
            this.lstbUsers.Size = new System.Drawing.Size(191, 134);
            this.lstbUsers.TabIndex = 0;
            this.lstbUsers.SelectedIndexChanged += new System.EventHandler(this.lstbUsers_SelectedIndexChanged);
            // 
            // grpbPersonalData
            // 
            this.grpbPersonalData.Controls.Add(this.pcbUserImage);
            this.grpbPersonalData.Controls.Add(this.dtpBirthdate);
            this.grpbPersonalData.Controls.Add(this.tbxJob);
            this.grpbPersonalData.Controls.Add(this.tbxGender);
            this.grpbPersonalData.Controls.Add(this.tbxLastname);
            this.grpbPersonalData.Controls.Add(this.tbxFirstname);
            this.grpbPersonalData.Controls.Add(this.label5);
            this.grpbPersonalData.Controls.Add(this.label4);
            this.grpbPersonalData.Controls.Add(this.label3);
            this.grpbPersonalData.Controls.Add(this.label2);
            this.grpbPersonalData.Controls.Add(this.label1);
            this.grpbPersonalData.Location = new System.Drawing.Point(221, 12);
            this.grpbPersonalData.Name = "grpbPersonalData";
            this.grpbPersonalData.Size = new System.Drawing.Size(316, 160);
            this.grpbPersonalData.TabIndex = 1;
            this.grpbPersonalData.TabStop = false;
            this.grpbPersonalData.Text = "Persönliche Daten";
            // 
            // pcbUserImage
            // 
            this.pcbUserImage.Image = global::Laufmappe.Properties.Resources.user_male_128;
            this.pcbUserImage.Location = new System.Drawing.Point(191, 17);
            this.pcbUserImage.Name = "pcbUserImage";
            this.pcbUserImage.Size = new System.Drawing.Size(115, 129);
            this.pcbUserImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbUserImage.TabIndex = 10;
            this.pcbUserImage.TabStop = false;
            // 
            // dtpBirthdate
            // 
            this.dtpBirthdate.Enabled = false;
            this.dtpBirthdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthdate.Location = new System.Drawing.Point(85, 72);
            this.dtpBirthdate.Name = "dtpBirthdate";
            this.dtpBirthdate.Size = new System.Drawing.Size(100, 20);
            this.dtpBirthdate.TabIndex = 9;
            // 
            // tbxJob
            // 
            this.tbxJob.Enabled = false;
            this.tbxJob.Location = new System.Drawing.Point(85, 126);
            this.tbxJob.Name = "tbxJob";
            this.tbxJob.Size = new System.Drawing.Size(100, 20);
            this.tbxJob.TabIndex = 8;
            // 
            // tbxGender
            // 
            this.tbxGender.Enabled = false;
            this.tbxGender.Location = new System.Drawing.Point(85, 96);
            this.tbxGender.Name = "tbxGender";
            this.tbxGender.Size = new System.Drawing.Size(100, 20);
            this.tbxGender.TabIndex = 7;
            // 
            // tbxLastname
            // 
            this.tbxLastname.Enabled = false;
            this.tbxLastname.Location = new System.Drawing.Point(83, 46);
            this.tbxLastname.Name = "tbxLastname";
            this.tbxLastname.Size = new System.Drawing.Size(100, 20);
            this.tbxLastname.TabIndex = 6;
            // 
            // tbxFirstname
            // 
            this.tbxFirstname.Enabled = false;
            this.tbxFirstname.Location = new System.Drawing.Point(83, 17);
            this.tbxFirstname.Name = "tbxFirstname";
            this.tbxFirstname.Size = new System.Drawing.Size(100, 20);
            this.tbxFirstname.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Beruf:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Geschlecht:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Geburtstag:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nachname:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vorname:";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(12, 180);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(525, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // frmShowStaffData
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 215);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grpbPersonalData);
            this.Controls.Add(this.grpbUsernames);
            this.Name = "frmShowStaffData";
            this.Text = "Benutzerdaten anzeigen";
            this.Load += new System.EventHandler(this.frmShowStaffData_Load);
            this.grpbUsernames.ResumeLayout(false);
            this.grpbPersonalData.ResumeLayout(false);
            this.grpbPersonalData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbUserImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpbUsernames;
        private System.Windows.Forms.GroupBox grpbPersonalData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpBirthdate;
        private System.Windows.Forms.TextBox tbxJob;
        private System.Windows.Forms.TextBox tbxGender;
        private System.Windows.Forms.TextBox tbxLastname;
        private System.Windows.Forms.TextBox tbxFirstname;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ListBox lstbUsers;
        private System.Windows.Forms.PictureBox pcbUserImage;

    }
}