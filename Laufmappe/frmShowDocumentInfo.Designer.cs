namespace Laufmappe
{
    partial class frmShowDocumentInfo
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpAddDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpChangeDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpCreateDate = new System.Windows.Forms.DateTimePicker();
            this.tbxDocumentName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxDocumentInfoNames = new System.Windows.Forms.ComboBox();
            this.btnAddInfo = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpInfoCreateDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxUser = new System.Windows.Forms.ComboBox();
            this.tbxDocumentInfo = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpAddDate);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dtpChangeDate);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtpCreateDate);
            this.groupBox1.Controls.Add(this.tbxDocumentName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(551, 111);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dokumentdaten";
            // 
            // dtpAddDate
            // 
            this.dtpAddDate.Enabled = false;
            this.dtpAddDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAddDate.Location = new System.Drawing.Point(98, 78);
            this.dtpAddDate.Name = "dtpAddDate";
            this.dtpAddDate.Size = new System.Drawing.Size(91, 20);
            this.dtpAddDate.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Hinzugefügt am:";
            // 
            // dtpChangeDate
            // 
            this.dtpChangeDate.Enabled = false;
            this.dtpChangeDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpChangeDate.Location = new System.Drawing.Point(302, 46);
            this.dtpChangeDate.Name = "dtpChangeDate";
            this.dtpChangeDate.Size = new System.Drawing.Size(91, 20);
            this.dtpChangeDate.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(206, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Änderungsdatum:";
            // 
            // dtpCreateDate
            // 
            this.dtpCreateDate.Enabled = false;
            this.dtpCreateDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCreateDate.Location = new System.Drawing.Point(98, 46);
            this.dtpCreateDate.Name = "dtpCreateDate";
            this.dtpCreateDate.Size = new System.Drawing.Size(91, 20);
            this.dtpCreateDate.TabIndex = 6;
            // 
            // tbxDocumentName
            // 
            this.tbxDocumentName.Enabled = false;
            this.tbxDocumentName.Location = new System.Drawing.Point(98, 17);
            this.tbxDocumentName.Name = "tbxDocumentName";
            this.tbxDocumentName.Size = new System.Drawing.Size(439, 20);
            this.tbxDocumentName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Erstelldatum:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dokumentname:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxDocumentInfoNames);
            this.groupBox2.Controls.Add(this.btnAddInfo);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.dtpInfoCreateDate);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cbxUser);
            this.groupBox2.Controls.Add(this.tbxDocumentInfo);
            this.groupBox2.Location = new System.Drawing.Point(13, 131);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(550, 371);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dokumentinformationen";
            // 
            // cbxDocumentInfoNames
            // 
            this.cbxDocumentInfoNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDocumentInfoNames.FormattingEnabled = true;
            this.cbxDocumentInfoNames.Location = new System.Drawing.Point(305, 28);
            this.cbxDocumentInfoNames.Name = "cbxDocumentInfoNames";
            this.cbxDocumentInfoNames.Size = new System.Drawing.Size(184, 21);
            this.cbxDocumentInfoNames.TabIndex = 10;
            this.cbxDocumentInfoNames.SelectedIndexChanged += new System.EventHandler(this.cbxDocumentNames_SelectedIndexChanged);
            // 
            // btnAddInfo
            // 
            this.btnAddInfo.Location = new System.Drawing.Point(305, 70);
            this.btnAddInfo.Name = "btnAddInfo";
            this.btnAddInfo.Size = new System.Drawing.Size(184, 23);
            this.btnAddInfo.TabIndex = 7;
            this.btnAddInfo.Text = "Information hinzufügen";
            this.btnAddInfo.UseVisualStyleBackColor = true;
            this.btnAddInfo.Click += new System.EventHandler(this.btnAddInfo_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Benutzer:";
            // 
            // dtpInfoCreateDate
            // 
            this.dtpInfoCreateDate.Enabled = false;
            this.dtpInfoCreateDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInfoCreateDate.Location = new System.Drawing.Point(97, 73);
            this.dtpInfoCreateDate.Name = "dtpInfoCreateDate";
            this.dtpInfoCreateDate.Size = new System.Drawing.Size(91, 20);
            this.dtpInfoCreateDate.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Erstelldatum:";
            // 
            // cbxUser
            // 
            this.cbxUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUser.FormattingEnabled = true;
            this.cbxUser.Location = new System.Drawing.Point(97, 28);
            this.cbxUser.Name = "cbxUser";
            this.cbxUser.Size = new System.Drawing.Size(121, 21);
            this.cbxUser.TabIndex = 1;
            this.cbxUser.SelectedIndexChanged += new System.EventHandler(this.cbxUser_SelectedIndexChanged);
            // 
            // tbxDocumentInfo
            // 
            this.tbxDocumentInfo.Location = new System.Drawing.Point(10, 107);
            this.tbxDocumentInfo.Multiline = true;
            this.tbxDocumentInfo.Name = "tbxDocumentInfo";
            this.tbxDocumentInfo.ReadOnly = true;
            this.tbxDocumentInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxDocumentInfo.Size = new System.Drawing.Size(534, 257);
            this.tbxDocumentInfo.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(13, 508);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(550, 23);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // frmShowDocumentInfo
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 538);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmShowDocumentInfo";
            this.Text = "Dokumentinformationen";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxDocumentName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbxDocumentInfo;
        private System.Windows.Forms.DateTimePicker dtpInfoCreateDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxUser;
        private System.Windows.Forms.DateTimePicker dtpAddDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpChangeDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpCreateDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnAddInfo;
        private System.Windows.Forms.ComboBox cbxDocumentInfoNames;
    }
}