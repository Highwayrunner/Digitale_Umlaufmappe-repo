namespace Laufmappe
{
    partial class frmMatchcodes
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
            this.btnOK = new System.Windows.Forms.Button();
            this.lstbMatchcodes = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDeleteMatchcodeItem = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cbxMatchcode = new System.Windows.Forms.ComboBox();
            this.btnAddMatch = new System.Windows.Forms.Button();
            this.grpbAddMatchcode = new System.Windows.Forms.GroupBox();
            this.btnAddMatchcodeItem = new System.Windows.Forms.Button();
            this.tbxMatchcodeItem = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.grpbAddMatchcode.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(6, 348);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(95, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // lstbMatchcodes
            // 
            this.lstbMatchcodes.FormattingEnabled = true;
            this.lstbMatchcodes.Location = new System.Drawing.Point(13, 30);
            this.lstbMatchcodes.Name = "lstbMatchcodes";
            this.lstbMatchcodes.Size = new System.Drawing.Size(246, 121);
            this.lstbMatchcodes.TabIndex = 2;
            this.lstbMatchcodes.DoubleClick += new System.EventHandler(this.btnDeleteMatchcodeItem_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Controls.Add(this.btnDeleteMatchcodeItem);
            this.groupBox3.Controls.Add(this.lstbMatchcodes);
            this.groupBox3.Location = new System.Drawing.Point(6, 100);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(270, 188);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Vorhandene Matchcodes";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(13, 159);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Speichern";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // btnDeleteMatchcodeItem
            // 
            this.btnDeleteMatchcodeItem.Location = new System.Drawing.Point(165, 159);
            this.btnDeleteMatchcodeItem.Name = "btnDeleteMatchcodeItem";
            this.btnDeleteMatchcodeItem.Size = new System.Drawing.Size(99, 23);
            this.btnDeleteMatchcodeItem.TabIndex = 3;
            this.btnDeleteMatchcodeItem.Text = "Löschen";
            this.btnDeleteMatchcodeItem.UseVisualStyleBackColor = true;
            this.btnDeleteMatchcodeItem.Click += new System.EventHandler(this.btnDeleteMatchcodeItem_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnDelete);
            this.groupBox5.Controls.Add(this.cbxMatchcode);
            this.groupBox5.Controls.Add(this.btnAddMatch);
            this.groupBox5.Location = new System.Drawing.Point(6, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(270, 82);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Matchcode Container";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(165, 53);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(99, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Löschen";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cbxMatchcode
            // 
            this.cbxMatchcode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMatchcode.FormattingEnabled = true;
            this.cbxMatchcode.Location = new System.Drawing.Point(7, 19);
            this.cbxMatchcode.Name = "cbxMatchcode";
            this.cbxMatchcode.Size = new System.Drawing.Size(138, 21);
            this.cbxMatchcode.TabIndex = 5;
            this.cbxMatchcode.SelectedIndexChanged += new System.EventHandler(this.cbxMatchcode_SelectedIndexChanged);
            // 
            // btnAddMatch
            // 
            this.btnAddMatch.Location = new System.Drawing.Point(165, 19);
            this.btnAddMatch.Name = "btnAddMatch";
            this.btnAddMatch.Size = new System.Drawing.Size(99, 23);
            this.btnAddMatch.TabIndex = 2;
            this.btnAddMatch.Text = "Hinzufügen";
            this.btnAddMatch.UseVisualStyleBackColor = true;
            this.btnAddMatch.Click += new System.EventHandler(this.btnAddMatch_Click);
            // 
            // grpbAddMatchcode
            // 
            this.grpbAddMatchcode.Controls.Add(this.btnAddMatchcodeItem);
            this.grpbAddMatchcode.Controls.Add(this.tbxMatchcodeItem);
            this.grpbAddMatchcode.Location = new System.Drawing.Point(6, 294);
            this.grpbAddMatchcode.Name = "grpbAddMatchcode";
            this.grpbAddMatchcode.Size = new System.Drawing.Size(270, 48);
            this.grpbAddMatchcode.TabIndex = 4;
            this.grpbAddMatchcode.TabStop = false;
            this.grpbAddMatchcode.Text = "Matchcode hinzufügen";
            // 
            // btnAddMatchcodeItem
            // 
            this.btnAddMatchcodeItem.Location = new System.Drawing.Point(165, 17);
            this.btnAddMatchcodeItem.Name = "btnAddMatchcodeItem";
            this.btnAddMatchcodeItem.Size = new System.Drawing.Size(99, 23);
            this.btnAddMatchcodeItem.TabIndex = 1;
            this.btnAddMatchcodeItem.Text = "Hinzufügen";
            this.btnAddMatchcodeItem.UseVisualStyleBackColor = true;
            this.btnAddMatchcodeItem.Click += new System.EventHandler(this.btnAddMatchcodeItem_Click);
            // 
            // tbxMatchcodeItem
            // 
            this.tbxMatchcodeItem.Location = new System.Drawing.Point(7, 19);
            this.tbxMatchcodeItem.Name = "tbxMatchcodeItem";
            this.tbxMatchcodeItem.Size = new System.Drawing.Size(135, 20);
            this.tbxMatchcodeItem.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(181, 348);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(95, 23);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Abbrechen";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // frmMatchcodes
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(284, 380);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grpbAddMatchcode);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMatchcodes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Objektmatchcode";
            this.groupBox3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.grpbAddMatchcode.ResumeLayout(false);
            this.grpbAddMatchcode.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ListBox lstbMatchcodes;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnAddMatch;
        private System.Windows.Forms.ComboBox cbxMatchcode;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox grpbAddMatchcode;
        private System.Windows.Forms.Button btnAddMatchcodeItem;
        private System.Windows.Forms.TextBox tbxMatchcodeItem;
        private System.Windows.Forms.Button btnDeleteMatchcodeItem;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;

    }
}