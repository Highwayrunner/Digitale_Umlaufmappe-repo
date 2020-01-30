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
    public partial class frmTransferFolder : Form
    {
        CSqlHelper SqlHelper = new CSqlHelper();
        private int m_nUserID = -1;

        public class ListBoxItem
        {
            public string Name { get; set; }
            public int ID { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }




        public frmTransferFolder(int nFolderUserID, string strFolderName)
        {
            InitializeComponent();

            SetFolderUser(nFolderUserID);
            LoadUserFromDb();

            this.tbxFolderName.Text = strFolderName;
        }

        private void SetFolderUser(int nFolderUserID)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = (SqlHelper.GetSqlConnectionString());

            string strSQL = "Select Benutzername From Benutzer Where idBenutzer = @nFolderUserID";

            SqlCommand cmd = new SqlCommand(strSQL, con);
            con.Open();
            cmd.Parameters.AddWithValue("@nFolderUserID", nFolderUserID);

            SqlDataReader reader = cmd.ExecuteReader();
            string strFolderUserName = "";

            while (reader.Read())
            {
                strFolderUserName = reader["Benutzername"].ToString();
            }

            this.tbxCurrentFolderUser.Text = strFolderUserName;
            reader.Close();
            con.Close();
        }




        private void LoadUserFromDb()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = (SqlHelper.GetSqlConnectionString());

            string strSQL = "Select idBenutzer, Benutzername From Benutzer";

            SqlCommand cmd = new SqlCommand(strSQL, con);
            con.Open();


            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListBoxItem item = new ListBoxItem(); 
                
                item.Name = reader["Benutzername"].ToString();
                item.ID = (int)reader["idBenutzer"];

                this.lstbUser.Items.Add(item);
            }

            reader.Close();
            con.Close();
        }




        private void btnTransfer_Click(object sender, EventArgs e)
        {
            ListBoxItem item = (ListBoxItem)this.lstbUser.SelectedItem;

            if (item != null)
            {
                DialogResult dialogResult = MessageBox.Show("Wollen Sie den Benutzer der Mappe wirklich ändern?", "Warnung!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    m_nUserID = item.ID;
                }
                else if (dialogResult == DialogResult.No)
                {
                    this.DialogResult = DialogResult.None;
                    MessageBox.Show("Die Mappe hat ihren Besitzer nicht gewechselt.", "Achtung!");
                }

                

            }
            else
            {
                this.DialogResult = DialogResult.None;
                MessageBox.Show("Sie haben keinen Benutzer ausgewählt.", "Warnung!");
            }
        }




        public int GetUserID()
        {
            return m_nUserID;
        }




        private void lstbUser_DoubleClick(object sender, EventArgs e)
        {
            ListBoxItem item = (ListBoxItem)this.lstbUser.SelectedItem;

            if (item != null)
            {
                DialogResult dialogResult = MessageBox.Show("Wollen Sie die Mappe wirklich an \"" + item.Name + "\" übergeben", "Warnung!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    m_nUserID = item.ID;
                    this.DialogResult = DialogResult.OK;
                }
                else if (dialogResult == DialogResult.No)
                {
                    this.DialogResult = DialogResult.None;
                    MessageBox.Show("Die Mappe hat ihren Besitzer nicht gewechselt.", "Achtung!");
                }



            }
            else
            {
                this.DialogResult = DialogResult.None;
                MessageBox.Show("Sie haben keinen Benutzer ausgewählt.", "Warnung!");
            }
        }
    }
}
