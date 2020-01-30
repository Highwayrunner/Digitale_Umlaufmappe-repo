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
    public partial class frmEditFolderActions : Form
    {
        CSqlHelper SqlHelper = new CSqlHelper();

        public frmEditFolderActions()
        {
            InitializeComponent();
            LoadActionsFromDb();
        }

        /*************************************************************************************************************
        ----------------------------------Lädt-alle-Aktionen-aus-der-Datenbank----------------------------------------
        **************************************************************************************************************/
        private void LoadActionsFromDb()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = (SqlHelper.GetSqlConnectionString());

            string strSQL = "Select Bezeichnung From Aktion";

            SqlCommand cmd = new SqlCommand(strSQL, con);
            

            con.Open();


            SqlDataReader reader = cmd.ExecuteReader();
            string strAction = "";

            while (reader.Read())
            {
                strAction = reader["Bezeichnung"].ToString();

                this.lstbExistingActions.Items.Add(strAction);
            }

            reader.Close();
            con.Close();
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/



        /*************************************************************************************************************
        ---------------------------------Löscht-die-Aktion-aus-der-Listbox-raus---------------------------------------
        **************************************************************************************************************/
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int nSelected = this.lstbExistingActions.SelectedIndex;

            if(nSelected > -1)
            {
                this.lstbExistingActions.Items.RemoveAt(nSelected);
            }
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        ---------------------------------Fügt-der-Listbox-einen-Eintrag-hinzu-----------------------------------------
        **************************************************************************************************************/
        private void btnAddAction_Click(object sender, EventArgs e)
        {
            string strNewAction = tbxNewAction.Text;

            if(strNewAction != "")
            {
                this.lstbExistingActions.Items.Add(strNewAction);
                this.tbxNewAction.Clear();
            }
            else
            {
                MessageBox.Show("Bitte geben Sie eine Aktion ein.", "Keine Aktion eingetragen.");
            }

        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        -------------------------------Speichert-die--eingegebenen-Aktionen-in-der-Datenbank--------------------------
        **************************************************************************************************************/
        private void btnSave_Click(object sender, EventArgs e)
        {
            int i = 0;
            int nCount = 0;
            string strItem = "";
            SqlHelper.SendQueryToDb("Delete From Aktion");      //Löscht alle noch vorhandenen Aktionen aus der Datenbank

            //Füllt die Datenbank mit den Einträgen aus der ListView
            for(i = 0; i < lstbExistingActions.Items.Count; i++)
            {
                nCount = i + 1;
                strItem = lstbExistingActions.Items[i].ToString();

                SqlConnection con = new SqlConnection();
                con.ConnectionString = (SqlHelper.GetSqlConnectionString());
                string strSQL = "insert into Aktion values (@nCount, @strItem)";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = strSQL;
                cmd.Parameters.AddWithValue("@nCount", nCount);
                cmd.Parameters.AddWithValue("@strItem", strItem);
               

                cmd.Connection = con;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

    }

}
