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
    public partial class frmShowFolderHistory : Form
    {
        private int m_nFolderID = -1;
        CSqlHelper SqlHelper = new CSqlHelper();


        public class myListView : ListViewItem
        {
            public string Bearbeiter { get; set; }
            public string Aktion {get; set;}
            public string Weitergereicht_Am { get; set; }

            public int MappeID { get; set; }
            public int Status { get; set; }

            public myListView(string Name)
            {
                this.Text = Name;
            }
        } 




        public frmShowFolderHistory(int nFolderID, string strFolderName)
        {
            InitializeComponent();

            m_nFolderID = nFolderID;
            this.tbxFolderName.Text = strFolderName;

            LoadUserChronicFromDb();
        }


        private void LoadUserChronicFromDb()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = (SqlHelper.GetSqlConnectionString());

            
            string strSQL = "select distinct BearbChron.Weitergereicht_Am, Ben.Benutzername, Akt.Bezeichnung, OrdAkt.Status From Bearbeitungschronik BearbChron " + 
                            "join Benutzer Ben " +
                            "on Ben.idBenutzer = BearbChron.ID_Vorheriger_Benutzer " +
                            "join Ordneraktionen OrdAkt " +
                            "on OrdAkt.ID_Ordner = BearbChron.ID_Ordner and BearbChron.ID_Vorheriger_Benutzer = OrdAkt.ID_benutzer " +
                            "and OrdAkt.idOrdneraktionen = BearbChron.ID_Ordneraktionen " +
                            "join Aktion Akt " +
                            "on OrdAkt.ID_Aktion = Akt.idAktion " +
                            "Where BearbChron.ID_Ordner =  @m_nFolderID " + 
                            "Order by BearbChron.Weitergereicht_Am";




            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@m_nFolderID", m_nFolderID);

            con.Open();


            SqlDataReader reader = cmd.ExecuteReader();
            string strUserName = "";
            string strContinueDate = "";
            string strAction = "";
            int nStatus = 0;
            DateTime dtContinueDate;

            while (reader.Read())
            {
                strUserName = reader["Benutzername"].ToString();
                strAction = reader["Bezeichnung"].ToString();
                nStatus = (int)reader["Status"];

                dtContinueDate = (DateTime)reader["Weitergereicht_Am"];
                strContinueDate = dtContinueDate.ToString("dd/MM/yyyy HH:mm:ss");

                if (strUserName != "")
                {
                    ListViewItem lvi = this.lstvShowHistory.Items.Add(strUserName);    // Neue Zeile und erste Spalte
                    lvi.SubItems.Add(strContinueDate);          // 2. Spalte
                    lvi.SubItems.Add(strAction);

                    if (nStatus == 0)
                    {
                        lvi.SubItems.Add("Nicht Erledigt"); 
                    }
                    else if (nStatus == 1)
                    {
                        lvi.SubItems.Add("Erledigt");
                    }
                }
            }

            reader.Close();
            con.Close();
        }



        private void btnOK_Click(object sender, EventArgs e)
        {

        }
    }
}
