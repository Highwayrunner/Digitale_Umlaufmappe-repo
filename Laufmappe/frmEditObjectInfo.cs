﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laufmappe
{
    public partial class frmEditObjectInfo : Form
    {
        string m_strObjectName = "";

        int m_nDocumentID = -1;

        /*************************************************************************************************************
        -----------------------------------Zum-initialisieren-der-Form------------------------------------------------
        **************************************************************************************************************/
        public frmEditObjectInfo(string strObjectName, int nDocumentID)
        {
            InitializeComponent();

            this.tbxFolderName.Text = strObjectName;    //Zeigt den derzeitigen Ordnernamen an
            m_nDocumentID = nDocumentID;                //Speichert sich die Dokument-ID
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        ----------------Speichert-sich-den-Objektnamen-und-den dazugehörigen-Dokumentpfad,-wenn vorhanden-------------
        **************************************************************************************************************/
        private void btnSave_Click(object sender, EventArgs e)
        {
            m_strObjectName = this.tbxFolderName.Text;

            if(m_strObjectName == "")
            {
                this.DialogResult = DialogResult.None;
                MessageBox.Show("Bitte geben Sie einen Namen ein.", "Warnung");
            }

        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        -----------------------------------------Gibt-den-Objektnamen-zurück------------------------------------------
        **************************************************************************************************************/
        public string GetNewObjectName()
        {
            return m_strObjectName;
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/
    }
}