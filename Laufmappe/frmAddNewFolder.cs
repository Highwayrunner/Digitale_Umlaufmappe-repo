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
    
    public partial class frmAddNewFolder : Form
    {
        private string m_strFolderName = "";


        /*************************************************************************************************************
        -----------------------------------------Initialisierung-der-Form---------------------------------------------
        **************************************************************************************************************/
        public frmAddNewFolder()
        {
            InitializeComponent();
            this.tbxFolderName.Focus();
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        -----------------------------------------Speichert-den-Dialognamen--------------------------------------------
        **************************************************************************************************************/
        private void btnOK_Click(object sender, EventArgs e)
        {
            m_strFolderName = this.tbxFolderName.Text;
            
            if(m_strFolderName == "")
            {
                this.DialogResult = DialogResult.None;
                MessageBox.Show("Sie müssen einen Namen eintragen.", "Achtung");
            }

        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        ----------------------------------------Gibt-den-Ordnernamen-zurück-------------------------------------------
        **************************************************************************************************************/
        public string GetFolderName()
        {
            return m_strFolderName;
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/
    }
}