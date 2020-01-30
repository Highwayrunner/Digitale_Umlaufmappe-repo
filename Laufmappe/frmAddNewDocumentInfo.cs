using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace Laufmappe
{
    public partial class frmAddNewDocumentInfo : Form
    {
        private string m_strText;               //Speichert sich die eingebene Documentinformation
        private string m_strInformationName;    //Speichert sich den eingegebenen Documentinformationsnamen

        private CSqlHelper SqlHelper = new CSqlHelper();    //Sql-Hilfsklasse



        /*************************************************************************************************************
        --------------------------------------Initialisierung-des-Dialogs---------------------------------------------
        **************************************************************************************************************/
        public frmAddNewDocumentInfo()
        {
            InitializeComponent();
            this.tbxInformationName.Focus();
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        -------------------------------Gibt-den-eingegebenen-Informationstext-zurück----------------------------------
        **************************************************************************************************************/
        public string GetDocumentInfo()
        {
            return m_strText;
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        ´----------------------------------Gibt-den-Informationsnamen-zurück------------------------------------------
        **************************************************************************************************************/
        public string GetInformationName()
        {
            return m_strInformationName;
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        ----------------------------------Funktion-zum-Speichern-der-Dokumentdaten------------------------------------
        **************************************************************************************************************/
        private void btnSave_Click(object sender, EventArgs e)
        {
            m_strText = this.tbxDocumentInfo.Text;
            m_strInformationName = this.tbxInformationName.Text;

            if (m_strInformationName == "")
            {
                MessageBox.Show("Sie haben keinen Informationsnamen eingetragen.", "Achtung");
                this.DialogResult = DialogResult.None;
                return;
            }

        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/









        /*************************************************************************************************************
        -----------------------------------Lädt-den-Informationstext-aus-der-Datenbank--------------------------------
        **************************************************************************************************************/
        public void LoadTextFromDb(int nDocumentID)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = (SqlHelper.GetSqlConnectionString());

            string strSQL = "select idDokumentinformation, Dokumentinformationsname, Dokumentinformation From Dokumentinformation Where idDokumentinformation = @nDocumentID";

            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@nDocumentID", nDocumentID);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            string strDocumentName = "";
            while (reader.Read())
            {
                strDocumentName = reader["Dokumentinformationsname"].ToString();

                if(strDocumentName != "")
                {
                    this.tbxInformationName.Text = strDocumentName;
                    this.tbxDocumentInfo.Text = reader["Dokumentinformation"].ToString();
                }

            }
            
            reader.Close();
            con.Close();
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/
    }
}
