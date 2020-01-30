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
    public partial class frmCreateWorkflow : Form
    {
        CSqlHelper SqlHelper = new CSqlHelper();


        public class ListboxItem
        {
            public string Username { get; set; }
            public int UserID{ get; set; }


            public override string ToString()
            {
                return Username;
            }
        }

        int m_nFolderID = -1;




        public frmCreateWorkflow(int nFolderID, string strFolderName)
        {
            InitializeComponent();
            m_nFolderID = nFolderID;
            this.tbxObjectName.Text = strFolderName;

            LoadUserFromDb();
            LoadChosenUserFromDb();
        }




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
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        ------------------Kopiert-den-Benutzer-aus-der-allgemeinen-Tebelle-in-die-Weitergabe-Tabelle------------------
        **************************************************************************************************************/
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            ListboxItem item = (ListboxItem)this.lstbAllUsers.SelectedItem;

            if(item != null)
            {
                this.lstbChosenUsers.Items.Add(item);
            }
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        ------------------------------Löscht-das-markierte-Objekt-aus-der-Weitergabe-Tabelle--------------------------
        **************************************************************************************************************/
        private void btnDeleteChosesUser_Click(object sender, EventArgs e)
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



        /*************************************************************************************************************
        ---------------------------------Öscht-alle-Einträge-aus-der-Auswahltabelle-----------------------------------
        **************************************************************************************************************/
        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            this.lstbChosenUsers.Items.Clear();
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/
        private void btnInsertItem_Click(object sender, EventArgs e)
        {
            ListboxItem item = (ListboxItem)this.lstbAllUsers.SelectedItem;

            if (item != null)
            {
                this.lstbChosenUsers.Items.Insert(this.lstbChosenUsers.SelectedIndex + 1, item);
            }
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        ----------------------------Speichert-die-Weitergabe-Tabelle-in-der-Datenbank---------------------------------
        **************************************************************************************************************/
        private void btnSave_Click_1(object sender, EventArgs e)
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

            MessageBox.Show("Einträge wurden gespeichert.", "Gespeichert");
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/

    }
}
