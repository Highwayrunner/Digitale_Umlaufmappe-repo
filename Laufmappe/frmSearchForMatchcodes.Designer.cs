namespace Laufmappe
{
    partial class frmSearchForMatchcodes
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.grpbSearch = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lstbSearchMatchcodes = new System.Windows.Forms.ListBox();
            this.rdbDocument = new System.Windows.Forms.RadioButton();
            this.rdbFolder = new System.Windows.Forms.RadioButton();
            this.grpbMatchcodes = new System.Windows.Forms.GroupBox();
            this.btnAddMatchcodeToSearch = new System.Windows.Forms.Button();
            this.lstbMatchcodes = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxMatchcodeContainer = new System.Windows.Forms.ComboBox();
            this.grpbSearch.SuspendLayout();
            this.grpbMatchcodes.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSearch.Location = new System.Drawing.Point(9, 342);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Suchen";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(216, 342);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Abbrechen";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // grpbSearch
            // 
            this.grpbSearch.Controls.Add(this.btnDelete);
            this.grpbSearch.Controls.Add(this.lstbSearchMatchcodes);
            this.grpbSearch.Controls.Add(this.rdbDocument);
            this.grpbSearch.Controls.Add(this.rdbFolder);
            this.grpbSearch.Location = new System.Drawing.Point(12, 5);
            this.grpbSearch.Name = "grpbSearch";
            this.grpbSearch.Size = new System.Drawing.Size(282, 154);
            this.grpbSearch.TabIndex = 2;
            this.grpbSearch.TabStop = false;
            this.grpbSearch.Text = "Suche";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(199, 75);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Löschen";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lstbSearchMatchcodes
            // 
            this.lstbSearchMatchcodes.FormattingEnabled = true;
            this.lstbSearchMatchcodes.Location = new System.Drawing.Point(9, 19);
            this.lstbSearchMatchcodes.Name = "lstbSearchMatchcodes";
            this.lstbSearchMatchcodes.Size = new System.Drawing.Size(176, 121);
            this.lstbSearchMatchcodes.TabIndex = 7;
            this.lstbSearchMatchcodes.DoubleClick += new System.EventHandler(this.btnDelete_Click);
            // 
            // rdbDocument
            // 
            this.rdbDocument.AutoSize = true;
            this.rdbDocument.Location = new System.Drawing.Point(200, 42);
            this.rdbDocument.Name = "rdbDocument";
            this.rdbDocument.Size = new System.Drawing.Size(74, 17);
            this.rdbDocument.TabIndex = 4;
            this.rdbDocument.Text = "Dokument";
            this.rdbDocument.UseVisualStyleBackColor = true;
            // 
            // rdbFolder
            // 
            this.rdbFolder.AutoSize = true;
            this.rdbFolder.Checked = true;
            this.rdbFolder.Location = new System.Drawing.Point(200, 19);
            this.rdbFolder.Name = "rdbFolder";
            this.rdbFolder.Size = new System.Drawing.Size(57, 17);
            this.rdbFolder.TabIndex = 3;
            this.rdbFolder.TabStop = true;
            this.rdbFolder.Text = "Ordner";
            this.rdbFolder.UseVisualStyleBackColor = true;
            // 
            // grpbMatchcodes
            // 
            this.grpbMatchcodes.Controls.Add(this.btnAddMatchcodeToSearch);
            this.grpbMatchcodes.Controls.Add(this.lstbMatchcodes);
            this.grpbMatchcodes.Controls.Add(this.label2);
            this.grpbMatchcodes.Controls.Add(this.cbxMatchcodeContainer);
            this.grpbMatchcodes.Location = new System.Drawing.Point(12, 165);
            this.grpbMatchcodes.Name = "grpbMatchcodes";
            this.grpbMatchcodes.Size = new System.Drawing.Size(282, 171);
            this.grpbMatchcodes.TabIndex = 3;
            this.grpbMatchcodes.TabStop = false;
            this.grpbMatchcodes.Text = "Matchcodes";
            // 
            // btnAddMatchcodeToSearch
            // 
            this.btnAddMatchcodeToSearch.Location = new System.Drawing.Point(199, 46);
            this.btnAddMatchcodeToSearch.Name = "btnAddMatchcodeToSearch";
            this.btnAddMatchcodeToSearch.Size = new System.Drawing.Size(75, 23);
            this.btnAddMatchcodeToSearch.TabIndex = 3;
            this.btnAddMatchcodeToSearch.Text = "Hinzufügen";
            this.btnAddMatchcodeToSearch.UseVisualStyleBackColor = true;
            this.btnAddMatchcodeToSearch.Click += new System.EventHandler(this.btnAddMatchcodeToSearch_Click);
            // 
            // lstbMatchcodes
            // 
            this.lstbMatchcodes.FormattingEnabled = true;
            this.lstbMatchcodes.Location = new System.Drawing.Point(9, 46);
            this.lstbMatchcodes.Name = "lstbMatchcodes";
            this.lstbMatchcodes.Size = new System.Drawing.Size(176, 121);
            this.lstbMatchcodes.TabIndex = 2;
            this.lstbMatchcodes.DoubleClick += new System.EventHandler(this.btnAddMatchcodeToSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Matchcode Container:";
            // 
            // cbxMatchcodeContainer
            // 
            this.cbxMatchcodeContainer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMatchcodeContainer.FormattingEnabled = true;
            this.cbxMatchcodeContainer.Location = new System.Drawing.Point(124, 19);
            this.cbxMatchcodeContainer.Name = "cbxMatchcodeContainer";
            this.cbxMatchcodeContainer.Size = new System.Drawing.Size(121, 21);
            this.cbxMatchcodeContainer.TabIndex = 0;
            this.cbxMatchcodeContainer.SelectedIndexChanged += new System.EventHandler(this.cbxMatchcodeContainer_SelectedIndexChanged);
            // 
            // frmSearchForMatchcodes
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(305, 371);
            this.Controls.Add(this.grpbMatchcodes);
            this.Controls.Add(this.grpbSearch);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmSearchForMatchcodes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Matchcodes suchen";
            this.grpbSearch.ResumeLayout(false);
            this.grpbSearch.PerformLayout();
            this.grpbMatchcodes.ResumeLayout(false);
            this.grpbMatchcodes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox grpbSearch;
        private System.Windows.Forms.RadioButton rdbFolder;
        private System.Windows.Forms.RadioButton rdbDocument;
        private System.Windows.Forms.GroupBox grpbMatchcodes;
        private System.Windows.Forms.ListBox lstbSearchMatchcodes;
        private System.Windows.Forms.ListBox lstbMatchcodes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxMatchcodeContainer;
        private System.Windows.Forms.Button btnAddMatchcodeToSearch;
        private System.Windows.Forms.Button btnDelete;
    }
}