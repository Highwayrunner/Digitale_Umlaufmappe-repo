namespace Laufmappe
{
    partial class frmEditFolderActions
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
            this.grpbExistsingActions = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lstbExistingActions = new System.Windows.Forms.ListBox();
            this.grpbNewAction = new System.Windows.Forms.GroupBox();
            this.btnAddAction = new System.Windows.Forms.Button();
            this.tbxNewAction = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.grpbExistsingActions.SuspendLayout();
            this.grpbNewAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpbExistsingActions
            // 
            this.grpbExistsingActions.Controls.Add(this.btnDelete);
            this.grpbExistsingActions.Controls.Add(this.lstbExistingActions);
            this.grpbExistsingActions.Location = new System.Drawing.Point(12, 12);
            this.grpbExistsingActions.Name = "grpbExistsingActions";
            this.grpbExistsingActions.Size = new System.Drawing.Size(260, 136);
            this.grpbExistsingActions.TabIndex = 1;
            this.grpbExistsingActions.TabStop = false;
            this.grpbExistsingActions.Text = "Vorhandene Aktionen";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(179, 108);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Löschen";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lstbExistingActions
            // 
            this.lstbExistingActions.FormattingEnabled = true;
            this.lstbExistingActions.Location = new System.Drawing.Point(7, 20);
            this.lstbExistingActions.Name = "lstbExistingActions";
            this.lstbExistingActions.Size = new System.Drawing.Size(247, 82);
            this.lstbExistingActions.TabIndex = 0;
            this.lstbExistingActions.DoubleClick += new System.EventHandler(this.btnDelete_Click);
            // 
            // grpbNewAction
            // 
            this.grpbNewAction.Controls.Add(this.btnAddAction);
            this.grpbNewAction.Controls.Add(this.tbxNewAction);
            this.grpbNewAction.Location = new System.Drawing.Point(12, 154);
            this.grpbNewAction.Name = "grpbNewAction";
            this.grpbNewAction.Size = new System.Drawing.Size(260, 54);
            this.grpbNewAction.TabIndex = 0;
            this.grpbNewAction.TabStop = false;
            this.grpbNewAction.Text = "Neue Aktion";
            // 
            // btnAddAction
            // 
            this.btnAddAction.Location = new System.Drawing.Point(179, 20);
            this.btnAddAction.Name = "btnAddAction";
            this.btnAddAction.Size = new System.Drawing.Size(75, 23);
            this.btnAddAction.TabIndex = 1;
            this.btnAddAction.Text = "Hinzufügen";
            this.btnAddAction.UseVisualStyleBackColor = true;
            this.btnAddAction.Click += new System.EventHandler(this.btnAddAction_Click);
            // 
            // tbxNewAction
            // 
            this.tbxNewAction.Location = new System.Drawing.Point(7, 20);
            this.tbxNewAction.Name = "tbxNewAction";
            this.tbxNewAction.Size = new System.Drawing.Size(166, 20);
            this.tbxNewAction.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(12, 219);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Speichern";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(197, 219);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Abbrechen";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // frmEditFolderActions
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(284, 254);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpbNewAction);
            this.Controls.Add(this.grpbExistsingActions);
            this.Name = "frmEditFolderActions";
            this.Text = "Aktionen hinzufügen";
            this.grpbExistsingActions.ResumeLayout(false);
            this.grpbNewAction.ResumeLayout(false);
            this.grpbNewAction.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpbExistsingActions;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ListBox lstbExistingActions;
        private System.Windows.Forms.GroupBox grpbNewAction;
        private System.Windows.Forms.Button btnAddAction;
        private System.Windows.Forms.TextBox tbxNewAction;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
    }
}