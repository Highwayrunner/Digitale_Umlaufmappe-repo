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
    public partial class frmMatchcodes : Form
    {
        CSqlHelper SqlHelper = new CSqlHelper();

        public class ComboboxItem
        {
            public string Name { get; set; }
            public int ID { get; set; }
            

            public override string ToString()
            {
                return Name;
            }
        }




        public frmMatchcodes()
        {
            InitializeComponent();
            LoadMatchcodeFromDb();

            if (this.cbxMatchcode.Items.Count > 0)
            {
                this.cbxMatchcode.SelectedIndex = 0;
            }
        }



        /*************************************************************************************************************
        ---------------------------Lädt-die-Matchcodecontainer-aus-der-Datenbank--------------------------------------
        **************************************************************************************************************/
        private void LoadMatchcodeFromDb()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = (SqlHelper.GetSqlConnectionString());
            this.cbxMatchcode.Items.Clear();
            string strSQL = "Select idMatchcode, Matchcodename From Matchcode ";

            SqlCommand cmd = new SqlCommand(strSQL, con);


            con.Open();


            SqlDataReader reader = cmd.ExecuteReader();
            string strMatchcodeName = "";
            
            while (reader.Read())
            {
                strMatchcodeName = reader["Matchcodename"].ToString();

                if(strMatchcodeName != "")
                {
                    ComboboxItem item = new ComboboxItem();

                    item.Name = strMatchcodeName;
                    item.ID = (int)reader["idMatchcode"];
                 //   item.MatchcodeItems = reader["Bezeichnung"].ToString();

                    this.cbxMatchcode.Items.Add(item);
                }
                   
            }

            reader.Close();
            con.Close();
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/


        /*************************************************************************************************************
        -------------------------Fügt-einen-neuen-Matchcodecontainer-in-die-Combobox-ein------------------------------
        **************************************************************************************************************/
        private void btnAddMatch_Click(object sender, EventArgs e)
        {
            frmAddNewMatchcode NewMatchcode = new frmAddNewMatchcode();
            NewMatchcode.ShowDialog();

            LoadMatchcodeFromDb();
            if(this.cbxMatchcode.Items.Count > 0)
            {
                this.cbxMatchcode.SelectedIndex = this.cbxMatchcode.Items.Count -1;
            }
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        ------------------------------Fügt-der-Matchcodeliste-einen-Eintrag-hinzu-------------------------------------
        **************************************************************************************************************/
        private void btnAddMatchcodeItem_Click(object sender, EventArgs e)
        {
            string strMatchcodeItem = this.tbxMatchcodeItem.Text;

            if(strMatchcodeItem != "")
            {
                ComboboxItem item = (ComboboxItem)this.cbxMatchcode.SelectedItem;

                if(item != null)
                {
                    this.lstbMatchcodes.Items.Add(strMatchcodeItem);
                }

                this.tbxMatchcodeItem.Clear();
            }
            else
            {
                MessageBox.Show("Matchcode konnte nicht hinzugefügt werden.", "Warnung");
            }
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        --------------------------------Lädt-die-Matchcodecontainer-in-die-Combobox-----------------------------------
        **************************************************************************************************************/
        private void LoadMatchcodeItemFromDb(int nMadchcodeID)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = (SqlHelper.GetSqlConnectionString());
            this.cbxMatchcode.Items.Clear();
            string strSQL = "Select idMatchcode, Matchcodename From Matchcode ";

            SqlCommand cmd = new SqlCommand(strSQL, con);


            con.Open();


            SqlDataReader reader = cmd.ExecuteReader();
            string strMatchcodeName = "";

            while (reader.Read())
            {
                strMatchcodeName = reader["Matchcodename"].ToString();

                if (strMatchcodeName != "")
                {
                    ComboboxItem item = new ComboboxItem();

                    item.Name = strMatchcodeName;
                    item.ID = (int)reader["idMatchcode"];

                    this.cbxMatchcode.Items.Add(item);
                }

            }

            reader.Close();
            con.Close();
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/



        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        /*************************************************************************************************************
        --------------Wenn-der-Matchcodecontainer-gewechselt-wird-müssen-die-Matchcodes-neu-geladen-werden------------
        **************************************************************************************************************/
        private void cbxMatchcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstbMatchcodes.Items.Clear();

            ComboboxItem item = (ComboboxItem)cbxMatchcode.SelectedItem;

            if(item != null)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = (SqlHelper.GetSqlConnectionString());
           
                string strSQL = "Select Bezeichnung From MatchcodeItem Where ID_Matchcode = " + item.ID;

                SqlCommand cmd = new SqlCommand(strSQL, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                string strMatchcodeItem = "";
                
                while (reader.Read())
                {
                    strMatchcodeItem = reader["Bezeichnung"].ToString();
                    this.lstbMatchcodes.Items.Add(strMatchcodeItem);
                }

                reader.Close();
                con.Close();
            }               
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        ----------------------------------Löscht-ein-MatchcodeItem-aus-der-Liste--------------------------------------
        **************************************************************************************************************/
        private void btnDeleteMatchcodeItem_Click(object sender, EventArgs e)
        {
            if (this.lstbMatchcodes.SelectedIndex > -1)
            {
                this.lstbMatchcodes.Items.RemoveAt(this.lstbMatchcodes.SelectedIndex);
            }
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        -------------------------------------Zum-Löschen-eines-Matchcodecontainers------------------------------------
        **************************************************************************************************************/
        private void btnDelete_Click(object sender, EventArgs e)
        {
            ComboboxItem item = (ComboboxItem)this.cbxMatchcode.SelectedItem;

            if(item != null)
            {
                DialogResult dialogResult = MessageBox.Show("Wollen Sie den Matchcodecontainer \"" + item.Name + "\" wirklich löschen?", "Löschen", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    SqlHelper.SendQueryToDb("Delete From Matchcode Where idMatchcode = " + item.ID);
                    SqlHelper.SendQueryToDb("Delete From MatchcodeItem Where ID_Matchcode = " + item.ID);
                    this.cbxMatchcode.Items.RemoveAt(this.cbxMatchcode.SelectedIndex);
                    this.lstbMatchcodes.Items.Clear();

                    if (this.cbxMatchcode.Items.Count > 0)
                    {
                        this.cbxMatchcode.SelectedIndex = 0;
                    }
                }      
                
            }

        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/



        /*************************************************************************************************************
        -----------------------------------------Zum-Abspeichern-der-Matchcodes---------------------------------------
        **************************************************************************************************************/
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            int i = 0;
            int nMaxMatchcodeItemID = SqlHelper.GetMaxID("idMatchcodeItem", "MatchcodeItem");

            string strMatchcodeItem = "";
            ComboboxItem item = (ComboboxItem)cbxMatchcode.SelectedItem;

            if (item != null)
            {
                SqlHelper.SendQueryToDb("Delete From MatchcodeItem Where ID_Matchcode = " + item.ID);

                for (i = 0; i < lstbMatchcodes.Items.Count; i++)
                {
                    nMaxMatchcodeItemID = nMaxMatchcodeItemID + 1;
                    strMatchcodeItem = lstbMatchcodes.Items[i].ToString();
                    //SqlHelper.SendQueryToDb("Insert into MatchcodeItem values(" + nMaxMatchcodeItemID + ", '" + strMatchcodeItem + "', " + item.ID + ")");

                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = (SqlHelper.GetSqlConnectionString());
                    string strSQL = "Insert into MatchcodeItem values(@nMaxMatchcodeItemID, @strMatchcodeItem, @itemID)";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = strSQL;

                    cmd.Parameters.AddWithValue("@nMaxMatchcodeItemID", nMaxMatchcodeItemID);
                    cmd.Parameters.AddWithValue("@strMatchcodeItem", strMatchcodeItem);
                    cmd.Parameters.AddWithValue("@itemID", item.ID);

                    
                    cmd.Connection = con;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                
                }

                MessageBox.Show("Einträge wurden gespeichert.", "Gespeichert");
            }
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/

    }

}
