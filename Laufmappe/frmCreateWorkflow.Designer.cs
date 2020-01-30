namespace Laufmappe
{
    partial class frmCreateWorkflow
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
            this.grpbUser = new System.Windows.Forms.GroupBox();
            this.lstbAllUsers = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstbChosenUsers = new System.Windows.Forms.ListBox();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnDeleteChosesUser = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.btnInsertItem = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tbxObjectName = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.grpbUser.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpbUser
            // 
            this.grpbUser.Controls.Add(this.lstbAllUsers);
            this.grpbUser.Location = new System.Drawing.Point(12, 63);
            this.grpbUser.Name = "grpbUser";
            this.grpbUser.Size = new System.Drawing.Size(204, 178);
            this.grpbUser.TabIndex = 0;
            this.grpbUser.TabStop = false;
            this.grpbUser.Text = "Benutzer";
            // 
            // lstbAllUsers
            // 
            this.lstbAllUsers.FormattingEnabled = true;
            this.lstbAllUsers.Location = new System.Drawing.Point(6, 19);
            this.lstbAllUsers.Name = "lstbAllUsers";
            this.lstbAllUsers.Size = new System.Drawing.Size(188, 147);
            this.lstbAllUsers.TabIndex = 1;
            this.lstbAllUsers.DoubleClick += new System.EventHandler(this.btnAddUser_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstbChosenUsers);
            this.groupBox1.Location = new System.Drawing.Point(313, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 178);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bearbeitungsreihenfolge";
            // 
            // lstbChosenUsers
            // 
            this.lstbChosenUsers.FormattingEnabled = true;
            this.lstbChosenUsers.Location = new System.Drawing.Point(6, 19);
            this.lstbChosenUsers.Name = "lstbChosenUsers";
            this.lstbChosenUsers.Size = new System.Drawing.Size(188, 147);
            this.lstbChosenUsers.TabIndex = 0;
            this.lstbChosenUsers.DoubleClick += new System.EventHandler(this.btnDeleteChosesUser_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(222, 82);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(85, 23);
            this.btnAddUser.TabIndex = 2;
            this.btnAddUser.Text = "Hinzufügen -->";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnDeleteChosesUser
            // 
            this.btnDeleteChosesUser.Location = new System.Drawing.Point(222, 139);
            this.btnDeleteChosesUser.Name = "btnDeleteChosesUser";
            this.btnDeleteChosesUser.Size = new System.Drawing.Size(85, 23);
            this.btnDeleteChosesUser.TabIndex = 3;
            this.btnDeleteChosesUser.Text = "<-- Löschen";
            this.btnDeleteChosesUser.UseVisualStyleBackColor = true;
            this.btnDeleteChosesUser.Click += new System.EventHandler(this.btnDeleteChosesUser_Click);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(12, 254);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(204, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Speichern";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Location = new System.Drawing.Point(222, 168);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(85, 23);
            this.btnDeleteAll.TabIndex = 6;
            this.btnDeleteAll.Text = "Alle löschen";
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // btnInsertItem
            // 
            this.btnInsertItem.Location = new System.Drawing.Point(222, 111);
            this.btnInsertItem.Name = "btnInsertItem";
            this.btnInsertItem.Size = new System.Drawing.Size(85, 23);
            this.btnInsertItem.TabIndex = 7;
            this.btnInsertItem.Text = "Einfügen -->";
            this.btnInsertItem.UseVisualStyleBackColor = true;
            this.btnInsertItem.Click += new System.EventHandler(this.btnInsertItem_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tbxObjectName);
            this.groupBox5.Location = new System.Drawing.Point(12, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(501, 44);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Mappenname";
            // 
            // tbxObjectName
            // 
            this.tbxObjectName.Enabled = false;
            this.tbxObjectName.Location = new System.Drawing.Point(7, 18);
            this.tbxObjectName.Name = "tbxObjectName";
            this.tbxObjectName.Size = new System.Drawing.Size(488, 20);
            this.tbxObjectName.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(313, 254);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(200, 23);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "Abbrechen";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // frmCreateWorkflow
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(525, 286);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnInsertItem);
            this.Controls.Add(this.btnDeleteAll);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDeleteChosesUser);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpbUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmCreateWorkflow";
            this.Text = "Arbeitsablauf";
            this.grpbUser.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpbUser;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstbChosenUsers;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnDeleteChosesUser;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ListBox lstbAllUsers;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.Button btnInsertItem;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox tbxObjectName;
        private System.Windows.Forms.Button btnExit;
    }
}