namespace Laufmappe
{
    partial class frmShowFolderHistory
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
            this.grpbFolderName = new System.Windows.Forms.GroupBox();
            this.tbxFolderName = new System.Windows.Forms.TextBox();
            this.grpbUserHistory = new System.Windows.Forms.GroupBox();
            this.lstvShowHistory = new System.Windows.Forms.ListView();
            this.colUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colContinueDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAction = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOK = new System.Windows.Forms.Button();
            this.grpbFolderName.SuspendLayout();
            this.grpbUserHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpbFolderName
            // 
            this.grpbFolderName.Controls.Add(this.tbxFolderName);
            this.grpbFolderName.Location = new System.Drawing.Point(13, 13);
            this.grpbFolderName.Name = "grpbFolderName";
            this.grpbFolderName.Size = new System.Drawing.Size(565, 50);
            this.grpbFolderName.TabIndex = 0;
            this.grpbFolderName.TabStop = false;
            this.grpbFolderName.Text = "Mappenname";
            // 
            // tbxFolderName
            // 
            this.tbxFolderName.Enabled = false;
            this.tbxFolderName.Location = new System.Drawing.Point(7, 20);
            this.tbxFolderName.Name = "tbxFolderName";
            this.tbxFolderName.Size = new System.Drawing.Size(545, 20);
            this.tbxFolderName.TabIndex = 0;
            // 
            // grpbUserHistory
            // 
            this.grpbUserHistory.Controls.Add(this.lstvShowHistory);
            this.grpbUserHistory.Location = new System.Drawing.Point(12, 69);
            this.grpbUserHistory.Name = "grpbUserHistory";
            this.grpbUserHistory.Size = new System.Drawing.Size(566, 176);
            this.grpbUserHistory.TabIndex = 1;
            this.grpbUserHistory.TabStop = false;
            this.grpbUserHistory.Text = "Bearbeitungsgeschichte";
            // 
            // lstvShowHistory
            // 
            this.lstvShowHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colUser,
            this.colContinueDate,
            this.colAction,
            this.colStatus});
            this.lstvShowHistory.FullRowSelect = true;
            this.lstvShowHistory.GridLines = true;
            this.lstvShowHistory.Location = new System.Drawing.Point(8, 19);
            this.lstvShowHistory.Name = "lstvShowHistory";
            this.lstvShowHistory.Size = new System.Drawing.Size(545, 147);
            this.lstvShowHistory.TabIndex = 0;
            this.lstvShowHistory.UseCompatibleStateImageBehavior = false;
            this.lstvShowHistory.View = System.Windows.Forms.View.Details;
            // 
            // colUser
            // 
            this.colUser.Text = "Bearbeiter";
            this.colUser.Width = 120;
            // 
            // colContinueDate
            // 
            this.colContinueDate.Text = "Weitergereicht am";
            this.colContinueDate.Width = 120;
            // 
            // colAction
            // 
            this.colAction.Text = "Aktion";
            this.colAction.Width = 210;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 90;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(13, 251);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(565, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmShowFolderHistory
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 283);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grpbUserHistory);
            this.Controls.Add(this.grpbFolderName);
            this.Name = "frmShowFolderHistory";
            this.Text = "Mappengeschichte ";
            this.grpbFolderName.ResumeLayout(false);
            this.grpbFolderName.PerformLayout();
            this.grpbUserHistory.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpbFolderName;
        private System.Windows.Forms.TextBox tbxFolderName;
        private System.Windows.Forms.GroupBox grpbUserHistory;
        private System.Windows.Forms.ListView lstvShowHistory;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ColumnHeader colUser;
        private System.Windows.Forms.ColumnHeader colContinueDate;
        private System.Windows.Forms.ColumnHeader colAction;
        private System.Windows.Forms.ColumnHeader colStatus;
    }
}