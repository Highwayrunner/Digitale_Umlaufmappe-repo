namespace Laufmappe
{
    partial class frmAssignMatchcode
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
            this.grpbMatchcodes = new System.Windows.Forms.GroupBox();
            this.grpUsedMatchcodes = new System.Windows.Forms.GroupBox();
            this.lstvUsedMatchcodes = new System.Windows.Forms.ListView();
            this.colMatchcode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMatchcodeContainer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnDeleteLink = new System.Windows.Forms.Button();
            this.grpbAllMatchcodes = new System.Windows.Forms.GroupBox();
            this.btnAddLink = new System.Windows.Forms.Button();
            this.lstbAllMatchcodes = new System.Windows.Forms.ListBox();
            this.cbxAllMatchcodes = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbxObjectName = new System.Windows.Forms.TextBox();
            this.grpbMatchcodes.SuspendLayout();
            this.grpUsedMatchcodes.SuspendLayout();
            this.grpbAllMatchcodes.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpbMatchcodes
            // 
            this.grpbMatchcodes.Controls.Add(this.grpUsedMatchcodes);
            this.grpbMatchcodes.Controls.Add(this.grpbAllMatchcodes);
            this.grpbMatchcodes.Location = new System.Drawing.Point(12, 64);
            this.grpbMatchcodes.Name = "grpbMatchcodes";
            this.grpbMatchcodes.Size = new System.Drawing.Size(463, 260);
            this.grpbMatchcodes.TabIndex = 0;
            this.grpbMatchcodes.TabStop = false;
            this.grpbMatchcodes.Text = "Matchcodes";
            // 
            // grpUsedMatchcodes
            // 
            this.grpUsedMatchcodes.Controls.Add(this.lstvUsedMatchcodes);
            this.grpUsedMatchcodes.Controls.Add(this.btnDeleteLink);
            this.grpUsedMatchcodes.Location = new System.Drawing.Point(223, 19);
            this.grpUsedMatchcodes.Name = "grpUsedMatchcodes";
            this.grpUsedMatchcodes.Size = new System.Drawing.Size(234, 232);
            this.grpUsedMatchcodes.TabIndex = 0;
            this.grpUsedMatchcodes.TabStop = false;
            this.grpUsedMatchcodes.Text = "Verwendete Matchcodes";
            // 
            // lstvUsedMatchcodes
            // 
            this.lstvUsedMatchcodes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMatchcode,
            this.colMatchcodeContainer});
            this.lstvUsedMatchcodes.FullRowSelect = true;
            this.lstvUsedMatchcodes.GridLines = true;
            this.lstvUsedMatchcodes.Location = new System.Drawing.Point(7, 27);
            this.lstvUsedMatchcodes.Name = "lstvUsedMatchcodes";
            this.lstvUsedMatchcodes.Size = new System.Drawing.Size(221, 160);
            this.lstvUsedMatchcodes.TabIndex = 3;
            this.lstvUsedMatchcodes.UseCompatibleStateImageBehavior = false;
            this.lstvUsedMatchcodes.View = System.Windows.Forms.View.Details;
            this.lstvUsedMatchcodes.DoubleClick += new System.EventHandler(this.btnDeleteLink_Click);
            // 
            // colMatchcode
            // 
            this.colMatchcode.Text = "Matchcode";
            this.colMatchcode.Width = 80;
            // 
            // colMatchcodeContainer
            // 
            this.colMatchcodeContainer.Text = "Container";
            this.colMatchcodeContainer.Width = 135;
            // 
            // btnDeleteLink
            // 
            this.btnDeleteLink.Location = new System.Drawing.Point(7, 194);
            this.btnDeleteLink.Name = "btnDeleteLink";
            this.btnDeleteLink.Size = new System.Drawing.Size(221, 23);
            this.btnDeleteLink.TabIndex = 2;
            this.btnDeleteLink.Text = "Verknüpfung löschen";
            this.btnDeleteLink.UseVisualStyleBackColor = true;
            this.btnDeleteLink.Click += new System.EventHandler(this.btnDeleteLink_Click);
            // 
            // grpbAllMatchcodes
            // 
            this.grpbAllMatchcodes.Controls.Add(this.btnAddLink);
            this.grpbAllMatchcodes.Controls.Add(this.lstbAllMatchcodes);
            this.grpbAllMatchcodes.Controls.Add(this.cbxAllMatchcodes);
            this.grpbAllMatchcodes.Location = new System.Drawing.Point(6, 19);
            this.grpbAllMatchcodes.Name = "grpbAllMatchcodes";
            this.grpbAllMatchcodes.Size = new System.Drawing.Size(200, 232);
            this.grpbAllMatchcodes.TabIndex = 1;
            this.grpbAllMatchcodes.TabStop = false;
            this.grpbAllMatchcodes.Text = "Alle Matchcodes";
            // 
            // btnAddLink
            // 
            this.btnAddLink.Location = new System.Drawing.Point(7, 194);
            this.btnAddLink.Name = "btnAddLink";
            this.btnAddLink.Size = new System.Drawing.Size(187, 23);
            this.btnAddLink.TabIndex = 2;
            this.btnAddLink.Text = "Verknüpfung hinzufügen";
            this.btnAddLink.UseVisualStyleBackColor = true;
            this.btnAddLink.Click += new System.EventHandler(this.btnAddLink_Click);
            // 
            // lstbAllMatchcodes
            // 
            this.lstbAllMatchcodes.FormattingEnabled = true;
            this.lstbAllMatchcodes.Location = new System.Drawing.Point(7, 53);
            this.lstbAllMatchcodes.Name = "lstbAllMatchcodes";
            this.lstbAllMatchcodes.Size = new System.Drawing.Size(187, 134);
            this.lstbAllMatchcodes.TabIndex = 1;
            this.lstbAllMatchcodes.DoubleClick += new System.EventHandler(this.btnAddLink_Click);
            // 
            // cbxAllMatchcodes
            // 
            this.cbxAllMatchcodes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAllMatchcodes.FormattingEnabled = true;
            this.cbxAllMatchcodes.Location = new System.Drawing.Point(7, 20);
            this.cbxAllMatchcodes.Name = "cbxAllMatchcodes";
            this.cbxAllMatchcodes.Size = new System.Drawing.Size(187, 21);
            this.cbxAllMatchcodes.TabIndex = 0;
            this.cbxAllMatchcodes.SelectedIndexChanged += new System.EventHandler(this.cbxAllMatchcodes_SelectedIndexChanged);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(12, 331);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(463, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbxObjectName);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(463, 45);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Objektname";
            // 
            // tbxObjectName
            // 
            this.tbxObjectName.Enabled = false;
            this.tbxObjectName.Location = new System.Drawing.Point(7, 20);
            this.tbxObjectName.Name = "tbxObjectName";
            this.tbxObjectName.Size = new System.Drawing.Size(450, 20);
            this.tbxObjectName.TabIndex = 0;
            // 
            // frmAssignMatchcode
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 359);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grpbMatchcodes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmAssignMatchcode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Matchcodes hinzufügen/löschen";
            this.grpbMatchcodes.ResumeLayout(false);
            this.grpUsedMatchcodes.ResumeLayout(false);
            this.grpbAllMatchcodes.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpbMatchcodes;
        private System.Windows.Forms.GroupBox grpUsedMatchcodes;
        private System.Windows.Forms.Button btnDeleteLink;
        private System.Windows.Forms.GroupBox grpbAllMatchcodes;
        private System.Windows.Forms.Button btnAddLink;
        private System.Windows.Forms.ListBox lstbAllMatchcodes;
        private System.Windows.Forms.ComboBox cbxAllMatchcodes;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbxObjectName;
        private System.Windows.Forms.ListView lstvUsedMatchcodes;
        private System.Windows.Forms.ColumnHeader colMatchcode;
        private System.Windows.Forms.ColumnHeader colMatchcodeContainer;
    }
}