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
    public partial class frmShowDocumentInfo : Form
    {
        private int m_nUserID = -1;         //Benutzer-ID
        private int m_nDocumentID = -1;     //Dokument-ID
        private int m_nRights = -1;         //Benutzerrechte

        
        private CSqlHelper SqlHelper = new CSqlHelper();    //Sql-Hilfklasse




        /*************************************************************************************************************
        -------------------------------------Benutzerdefiniertes-Combobox-Item----------------------------------------
        **************************************************************************************************************/
        public class ComboboxItem
        {
            public string Text { get; set; }    //Text, der angezeigt werden soll
            public int ID { get; set; }         //ID, die gespeichert werden soll

            public override string ToString()
            {
                return Text;
            }
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        -----------------------------------------Initialisiert-die-Form-----------------------------------------------
        **************************************************************************************************************/
        public frmShowDocumentInfo(int nUserID, int nRights, int nDocumentID)
        {
            InitializeComponent();
            m_nUserID = nUserID;
            m_nRights = nRights;

            m_nDocumentID = nDocumentID;
            LoadUser();

        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/



        /*************************************************************************************************************
        -------------------------------Lädt-Informationen-zum-Dokument-aus-der-Datenbank------------------------------
        **************************************************************************************************************/
        public void LoadDocumentInfo(int nUserID, int nDocumentID)
        {
            m_nUserID = nUserID;
            m_nDocumentID = nDocumentID;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = (SqlHelper.GetSqlConnectionString());

            string strSQL = "select idDokument, Dokumentname, Erstelldatum, Aenderungsdatum, Hinzugefuegt_Am From Dokument Where idDokument = @m_nDocumentID";

            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@m_nDocumentID", m_nDocumentID);

            con.Open();


            SqlDataReader reader = cmd.ExecuteReader();
            string strDocumentName;
            

            while (reader.Read())
            {
                strDocumentName = reader["Dokumentname"].ToString();
                
                if(strDocumentName != "")
                {
                    //Speichert sich die DokumentInformationen
                    this.tbxDocumentName.Text = strDocumentName;
                   
                    this.dtpCreateDate.Value = (DateTime)reader["Erstelldatum"];
                    this.dtpChangeDate.Value = (DateTime)reader["Aenderungsdatum"];
                    this.dtpAddDate.Value = (DateTime)reader["Hinzugefuegt_Am"];
                }
            }

            reader.Close();
            con.Close();
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        -------------------------------Lädt-alle-Benutzer-aus-der-Datenbank-------------------------------------------
        **************************************************************************************************************/
        private void LoadUser()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = (SqlHelper.GetSqlConnectionString());

            string strSQL = "select idBenutzer, Benutzername From Benutzer Order By idBenutzer";

            SqlCommand cmd = new SqlCommand(strSQL, con);


            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            string strUsername = "";
            while (reader.Read())
            {
                strUsername = reader["Benutzername"].ToString();
                
                if (strUsername != "")
                {
                    ComboboxItem item = new ComboboxItem();
                    item.Text = strUsername;
                    item.ID = (int)reader["idBenutzer"];

                    this.cbxUser.Items.Add(item);
                }
                
            }
            this.cbxUser.SelectedIndex = 0;
            reader.Close();
            con.Close();
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/



        /*************************************************************************************************************
        -----------------------------------Funktion-zum-Hinzufügen-von-Dateiinformationen-----------------------------
        **************************************************************************************************************/
        private void btnAddInfo_Click(object sender, EventArgs e)
        {
            frmAddNewDocumentInfo NewDocumentInfo = new frmAddNewDocumentInfo();
            NewDocumentInfo.ShowDialog();

            if(NewDocumentInfo.DialogResult != DialogResult.OK)
            {
                return;
            }

            int nMaxInfoID = 0;

            //Übergibt die Informationen aus frmAddNewDocumentInfo an frmShowDocumentInfo
            string strDocumentInfo = NewDocumentInfo.GetDocumentInfo();
            string strDocInfoName = NewDocumentInfo.GetInformationName();

            nMaxInfoID = SqlHelper.GetMaxID("idDokumentinformation", "Dokumentinformation");    //Holt sich die größte ID aus der Tabelle Dokumentinformation
            nMaxInfoID = nMaxInfoID + 1;        //Zählt diese um 1 hoch

            //Holt sich das aktuelle Datum und wandelt es in ein für die Datenbank lsebares Format um
            DateTime today = DateTime.Now;
            string strDateTimeToday = today.ToString("yyyy-dd-MM HH:mm:ss");

            SqlConnection con = new SqlConnection();
            con.ConnectionString = (SqlHelper.GetSqlConnectionString());
            string strSQL = "Insert into Dokumentinformation Values(@nMaxInfoID, @strDocInfoName, @strDocumentInfo, @m_nUserID, @strDateTimeToday, @m_nDocumentID)";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = strSQL;

            cmd.Parameters.AddWithValue("@nMaxInfoID", nMaxInfoID);
            cmd.Parameters.AddWithValue("@strDocInfoName", strDocInfoName);
            cmd.Parameters.AddWithValue("@strDocumentInfo", strDocumentInfo);

            cmd.Parameters.AddWithValue("@m_nUserID", m_nUserID);
            cmd.Parameters.AddWithValue("@strDateTimeToday", strDateTimeToday);
            cmd.Parameters.AddWithValue("@m_nDocumentID", m_nDocumentID);

            cmd.Connection = con;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


            int i = 0;


            for(i = 0; i < this.cbxUser.Items.Count; i++)
            {
                ComboboxItem item = (ComboboxItem)this.cbxUser.Items[i];
                
                if (item.ID == m_nUserID)
                {
                    this.cbxUser.SelectedItem = (ComboboxItem)this.cbxUser.Items[i];
                    LoadDocumentNames();
                    
                    if (this.cbxDocumentInfoNames.Items.Count > 0)
                    {
                        this.cbxDocumentInfoNames.SelectedIndex = this.cbxDocumentInfoNames.Items.Count-1;
                    }

                    break;
                }

            }

            
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        ----------------------------------Wenn-der-Benutzer-gewechselt-wurde------------------------------------------
        **************************************************************************************************************/
        private void cbxUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDocumentNames();
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        --------------------------Zum-laden-der-Dokumentnamen-und-Dokumentinformationen------------------------------
        **************************************************************************************************************/
        private void LoadDocumentNames()
        {
            ComboboxItem UserItem = (ComboboxItem)this.cbxUser.SelectedItem;    //Speichert sich den gerade ausgewählten Benutzer
            ComboboxItem DocumentItem;              //Zum Hinzufügen eines neuen Dokumentinformationsnamens
            cbxDocumentInfoNames.Items.Clear();     //Löscht alle Dokumentinformationsnamen

            SqlConnection con = new SqlConnection();
            con.ConnectionString = (SqlHelper.GetSqlConnectionString());

            string strSQL = "select idDokumentinformation, Dokumentinformationsname, ID_Dokument From Dokumentinformation Where ID_Benutzer = @itemID and ID_Dokument = @m_nDocumentID Order by Erstelldatum";

            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@itemID", UserItem.ID);
            cmd.Parameters.AddWithValue("@m_nDocumentID", m_nDocumentID);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            string strDocumentName = "";
            while (reader.Read())
            {
                strDocumentName = reader["Dokumentinformationsname"].ToString();

                if (strDocumentName != "")
                {
                    DocumentItem = new ComboboxItem();
                    DocumentItem.Text = strDocumentName;
                    DocumentItem.ID = (int)reader["idDokumentinformation"];

                    this.cbxDocumentInfoNames.Items.Add(DocumentItem);
                }

            }

            if (this.cbxDocumentInfoNames.Items.Count > 0)
            {
                this.cbxDocumentInfoNames.SelectedIndex = 0;
            }

            reader.Close();
            con.Close();
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        -------------------------------------Zum-Wechseln-der-Dokumentinformationen-----------------------------------
        **************************************************************************************************************/
        private void cbxDocumentNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboboxItem item = (ComboboxItem)this.cbxDocumentInfoNames.SelectedItem;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = (SqlHelper.GetSqlConnectionString());

            string strSQL = "select idDokumentinformation, Dokumentinformationsname, Dokumentinformation, Erstelldatum From Dokumentinformation Where idDokumentinformation = @itemID";

            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("itemID", item.ID);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            string strDocumentName = "";

            while (reader.Read())
            {
                strDocumentName = reader["Dokumentinformationsname"].ToString();

                if (strDocumentName != "")
                {
                    this.tbxDocumentInfo.Text = reader["Dokumentinformation"].ToString();
                    this.dtpInfoCreateDate.Value = (DateTime)reader["Erstelldatum"];
                //    this.dtpInfoChange.Value = (DateTime)reader["Aenderungsdatum"]; 
                }

            }

            reader.Close();
            con.Close();
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        -------------------------------------Wenn-die-Information-gewechselt-wird-------------------------------------
        **************************************************************************************************************/
  /*      private void btnChangeInfo_Click(object sender, EventArgs e)
        {
            ComboboxItem itemUser = (ComboboxItem)this.cbxUser.SelectedItem;

            if (itemUser.ID == m_nUserID)
            {
                ComboboxItem itemDocNames = (ComboboxItem)this.cbxDocumentInfoNames.SelectedItem;
                if (itemDocNames == null)
                {
                    return;
                }

                frmAddNewDocumentInfo AddNewDocInfo = new frmAddNewDocumentInfo();
                AddNewDocInfo.LoadTextFromDb(itemDocNames.ID);
                AddNewDocInfo.ShowDialog();

                if(AddNewDocInfo.DialogResult == DialogResult.Cancel)
                {
                    return;
                }

                DateTime today = DateTime.Now;
                string strDateTimeToday = today.ToString("yyyy-dd-MM HH:mm:ss");

                int i = 0;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = (SqlHelper.GetSqlConnectionString());
                string strSQL = "Update Dokumentinformation " +
                                        "SET Dokumentinformationsname = @AddNewDocInfoGetInformationName, Dokumentinformation = @AddNewDocInfoGetDocumentInfo, Aenderungsdatum = @strDateTimeToday " +
                                        "Where idDokumentinformation = @itemDocNamesID";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = strSQL;

                cmd.Parameters.AddWithValue("@AddNewDocInfoGetInformationName", AddNewDocInfo.GetInformationName());
                cmd.Parameters.AddWithValue("@AddNewDocInfoGetDocumentInfo", AddNewDocInfo.GetDocumentInfo());
                cmd.Parameters.AddWithValue("@strDateTimeToday", strDateTimeToday);
                cmd.Parameters.AddWithValue("@itemDocNamesID", itemDocNames.ID);

                cmd.Connection = con;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();





                LoadDocumentNames();

                //Damit der richtige Dokumentinformationsname angezeigt wird 
                for (i = 0; i < this.cbxDocumentInfoNames.Items.Count; i++ )
                {
                    ComboboxItem item = (ComboboxItem)this.cbxDocumentInfoNames.Items[i];

                    if (item.ID == itemDocNames.ID)
                    {
                        this.cbxDocumentInfoNames.SelectedItem = item;
                        break;
                    }
                }
                
                this.tbxDocumentInfo.Text = AddNewDocInfo.GetDocumentInfo();    //Zeigt den geänderten Text in der Textbox an
            }

        }*/
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        ---------------------------------------Löscht-die-ausgewählte-Information-------------------------------------
        **************************************************************************************************************/
/*        private void btnDeleteInfo_Click(object sender, EventArgs e)
        {
            ComboboxItem itemUser = (ComboboxItem)this.cbxUser.SelectedItem;

            if (itemUser.ID == m_nUserID)
            {
                ComboboxItem itemDocNames = (ComboboxItem)this.cbxDocumentInfoNames.SelectedItem;
                
                if ((this.cbxDocumentInfoNames.Items.Count > 0)
                && (itemDocNames != null))
                {
                    DialogResult dialogResult = MessageBox.Show("Wollen Sie wirklich diese Dokumentinformation löschen?", "Löschen", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        SqlHelper.SendQueryToDb("Delete from Dokumentinformation Where idDokumentinformation = " + itemDocNames.ID);
                        this.tbxDocumentInfo.Clear();

                        LoadDocumentNames();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //do something else
                    }

                }

            }
            else
            {
                MessageBox.Show("Sie haben keine Berechtigung, dieses Element zu löschen.", "Warnung");
            }

        }*/
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/


    }
}
