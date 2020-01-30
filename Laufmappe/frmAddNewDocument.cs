using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
namespace Laufmappe
{
    public partial class frmAddNewDocument : Form
    {
        private string m_strDocumentName = "";      //Dokumentname
        private string m_strDocumentPath= "";       //Dokumentpfad
        private List<string> m_strDocumentList = new List<string>();    //Dokumentpfadliste


        /*************************************************************************************************************
        -----------------------------------Beim-Initialisieren-der-Form-----------------------------------------------
        **************************************************************************************************************/
        public frmAddNewDocument(string strFolderName)
        {
            InitializeComponent();
            this.lbxMultipleDocuments.Enabled = false;      //Deaktiviert die ListBox für mehrere Dokumente 
            this.grpbMultibleDocuments.Enabled = false;     //Deaktiviert die Groupbox für mehrere Dokumente
            this.tbxFolderName.Text = strFolderName;
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        ---------------------------Wenn-ein-einzelnes-Dokument-geladen-werden-soll------------------------------------
        **************************************************************************************************************/
        private void btnLoadDocument_Click(object sender, EventArgs e)
        {
            OpenFileDialog LoadDocument = new OpenFileDialog();
            LoadDocument.Title = "Bitte Dokument auswählen";
            LoadDocument.Multiselect = false;
            DialogResult DR = LoadDocument.ShowDialog();
            
            string strDocumentPath = "";
            string strDocumentName = "";

            if (DR == DialogResult.OK)
            {
                //Dokumentpfad in Textbox eintragen
                strDocumentPath = LoadDocument.FileName;
                this.tbxDocumentPath.Text = strDocumentPath;

                //Wenn kein Dokumentname eingetragen wurde
                if (this.tbxDocumentName.Text == "")
                {
                    strDocumentName = Path.GetFileName(strDocumentPath);    //Gibt den Dokumentnamen wie er im Filesystem steht zurück
                    this.tbxDocumentName.Text = strDocumentName;
                }
            }

        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        --------------------------------------Schaltet-die-Group-Boxes-um---------------------------------------------
        **************************************************************************************************************/
        private void rdbSingleDocument_CheckedChanged(object sender, EventArgs e)
        {
            //Wenn ein einzelnes Dokument ausgewählt werden soll
            if(this.rdbSingleDocument.Checked)
            {
                this.grpbMultibleDocuments.Enabled = false;
                this.grpbSingleDocument.Enabled = true;
            }
            else if(this.rdbMultibleDocuments.Checked)      //Wenn mehrere Dokumente ausgewählt werden sollen
            {
                this.grpbSingleDocument.Enabled = false;
                this.grpbMultibleDocuments.Enabled = true;
            }

        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        -----------------------------Speichert-alle-ausgewählten-Dateien-in-einem-Array-------------------------------
        **************************************************************************************************************/
        private void btnLoadDocuments_Click(object sender, EventArgs e)
        {
            OpenFileDialog LoadDocument = new OpenFileDialog();
            LoadDocument.Title = "Bitte Dokumente auswählen";
            LoadDocument.Multiselect = true;
            DialogResult DR = LoadDocument.ShowDialog();

            string[] strDocumentList;
            if (DR == DialogResult.OK)
            {
                strDocumentList = LoadDocument.FileNames;               //Speichert sich die Liste mit allen Dokumenten, die ausgewählt wurden
                lbxMultipleDocuments.Items.AddRange(strDocumentList);   //Trägt sie in die Listbox ein
            }
            
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        -------------------------Funktion-zum-Speichern-der-ausgewählten-Dateien--------------------------------------
        **************************************************************************************************************/
        private void btnSave_Click(object sender, EventArgs e)
        {
            //Wenn nur ein einzelnes Dokument ausgewählt wurde
            if (this.rdbSingleDocument.Checked)
            {
                m_strDocumentName = this.tbxDocumentName.Text;  
                m_strDocumentPath = this.tbxDocumentPath.Text;

                //Wenn kein Dokumentname vorhanden ist
                if (m_strDocumentName == "")
                {
                    this.DialogResult = DialogResult.None;
                    MessageBox.Show("Kein Dokumentname eingegeben.", "Dokumentname");
                    return;
                }
                
                //Wenn kein Dokumentpfad vorhanden ist
                if(m_strDocumentPath == "")
                {
                    this.DialogResult = DialogResult.None;
                    MessageBox.Show("Kein Dokumentpfad eingegeben.", "Dokumentpfad");
                    return;
                }
            }
            else if (this.rdbMultibleDocuments.Checked)     //Wenn mehrere Dokumente abgespeichert werden sollen
            {
                int i = 0;
                string strDocument = "";

                //Geht die gesamte Listbox durch
                for (i = 0; i < lbxMultipleDocuments.Items.Count; i++)
                {
                    //Speichert sich die Dateien aus der Listbox in m_strDocumentList
                    strDocument = lbxMultipleDocuments.Items[i].ToString();
                    m_strDocumentList.Add(strDocument);
                }

                //Wenn keine Dateien gefunden wurden
                if (lbxMultipleDocuments.Items.Count == 0)
                {
                    this.DialogResult = DialogResult.None;
                    MessageBox.Show("Keine Dokumente ausgewählt.", "Achtung");
                }

            }

        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        --------------------------------------Gibt-die-Dokumentliste-zurück-------------------------------------------
        **************************************************************************************************************/
        public List<string> GetDocumentList()
        {
            return m_strDocumentList;
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        -----------------------------Gibt-die-Daten-einer-einzzelnden-Datei-zurück------------------------------------
        **************************************************************************************************************/
        public void GetSingleDocument(ref string strDocumentName, ref string strDocumentPath)
        { 
            strDocumentName = m_strDocumentName;
            strDocumentPath = m_strDocumentPath;
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        ---------------------Gibt-zurück,-ob-ein-einzelnes-Dokuemt-ausgewählt-wurde-oder-mehrere----------------------
        **************************************************************************************************************/
        public bool ReturnSingleDocument()
        {
            return this.rdbSingleDocument.Checked;
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        -------------------------------Löscht-alle-Einträge-aus-der-Listbox-------------------------------------------
        **************************************************************************************************************/
        private void btnDeleteAllItems_Click(object sender, EventArgs e)
        {
            lbxMultipleDocuments.Items.Clear();
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/
    }
}
