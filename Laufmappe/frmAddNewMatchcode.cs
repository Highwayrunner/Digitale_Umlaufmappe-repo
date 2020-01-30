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
    public partial class frmAddNewMatchcode : Form
    {
        CSqlHelper SqlHelper = new CSqlHelper();

        /*************************************************************************************************************
        ----------------------------------------------Initialisierung-der-Form----------------------------------------
        **************************************************************************************************************/
        public frmAddNewMatchcode()
        {
            InitializeComponent();
            this.tbxMatchcodeName.Focus();
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        ------------------------------------Speichert-einen-neuen-Matchcodecontainder---------------------------------
        **************************************************************************************************************/
        private void btnSave_Click(object sender, EventArgs e)
        {
            string strMatchcodeName = this.tbxMatchcodeName.Text;
           
            if(strMatchcodeName != "")
            {
                
                int nMaxMatchcodeID = SqlHelper.GetMaxID("idMatchcode", "Matchcode");
                nMaxMatchcodeID = nMaxMatchcodeID + 1;
               
                SqlConnection con = new SqlConnection();
                con.ConnectionString = (SqlHelper.GetSqlConnectionString());
                string strSQL = "Insert Into Matchcode values (@nMaxMatchcodeID , @strMatchcodeName)";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = strSQL;

                cmd.Parameters.AddWithValue("@nMaxMatchcodeID", nMaxMatchcodeID);
                cmd.Parameters.AddWithValue("@strMatchcodeName", strMatchcodeName);
                cmd.Connection = con;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                this.DialogResult = DialogResult.None;
                MessageBox.Show("Bitte tragen Sie einen Namen ein.", "Warnung");
            }

        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/
    }
}
