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
    public partial class frmAssignMatchcode : Form
    {
        CSqlHelper SqlHelper = new CSqlHelper();
        private int m_nFolderID = -1;
        private int m_nDocumentID = -1;


        public class ComboboxItem
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


            public override string ToString()
            {
                return Name;
            }
        }

        public class myListView : ListViewItem
        {
            public int ID {get;set;}

            public myListView(string Name)
            {
                this.Text = Name;
            }
        }

        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/
        public frmAssignMatchcode(int nFolderID, int nDocumentID, string strObjectName)
        {
            InitializeComponent();
            m_nFolderID = nFolderID;                    //Übergibt die Mappen-ID
            m_nDocumentID = nDocumentID;                //Übergibt die Dokument-ID
            this.tbxObjectName.Text = strObjectName;    //Zeigt den Dokument-  bzw. Mappenname an

            LoadMatchcodesFromDb();         //Lädt alle Matchcodes aus der Datenbank
            LoadUsedMatchcodesFromDb();     //Lädt die am Objekt hängenden Matchcodes aus der Datenbank
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/





        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*************************************************************************************************************
        --------------------------------Holt-sich-alle-Matchcodes-aus-der-Datenbank-----------------------------------
        **************************************************************************************************************/
        private void LoadMatchcodesFromDb()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = (SqlHelper.GetSqlConnectionString());

            string strSQL = "select idMatchcode, Matchcodename From Matchcode order by idMatchcode";

            SqlCommand cmd = new SqlCommand(strSQL, con);


            con.Open();


            SqlDataReader reader = cmd.ExecuteReader();
            string strMatchcodeName = "";
            

            while (reader.Read())
            {
                ComboboxItem item = new ComboboxItem();
                strMatchcodeName = reader["Matchcodename"].ToString();

                if(strMatchcodeName != "")
                {
                    item.ID = (int)reader["idMatchcode"];
                    item.Name = strMatchcodeName;

                    this.cbxAllMatchcodes.Items.Add(item);
                }
              
            }

            if (this.cbxAllMatchcodes.Items.Count > 0)
            {
                this.cbxAllMatchcodes.SelectedIndex = 0;
            }

            reader.Close();
            con.Close();
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        -----------------------------Lädt-die-schon-Verknüpften-Matchcodes-aus-der-Datenbank--------------------------
        **************************************************************************************************************/
        private void LoadUsedMatchcodesFromDb()
        {
            this.lstvUsedMatchcodes.Items.Clear();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = (SqlHelper.GetSqlConnectionString());


            string strSQL = "";

            if(m_nDocumentID > -1)
            {
                strSQL = "Select ObjMC.ID_MatchcodeItem, ObjMC.ID_Dokument, MCI.Bezeichnung, MC.Matchcodename " +
                 "From Objektmatchcode ObjMC " +
                 "join MatchcodeItem MCI on MCI.idMatchcodeItem = ObjMC.ID_MatchcodeItem " +
                 "Join Matchcode MC on MCI.ID_Matchcode = MC.idMatchcode " +
                 "Where ID_Dokument = @m_nDocumentID";
            }
            else
            {
                strSQL = "Select ObjMC.ID_MatchcodeItem, ObjMC.ID_Ordner, MCI.Bezeichnung, MC.Matchcodename " +
                         "From Objektmatchcode ObjMC " +
                         "join MatchcodeItem MCI on MCI.idMatchcodeItem = ObjMC.ID_MatchcodeItem " +
                         "join Matchcode MC on MC.idMatchcode = MCI.ID_Matchcode " +
                         "Where ObjMC.ID_Ordner = @m_nFolderID";
            }

            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@m_nDocumentID", m_nDocumentID);
            cmd.Parameters.AddWithValue("@m_nFolderID", m_nFolderID);

            con.Open();
            string strMatchcode = "";
            string strMatchcodeContainer = "";

            SqlDataReader reader = cmd.ExecuteReader();         

            while (reader.Read())
            {
                strMatchcode = reader["Bezeichnung"].ToString();
                strMatchcodeContainer = reader["Matchcodename"].ToString();

                myListView lvi = new myListView(strMatchcode);

                lvi.ID = (int)reader["ID_MatchcodeItem"];
                lvi.SubItems.Add(strMatchcodeContainer);
                this.lstvUsedMatchcodes.Items.Add(lvi);
 
            }

            reader.Close();
            con.Close();
        }



        /*************************************************************************************************************
        ------------------------Funktion,-um-eine-Verknüpfung-zwischen-Matchcode-und ID-zu-schaffen-------------------
        **************************************************************************************************************/
        private void btnAddLink_Click(object sender, EventArgs e)
        {
            ListBoxItem itemListBox = (ListBoxItem)this.lstbAllMatchcodes.SelectedItem;
            int nMaxObjMatchcodeID = SqlHelper.GetMaxID("idObjektmatchcode", "Objektmatchcode");
            nMaxObjMatchcodeID = nMaxObjMatchcodeID + 1;
            int i = 0;
            bool bItemExist = false;


            //Prüft ab, ob ein Element schon in der Liste existiert
            for (i = 0; i < this.lstvUsedMatchcodes.Items.Count; i++)
            {
               this.lstvUsedMatchcodes.Items[i].ToString();

               if (itemListBox != null)
               {
                   if (this.lstvUsedMatchcodes.Items[i].ToString() == itemListBox.Name)
                   {
                       bItemExist = true;
                   }
               }
            }

            //wenn ein Element ausgewählt ist
            if (itemListBox != null)
            {
                //...und es noch nicht existiert
                if (!bItemExist)
                {
                    //Wenn es ein Dokument ist
                    if (m_nDocumentID > -1)
                    { 
                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = (SqlHelper.GetSqlConnectionString());
                        string strSQL = "Insert into Objektmatchcode values (@nMaxObjMatchcodeID, @m_nDocumentID, -1, 0, @itemListBoxID)";

                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = strSQL;

                        cmd.Parameters.AddWithValue("@nMaxObjMatchcodeID", nMaxObjMatchcodeID);
                        cmd.Parameters.AddWithValue("@m_nDocumentID", m_nDocumentID);
                        cmd.Parameters.AddWithValue("@itemListBoxID", itemListBox.ID);

                        cmd.Connection = con;

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = (SqlHelper.GetSqlConnectionString());
                        string strSQL = "Insert into Objektmatchcode values (@nMaxObjMatchcodeID, -1, @m_nFolderID, 1, @itemListBoxID)";

                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = strSQL;

                        cmd.Parameters.AddWithValue("@nMaxObjMatchcodeID", nMaxObjMatchcodeID);
                        cmd.Parameters.AddWithValue("@m_nFolderID", m_nFolderID);
                        cmd.Parameters.AddWithValue("@itemListBoxID", itemListBox.ID);

                        cmd.Connection = con;

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }

                  //  this.lstbUsedMatchcodes.Items.Add(itemListBox);
                    myListView lvi = new myListView(itemListBox.Name);
                    lvi.ID = itemListBox.ID;
                    lvi.SubItems.Add(this.cbxAllMatchcodes.SelectedItem.ToString());
                    this.lstvUsedMatchcodes.Items.Add(lvi);
                    
                }
                else
                {
                    MessageBox.Show("Element existiert bereits in der Liste", "Warnung");
                }
                
            }
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        ´------------------------------Wenn-der-Eintrag-in-der-Combobox-gewechselt-wird-------------------------------
        **************************************************************************************************************/
        private void cbxAllMatchcodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboboxItem item = (ComboboxItem)this.cbxAllMatchcodes.SelectedItem;
            this.lstbAllMatchcodes.Items.Clear();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = (SqlHelper.GetSqlConnectionString());


            string strSQL = "select idMatchcodeItem, Bezeichnung From MatchcodeItem Where ID_Matchcode = @itemID";

            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@itemID", item.ID);

            con.Open();


            SqlDataReader reader = cmd.ExecuteReader();
            string strMatchcodeName = "";


            while (reader.Read())
            {
                ListBoxItem itemListBox = new ListBoxItem();
                strMatchcodeName = reader["Bezeichnung"].ToString();

                if (strMatchcodeName != "")
                {
                    itemListBox.ID = (int)reader["idMatchcodeItem"];
                    itemListBox.Name = strMatchcodeName;

                    this.lstbAllMatchcodes.Items.Add(itemListBox);
                }

            }

            reader.Close();
            con.Close();

        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        ---------------------------------------ZUm-Löschen-eines-Eintrages--------------------------------------------
        **************************************************************************************************************/
        private void btnDeleteLink_Click(object sender, EventArgs e)
        {
            if (this.lstvUsedMatchcodes.SelectedItems.Count > 0)
            {

                myListView lvi = (myListView)this.lstvUsedMatchcodes.SelectedItems[0];

                if (lvi != null)
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = (SqlHelper.GetSqlConnectionString());
                    string strSQL = "Delete from Objektmatchcode Where ID_MatchcodeItem = @lvi";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = strSQL;
                    cmd.Parameters.AddWithValue("@lvi", lvi.ID);

                    cmd.Connection = con;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    this.lstvUsedMatchcodes.Items.Remove(lvi);
                }
            }
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/

    }

}
