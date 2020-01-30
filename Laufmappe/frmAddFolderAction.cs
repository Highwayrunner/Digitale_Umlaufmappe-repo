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
    public partial class frmAddFolderAction : Form
    {
        private int m_nFolderID = -1;   //Die ID des ausgewhlten Ordners
        private int m_nUserID = -1;     //Die Benutzer ID
        private int m_nNextUserID = -1;
        CSqlHelper SqlHelper = new CSqlHelper();    //SQL-Hilfklasse

        public class ListboxItem
        {
            public string Username { get; set; }
            public int UserID { get; set; }


            public override string ToString()
            {
                return Username;
            }
        }

        /*************************************************************************************************************
        -----------------------Wird-benutzt,-um-ein-benutzerdefiniertes-Combobox-Item hinzuzufügen--------------------
        **************************************************************************************************************/
        public class ComboboxItem
        {
            public string Text { get; set; }        //Den Text, den die Combobox anzeigen soll
            public int ID { get; set; }             //Die ID, die die Combobox speichern soll

            //Zeigt den Text an, der in der Variable Text gespeichert wird 
            public override string ToString()
            {
                return Text;
            }
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        --------------------------------------------Initialisierung-der-Form------------------------------------------
        **************************************************************************************************************/
        public frmAddFolderAction(int nUserID, int nFolderID, string strFolderName)
        {
            InitializeComponent();
            m_nFolderID = nFolderID;                    //Speichert sich die Ordner ID
            m_nUserID = nUserID;                        //Speichert sich die Benutzer ID
            this.tbxFolderName.Text = strFolderName;    //Speichert sich den Ordnernamen

            LoadActionsFromDb();                        //Lädt die Aktionen aus der Datenbank
            LoadCurrentActionFromDb();                  //Lädt die zuletzt gewählte aktuelle Aktion
            LoadNextActionFromDb();                     //Lädt die nächste Aktion

            LoadUserFromDb();
            LoadChosenUserFromDb();
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        ---------------------------------Lädt-die-Daten-für-die-nächste-Aktion----------------------------------------
        **************************************************************************************************************/
        private void LoadNextActionFromDb()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = (SqlHelper.GetSqlConnectionString());


            string strSQL = "select idAktion, Status, Bezeichnung " +
                            "From Ordneraktionen join Aktion on idAktion = ID_Naechste_Aktion where ID_Ordner = @m_nFolderID";

            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@m_nFolderID", m_nFolderID);

            con.Open();


            SqlDataReader reader = cmd.ExecuteReader();
            string strActionName = "";
            this.lbNextAction.Text = "Noch nicht gesetzt";
            int i = 0;
            int nActionID = -1;

            while (reader.Read())
            {
                strActionName = reader["Bezeichnung"].ToString();

                if (strActionName != "")
                {
                    this.lbNextAction.Text = strActionName;
                    nActionID = (int)reader["idAktion"];
                }
            }


            for (i = 0; i < this.cbxNextActions.Items.Count; i++)
            {
                ComboboxItem NextActionItem = (ComboboxItem)this.cbxNextActions.Items[i];

                if (nActionID == NextActionItem.ID)
                {
                    this.cbxNextActions.SelectedItem = NextActionItem;
                    break;
                }
            }


            reader.Close();
            con.Close();
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/


        /*************************************************************************************************************
        ---------------------------------Lädt-die-aktuell-gewählte-Ordneraktion---------------------------------------
        **************************************************************************************************************/
        private void LoadCurrentActionFromDb()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = (SqlHelper.GetSqlConnectionString());

            string strSQL = "select idAktion, Status, Bezeichnung From Ordneraktionen join Aktion on idAktion = ID_Aktion where ID_Ordner = @m_nFolderID";

            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@m_nFolderID", m_nFolderID);

            con.Open();
            

            SqlDataReader reader = cmd.ExecuteReader();
            string strActionName = "";
            int nStatus = 0;
            int i = 0;
            int nActionID = -1;

            this.lbAktion.Text = "Noch nicht gesetzt";

            while (reader.Read())
            {
                strActionName = reader["Bezeichnung"].ToString();

                if (strActionName != "")
                {
                    this.lbAktion.Text = strActionName;
                    nStatus = (int)reader["Status"];
                    nActionID = (int)reader["idAktion"];
                }
            }

            for (i = 0; i < this.cbxCurrentAction.Items.Count; i++)
            {
                ComboboxItem CurrentActionItem = (ComboboxItem)this.cbxCurrentAction.Items[i];

                if(nActionID == CurrentActionItem.ID)
                {
                    this.cbxCurrentAction.SelectedItem = CurrentActionItem;
                    break;
                }
            }

            //Setzt die Statusanzeige
            if (nStatus == 0)
            {
                this.lbStatus.Text = "Nicht Erledigt";
                this.rdbFolderNotReady.Checked = true;
            }
            else
            {
                this.lbStatus.Text = "Erledigt";
                this.rdbFolderReady.Checked = true;
            }


            reader.Close();
            con.Close();
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/



        /*************************************************************************************************************
        ------------------------------------Lädt-alle-Aktionen-aus-der-Datenbank--------------------------------------
        **************************************************************************************************************/
        private void LoadActionsFromDb()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = (SqlHelper.GetSqlConnectionString());

            string strSQL = "select idAktion, Bezeichnung From Aktion";     //Lädt alle Daten aus der Tabelle Aktion

            SqlCommand cmd = new SqlCommand(strSQL, con);
            con.Open();


            SqlDataReader reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                ComboboxItem item = new ComboboxItem();
                
                item.Text = reader["Bezeichnung"].ToString();       //Lädt die Aktionsbezeichnung

                if(item.Text != "")
                {
                    item.ID = (int)reader["idAktion"];              //Lädt die AktionsbezeichnungsID
                    this.cbxCurrentAction.Items.Add(item);          //Fügt das Item der Combobox hinzu
                    this.cbxCurrentAction.SelectedIndex = 0;        //Setzt das ausgewählte Item auf den ersten Platz

                    this.cbxNextActions.Items.Add(item);        
                    this.cbxNextActions.SelectedIndex = 0;
                }
            }

            reader.Close();
            con.Close();
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        -------------------------------------Speichert-die-ausgewählten-Attribute-------------------------------------
        **************************************************************************************************************/
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveActionSettings();
            
            this.lbAktion.Text = this.cbxCurrentAction.Text;
            this.lbNextAction.Text = this.cbxNextActions.Text;

            if (rdbFolderReady.Checked)
            {
                lbStatus.Text = "Erledigt";
            }
            else
            {
                lbStatus.Text = "Nicht Erledigt";
            }

            MessageBox.Show("Aktion wurde abgespeichert.", "Gespeichert");
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/


        private void SaveWorkFlow()
        {
            int i = 0;
            int nMaxID = SqlHelper.GetMaxID("idBenutzerordner", "Benutzerordner");

            SqlConnection con = new SqlConnection();
            con.ConnectionString = (SqlHelper.GetSqlConnectionString());
            string strSQL = "Delete from Benutzerordner where ID_Ordner = @m_nFolderID";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = strSQL;
            cmd.Parameters.AddWithValue("@m_nFolderID", m_nFolderID);

            cmd.Connection = con;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            for (i = 0; i < lstbChosenUsers.Items.Count; i++)
            {
                ListboxItem item = (ListboxItem)lstbChosenUsers.Items[i];
                nMaxID = nMaxID + 1;

                if (item != null)
                {
                    SqlHelper.SendQueryToDb("Insert into Benutzerordner values (" + nMaxID + ", " + item.UserID + ", " + m_nFolderID + ", " + i + ", 0)");
                }
            }

        }


        private void SaveActionSettings()
        {
            int nReady = 0;

            //Holt sich das aktuelle Datum und die Uhrzeit
            DateTime today = DateTime.Now;
            string strDateTimeToday = today.ToString("yyyy-dd-MM HH:mm:ss");

            //Wenn der Ordner als erledig markiert wurde
            if (this.rdbFolderReady.Checked)
            {
                nReady = 1;
            }
            else
            {
                nReady = 0;
            }

            ComboboxItem CurrentActionItem = (ComboboxItem)this.cbxCurrentAction.SelectedItem;
            ComboboxItem NextActionItem = (ComboboxItem)this.cbxNextActions.SelectedItem;

            //Setzt die Ordneraktion in der Datenbank
            if ((CurrentActionItem != null)
            && (NextActionItem != null))
            {
                if (nReady == 1)
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = (SqlHelper.GetSqlConnectionString());

                    SqlCommand cmd = new SqlCommand();
                    string strSQL = "Update Ordneraktionen Set ID_Aktion = @CurrentActionItemID, ID_Naechste_Aktion = @NextActionItemID, Status = @nReady, Erledigt_Am = @strDateTimeToday Where ID_Ordner = @m_nFolderID and ID_Benutzer = @m_nUserID and " +
                                    "idOrdneraktionen = (select max(idOrdneraktionen) From Ordneraktionen Where ID_Ordner = @m_nFolderID and ID_Benutzer = @m_nUserID)";
                    cmd.CommandText = strSQL;
                    cmd.Parameters.AddWithValue("@CurrentActionItemID", CurrentActionItem.ID);
                    cmd.Parameters.AddWithValue("@nReady", nReady);
                    cmd.Parameters.AddWithValue("@strDateTimeToday", strDateTimeToday);
                    cmd.Parameters.AddWithValue("@m_nFolderID", m_nFolderID);
                    cmd.Parameters.AddWithValue("@m_nUserID", m_nUserID);
                    cmd.Parameters.AddWithValue("@NextActionItemID", NextActionItem.ID);
                    cmd.Connection = con;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
                else
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = (SqlHelper.GetSqlConnectionString());

                    SqlCommand cmd = new SqlCommand();
                    string strSQL = "Update Ordneraktionen Set ID_Aktion = @itemID, ID_Naechste_Aktion = @NextActionItemID, Status = @nReady Where ID_Ordner = @m_nFolderID and ID_Benutzer = @m_nUserID and " +
                                    "idOrdneraktionen = (select max(idOrdneraktionen) From Ordneraktionen Where ID_Ordner = @m_nFolderID and ID_Benutzer = @m_nUserID)";

                    cmd.CommandText = strSQL;
                    cmd.Parameters.AddWithValue("@itemID", CurrentActionItem.ID);
                    cmd.Parameters.AddWithValue("@nReady", nReady);
                    cmd.Parameters.AddWithValue("@m_nFolderID", m_nFolderID);
                    cmd.Parameters.AddWithValue("@m_nUserID", m_nUserID);
                    cmd.Parameters.AddWithValue("@NextActionItemID", NextActionItem.ID);

                    cmd.Connection = con;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            
            }

        }



        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }



        private void btnSaveWorkFlow_Click(object sender, EventArgs e)
        {
            SaveWorkFlow();
            MessageBox.Show("Einträge wurden gespeichert.", "Gespeichert");
        }



        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            this.lstbChosenUsers.Items.Clear();
        }




        private void btnDeleteChosesUser_Click(object sender, EventArgs e)
        {
            ListboxItem item = (ListboxItem)this.lstbChosenUsers.SelectedItem;

            if (item != null)
            {
                this.lstbChosenUsers.Items.Remove(item);
            }
        }



        private void btnInsertItem_Click(object sender, EventArgs e)
        {
            ListboxItem item = (ListboxItem)this.lstbAllUsers.SelectedItem;

            if (item != null)
            {
                this.lstbChosenUsers.Items.Insert(this.lstbChosenUsers.SelectedIndex + 1, item);
            }
        }



        private void btnAddUser_Click(object sender, EventArgs e)
        {
            ListboxItem item = (ListboxItem)this.lstbAllUsers.SelectedItem;

            if (item != null)
            {
                this.lstbChosenUsers.Items.Add(item);
            }
        }



        private void btnTransferByOrder_Click(object sender, EventArgs e)
        {
            int nPassFolderResult = 0;

            SaveActionSettings();
            SaveWorkFlow();

            nPassFolderResult = PassFolder();

            if (nPassFolderResult == 1)
            {
                this.DialogResult = DialogResult.OK;
                return;
            }
            

            this.DialogResult = DialogResult.None;

        }





        private int PassFolder()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = (SqlHelper.GetSqlConnectionString());

            string strSQL = "Select idBenutzerordner, ID_Benutzer, Benutzername From Benutzerordner join Benutzer on idBenutzer = ID_Benutzer Where ID_Ordner = @FolderID Order by Position";

            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@FolderID", m_nFolderID);

            con.Open();


            SqlDataReader reader = cmd.ExecuteReader();
            int nNextUser = -1;
            int nBenutzerordnerID = -1;
            int nFoundUser = 0;
            string strNextUser = "";

            while (reader.Read())
            {
                nBenutzerordnerID = (int)reader["idBenutzerordner"];
                nNextUser = (int)reader["ID_Benutzer"];
                nFoundUser = 1;
                strNextUser = reader["Benutzername"].ToString();

                break;
            }

            reader.Close();
            con.Close();

            //Wenn ein Benutzer gefunden wurde
            if (nFoundUser == 1)
            {
                DialogResult dialogResult = MessageBox.Show("Sind sie sich sicher, dass Sie die Mappe an \"" + strNextUser + "\" weiterreichen wollen?", "Mappenweitergabe", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.No)
                {
                    return -1;
                }


                DateTime today = DateTime.Now;
                string strDateTimeToday = today.ToString("yyyy-dd-MM HH:mm:ss");


                SqlHelper.SendQueryToDb("Delete From Benutzerordner Where idBenutzerordner = " + nBenutzerordnerID);
                SqlHelper.SendQueryToDb("Update Ordner Set ID_Benutzer = " + nNextUser + " Where idOrdner = " + m_nFolderID);


                int nMaxFolderActionID = SqlHelper.GetMaxID("idOrdneraktionen", "Ordneraktionen");
                int nFolderReady = 0;
                int nProcessingReason = GetProcessingReason(m_nFolderID);
                nMaxFolderActionID = nMaxFolderActionID + 1;



                con = new SqlConnection();
                con.ConnectionString = (SqlHelper.GetSqlConnectionString());
                strSQL = "insert into Ordneraktionen values (@nMaxFolderActionID, @NodeGetFolderID, @nNextUser, @nProcessingReason, 1, 0, @strDateTimeToday)";

                cmd = new SqlCommand();
                cmd.CommandText = strSQL;
                cmd.Parameters.AddWithValue("@nMaxFolderActionID", nMaxFolderActionID);
                cmd.Parameters.AddWithValue("@NodeGetFolderID", m_nFolderID);
                cmd.Parameters.AddWithValue("@nNextUser", nNextUser);
                cmd.Parameters.AddWithValue("@strDateTimeToday", strDateTimeToday);
                cmd.Parameters.AddWithValue("@nProcessingReason", nProcessingReason);
                cmd.Parameters.AddWithValue("@nFolderReady", nFolderReady);
                cmd.Connection = con;

                int nMaxChonikID = SqlHelper.GetMaxID("idBearbeitungschronik", "Bearbeitungschronik");
                nMaxChonikID = nMaxChonikID + 1;
                int nPreviousFolderActionID = GetMaxFolderActionID(m_nUserID, m_nFolderID);
                SqlHelper.SendQueryToDb("Insert into Bearbeitungschronik values (" + nMaxChonikID + ", " + m_nUserID + ", " + m_nFolderID + ", " + nPreviousFolderActionID + ", '" + strDateTimeToday + "')");


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                m_nNextUserID = nNextUser;
            }
            else
            {
                MessageBox.Show("Es wurden keine weiteren Bearbeiter gefunden.", "Fehler");
            }

            return nFoundUser;
        }



        public int GetNextUserID()
        {
            return m_nNextUserID;
        }



        private int GetProcessingReason(int nFolderID)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = (SqlHelper.GetSqlConnectionString());

            string strSQL = "Select ID_Naechste_Aktion From Ordneraktionen Where  ID_Ordner = @nFolderID and Erledigt_Am = (Select max(Erledigt_Am) From Ordneraktionen Where ID_Ordner = @nFolderID)";
            int nProcessingReason = -1;

            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@nFolderID", nFolderID);

            con.Open();


            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                nProcessingReason = (int)reader["ID_Naechste_Aktion"];
            }


            reader.Close();
            con.Close();
            return nProcessingReason;
        }



        /*************************************************************************************************************
        ----------------------------------Gibt-die-größte-OrdnerAktion-ID-zurück--------------------------------------
        **************************************************************************************************************/
        private int GetMaxFolderActionID(int nUserID, int nFolderID)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = (SqlHelper.GetSqlConnectionString());

            string strSQL = "Select max(idOrdnerAktionen) as MaxFolderActionID From Ordneraktionen Where ID_Benutzer = @nUserID and ID_Ordner = @nFolderID";

            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@nUserID", nUserID);
            cmd.Parameters.AddWithValue("@nFolderID", nFolderID);

            con.Open();


            SqlDataReader reader = cmd.ExecuteReader();
            int nMaxFolderActionID = -1;

            while (reader.Read())
            {
                nMaxFolderActionID = (int)reader["MaxFolderActionID"];
            }


            reader.Close();
            con.Close();

            return nMaxFolderActionID;
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/



        /*************************************************************************************************************
        --------------------Lädt-alle-Benutzer-aus-der-Datenbank,-die-in-der-Weitergabeliste-stehen-------------------
        **************************************************************************************************************/
        private void LoadChosenUserFromDb()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = (SqlHelper.GetSqlConnectionString());

            string strSQL = "select idbenutzer, Benutzername From Benutzer join Benutzerordner on idBenutzer = ID_Benutzer where ID_Ordner = @m_nFolderID order by Position ";

            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@m_nFolderID", m_nFolderID);

            con.Open();

            string strUsername = "";
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                strUsername = reader["Benutzername"].ToString();

                if (strUsername != "")
                {
                    ListboxItem item = new ListboxItem();
                    item.Username = strUsername;
                    item.UserID = (int)reader["idBenutzer"];
                    this.lstbChosenUsers.Items.Add(item);
                }

            }

            reader.Close();
            con.Close();
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        ------------------------------------Lädt-alle-Benutzer-aus-der-Datenbank--------------------------------------
        **************************************************************************************************************/
        private void LoadUserFromDb()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = (SqlHelper.GetSqlConnectionString());

            string strSQL = "select idBenutzer, Benutzername From Benutzer order by idBenutzer";

            SqlCommand cmd = new SqlCommand(strSQL, con);


            con.Open();

            string strUsername = "";
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                strUsername = reader["Benutzername"].ToString();

                if (strUsername != "")
                {
                    ListboxItem item = new ListboxItem();
                    item.Username = strUsername;
                    item.UserID = (int)reader["idBenutzer"];
                    this.lstbAllUsers.Items.Add(item);
                }

            }

            reader.Close();
            con.Close();
        }



        private void lstbAllUsers_DoubleClick(object sender, EventArgs e)
        {
            ListboxItem item = (ListboxItem)this.lstbAllUsers.SelectedItem;

            if (item != null)
            {
                this.lstbChosenUsers.Items.Add(item);
            }
        }



        private void lstbChosenUsers_DoubleClick(object sender, EventArgs e)
        {
            ListboxItem item = (ListboxItem)this.lstbChosenUsers.SelectedItem;

            if (item != null)
            {
                this.lstbChosenUsers.Items.Remove(item);
            }
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/
    }

}
