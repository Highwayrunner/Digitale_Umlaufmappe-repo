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
using System.IO;

namespace Laufmappe
{
  
    public partial class frmPersonalData : Form
    {
        private int m_nUserID;
        private string m_strUserImage;
        CSqlHelper SqlHelper = new CSqlHelper();



        public void SetUserID(int nUserID)
        {
            m_nUserID = nUserID;
            LoadPersonalData();     //Lädt die persönlichen Daten auf die Form
        }





        public frmPersonalData()
        {
            InitializeComponent();
        }





        /*************************************************************************************************************
        -----------------------------Funktion-zum-abspeichern-der-persönlichen-Daten----------------------------------
        **************************************************************************************************************/
        private void btnSave_Click(object sender, EventArgs e)
        {
            string strFirstName = this.tbxFirstName.Text;
            string strLastName = this.tbxLastName.Text;
            string strJob = this.tbxJob.Text;
            int bFemale = 0;
            string strBirthdate = this.dtpBirthdate.Value.ToString("yyyy-MM-dd");
       
            if(this.cmbxGender.SelectedIndex == 0)
            {
                bFemale = 0;
            }
            else if(this.cmbxGender.SelectedIndex == 1)
            {
                bFemale = 1;
            }

            /*SqlHelper.SendQueryToDb("UPDATE Benutzer " +
                                    "SET Vorname =" + "'" + strFirstName + "'" + ", Nachname = " + "'" + strLastName + "', " + "Beruf = " + "'" + strJob + "', " + "Geschlecht = " + bFemale + ", " + "Bild = " + "'" + m_strUserImage + "' " + ", Geburtsdatum = '" + strBirthdate + "' " +
                                    "WHERE idBenutzer = "+ m_nUserID);*/
            SqlConnection con = new SqlConnection();
            con.ConnectionString = (SqlHelper.GetSqlConnectionString());
            string strSQL = "UPDATE Benutzer " +
                            "SET Vorname = @strFirstName, Nachname = @strLastName, Beruf = @strJob, Geschlecht = @bFemale, Bild = @m_strUserImage, Geburtsdatum = @strBirthdate "+ 
                            "WHERE idBenutzer = @m_nUserID";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = strSQL;

            cmd.Parameters.AddWithValue("@strFirstName", strFirstName);
            cmd.Parameters.AddWithValue("@strLastName", strLastName);
            cmd.Parameters.AddWithValue("@strJob", strJob);

            cmd.Parameters.AddWithValue("@bFemale", bFemale);
            cmd.Parameters.AddWithValue("@m_strUserImage", m_strUserImage);
            cmd.Parameters.AddWithValue("@strBirthdate", strBirthdate);

            cmd.Parameters.AddWithValue("@m_nUserID", m_nUserID);

            cmd.Connection = con;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


            MessageBox.Show("Daten wurden gespeichert", "Gespeichert");
            this.Close();
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/



        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        /*************************************************************************************************************
        ---------------------------------------Funktion-zum-Laden-des-Bildes------------------------------------------
        **************************************************************************************************************/
        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdImage = new OpenFileDialog();
            ofdImage.Title = "Bild auswählen";
            ofdImage.Multiselect = false;
            ofdImage.Filter = "Bilder|*.png;*.bmp;*.jpg";
            DialogResult DR = ofdImage.ShowDialog();

            Image imgContact;
            if (DR == DialogResult.OK)
            {
                imgContact = Image.FromFile(ofdImage.FileName);
                this.pcbUserImage.Image = imgContact;
                m_strUserImage = ofdImage.FileName;
            }
            else
            {
                this.pcbUserImage.Image = Laufmappe.Properties.Resources.user_male_128;
                m_strUserImage = "";
            }

        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        ------------------------------------Daten-werden-in-die-Textboxen-geladen-------------------------------------
        **************************************************************************************************************/
        private void LoadPersonalData()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = (SqlHelper.GetSqlConnectionString());

            string strSQL = "SELECT Benutzername, Vorname, Nachname, Geburtsdatum, Beruf, Bild, Geschlecht, Bezeichnung " +
                            "FROM Benutzer Join Rechte on idRechte = ID_Rechte " +
                            "WHERE idBenutzer = @m_nUserID";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@m_nUserID", m_nUserID);

            con.Open();


            SqlDataReader reader = cmd.ExecuteReader();
            int nGender = 0;
            Image imgContact;

            while (reader.Read())
            {
                this.tbxUsername.Text = reader["Benutzername"].ToString();
                this.tbxRights.Text = reader["Bezeichnung"].ToString();
                
                this.tbxFirstName.Text = reader["Vorname"].ToString();
                this.tbxLastName.Text = reader["Nachname"].ToString();
                this.tbxJob.Text = reader["Beruf"].ToString();
                this.dtpBirthdate.Value = (DateTime)reader["Geburtsdatum"];
                
                nGender = (int)reader["Geschlecht"];

                m_strUserImage = reader["Bild"].ToString();

                if (File.Exists(m_strUserImage))
                {
                    imgContact = Image.FromFile(m_strUserImage);
                    this.pcbUserImage.Image = imgContact;
                }

                if (nGender == 0)       //Männlich
                {
                    this.cmbxGender.SelectedIndex = 0;
                }
                else if (nGender == 1)  //Weiblich     
                {
                    this.cmbxGender.SelectedIndex = 1;
                }
            }

            reader.Close();
            con.Close();
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        ----------------------------------------Funktion-zum-Löschen-des-Bildes---------------------------------------
        **************************************************************************************************************/
        private void btnDeleteImage_Click(object sender, EventArgs e)
        {
            this.pcbUserImage.Image = Laufmappe.Properties.Resources.user_male_128;
            m_strUserImage = "";
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/
    }





}
