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
    public partial class frmShowStaffData : Form
    {
        CSqlHelper SqlHelper = new CSqlHelper();

        public class ListBoxItem
        {
            public int ID { get; set; }
            public int Gender { get; set; }

            public string Username { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Job { get; set; }
            public string ImagePath { get; set; }

            public DateTime Birthdate { get; set; }

            public override string ToString()
            {
                return Username;
            }
        }

        public frmShowStaffData()
        {
            InitializeComponent();
            LoadUserNamesFromDb();
        }


        private void LoadUserNamesFromDb()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = (SqlHelper.GetSqlConnectionString());

            string strSQL = "Select Benutzername, Vorname, Nachname, Geburtsdatum, Geschlecht, Beruf, Bild From Benutzer";

            SqlCommand cmd = new SqlCommand(strSQL, con);
            

            con.Open();


            SqlDataReader reader = cmd.ExecuteReader();
            

            while (reader.Read())
            {
                ListBoxItem item = new ListBoxItem();

                item.Username = reader["Benutzername"].ToString();
                item.FirstName = reader["Vorname"].ToString();
                item.LastName = reader["Nachname"].ToString();
                item.Job = reader["Beruf"].ToString();
                item.ImagePath = reader["Bild"].ToString();

                item.Gender = (int)reader["Geschlecht"];
                item.Birthdate = (DateTime)reader["Geburtsdatum"];
                this.lstbUsers.Items.Add(item);
            }

            reader.Close();
            con.Close();
        }



        private void lstbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxItem item = (ListBoxItem)this.lstbUsers.SelectedItem;

            if (item != null)
            {
                this.tbxFirstname.Text = item.FirstName;
                this.tbxLastname.Text = item.LastName;
                this.tbxJob.Text = item.Job;

                this.dtpBirthdate.Value = item.Birthdate;
                if (item.Gender == 0)
                {
                    this.tbxGender.Text = "Männlich";
                }
                else
                {
                    this.tbxGender.Text = "Weiblich";
                }


                Image imgContact;
                
                if(item.ImagePath != "")
                {
                    imgContact = Image.FromFile(item.ImagePath);
                    this.pcbUserImage.Image = imgContact;

                }
                else
                {
                    this.pcbUserImage.Image = Laufmappe.Properties.Resources.user_male_128;   
                }



            }

        }

        private void frmShowStaffData_Load(object sender, EventArgs e)
        {

        }

    }

}
