using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;


namespace Laufmappe
{
    class CSqlHelper
    {
        private int[] m_nDatePos = new int[8];
        private int[] m_nTimePos = new int[6];

        enum enDateTime{
                            Year1,
                            Year2,
                            Year3,
                            Year4,

                            Month1,
                            Month2,

                            Day1,
                            Day2,

                            Hour1,
                            Hour2,

                            Minute1,
                            Minute2,

                            Second1,
                            Second2,
                        };
      /*  private string m_strDataBaseConnection = @"Data Source=.\sqlexpress;" +
                                         "Initial Catalog = Umlaufmappe;" +
                                        "Integrated Security=True";*/

        private string m_strDataBaseConnection = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;

        public CSqlHelper()
        {
            for (int i = 0; i < m_nDatePos.Length; i++)
            {
                m_nDatePos[i] = i;
            }

            for (int i = 0; i < m_nTimePos.Length; i++)
            {
                m_nTimePos[i] = i + m_nDatePos.Length;
            }
        }


        public string GetSqlConnectionString()
        {
            return m_strDataBaseConnection;
        }



        /*************************************************************************************************************
        ------------------------------Funktion-zum-Absetzen-einer-SQL-Abfrage-----------------------------------------
        **************************************************************************************************************/
        public void SendQueryToDb(string strSQL)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = (m_strDataBaseConnection);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = strSQL;
            cmd.Connection = con;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        -------------------------Gibt-den-größten-Wert-der-angegebenen-Spalte-aus-------------------------------------
        **************************************************************************************************************/
        public int GetMaxID(string strColumn, string Table)
        {
            int nMaxID = 0;

            string strMaxIDTest = "";

            SqlConnection con = new SqlConnection();
            con.ConnectionString = (m_strDataBaseConnection);

            string strSQL = "SELECT MAX(" + strColumn + ") as MaxID FROM " + Table + ";";

            SqlCommand cmd = new SqlCommand(strSQL, con);


            con.Open();


            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                strMaxIDTest = reader["MaxID"].ToString();

                if (strMaxIDTest != "")
                {
                    nMaxID = (int)reader["MaxID"];
                }
                else
                {
                    nMaxID = 0;
                }

            }

            reader.Close();
            con.Close();

            return nMaxID;
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/



        public string GetSHA256Hash(string input)
        {
            //Umwandlung des Eingastring in den SHA256 Hash
            System.Security.Cryptography.SHA256 SHA256 = new System.Security.Cryptography.SHA256CryptoServiceProvider();
            byte[] textToHash = Encoding.Default.GetBytes(input);
            byte[] result = SHA256.ComputeHash(textToHash);

            //SHA256 Hash in String konvertieren
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in result)
            {
                s.Append(b.ToString("x2").ToLower());
            }

            return s.ToString();
        }


        
        public bool VerifySHA256Hash(string input, string hash)
        {
            System.Security.Cryptography.SHA256 SHA256 = new System.Security.Cryptography.SHA256CryptoServiceProvider();
            // Hash the input.
            string hashOfInput = GetSHA256Hash(input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.CurrentCulture;//.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void SetDateTimeMix(int nYear1, int nYear2, int nYear3, int nYear4, int nMonth1, int nMonth2, int nDay1, int nDay2, int nHour1, int nHour2, int nMinute1, int nMinute2, int nSecond1, int nSecond2)
        {
            m_nDatePos[0] = nYear1;
            m_nDatePos[1] = nYear2;
            m_nDatePos[2] = nYear3;
            m_nDatePos[3] = nYear4;

            m_nDatePos[4] = nMonth1;
            m_nDatePos[5] = nMonth2;

            m_nDatePos[6] = nDay1;
            m_nDatePos[7] = nDay2;


            m_nTimePos[0] = nHour1;
            m_nTimePos[1] = nHour2;

            m_nTimePos[2] = nMinute1;
            m_nTimePos[3] = nMinute2;

            m_nTimePos[4] = nSecond1;
            m_nTimePos[5] = nSecond2;
        }



        public string GetMixedDateTime(DateTime dtOrgDateTime)
        {
            string strOrgDateTime = GetDateTimeInNumberString(dtOrgDateTime);
            string strNewDatetime = "";
            int i = 0;

            for (i = 0; i < m_nDatePos.Length; i++)
            {
                strNewDatetime += strOrgDateTime[m_nDatePos[i]];
            }

            for (i = 0; i < m_nTimePos.Length; i++)
            {
                strNewDatetime += strOrgDateTime[m_nTimePos[i]];
            }

            return strNewDatetime;

        }


        public string GetDateTimeInNumberString(DateTime dtDateTime)
        {
            string strDate = "";
            
            string strYear = dtDateTime.Year.ToString();
            string strMonth = dtDateTime.Month.ToString();
            string strDay = dtDateTime.Day.ToString();

            string strHour = dtDateTime.Hour.ToString();
            string strMinutes = dtDateTime.Minute.ToString();
            string strSeconds = dtDateTime.Second.ToString();

            if (strYear.Length < 4)
            {
                int nFillUp = 4 - strYear.Length;

                for (int i = 0; i < nFillUp; i++)
                {
                    strYear = strYear.Insert(0, "0");
                }
            }



            if (strMonth.Length < 2)
            {
                strMonth = strMonth.Insert(0, "0");
            }


            if (strDay.Length < 2)
            {
                strDay = strDay.Insert(0, "0");
            }


            if (strHour.Length < 2)
            {
                strHour = strHour.Insert(0, "0");
            }


            if (strMinutes.Length < 2)
            {
                strMinutes = strMinutes.Insert(0, "0");
            }


            if (strSeconds.Length < 2)
            {
                strSeconds = strSeconds.Insert(0, "0");
            }

            strDate = strYear + strMonth + strDay + strHour + strMinutes + strSeconds;

            return  strDate;
        }
    }

}
