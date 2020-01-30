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
    public partial class frmLogin : Form
    {
        /*private string m_strDataBaseConnection = @"Data Source=.\sqlexpress;" +
                                         "Initial Catalog = Laufmappe;" +
                                        "Integrated Security=True";*/
        CSqlHelper SqlHelper = new CSqlHelper();

        private string m_strUsername = "";
        private int m_nUserID = -1;
        private int m_nRights = -1;

        /*************************************************************************************************************
       ----------------------------------------Initialisiert-die-Form-------------------------------------------------
       ***************************************************************************************************************/
        public frmLogin()
        {
            InitializeComponent();
            this.tbxUsername.Text = "Admin";
            this.tbxPassword.Text = "Admin";

            this.tbxUsername.Focus();
        }
       /**************************************************************************************************************
       ***************************************************************************************************************
       ***************************************************************************************************************/




        /**************************************************************************************************************
        --------------------------------------Gibt-die-BenutzerID-zurück-----------------------------------------------
        ***************************************************************************************************************/
        public int GetUserId()
        {
            return m_nUserID;
        }
        /**************************************************************************************************************
        ***************************************************************************************************************
        ***************************************************************************************************************/

        public int GetRights()
        {
            return m_nRights;
        }


        /**************************************************************************************************************
        ---------------------------------Schließt-das-gesamte-Programm-------------------------------------------------
        ***************************************************************************************************************/
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /**************************************************************************************************************
        ***************************************************************************************************************
        ***************************************************************************************************************/



        /**************************************************************************************************************
        -------------------------------Sorgt-dafür,-dass-man-sich-einloggen-kann---------------------------------------
        ***************************************************************************************************************/
        private void btnOK_Click(object sender, EventArgs e)
        {
            string strUsername = this.tbxUsername.Text;
            string strPassword = this.tbxPassword.Text;


            if ((strUsername == "")
            || (strPassword == ""))
            {
                MessageBox.Show("Kein Benutzernamen und/oder Passowort eingetragen.", "Warnung");
                return;
            }

            int nMaxUserID = SqlHelper.GetMaxID("idBenutzer", "Benutzer");

            SqlConnection con = new SqlConnection();
            con.ConnectionString = (SqlHelper.GetSqlConnectionString());

            string strSQL = "select idBenutzer, Benutzername, Passwort, ID_Rechte From Benutzer " +
                            "Where Benutzername = @strUsername";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@strUsername", strUsername);
          //  cmd.Parameters.AddWithValue("@strPassword", strPassword);

            con.Open();


            SqlDataReader reader = cmd.ExecuteReader();
           
            

            string strUsernameDb = "";
            string strPasswordDb = "";

            bool bLogin = false;

            while (reader.Read())
            {
                strUsernameDb = reader["Benutzername"].ToString();
                strPasswordDb = reader["Passwort"].ToString();

                

                if(strUsernameDb == strUsername)
                {
                    bool bHash = SqlHelper.VerifySHA256Hash(strPassword, strPasswordDb);

                    if (bHash)
                    {
                        bLogin = true;
                        m_strUsername = strUsername;
                        m_nUserID = (int)reader["idBenutzer"];
                        m_nRights = (int)reader["ID_Rechte"];
                        break;
                    }
                }
            }

            reader.Close();
            
            


            if (nMaxUserID == 0)
            {
                DateTime dtToday = DateTime.Now;
                con = new SqlConnection();
                con.ConnectionString = (SqlHelper.GetSqlConnectionString());
                strSQL = "Insert Into Benutzer values "
                                + "(@nMaxUserID, @strUserName, @strPassword, @DateTimeToday, @DateTimeToday, 0, @itemRightsID,  '', '', '1970.01.01', 0, '', '')";

                cmd = new SqlCommand();
                cmd.CommandText = strSQL;

                string Hash = SqlHelper.GetSHA256Hash(strPassword);            //SHA256 Hash von Passwort erzeugen
                cmd.Parameters.AddWithValue("@nMaxUserID", 1);
                cmd.Parameters.AddWithValue("@strUserName", "Admin");
                cmd.Parameters.AddWithValue("@strPassword", Hash);

                cmd.Parameters.AddWithValue("@DateTimeToday", dtToday);
                cmd.Parameters.AddWithValue("@itemRightsID", 1);


                cmd.Connection = con;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            if( (!bLogin)
            && (nMaxUserID > 0))
            {
                this.DialogResult = DialogResult.None;
                MessageBox.Show("Benutzername oder Passwort ist falsch.", "Warnung");
            }
            con.Close();
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/
        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                Application.Exit();
            }
        }
        /**************************************************************************************************************
        ***************************************************************************************************************
        ***************************************************************************************************************/
    }

}
