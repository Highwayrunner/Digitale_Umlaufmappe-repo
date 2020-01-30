namespace Laufmappe
{
    partial class frmAddFolderAction
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
            this.grbxFolderStatus = new System.Windows.Forms.GroupBox();
            this.lbStatus = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbAktion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rdbFolderReady = new System.Windows.Forms.RadioButton();
            this.rdbFolderNotReady = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxCurrentAction = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbxFolderName = new System.Windows.Forms.TextBox();
            this.grpbNextAction = new System.Windows.Forms.GroupBox();
            this.lbNextAction = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxNextActions = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnInsertItem = new System.Windows.Forms.Button();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.btnSaveWorkFlow = new System.Windows.Forms.Button();
            this.btnDeleteChosesUser = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstbAllUsers = new System.Windows.Forms.ListBox();
            this.lstbChosenUsers = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnTransferByOrder = new System.Windows.Forms.Button();
            this.grbxFolderStatus.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpbNextAction.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbxFolderStatus
            // 
            this.grbxFolderStatus.Controls.Add(this.lbStatus);
            this.grbxFolderStatus.Controls.Add(this.label4);
            this.grbxFolderStatus.Controls.Add(this.lbAktion);
            this.grbxFolderStatus.Controls.Add(this.label2);
            this.grbxFolderStatus.Controls.Add(this.rdbFolderReady);
            this.grbxFolderStatus.Controls.Add(this.rdbFolderNotReady);
            this.grbxFolderStatus.Controls.Add(this.label1);
            this.grbxFolderStatus.Controls.Add(this.cbxCurrentAction);
            this.grbxFolderStatus.Location = new System.Drawing.Point(6, 19);
            this.grbxFolderStatus.Name = "grbxFolderStatus";
            this.grbxFolderStatus.Size = new System.Drawing.Size(258, 133);
            this.grbxFolderStatus.TabIndex = 0;
            this.grbxFolderStatus.TabStop = false;
            this.grbxFolderStatus.Text = "Mappenstatus";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(99, 47);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(69, 13);
            this.lbStatus.TabIndex = 7;
            this.lbStatus.Text = "Nicht erledigt";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Aktueller Status:";
            // 
            // lbAktion
            // 
            this.lbAktion.AutoSize = true;
            this.lbAktion.Location = new System.Drawing.Point(99, 24);
            this.lbAktion.Name = "lbAktion";
            this.lbAktion.Size = new System.Drawing.Size(37, 13);
            this.lbAktion.TabIndex = 5;
            this.lbAktion.Text = "Aktion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Aktuelle Aktion:";
            // 
            // rdbFolderReady
            // 
            this.rdbFolderReady.AutoSize = true;
            this.rdbFolderReady.Location = new System.Drawing.Point(156, 104);
            this.rdbFolderReady.Name = "rdbFolderReady";
            this.rdbFolderReady.Size = new System.Drawing.Size(60, 17);
            this.rdbFolderReady.TabIndex = 3;
            this.rdbFolderReady.Text = "Erledigt";
            this.rdbFolderReady.UseVisualStyleBackColor = true;
            // 
            // rdbFolderNotReady
            // 
            this.rdbFolderNotReady.AutoSize = true;
            this.rdbFolderNotReady.Checked = true;
            this.rdbFolderNotReady.Location = new System.Drawing.Point(9, 104);
            this.rdbFolderNotReady.Name = "rdbFolderNotReady";
            this.rdbFolderNotReady.Size = new System.Drawing.Size(87, 17);
            this.rdbFolderNotReady.TabIndex = 2;
            this.rdbFolderNotReady.TabStop = true;
            this.rdbFolderNotReady.Text = "Nicht erledigt";
            this.rdbFolderNotReady.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Aktion:";
            // 
            // cbxCurrentAction
            // 
            this.cbxCurrentAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCurrentAction.FormattingEnabled = true;
            this.cbxCurrentAction.Location = new System.Drawing.Point(52, 80);
            this.cbxCurrentAction.Name = "cbxCurrentAction";
            this.cbxCurrentAction.Size = new System.Drawing.Size(200, 21);
            this.cbxCurrentAction.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(6, 239);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(258, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Speichern";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(581, 306);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(232, 32);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Schließen";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbxFolderName);
            this.groupBox1.Location = new System.Drawing.Point(292, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 50);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mappenname";
            // 
            // tbxFolderName
            // 
            this.tbxFolderName.Enabled = false;
            this.tbxFolderName.Location = new System.Drawing.Point(9, 20);
            this.tbxFolderName.Name = "tbxFolderName";
            this.tbxFolderName.Size = new System.Drawing.Size(255, 20);
            this.tbxFolderName.TabIndex = 0;
            // 
            // grpbNextAction
            // 
            this.grpbNextAction.Controls.Add(this.lbNextAction);
            this.grpbNextAction.Controls.Add(this.label5);
            this.grpbNextAction.Controls.Add(this.cbxNextActions);
            this.grpbNextAction.Controls.Add(this.label3);
            this.grpbNextAction.Location = new System.Drawing.Point(6, 159);
            this.grpbNextAction.Name = "grpbNextAction";
            this.grpbNextAction.Size = new System.Drawing.Size(258, 73);
            this.grpbNextAction.TabIndex = 4;
            this.grpbNextAction.TabStop = false;
            this.grpbNextAction.Text = "Nächste Aktion";
            // 
            // lbNextAction
            // 
            this.lbNextAction.AutoSize = true;
            this.lbNextAction.Location = new System.Drawing.Point(99, 20);
            this.lbNextAction.Name = "lbNextAction";
            this.lbNextAction.Size = new System.Drawing.Size(37, 13);
            this.lbNextAction.TabIndex = 3;
            this.lbNextAction.Text = "Aktion";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Nächste Aktion:";
            // 
            // cbxNextActions
            // 
            this.cbxNextActions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNextActions.FormattingEnabled = true;
            this.cbxNextActions.Location = new System.Drawing.Point(52, 46);
            this.cbxNextActions.Name = "cbxNextActions";
            this.cbxNextActions.Size = new System.Drawing.Size(200, 21);
            this.cbxNextActions.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Aktion:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grbxFolderStatus);
            this.groupBox2.Controls.Add(this.grpbNextAction);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Location = new System.Drawing.Point(12, 68);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(274, 270);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mappenaktion";
            // 
            // btnInsertItem
            // 
            this.btnInsertItem.Location = new System.Drawing.Point(216, 67);
            this.btnInsertItem.Name = "btnInsertItem";
            this.btnInsertItem.Size = new System.Drawing.Size(85, 23);
            this.btnInsertItem.TabIndex = 18;
            this.btnInsertItem.Text = "Einfügen -->";
            this.btnInsertItem.UseVisualStyleBackColor = true;
            this.btnInsertItem.Click += new System.EventHandler(this.btnInsertItem_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Location = new System.Drawing.Point(216, 124);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(85, 23);
            this.btnDeleteAll.TabIndex = 17;
            this.btnDeleteAll.Text = "Alle löschen";
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // btnSaveWorkFlow
            // 
            this.btnSaveWorkFlow.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSaveWorkFlow.Location = new System.Drawing.Point(118, 205);
            this.btnSaveWorkFlow.Name = "btnSaveWorkFlow";
            this.btnSaveWorkFlow.Size = new System.Drawing.Size(282, 23);
            this.btnSaveWorkFlow.TabIndex = 16;
            this.btnSaveWorkFlow.Text = "Speichern";
            this.btnSaveWorkFlow.UseVisualStyleBackColor = true;
            this.btnSaveWorkFlow.Click += new System.EventHandler(this.btnSaveWorkFlow_Click);
            // 
            // btnDeleteChosesUser
            // 
            this.btnDeleteChosesUser.Location = new System.Drawing.Point(216, 95);
            this.btnDeleteChosesUser.Name = "btnDeleteChosesUser";
            this.btnDeleteChosesUser.Size = new System.Drawing.Size(85, 23);
            this.btnDeleteChosesUser.TabIndex = 15;
            this.btnDeleteChosesUser.Text = "<-- Löschen";
            this.btnDeleteChosesUser.UseVisualStyleBackColor = true;
            this.btnDeleteChosesUser.Click += new System.EventHandler(this.btnDeleteChosesUser_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(216, 38);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(85, 23);
            this.btnAddUser.TabIndex = 14;
            this.btnAddUser.Text = "Hinzufügen -->";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lstbAllUsers);
            this.groupBox3.Location = new System.Drawing.Point(6, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(204, 178);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Benutzer";
            // 
            // lstbAllUsers
            // 
            this.lstbAllUsers.FormattingEnabled = true;
            this.lstbAllUsers.Location = new System.Drawing.Point(6, 19);
            this.lstbAllUsers.Name = "lstbAllUsers";
            this.lstbAllUsers.Size = new System.Drawing.Size(188, 147);
            this.lstbAllUsers.TabIndex = 1;
            this.lstbAllUsers.DoubleClick += new System.EventHandler(this.lstbAllUsers_DoubleClick);
            // 
            // lstbChosenUsers
            // 
            this.lstbChosenUsers.FormattingEnabled = true;
            this.lstbChosenUsers.Location = new System.Drawing.Point(6, 19);
            this.lstbChosenUsers.Name = "lstbChosenUsers";
            this.lstbChosenUsers.Size = new System.Drawing.Size(188, 147);
            this.lstbChosenUsers.TabIndex = 0;
            this.lstbChosenUsers.DoubleClick += new System.EventHandler(this.lstbChosenUsers_DoubleClick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lstbChosenUsers);
            this.groupBox4.Location = new System.Drawing.Point(307, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 178);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Bearbeitungsreihenfolge";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox3);
            this.groupBox5.Controls.Add(this.groupBox4);
            this.groupBox5.Controls.Add(this.btnInsertItem);
            this.groupBox5.Controls.Add(this.btnAddUser);
            this.groupBox5.Controls.Add(this.btnDeleteAll);
            this.groupBox5.Controls.Add(this.btnDeleteChosesUser);
            this.groupBox5.Controls.Add(this.btnSaveWorkFlow);
            this.groupBox5.Location = new System.Drawing.Point(298, 68);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(515, 232);
            this.groupBox5.TabIndex = 20;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Bearbeitungsreihenfolge ändern";
            // 
            // btnTransferByOrder
            // 
            this.btnTransferByOrder.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnTransferByOrder.Location = new System.Drawing.Point(298, 306);
            this.btnTransferByOrder.Name = "btnTransferByOrder";
            this.btnTransferByOrder.Size = new System.Drawing.Size(232, 32);
            this.btnTransferByOrder.TabIndex = 19;
            this.btnTransferByOrder.Text = "Weitergeben";
            this.btnTransferByOrder.UseVisualStyleBackColor = true;
            this.btnTransferByOrder.Click += new System.EventHandler(this.btnTransferByOrder_Click);
            // 
            // frmAddFolderAction
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(833, 346);
            this.Controls.Add(this.btnTransferByOrder);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnExit);
            this.Name = "frmAddFolderAction";
            this.Text = "Mappen Aktion";
            this.grbxFolderStatus.ResumeLayout(false);
            this.grbxFolderStatus.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpbNextAction.ResumeLayout(false);
            this.grpbNextAction.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbxFolderStatus;
        private System.Windows.Forms.RadioButton rdbFolderReady;
        private System.Windows.Forms.RadioButton rdbFolderNotReady;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxCurrentAction;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lbAktion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbxFolderName;
        private System.Windows.Forms.GroupBox grpbNextAction;
        private System.Windows.Forms.ComboBox cbxNextActions;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbNextAction;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnInsertItem;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.Button btnSaveWorkFlow;
        private System.Windows.Forms.Button btnDeleteChosesUser;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lstbAllUsers;
        private System.Windows.Forms.ListBox lstbChosenUsers;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnTransferByOrder;
    }
}