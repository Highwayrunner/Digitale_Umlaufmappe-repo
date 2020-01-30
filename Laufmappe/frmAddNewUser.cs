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
    public partial class frmAddNewUser : Form
    {
        CSqlHelper SqlHelper = new CSqlHelper();
        private int m_nUserID = -1;

        public class ComboBoxItem
        {
            public string Name { get; set; }
            public int ID { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }

        public class ListBoxItem
        {
            public string Name { get; set; }
            public int ID { get; set; }
            public int Rights { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }


        public class myListView : ListViewItem
        {
            public int ID { get; set; }
            public int Rights { get; set; }

            public myListView(string Name)
            {
                this.Text = Name;
            }
        }

        /*************************************************************************************************************
        ----------------------------------------Initialisierung-der-Form ---------------------------------------------
        **************************************************************************************************************/
        public frmAddNewUser(int nUserID)
        {
            InitializeComponent();
            m_nUserID = nUserID;

            LoadRightsFromDb();     //Lädt die Rechte aus der Datenbank
            LoadUserFromDb();       //Lädt die vorhandenen Benutzer aus der Datenbank
            this.tbxUsername.Focus();
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        -----------------------------------Lädt-die-Benutzer-aus-der-Datenbank----------------------------------------
        **************************************************************************************************************/
        private void LoadUserFromDb()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = (SqlHelper.GetSqlConnectionString());

            string strSQL = "select idBenutzer, Benutzername, ID_Rechte, Bezeichnung From Benutzer Join Rechte On ID_Rechte = idRechte";
                
            SqlCommand cmd = new SqlCommand(strSQL, con);


            con.Open();


            SqlDataReader reader = cmd.ExecuteReader();
            string strUsername = "";
            string strRight = "";

            while (reader.Read())
            {
                strUsername = reader["Benutzername"].ToString();
                strRight = reader["Bezeichnung"].ToString();

                if (strUsername != "")
                {
                    myListView lvi = new myListView(strUsername);
                    lvi.ID = (int)reader["idBenutzer"];
                    lvi.Rights = (int)reader["ID_Rechte"];

                    lvi.SubItems.Add(strRight);
                    this.lstvUser.Items.Add(lvi);
                }
            }

            reader.Close();
            con.Close();
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        ------------------------------Lädt-die-vorhandenen-Rechte-aus-der-Datenbank-----------------------------------
        **************************************************************************************************************/
        private void LoadRightsFromDb()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = (SqlHelper.GetSqlConnectionString());

            string strSQL = "select idRechte, Bezeichnung From Rechte order by idRechte";

            SqlCommand cmd = new SqlCommand(strSQL, con);


            con.Open();


            SqlDataReader reader = cmd.ExecuteReader();
            string strRightName = "";


            while (reader.Read())
            {
                strRightName = reader["Bezeichnung"].ToString();

                if(strRightName != "")
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Name = strRightName;
                    item.ID = (int)reader["idRechte"];

                    this.cmbxRights.Items.Add(item);
                }
            }

            if (this.cmbxRights.Items.Count > 0)
            {
                this.cmbxRights.SelectedIndex = 0;
            }

            reader.Close();
            con.Close();
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        ----------------------------Funktion-zum-Hinzufügen-eines-neuen-Benutzers-------------------------------------
        **************************************************************************************************************/
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            int nMaxUserID = SqlHelper.GetMaxID("idBenutzer", "Benutzer");
            nMaxUserID = nMaxUserID + 1;
            string strPassword = "";
    

            if( (this.tbxUsername.Text != "")
            &&  (this.tbxPassword.Text != "") )
            {
                strPassword = this.tbxPassword.Text;

                DateTime today = DateTime.Now;
                string strDateTimeToday = today.ToString("yyyy-dd-MM HH:mm:ss");
                ComboBoxItem itemRights = (ComboBoxItem)this.cmbxRights.SelectedItem;

                myListView lvi = new myListView(this.tbxUsername.Text);
                lvi.ID = nMaxUserID;
                lvi.Rights = itemRights.ID;
                lvi.SubItems.Add(itemRights.Name);
                this.lstvUser.Items.Add(lvi);

                SqlConnection con = new SqlConnection();
                con.ConnectionString = (SqlHelper.GetSqlConnectionString());
                string strSQL = "Insert Into Benutzer values "
                                + "(@nMaxUserID, @itemName, @strPassword, @strDateTimeToday, @strDateTimeToday, 0, @itemRightsID,  '', '', '1970.01.01', 0, '', '')";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = strSQL;

                string Hash = SqlHelper.GetSHA256Hash(strPassword);            //SHA256 Hash von Passwort erzeugen
                cmd.Parameters.AddWithValue("@nMaxUserID", nMaxUserID);
                cmd.Parameters.AddWithValue("@itemName", lvi.Text);
                cmd.Parameters.AddWithValue("@strPassword", Hash);

                cmd.Parameters.AddWithValue("@strDateTimeToday", strDateTimeToday);
                cmd.Parameters.AddWithValue("@itemRightsID", itemRights.ID);
                

                cmd.Connection = con;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        -----------------------------------Funktion-zum-Löschen-eines-Benutzers---------------------------------------
        **************************************************************************************************************/
        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
        //    ListBoxItem item = (ListBoxItem)this.lstbUsers.SelectedItem;
            myListView lvi = (myListView)this.lstvUser.SelectedItems[0];

            //Wenn der ausgewählte Benutzer der Benutzer ist, der eingeloggt ist
            if (lvi.ID == m_nUserID)
            {
                MessageBox.Show("Sie können sich nicht selbst löschen", "Warnung!");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Wollen Sie den Benutzer \"" + lvi.Text + "\" wirklich löschen?", "Löschen", MessageBoxButtons.YesNo);
            
            if (dialogResult == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = (SqlHelper.GetSqlConnectionString());
                string strSQL = "Delete from Benutzer where idBenutzer = @lviID";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = strSQL;

                cmd.Parameters.AddWithValue("@lviID", lvi.ID);
                
                cmd.Connection = con;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Benutzer \"" + lvi.Text + "\" wurde gelöscht.", "Achtung");
                this.lstvUser.Items.Remove(lvi);
            }

        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/
    }
}
