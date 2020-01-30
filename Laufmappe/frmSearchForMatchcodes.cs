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
    public partial class frmSearchForMatchcodes : Form
    {
        private List<int> m_nFolderID = new List<int>();
        private List<int> m_nDocumentID = new List<int>();


        CSqlHelper SqlHelper = new CSqlHelper();

        public class ComboBoxItem
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public List<string> MatchcodeList = new List<string>();

            public override string ToString()
            {
                return Name;
            }
        }
        



        public class myListView : ListViewItem
        {
            public int ID { get; set; }

            public myListView(string Name)
            {
                this.Text = Name;
            }
        }

        /*************************************************************************************************************
        -----------------------------------------------Initialisiert-die-Form-----------------------------------------
        **************************************************************************************************************/
        public frmSearchForMatchcodes()
        {
            InitializeComponent();
            LoadMatchcodeContainerFromDb();
            LoadMatchCodesFromDb();

            if (this.cbxMatchcodeContainer.Items.Count > 0)
            {
                this.cbxMatchcodeContainer.SelectedIndex = 0;
            }
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        ------------------------------------Lädt-die-Matchcodes-aus-der-Datenbank-------------------------------------
        **************************************************************************************************************/
        private void LoadMatchCodesFromDb()
        {
            int i = 0;

            for (i = 0; i < this.cbxMatchcodeContainer.Items.Count; i++)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = (SqlHelper.GetSqlConnectionString());
                ComboBoxItem item = (ComboBoxItem)this.cbxMatchcodeContainer.Items[i];

                string strSQL = "";

                strSQL = "Select Bezeichnung from MatchcodeItem Where ID_Matchcode = @nMatchcodeID";

                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@nMatchcodeID", item.ID);
                
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                string strMatchcode = "";
                while (reader.Read())
                {
                    strMatchcode = reader["Bezeichnung"].ToString();
                    item.MatchcodeList.Add(strMatchcode);
                }

                reader.Close();
                con.Close();
            }

        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        ---------------------------Lädt-die-Matchcodecontainer-aus-der-Datenbank--------------------------------------
        **************************************************************************************************************/
        private void LoadMatchcodeContainerFromDb()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = (SqlHelper.GetSqlConnectionString());
            string strSQL = "";
            


            strSQL = "Select idMatchcode, Matchcodename from Matchcode";
          

            SqlCommand cmd = new SqlCommand(strSQL, con);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            string strMatchCodename = "";

            while (reader.Read())
            {
                strMatchCodename = reader["Matchcodename"].ToString();
   
                if(strMatchCodename != "")
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.ID = (int)reader["idMatchcode"];
                    item.Name = strMatchCodename;

                    this.cbxMatchcodeContainer.Items.Add(item);
                }
            }

            
            reader.Close();
            con.Close();

        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        -------------------------------------Sucht-die-Strings-in-der-Datenbank---------------------------------------
        **************************************************************************************************************/
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = (SqlHelper.GetSqlConnectionString());
            string strSQL = "";
            string strSearch = "";
            string strSearchString = "";
            string str = "";

            m_nFolderID.Clear();
            m_nDocumentID.Clear();

            int i = 0;
            for (i = 0; i < this.lstbSearchMatchcodes.Items.Count; i++)
            {
                strSearchString = this.lstbSearchMatchcodes.Items[i].ToString();
                str = "@SearchString" + i;

                if (i == 0)
                {
                    if (rdbFolder.Checked)
                    {
                        strSearch += "Objekttyp = 1 and Bezeichnung = " + str;
                    }
                    else
                    {
                        strSearch += "Objekttyp = 0 and Bezeichnung = " + str;
                    }
                }
                else
                {
                    if (rdbFolder.Checked)
                    {
                        strSearch += " OR Objekttyp = 1 and Bezeichnung = " + str;
                    }
                    else
                    {
                        strSearch += " OR Objekttyp = 0 and Bezeichnung = " + str;
                    }
                }
            }

            if (rdbFolder.Checked)
            {
                strSQL = "select ID_Ordner, Bezeichnung From Objektmatchcode join MatchcodeItem on idMatchcodeItem = ID_MatchcodeItem where " + strSearch;
            }
            else
            {
                strSQL = "select ID_Dokument, Bezeichnung From Objektmatchcode join MatchcodeItem on idMatchcodeItem = ID_MatchcodeItem where " + strSearch;
            }
                

            SqlCommand cmd = new SqlCommand(strSQL, con);


            for (i = 0; i < this.lstbSearchMatchcodes.Items.Count; i++)
            {
                strSearchString = this.lstbSearchMatchcodes.Items[i].ToString();
                str = "@SearchString" + i;
                cmd.Parameters.AddWithValue(str, strSearchString);
            }


            if (i == 0)
            {
                return;
            }
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            string strIdentity;

            while (reader.Read())
            {
                strIdentity = reader["Bezeichnung"].ToString();

                if(strIdentity != "")
                {
                    if (rdbFolder.Checked)
                    {
                        m_nFolderID.Add((int)reader["ID_Ordner"]);
                    }
                    else
                    {
                        m_nDocumentID.Add((int)reader["ID_Dokument"]);
                    }
                }
            }

            reader.Close();
            con.Close();
            

            this.Close();
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        -------------------------------------Gibt-die-gefundenen-Ordner-zurück----------------------------------------
        **************************************************************************************************************/
        public List<int> GetFoundFolders()
        {
            return m_nFolderID;    
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        ---------------------------------Gibt-die-gefundenen-Dokumente-zurück-----------------------------------------
        **************************************************************************************************************/
        public List<int> GetFoundDocuments()
        {
            return m_nDocumentID;
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/
        public bool IsFolderSearch()
        {
            return rdbFolder.Checked;
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        ------------------------------Wenn-der-Matchcodecontainer-gewechselt-wird-------------------------------------
        **************************************************************************************************************/
        private void cbxMatchcodeContainer_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)this.cbxMatchcodeContainer.SelectedItem;
            int i = 0;
            this.lstbMatchcodes.Items.Clear();

            for(i = 0; i < item.MatchcodeList.Count; i++)
            {
                this.lstbMatchcodes.Items.Add(item.MatchcodeList[i]);
            }
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        ----------------------------------------Fügt-Matchcodes-der-Suche-hinzu---------------------------------------
        **************************************************************************************************************/
        private void btnAddMatchcodeToSearch_Click(object sender, EventArgs e)
        {
            int nSelected = this.lstbMatchcodes.SelectedIndex;
            int i = 0;
            bool bSameName = false;

            if (nSelected > -1)
            {
                for (i = 0; i < this.lstbSearchMatchcodes.Items.Count; i++)
                {
                    if (this.lstbSearchMatchcodes.Items[i] == this.lstbMatchcodes.Items[nSelected])
                    {
                        bSameName = true;
                    }
                }

                if (!bSameName)
                {
                    this.lstbSearchMatchcodes.Items.Add(this.lstbMatchcodes.Items[nSelected]);
                }
            }
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/



        /*************************************************************************************************************
        ------------------------------Löscht-zu-suchende-Matchcodes-aus-der-Liste-------------------------------------
        **************************************************************************************************************/
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int nSelected = this.lstbSearchMatchcodes.SelectedIndex;

            if (nSelected > -1)
            {
                this.lstbSearchMatchcodes.Items.RemoveAt(nSelected);
            }
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/
    }

}
