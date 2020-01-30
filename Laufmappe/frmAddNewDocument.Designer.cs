namespace Laufmappe
{
    partial class frmAddNewDocument
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxDocumentName = new System.Windows.Forms.TextBox();
            this.tbxDocumentPath = new System.Windows.Forms.TextBox();
            this.btnLoadDocument = new System.Windows.Forms.Button();
            this.grpbSingleDocument = new System.Windows.Forms.GroupBox();
            this.grpbMultibleDocuments = new System.Windows.Forms.GroupBox();
            this.btnDeleteAllItems = new System.Windows.Forms.Button();
            this.btnLoadDocuments = new System.Windows.Forms.Button();
            this.lbxMultipleDocuments = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdbMultibleDocuments = new System.Windows.Forms.RadioButton();
            this.rdbSingleDocument = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbxFolderName = new System.Windows.Forms.TextBox();
            this.grpbSingleDocument.SuspendLayout();
            this.grpbMultibleDocuments.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(279, 489);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Abbrechen";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(13, 489);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Speichern";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Dokumentname:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Dokumentpfad:";
            // 
            // tbxDocumentName
            // 
            this.tbxDocumentName.Location = new System.Drawing.Point(105, 25);
            this.tbxDocumentName.Name = "tbxDocumentName";
            this.tbxDocumentName.Size = new System.Drawing.Size(201, 20);
            this.tbxDocumentName.TabIndex = 4;
            // 
            // tbxDocumentPath
            // 
            this.tbxDocumentPath.Location = new System.Drawing.Point(105, 52);
            this.tbxDocumentPath.Name = "tbxDocumentPath";
            this.tbxDocumentPath.Size = new System.Drawing.Size(201, 20);
            this.tbxDocumentPath.TabIndex = 5;
            // 
            // btnLoadDocument
            // 
            this.btnLoadDocument.Location = new System.Drawing.Point(312, 50);
            this.btnLoadDocument.Name = "btnLoadDocument";
            this.btnLoadDocument.Size = new System.Drawing.Size(30, 23);
            this.btnLoadDocument.TabIndex = 6;
            this.btnLoadDocument.Text = "...";
            this.btnLoadDocument.UseVisualStyleBackColor = true;
            this.btnLoadDocument.Click += new System.EventHandler(this.btnLoadDocument_Click);
            // 
            // grpbSingleDocument
            // 
            this.grpbSingleDocument.Controls.Add(this.btnLoadDocument);
            this.grpbSingleDocument.Controls.Add(this.label1);
            this.grpbSingleDocument.Controls.Add(this.tbxDocumentPath);
            this.grpbSingleDocument.Controls.Add(this.label2);
            this.grpbSingleDocument.Controls.Add(this.tbxDocumentName);
            this.grpbSingleDocument.Location = new System.Drawing.Point(12, 60);
            this.grpbSingleDocument.Name = "grpbSingleDocument";
            this.grpbSingleDocument.Size = new System.Drawing.Size(348, 94);
            this.grpbSingleDocument.TabIndex = 7;
            this.grpbSingleDocument.TabStop = false;
            this.grpbSingleDocument.Text = "Einzelnes Dokument";
            // 
            // grpbMultibleDocuments
            // 
            this.grpbMultibleDocuments.Controls.Add(this.btnDeleteAllItems);
            this.grpbMultibleDocuments.Controls.Add(this.btnLoadDocuments);
            this.grpbMultibleDocuments.Controls.Add(this.lbxMultipleDocuments);
            this.grpbMultibleDocuments.Location = new System.Drawing.Point(13, 160);
            this.grpbMultibleDocuments.Name = "grpbMultibleDocuments";
            this.grpbMultibleDocuments.Size = new System.Drawing.Size(347, 264);
            this.grpbMultibleDocuments.TabIndex = 8;
            this.grpbMultibleDocuments.TabStop = false;
            this.grpbMultibleDocuments.Text = "Mehrere Dokumente";
            // 
            // btnDeleteAllItems
            // 
            this.btnDeleteAllItems.Location = new System.Drawing.Point(7, 228);
            this.btnDeleteAllItems.Name = "btnDeleteAllItems";
            this.btnDeleteAllItems.Size = new System.Drawing.Size(328, 23);
            this.btnDeleteAllItems.TabIndex = 2;
            this.btnDeleteAllItems.Text = "Dokumente in der Liste löschen";
            this.btnDeleteAllItems.UseVisualStyleBackColor = true;
            this.btnDeleteAllItems.Click += new System.EventHandler(this.btnDeleteAllItems_Click);
            // 
            // btnLoadDocuments
            // 
            this.btnLoadDocuments.Location = new System.Drawing.Point(7, 199);
            this.btnLoadDocuments.Name = "btnLoadDocuments";
            this.btnLoadDocuments.Size = new System.Drawing.Size(328, 23);
            this.btnLoadDocuments.TabIndex = 1;
            this.btnLoadDocuments.Text = "Dokumente hinzufügen";
            this.btnLoadDocuments.UseVisualStyleBackColor = true;
            this.btnLoadDocuments.Click += new System.EventHandler(this.btnLoadDocuments_Click);
            // 
            // lbxMultipleDocuments
            // 
            this.lbxMultipleDocuments.FormattingEnabled = true;
            this.lbxMultipleDocuments.Location = new System.Drawing.Point(7, 20);
            this.lbxMultipleDocuments.Name = "lbxMultipleDocuments";
            this.lbxMultipleDocuments.Size = new System.Drawing.Size(328, 173);
            this.lbxMultipleDocuments.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdbMultibleDocuments);
            this.groupBox3.Controls.Add(this.rdbSingleDocument);
            this.groupBox3.Location = new System.Drawing.Point(13, 430);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(347, 53);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Hinzufügen";
            // 
            // rdbMultibleDocuments
            // 
            this.rdbMultibleDocuments.AutoSize = true;
            this.rdbMultibleDocuments.Location = new System.Drawing.Point(213, 20);
            this.rdbMultibleDocuments.Name = "rdbMultibleDocuments";
            this.rdbMultibleDocuments.Size = new System.Drawing.Size(122, 17);
            this.rdbMultibleDocuments.TabIndex = 1;
            this.rdbMultibleDocuments.Text = "Mehrere Dokumente";
            this.rdbMultibleDocuments.UseVisualStyleBackColor = true;
            this.rdbMultibleDocuments.CheckedChanged += new System.EventHandler(this.rdbSingleDocument_CheckedChanged);
            // 
            // rdbSingleDocument
            // 
            this.rdbSingleDocument.AutoSize = true;
            this.rdbSingleDocument.Checked = true;
            this.rdbSingleDocument.Location = new System.Drawing.Point(21, 20);
            this.rdbSingleDocument.Name = "rdbSingleDocument";
            this.rdbSingleDocument.Size = new System.Drawing.Size(122, 17);
            this.rdbSingleDocument.TabIndex = 0;
            this.rdbSingleDocument.TabStop = true;
            this.rdbSingleDocument.Text = "Einzelnes Dokument";
            this.rdbSingleDocument.UseVisualStyleBackColor = true;
            this.rdbSingleDocument.CheckedChanged += new System.EventHandler(this.rdbSingleDocument_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tbxFolderName);
            this.groupBox4.Location = new System.Drawing.Point(12, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(348, 48);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Mappenname";
            // 
            // tbxFolderName
            // 
            this.tbxFolderName.Enabled = false;
            this.tbxFolderName.Location = new System.Drawing.Point(8, 20);
            this.tbxFolderName.Name = "tbxFolderName";
            this.tbxFolderName.Size = new System.Drawing.Size(334, 20);
            this.tbxFolderName.TabIndex = 0;
            // 
            // frmAddNewDocument
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(369, 522);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grpbMultibleDocuments);
            this.Controls.Add(this.grpbSingleDocument);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmAddNewDocument";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Neues Dokument hinzufügen";
            this.grpbSingleDocument.ResumeLayout(false);
            this.grpbSingleDocument.PerformLayout();
            this.grpbMultibleDocuments.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxDocumentName;
        private System.Windows.Forms.TextBox tbxDocumentPath;
        private System.Windows.Forms.Button btnLoadDocument;
        private System.Windows.Forms.GroupBox grpbSingleDocument;
        private System.Windows.Forms.GroupBox grpbMultibleDocuments;
        private System.Windows.Forms.ListBox lbxMultipleDocuments;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdbMultibleDocuments;
        private System.Windows.Forms.RadioButton rdbSingleDocument;
        private System.Windows.Forms.Button btnLoadDocuments;
        private System.Windows.Forms.Button btnDeleteAllItems;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tbxFolderName;
    }
}