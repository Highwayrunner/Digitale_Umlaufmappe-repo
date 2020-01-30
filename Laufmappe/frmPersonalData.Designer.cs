namespace Laufmappe
{
    partial class frmPersonalData
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpBirthdate = new System.Windows.Forms.DateTimePicker();
            this.tbxFirstName = new System.Windows.Forms.TextBox();
            this.tbxLastName = new System.Windows.Forms.TextBox();
            this.cmbxGender = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxJob = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.btnDeleteImage = new System.Windows.Forms.Button();
            this.pcbUserImage = new System.Windows.Forms.PictureBox();
            this.grpbPersonalData = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxUsername = new System.Windows.Forms.TextBox();
            this.grpbUserInfo = new System.Windows.Forms.GroupBox();
            this.tbxRights = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pcbUserImage)).BeginInit();
            this.grpbPersonalData.SuspendLayout();
            this.grpbUserInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vorname:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nachname:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Geburtstag:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Geschlecht:";
            // 
            // dtpBirthdate
            // 
            this.dtpBirthdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthdate.Location = new System.Drawing.Point(81, 80);
            this.dtpBirthdate.Name = "dtpBirthdate";
            this.dtpBirthdate.Size = new System.Drawing.Size(74, 20);
            this.dtpBirthdate.TabIndex = 4;
            // 
            // tbxFirstName
            // 
            this.tbxFirstName.Location = new System.Drawing.Point(81, 24);
            this.tbxFirstName.Name = "tbxFirstName";
            this.tbxFirstName.Size = new System.Drawing.Size(151, 20);
            this.tbxFirstName.TabIndex = 5;
            // 
            // tbxLastName
            // 
            this.tbxLastName.Location = new System.Drawing.Point(81, 54);
            this.tbxLastName.Name = "tbxLastName";
            this.tbxLastName.Size = new System.Drawing.Size(151, 20);
            this.tbxLastName.TabIndex = 6;
            // 
            // cmbxGender
            // 
            this.cmbxGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxGender.FormattingEnabled = true;
            this.cmbxGender.Items.AddRange(new object[] {
            "Männlich",
            "Weiblich"});
            this.cmbxGender.Location = new System.Drawing.Point(81, 104);
            this.cmbxGender.Name = "cmbxGender";
            this.cmbxGender.Size = new System.Drawing.Size(121, 21);
            this.cmbxGender.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Beruf:";
            // 
            // tbxJob
            // 
            this.tbxJob.Location = new System.Drawing.Point(81, 136);
            this.tbxJob.Name = "tbxJob";
            this.tbxJob.Size = new System.Drawing.Size(151, 20);
            this.tbxJob.TabIndex = 9;
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSave.Location = new System.Drawing.Point(17, 290);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Speichern";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(184, 290);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "Abbrechen";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(283, 154);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(76, 23);
            this.btnLoadImage.TabIndex = 13;
            this.btnLoadImage.Text = "Bild laden";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // btnDeleteImage
            // 
            this.btnDeleteImage.Image = global::Laufmappe.Properties.Resources.delete_16;
            this.btnDeleteImage.Location = new System.Drawing.Point(365, 154);
            this.btnDeleteImage.Name = "btnDeleteImage";
            this.btnDeleteImage.Size = new System.Drawing.Size(33, 23);
            this.btnDeleteImage.TabIndex = 14;
            this.btnDeleteImage.UseVisualStyleBackColor = true;
            this.btnDeleteImage.Click += new System.EventHandler(this.btnDeleteImage_Click);
            // 
            // pcbUserImage
            // 
            this.pcbUserImage.Image = global::Laufmappe.Properties.Resources.user_male_128;
            this.pcbUserImage.InitialImage = null;
            this.pcbUserImage.Location = new System.Drawing.Point(283, 12);
            this.pcbUserImage.Name = "pcbUserImage";
            this.pcbUserImage.Size = new System.Drawing.Size(115, 128);
            this.pcbUserImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbUserImage.TabIndex = 12;
            this.pcbUserImage.TabStop = false;
            // 
            // grpbPersonalData
            // 
            this.grpbPersonalData.Controls.Add(this.label1);
            this.grpbPersonalData.Controls.Add(this.label2);
            this.grpbPersonalData.Controls.Add(this.label3);
            this.grpbPersonalData.Controls.Add(this.label4);
            this.grpbPersonalData.Controls.Add(this.dtpBirthdate);
            this.grpbPersonalData.Controls.Add(this.tbxFirstName);
            this.grpbPersonalData.Controls.Add(this.tbxJob);
            this.grpbPersonalData.Controls.Add(this.tbxLastName);
            this.grpbPersonalData.Controls.Add(this.label5);
            this.grpbPersonalData.Controls.Add(this.cmbxGender);
            this.grpbPersonalData.Location = new System.Drawing.Point(17, 103);
            this.grpbPersonalData.Name = "grpbPersonalData";
            this.grpbPersonalData.Size = new System.Drawing.Size(242, 169);
            this.grpbPersonalData.TabIndex = 15;
            this.grpbPersonalData.TabStop = false;
            this.grpbPersonalData.Text = "Persönliche Daten";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Benutzername:";
            // 
            // tbxUsername
            // 
            this.tbxUsername.Enabled = false;
            this.tbxUsername.Location = new System.Drawing.Point(95, 17);
            this.tbxUsername.Name = "tbxUsername";
            this.tbxUsername.Size = new System.Drawing.Size(137, 20);
            this.tbxUsername.TabIndex = 1;
            // 
            // grpbUserInfo
            // 
            this.grpbUserInfo.Controls.Add(this.tbxRights);
            this.grpbUserInfo.Controls.Add(this.label7);
            this.grpbUserInfo.Controls.Add(this.tbxUsername);
            this.grpbUserInfo.Controls.Add(this.label6);
            this.grpbUserInfo.Location = new System.Drawing.Point(17, 13);
            this.grpbUserInfo.Name = "grpbUserInfo";
            this.grpbUserInfo.Size = new System.Drawing.Size(242, 84);
            this.grpbUserInfo.TabIndex = 16;
            this.grpbUserInfo.TabStop = false;
            this.grpbUserInfo.Text = "Benutzerinformation";
            // 
            // tbxRights
            // 
            this.tbxRights.Enabled = false;
            this.tbxRights.Location = new System.Drawing.Point(95, 49);
            this.tbxRights.Name = "tbxRights";
            this.tbxRights.Size = new System.Drawing.Size(137, 20);
            this.tbxRights.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(44, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Rechte:";
            // 
            // frmPersonalData
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(410, 321);
            this.Controls.Add(this.grpbUserInfo);
            this.Controls.Add(this.grpbPersonalData);
            this.Controls.Add(this.btnDeleteImage);
            this.Controls.Add(this.btnLoadImage);
            this.Controls.Add(this.pcbUserImage);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmPersonalData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Perönliche Daten ";
            ((System.ComponentModel.ISupportInitialize)(this.pcbUserImage)).EndInit();
            this.grpbPersonalData.ResumeLayout(false);
            this.grpbPersonalData.PerformLayout();
            this.grpbUserInfo.ResumeLayout(false);
            this.grpbUserInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpBirthdate;
        private System.Windows.Forms.TextBox tbxFirstName;
        private System.Windows.Forms.TextBox tbxLastName;
        private System.Windows.Forms.ComboBox cmbxGender;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxJob;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.PictureBox pcbUserImage;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.Button btnDeleteImage;
        private System.Windows.Forms.GroupBox grpbPersonalData;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxUsername;
        private System.Windows.Forms.GroupBox grpbUserInfo;
        private System.Windows.Forms.TextBox tbxRights;
        private System.Windows.Forms.Label label7;
    }
}