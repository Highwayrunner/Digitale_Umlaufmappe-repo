namespace Laufmappe
{
    partial class frmTransferFolder
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
            this.lstbUser = new System.Windows.Forms.ListBox();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.grpCurrentFolderUser = new System.Windows.Forms.GroupBox();
            this.tbxCurrentFolderUser = new System.Windows.Forms.TextBox();
            this.grpbFolderName = new System.Windows.Forms.GroupBox();
            this.tbxFolderName = new System.Windows.Forms.TextBox();
            this.grpbUser.SuspendLayout();
            this.grpCurrentFolderUser.SuspendLayout();
            this.grpbFolderName.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpbUser
            // 
            this.grpbUser.Controls.Add(this.lstbUser);
            this.grpbUser.Location = new System.Drawing.Point(12, 112);
            this.grpbUser.Name = "grpbUser";
            this.grpbUser.Size = new System.Drawing.Size(186, 134);
            this.grpbUser.TabIndex = 0;
            this.grpbUser.TabStop = false;
            this.grpbUser.Text = "Benutzer";
            // 
            // lstbUser
            // 
            this.lstbUser.FormattingEnabled = true;
            this.lstbUser.Location = new System.Drawing.Point(6, 19);
            this.lstbUser.Name = "lstbUser";
            this.lstbUser.Size = new System.Drawing.Size(174, 108);
            this.lstbUser.TabIndex = 0;
            this.lstbUser.DoubleClick += new System.EventHandler(this.lstbUser_DoubleClick);
            // 
            // btnTransfer
            // 
            this.btnTransfer.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnTransfer.Location = new System.Drawing.Point(18, 250);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(80, 23);
            this.btnTransfer.TabIndex = 1;
            this.btnTransfer.Text = "Weitergeben";
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(112, 250);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Abbrechen";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // grpCurrentFolderUser
            // 
            this.grpCurrentFolderUser.Controls.Add(this.tbxCurrentFolderUser);
            this.grpCurrentFolderUser.Location = new System.Drawing.Point(12, 61);
            this.grpCurrentFolderUser.Name = "grpCurrentFolderUser";
            this.grpCurrentFolderUser.Size = new System.Drawing.Size(186, 45);
            this.grpCurrentFolderUser.TabIndex = 3;
            this.grpCurrentFolderUser.TabStop = false;
            this.grpCurrentFolderUser.Text = "Aktueller Bearbeiter";
            // 
            // tbxCurrentFolderUser
            // 
            this.tbxCurrentFolderUser.Enabled = false;
            this.tbxCurrentFolderUser.Location = new System.Drawing.Point(7, 20);
            this.tbxCurrentFolderUser.Name = "tbxCurrentFolderUser";
            this.tbxCurrentFolderUser.Size = new System.Drawing.Size(173, 20);
            this.tbxCurrentFolderUser.TabIndex = 0;
            // 
            // grpbFolderName
            // 
            this.grpbFolderName.Controls.Add(this.tbxFolderName);
            this.grpbFolderName.Location = new System.Drawing.Point(12, 10);
            this.grpbFolderName.Name = "grpbFolderName";
            this.grpbFolderName.Size = new System.Drawing.Size(186, 45);
            this.grpbFolderName.TabIndex = 4;
            this.grpbFolderName.TabStop = false;
            this.grpbFolderName.Text = "Mappenname";
            // 
            // tbxFolderName
            // 
            this.tbxFolderName.Enabled = false;
            this.tbxFolderName.Location = new System.Drawing.Point(7, 20);
            this.tbxFolderName.Name = "tbxFolderName";
            this.tbxFolderName.Size = new System.Drawing.Size(173, 20);
            this.tbxFolderName.TabIndex = 0;
            // 
            // frmTransferFolder
            // 
            this.AcceptButton = this.btnTransfer;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(207, 278);
            this.Controls.Add(this.grpbFolderName);
            this.Controls.Add(this.grpCurrentFolderUser);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.grpbUser);
            this.Name = "frmTransferFolder";
            this.Text = "Weitergabe";
            this.grpbUser.ResumeLayout(false);
            this.grpCurrentFolderUser.ResumeLayout(false);
            this.grpCurrentFolderUser.PerformLayout();
            this.grpbFolderName.ResumeLayout(false);
            this.grpbFolderName.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpbUser;
        private System.Windows.Forms.ListBox lstbUser;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox grpCurrentFolderUser;
        private System.Windows.Forms.TextBox tbxCurrentFolderUser;
        private System.Windows.Forms.GroupBox grpbFolderName;
        private System.Windows.Forms.TextBox tbxFolderName;
    }
}