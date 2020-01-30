using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Runtime.InteropServices;



namespace Laufmappe
{

    enum enRights
    { 
        User = 0,
        Admin = 1
    };

    public partial class frmMain : Form
    {
        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(System.Int32 vKey);

        private int m_nUserID = -1;     //Der gerade eingeloggte Benutzer   
        private int m_nRights = -1;     //Die Rechte des Benutzers
        private clsCopyDocument m_CopyDocument = new clsCopyDocument();     //Klasse zum Kopieren und Einfügen von Dokumenten
        private const string m_strTempFolder = "C:\\Temp\\";
        private string m_strTempViewerFile = "";

        private List<clsTempFile> m_lstTempWorkingFiles = new List<clsTempFile>();
        private static List<clsRunningPrograms> m_lstRunningPrograms = new List<clsRunningPrograms>();
        private static bool m_bMouseLeftPressed = false;
        private static bool m_bMouseLeftClicked = false;

        System.Windows.Forms.Timer m_Timer = new System.Windows.Forms.Timer();
        


        class clsRunningPrograms
        {
            private System.Diagnostics.Process m_Program = null;
            private string m_strFilePath;
            private clsTempFile m_TempFileInfo;

            public clsRunningPrograms()
            {
                m_Program = null;
                m_strFilePath = "";
            }

            public clsRunningPrograms(string strFilePath, clsTempFile TempFileInfo)
            {
                m_strFilePath = strFilePath;
                Process.Start(strFilePath);
                m_TempFileInfo = TempFileInfo;
            }

            public void OpenFile(string strFilePath, clsTempFile TempFileInfo)
            {
                m_strFilePath = strFilePath;
                Process.Start(strFilePath);
                m_TempFileInfo = TempFileInfo;
            }

            public System.Diagnostics.Process GetProcess()
            { 
                return m_Program;
            }


            public clsTempFile GetTempFileInfo()
            {
                return m_TempFileInfo;
            }
        }


        class clsTempFile
        {
            private int m_nDocumentID = 0;
            private string m_strDocumentName = "";
            private string m_strTempFileName = "";
            private string m_strChecksum = "";
            private DateTime m_dtCreationTime ;
            private myTreeNode m_Node = null;

            public clsTempFile(int nDocumentID, string strTempFileName, string strDocumentName, DateTime dtCreationTime, myTreeNode Node)
            {
                m_nDocumentID = nDocumentID;
                m_strTempFileName = strTempFileName;
                m_strDocumentName = strDocumentName;
                m_dtCreationTime = new DateTime(dtCreationTime.Year, dtCreationTime.Month, dtCreationTime.Day, dtCreationTime.Hour, dtCreationTime.Minute, dtCreationTime.Second, dtCreationTime.Millisecond);
                m_Node = Node;
            }

            public myTreeNode GetNode()
            {
                return m_Node;
            }

            public int GetDocumentID()
            {
                return m_nDocumentID;
            }

            public string GetDocumentName()
            {
                return m_strDocumentName;
            }

            public string GetTempFileName()
            {
                return m_strTempFileName;
            }

            public string GetChecksum()
            {
                return m_strChecksum;
            }

            public void SetChecksum(string strChecksum)
            {
                m_strChecksum = strChecksum;
            }
        }

        //Klasse zum Zwischenspeichern von Dokumenten 
        class clsCopyDocument
        {
            public string m_strNodeName { get; set; }       //Name des Dokumentes
            public string m_strFileExtension { get; set; }

            public int m_nFolderID { get; set; }            //OrdnerID
            public int m_nDocumentID { get; set; }          //DokumentID
            public int m_nUserID { get; set; }              //Benutzer
            public int m_nUserGroupID { get; set; }         //Benutzergruppe

            public DateTime m_dtCreateDate;
            public DateTime m_dtEditDate;
            public DateTime m_dtAddDate;

            public bool m_bIsEmpty { get; set; }
            public byte[] m_byFileBLOB { get; set; }

            public bool m_bNodeCreatedInSession = false;

            public clsCopyDocument()
            {
                m_strNodeName = "";
            
                m_nFolderID = -1;
                m_nDocumentID = -1;

                m_nUserID = -1;
                m_bIsEmpty = true;
                m_byFileBLOB = null;
                m_strFileExtension = "";
                m_bNodeCreatedInSession = false;
            }


            public void SetDates(DateTime dtCreateDate, DateTime dtEditDate, DateTime dtAddDate)
            {
                m_dtCreateDate = new DateTime(dtCreateDate.Year, dtCreateDate.Month, dtCreateDate.Day, dtCreateDate.Hour, dtCreateDate.Minute, dtCreateDate.Second, dtCreateDate.Millisecond);
                m_dtEditDate = new DateTime(dtEditDate.Year, dtEditDate.Month, dtEditDate.Day, dtEditDate.Hour, dtEditDate.Minute, dtEditDate.Second, dtEditDate.Millisecond);
                m_dtAddDate = new DateTime(dtAddDate.Year, dtAddDate.Month, dtAddDate.Day, dtAddDate.Hour, dtAddDate.Minute, dtAddDate.Second, dtAddDate.Millisecond);
            }


            public void GetDates(ref DateTime dtCreateDate, ref DateTime dtEditDate, ref DateTime dtAddDate)
            {
                dtCreateDate = new DateTime(m_dtCreateDate.Year, m_dtCreateDate.Month, m_dtCreateDate.Day, m_dtCreateDate.Hour, m_dtCreateDate.Minute, m_dtCreateDate.Second, m_dtCreateDate.Millisecond);
                dtEditDate = new DateTime(m_dtEditDate.Year, m_dtEditDate.Month, m_dtEditDate.Day, m_dtEditDate.Hour, m_dtEditDate.Minute, m_dtEditDate.Second, m_dtEditDate.Millisecond);
                dtAddDate = new DateTime(m_dtAddDate.Year, m_dtAddDate.Month, m_dtAddDate.Day, m_dtAddDate.Hour, m_dtAddDate.Minute, m_dtAddDate.Second, m_dtAddDate.Millisecond);
            }

           
            //Löscht alle Einträge aus der Klasse
            public void Clear()
            {
                m_strNodeName = "";
                m_nFolderID = -1;
                m_nDocumentID = -1;
                m_nUserID = -1;
                m_bIsEmpty = true;

                m_byFileBLOB = null;
                m_strFileExtension = "";
            }
        }


        class myTreeNode : TreeNode
        {
            private string m_strNodeName;
            
            private int m_nFolderID;
            private int m_nDocumentID;
            private int m_nUserID;


            private byte[] m_byFileBLOB;
            private string m_strFileExtension;

            private DateTime m_dtCreateDate;
            private DateTime m_dtEditDate;
            private DateTime m_dtAddDate;
            private bool m_bNodeCreatedInSession = false;
            
            /*************************************************************************************************************
            ---------------------------Funktion-zum-Erstellen-einer-eigenen-TreeNode--------------------------------------
            **************************************************************************************************************/
            public myTreeNode(int nUserID, int nFolderID, string strNodeName, bool bNodeCreatedInSession = false, int nDocumentID = -1, string strFileExtension = "", byte[] byFileBLOB = null)
            {
                m_nUserID = nUserID;                    //Speichert die UserID
                m_nFolderID = nFolderID;                //Speichert die Ordner-ID
                m_strNodeName = strNodeName;            //Speichert sich den Namen der Node
                m_nDocumentID = nDocumentID;            //Speichert sich die Dokument ID falls vorhanden
                m_byFileBLOB = byFileBLOB;
                m_strFileExtension = strFileExtension;
                this.Text = strNodeName;                //Zum Anzeigen des Textes im TreeView
                m_bNodeCreatedInSession = bNodeCreatedInSession;
            }
            /*************************************************************************************************************
            **************************************************************************************************************
            **************************************************************************************************************/

            public DateTime GetCreateDate()
            {
                return m_dtCreateDate;
            }

            public DateTime GetEditDate()
            {
                return m_dtEditDate;
            }

            public DateTime GetAddDate()
            {
                return m_dtAddDate;
            }




            public byte[] GetFileBLOB()
            {
                if (m_byFileBLOB == null)
                {
                    return null;
                }

                byte[] byFileBLOB = new byte[m_byFileBLOB.Length];
                m_byFileBLOB.CopyTo(byFileBLOB, 0);

                return m_byFileBLOB;
            }


            /*************************************************************************************************************
            ----------------------------------Gibt-die-UserID-der-Node-zurück---------------------------------------------
            **************************************************************************************************************/
            public int GetUserID()
            {
                return m_nUserID;
            }
            /*************************************************************************************************************
            **************************************************************************************************************
            **************************************************************************************************************/




            /*************************************************************************************************************
            ------------------------------Gibt-die-Ordner-ID,-die-an-der-Node-hängt-zurück--------------------------------
            **************************************************************************************************************/
            public int GetFolderID()
            {
                return m_nFolderID;
            }
            /*************************************************************************************************************
            **************************************************************************************************************
            **************************************************************************************************************/




            /*************************************************************************************************************
            ------------------------------------------Gibt-den-Nodenamen-zurück-------------------------------------------
            **************************************************************************************************************/
            public string GetNodeName()
            {
                return m_strNodeName;
            }
            /*************************************************************************************************************
            **************************************************************************************************************
            **************************************************************************************************************/


            /*************************************************************************************************************
            ------------------------------------------Gibt-die-DokumentID-zurück------------------------------------------
            **************************************************************************************************************/
            public int GetDocumentID()
            {
                return m_nDocumentID;
            }
            /*************************************************************************************************************
            **************************************************************************************************************
            **************************************************************************************************************/

            public string GetFileExtension()
            {
                return m_strFileExtension;
            }


            public void GetDates(ref DateTime dtCreateDate, ref DateTime dtEditDate, ref DateTime dtAddDate)
            {
                dtCreateDate = new DateTime(m_dtCreateDate.Year, m_dtCreateDate.Month, m_dtCreateDate.Day, m_dtCreateDate.Hour, m_dtCreateDate.Minute, m_dtCreateDate.Second, m_dtCreateDate.Millisecond);
                dtEditDate = new DateTime(m_dtEditDate.Year, m_dtEditDate.Month, m_dtEditDate.Day, m_dtEditDate.Hour, m_dtEditDate.Minute, m_dtEditDate.Second, m_dtEditDate.Millisecond);
                dtAddDate = new DateTime(m_dtAddDate.Year, m_dtAddDate.Month, m_dtAddDate.Day, m_dtAddDate.Hour, m_dtAddDate.Minute, m_dtAddDate.Second, m_dtAddDate.Millisecond);
            }


            public bool WasNodeCreatedInSession()
            {
                return m_bNodeCreatedInSession;
            }

            public void SetFileExtension(string strFileExtension)
            {
                m_strFileExtension = strFileExtension;
            }


            public void SetFileBLOB(byte[] byFileBLOB)
            {
                m_byFileBLOB = byFileBLOB;
            }


           /*************************************************************************************************************
           ------------------------------------Setzt-die-UserID,-die-an-der-Node-hängt-----------------------------------
           **************************************************************************************************************/
            public void SetUserID(int nUserID)
            {
                m_nUserID = nUserID;
            }
            /*************************************************************************************************************
            **************************************************************************************************************
            **************************************************************************************************************/




            /*************************************************************************************************************
            ------------------------------Setzt-die-Ordner-ID,-die-an-der-Node-hängt-zurück-------------------------------
            **************************************************************************************************************/
            public void SetFolderID(int nFolderID)
            {
                m_nFolderID = nFolderID;
            }
            /*************************************************************************************************************
            **************************************************************************************************************
            **************************************************************************************************************/




            /*************************************************************************************************************
            -----------------------------------------Setzt-den-Nodenamen-zurück-------------------------------------------
            **************************************************************************************************************/
            public void SetNodeName(string strNodeName)
            {
                m_strNodeName = strNodeName;
                this.Text = m_strNodeName;
            }
            /*************************************************************************************************************
            **************************************************************************************************************
            **************************************************************************************************************/


            /*************************************************************************************************************
            ------------------------------------------Setzt-die-DokumentID------------------------------------------------
            **************************************************************************************************************/
            public void SetDocumentID(int nDocumentID)
            {
                m_nDocumentID = nDocumentID;
            }
            /*************************************************************************************************************
            **************************************************************************************************************
            **************************************************************************************************************/


            public void SetDates(DateTime dtCreateDate, DateTime dtEditDate, DateTime dtAddDate)
            {
                m_dtCreateDate = new DateTime(dtCreateDate.Year, dtCreateDate.Month, dtCreateDate.Day, dtCreateDate.Hour, dtCreateDate.Minute, dtCreateDate.Second, dtCreateDate.Millisecond);
                m_dtEditDate = new DateTime(dtEditDate.Year, dtEditDate.Month, dtEditDate.Day, dtEditDate.Hour, dtEditDate.Minute, dtEditDate.Second, dtEditDate.Millisecond);
                m_dtAddDate = new DateTime(dtAddDate.Year, dtAddDate.Month, dtAddDate.Day, dtAddDate.Hour, dtAddDate.Minute, dtAddDate.Second, dtAddDate.Millisecond);
            }


            public void SetEditDate(DateTime dtEditDate)
            {
                m_dtEditDate = new DateTime(dtEditDate.Year, dtEditDate.Month, dtEditDate.Day, dtEditDate.Hour, dtEditDate.Minute, dtEditDate.Second, dtEditDate.Millisecond);
            }
        }


        private CSqlHelper SqlHelper = new CSqlHelper();

        
       /* public string m_strDataBaseConnection = @"Data Source=.\sqlexpress;" +
                                         "Initial Catalog = Laufmappe;" +
                                        "Integrated Security=True";*/
     /*    public string m_strDataBaseConnection = @"Data Source=.\sqlexpress;" +
                                                 @"AttachDbFilename=L:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\NicosDb.mdf;" +
                                                 "Integrated Security=True;" +
                                                 "User Instance=True";*/
      
        public frmMain()
        {
            InitializeComponent();
         
            //Startet den Einlog-Dialog
            frmLogin LoginForm = new frmLogin();
            LoginForm.ShowDialog();

            m_nUserID = LoginForm.GetUserId();        //BenutzerID speichern 
            m_nRights = LoginForm.GetRights();        //Benutzerrechte speichern

            SetOnlineStatusInDb(1);     //setzt den Onlinestatus des gerade eingeloggten Benutzers

            EditMenu();                     //Legt die Buttons fest, die nur mit Berechtigung gedrückt werden können
            DeactivateButtonsOnStart();     //Deaktiviert beim Start des Programmes ein paar Buttons

            wbBrwShowPDF.Dock = DockStyle.Fill;     //Hängt das Webbrowsercontrol an die Ränder der rechten Hälfte
            pcbImage.Dock = DockStyle.Fill;         //Hängt die Bildanzeige an die Ränder der linken Hälfte        
            pcbImage.Visible = false;               //Macht die Bildanzeige unsichtbar

            FillTreeViewWithDocsAndFolders();
            tsbSaveDocumentsInDatabase.Enabled = false;


            m_Timer.Interval = 10; // specify interval time as you want
            m_Timer.Tick += new EventHandler(OnTimedEvent);
            m_Timer.Start();
        }

        private static void OnTimedEvent(object source, EventArgs e)
        {
            if (m_bMouseLeftClicked)
            {
                Debug.WriteLine("Geht");
                AnyWorkToSave();
            }
                

            if( (!m_bMouseLeftPressed)
            &&  (0 > GetAsyncKeyState(0x1)) )
            {
                m_bMouseLeftClicked = true;
            }
            else
                m_bMouseLeftClicked = false;

            if (0 > GetAsyncKeyState(0x1))
            {
                m_bMouseLeftPressed = true;
            }
            else
            {
                m_bMouseLeftPressed = false;
                m_bMouseLeftClicked = false;
            }
       }


        private static void AnyWorkToSave()
        {
            for (int i = 0; i < m_lstRunningPrograms.Count; i++)
            {
                System.Diagnostics.Process Process = m_lstRunningPrograms[i].GetProcess();

                if (Process != null)
                {
                    if (Process.HasExited)
                    {
                        SaveFile(i);
                        m_lstRunningPrograms.RemoveAt(i);
                        i--;
                    }
                }

            }

        }


        private static void SaveFile(int nClosedProgramPos)
        {
         /*   string strTempFilePath = "";
            string strChecksumTempFile = "";
            byte[] byFileBLOB = null;


            strTempFilePath = m_strTempFolder + m_lstRunningPrograms[nClosedProgramPos].GetTempFileInfo().GetTempFileName();

            FileInfo fi1 = new FileInfo(strTempFilePath);
            byFileBLOB = GetBLOB(strTempFilePath);


            strChecksumTempFile = GetBLOBChecksum(byFileBLOB, fi1.CreationTime, fi1.LastWriteTime);

            if (strChecksumTempFile == m_lstRunningPrograms[nClosedProgramPos].GetTempFileInfo().GetChecksum())
            {
                return;
            }




            if (MessageBox.Show("Wollen Sie die Änderungen an dem Dokument " + m_lstRunningPrograms[nClosedProgramPos].GetTempFileInfo().GetDocumentName() + " bestätigen?", "Speichern", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = (SqlHelper.GetSqlConnectionString());
                con.Open();

                DateTime ctEditDate = DateTime.Now;
                string strOpenFiles = "";


                myTreeNode DocNode = m_lstRunningPrograms[nClosedProgramPos].GetTempFileInfo().GetNode();

                string strSQL = "";
                string strAddDate = SqlHelper.GetDateTimeInNumberString(DocNode.GetAddDate());
                int nOldDocCheckPK = GetBLOBPrimaryKey(DocNode.GetFileBLOB(), strAddDate);
                int nNewDocCheckPK = GetBLOBPrimaryKey(byFileBLOB, strAddDate);

                string strChecksumCalc = GetBLOBChecksumSimple(byFileBLOB, DocNode.GetAddDate(), nNewDocCheckPK);
                SqlCommand cmd = new SqlCommand();

                if (!IsFileOriginal(DocNode.GetFileBLOB(), DocNode.GetAddDate()))
                {
                    strSQL = "Insert Into DokumentCheck Values (@nNewidDocCheckPK, @strChecksumCalc)";
                    cmd = new SqlCommand(strSQL, con);

                    cmd.Parameters.AddWithValue("@strChecksumCalc", strChecksumCalc);
                    cmd.Parameters.AddWithValue("@nNewidDocCheckPK", nNewDocCheckPK);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    strSQL = "Update DokumentCheck Set idDokumentCheck = @nNewidDocCheckPK, Checksum = @strNewChecksum Where idDokumentCheck = @nOldidDocCheckPK";
                    cmd = new SqlCommand(strSQL, con);
                    cmd.Parameters.AddWithValue("@nNewidDocCheckPK", nNewDocCheckPK);
                    cmd.Parameters.AddWithValue("@nOldidDocCheckPK", nOldDocCheckPK);
                    cmd.Parameters.AddWithValue("@strNewChecksum", strChecksumCalc);

                    cmd.ExecuteNonQuery();
                }


                int nDocumentID = m_lstRunningPrograms[nClosedProgramPos].GetTempFileInfo().GetDocumentID();





                strSQL = "Update Dokument Set Dokument_BLOB = @byFileBLOB, Aenderungsdatum = @ctEditDate  Where idDokument = @nDocumentID";

                cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@nDocumentID", nDocumentID);
                cmd.Parameters.AddWithValue("@byFileBLOB", byFileBLOB);
                cmd.Parameters.AddWithValue("@ctEditDate", ctEditDate);

                cmd.ExecuteNonQuery();


                DocNode.SetFileBLOB(byFileBLOB);
                DocNode.SetEditDate(ctEditDate);



                con.Close();
            }*/
        }


        /*************************************************************************************************************
        ----------------------------------Füllt-das-TreeView-mit-Ordnern-aus-der-Datenbank----------------------------
        **************************************************************************************************************/
        private void FillTreeViewWithFolders()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = SqlHelper.GetSqlConnectionString();
            string strSQL = "";

            
            if (m_nRights == (int)enRights.Admin)
            {
                //Soll alle Ordner anzeigen
                strSQL = "select idOrdner, Ordnername, ID_Benutzer From Ordner order by idOrdner";
            }
            else
            {
                //Soll nur die Ordner anzeigen, die dem Benutzer gehören
                strSQL = "select idOrdner, Ordnername, ID_Benutzer From Ordner where ID_Benutzer= @m_nUserID order by idOrdner";
            }

            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@m_nUserID", m_nUserID);
            
            con.Open();
           

            SqlDataReader reader = cmd.ExecuteReader();
            string strFolderName;
            int nFolderID;
            int nCounter = 0;
            int nUserID = -1;

            while (reader.Read())
            {
                nFolderID = (int)reader["idOrdner"];
                nUserID = (int)reader["ID_Benutzer"];
                
                strFolderName = (string)reader["Ordnername"];
                trvFolders.Nodes.Add(new myTreeNode(nUserID, nFolderID, strFolderName));        //Fügt dem TreeView eine benutzerdefinierte Node hinzu

                //Wenn der Ordner nicht dem gerade eingeloggten Benutzer gehört wird er Lila gefärbt
                if (nUserID != m_nUserID)
                {
                    trvFolders.Nodes[nCounter].ForeColor = Color.Purple;
                }

                nCounter = nCounter + 1;
            }

           

            reader.Close();
            con.Close();
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        ----------------------------------Füllt-das-TreeView-mit-Dokumenten-aus-der-Datenbank-------------------------
        **************************************************************************************************************/
        private void FillTreeViewWithDocuments()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = (SqlHelper.GetSqlConnectionString());

            string strSQL = "SELECT idDokument, Dokumentname, Dokument_BLOB, Dateiendung, ID_Ordner, ID_Benutzer, Dokument.Erstelldatum AS DocErstelldatum, Aenderungsdatum, Hinzugefuegt_Am " 
                           +"FROM Dokument JOIN Ordner ON idOrdner = ID_Ordner ORDER BY ID_Ordner";

            SqlCommand cmd = new SqlCommand(strSQL, con);


            con.Open();


            SqlDataReader reader = cmd.ExecuteReader();
            string strDocumentName;
            string strFileExtension = "";

            int nFolderID;
            int nDocumentID;
            int i = 0;
            int nUserID = -1;

            byte[] byFileBLOB = null;


            while (reader.Read())
            {
                nFolderID = (int)reader["ID_Ordner"];
                nDocumentID = (int)reader["idDokument"];
                nUserID = (int)reader["ID_Benutzer"];
                
                strDocumentName = reader["Dokumentname"].ToString();
                strFileExtension = reader["Dateiendung"].ToString();

                byFileBLOB = (byte[])reader["Dokument_BLOB"];
                DateTime dtCreateDate = (DateTime)reader["DocErstelldatum"];
                DateTime dtEditDate = (DateTime)reader["Aenderungsdatum"];
                DateTime dtAddDate = (DateTime)reader["Hinzugefuegt_Am"];

                for (i = 0; i < trvFolders.GetNodeCount(false); i++)
                {
                    myTreeNode Node = (myTreeNode)trvFolders.Nodes[i];
                   
                    if (Node.GetFolderID() == nFolderID)
                    {
                        myTreeNode NewNode = new myTreeNode(nUserID, nFolderID, strDocumentName, false, nDocumentID, strFileExtension, byFileBLOB);
                        NewNode.SetDates(dtCreateDate, dtEditDate, dtAddDate);

                        int nNode = Node.Nodes.Add(NewNode);

                        Node.Nodes[nNode].ImageIndex = GetFileImageID(strFileExtension);//strDocumentPath);
                        Node.Nodes[nNode].SelectedImageIndex = Node.Nodes[nNode].ImageIndex;
                        
                        //Wenn der Benutzer nicht der eingeloggt Benutzer ist
                        if( (nUserID != m_nUserID)
                        &&  (m_nRights != (int)enRights.Admin) )
                        {
                            Node.Nodes[nNode].ForeColor = Color.Purple;     //Wird das Dokument Lila gefärbt
                        }

                        break;
                    }

                }

            }

            reader.Close();
            con.Close();
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        -------Gibt-die-ID-des-zu-verwendenden-Bildes-zurück,-die-anhand-der-Endung-der-Datei-festgemacht wird--------
        **************************************************************************************************************/
        private int GetFileImageID(string strDocumentPath)
        {
            string strDocumentName = Path.GetFileName(strDocumentPath);

           
            if (strDocumentName.IndexOf(".pdf") > -1)
            {
                return 2;
            }

            if( (strDocumentName.IndexOf(".doc") > -1)
            ||  (strDocumentName.IndexOf(".docx") > -1))
            {
                return 3;
            }

            if( (strDocumentName.IndexOf(".jpg") > -1)
            ||  (strDocumentName.IndexOf(".tif") > -1)
            || (strDocumentName.IndexOf(".bmp") > -1)
            || (strDocumentName.IndexOf(".gif") > -1)
            || (strDocumentName.IndexOf(".png") > -1))
            {
                return 4;
            }

            if (strDocumentName.IndexOf(".odt") > -1)
            {
                return 5;
            }

            if( (strDocumentName.IndexOf(".xlsx") > -1)
            ||  (strDocumentName.IndexOf(".xls") > -1) )
            {
                return 6;
            }

            return 1;
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/


        /*************************************************************************************************************
        ------------------------Öffnet-den-Dialog,-mit-dem-man-persönliche-Daten-ändern-kann--------------------------
        **************************************************************************************************************/
        private void tsbChangeUserData_Click(object sender, EventArgs e)
        {
            frmPersonalData PersData = new frmPersonalData();
            PersData.SetUserID(m_nUserID);
            PersData.ShowDialog();
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        ------------------------------Wenn-auf-ein-Treeview-Item-ein-Doppelklick-verübt-wird--------------------------
        **************************************************************************************************************/
        private void trvFolders_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenDocumentWithStandardProgram();
        }
       /*************************************************************************************************************
       **************************************************************************************************************
       **************************************************************************************************************/




        /*************************************************************************************************************
        -------------------------Funktion-zum-Öffnen-von-Dateien-mit-dem-Standardprogramm-----------------------------
        **************************************************************************************************************/
        private void OpenDocumentWithStandardProgram()
        {
            
            myTreeNode Node = (myTreeNode)trvFolders.SelectedNode;

            if (Node != null)
            {
                if(Node.GetFileBLOB() != null)        //Wenn ein Dokument existiert
                {
                    if((m_nRights == (int)enRights.Admin)
                    ||(Node.GetUserID() == m_nUserID) )   //Und der Benutzer der Benutzer ist, der das Dokument bearbeitet
                    {
                        int nTempNumber = m_lstTempWorkingFiles.Count + 1;
                        bool bTempFileExists = false;

                        string strTempFileName = "Temp_File_" + nTempNumber + Node.GetFileExtension();
                        string strTempFilePath = "";
                        string strChecksum = "";

                        if (!IsFileOriginal(Node.GetFileBLOB(), Node.GetAddDate()))
                        {
                            MessageBox.Show("Das angezeigte Dokument entspricht nicht dem Original!", "Warnung");
                        }

                    
                        for (int i = 0; i < m_lstTempWorkingFiles.Count; i++)
                        {
                            if (m_lstTempWorkingFiles[i].GetDocumentID() == Node.GetDocumentID())
                            {
                                strTempFilePath = m_strTempFolder + m_lstTempWorkingFiles[i].GetTempFileName();

                                if (File.Exists(strTempFilePath))
                                {
                                    bTempFileExists = true;
                                }

                                break;
                            }
                        }



                        if (!bTempFileExists)
                        {
                            DateTime dtToday = DateTime.Now;
                            DateTime dtCreateDate = new DateTime();
                            DateTime dtEditDate = new DateTime();
                            DateTime dtAddDate = new DateTime();

                            Node.GetDates(ref dtCreateDate, ref dtEditDate, ref dtAddDate);

                            clsTempFile TempFile = new clsTempFile(Node.GetDocumentID(), strTempFileName, Node.GetNodeName(), dtCreateDate, Node);
                            strChecksum = GetBLOBChecksum(Node.GetFileBLOB(), dtCreateDate, dtEditDate);
                            TempFile.SetChecksum(strChecksum); 
                        
                            strTempFilePath = WriteStreamToFile(strTempFileName, Node.GetFileBLOB());

                            if (strTempFilePath == string.Empty)
                            {
                                return;
                            }

                            m_lstTempWorkingFiles.Add(TempFile);

                            try
                            {
                                FileInfo fi = new FileInfo(strTempFilePath);
                                fi.CreationTime = dtCreateDate;
                                fi.LastWriteTime = dtEditDate;
                            }
                            catch
                            {
                            }

                            OpenFile(strTempFilePath, TempFile);
                        }
                        else if (bTempFileExists)
                        {
                            MessageBox.Show("Speichern Sie ab und öffnen Sie das Dokument erneut.", "Fehler");
                        }

                        tsbSaveDocumentsInDatabase.Enabled = true;
                    }
                    else if( (Node.GetUserID() != m_nUserID)
                    &&       (m_nRights != (int)enRights.Admin) )
                    {
                        MessageBox.Show("Dieses Dokument gehört einem anderem Benutzer und ist für die Bearbeitung gesperrt.", "Warnung");
                    }


                }

            }
            
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/


        private void OpenFile(string strFilePath, clsTempFile TempFileInfo)
        {
            m_lstRunningPrograms.Add(new clsRunningPrograms(strFilePath, TempFileInfo));
        }



        /*************************************************************************************************************
        ---------------------------------------Wenn-ein-Mausklick-verübt-wird-----------------------------------------
        **************************************************************************************************************/
        private void trvFolders_MouseClick(object sender, MouseEventArgs e)
        {
            //Wenn ein Rechtsklick ausgeführt wird, soll er auch das Item im TreeView markieren
            MouseEventArgs MouseClick = (MouseEventArgs)e;
            if (MouseClick.Button == System.Windows.Forms.MouseButtons.Right) 
            {
                trvFolders.SelectedNode = trvFolders.GetNodeAt(e.X, e.Y);
            }
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        --------------------------Öffnet-das-Dokument-im-dafür-festgelegtem-Standardprogramm--------------------------
        **************************************************************************************************************/
        private void tsmOpenInStandardProgram_Click(object sender, EventArgs e)
        {
            OpenDocumentWithStandardProgram();
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        ---------------------Öffnet-eine-PDF-im-Webrowser-von-C#-oder-ein-Bild-in-der-PictureBox----------------------
        **************************************************************************************************************/
        private void tsmOpenInViewer_Click(object sender, EventArgs e)
        {
            if (trvFolders.SelectedNode != null)
            {
                myTreeNode Node = (myTreeNode)trvFolders.SelectedNode;
                string strFileExtension = Node.GetFileExtension();
                byte[] byFileBLOB = Node.GetFileBLOB();

                if (byFileBLOB != null)
                {
                    if(!IsFileOriginal(Node.GetFileBLOB(), Node.GetAddDate()))
                    {
                        MessageBox.Show("Das angezeigte Dokument entspricht nicht dem Original!",  "Warnung");
                    }

                    if (strFileExtension.IndexOf(".pdf") > -1)
                    {
                        pcbImage.Visible = false;
                        wbBrwShowPDF.Visible = true;
                        
                        WriteStreamToFileForViewer(Node.GetFileBLOB(), Node.GetFileExtension());

                        wbBrwShowPDF.Navigate(m_strTempViewerFile);
                    }

                    if ((strFileExtension.IndexOf(".jpg") > -1)
                    || (strFileExtension.IndexOf(".tif") > -1)
                    || (strFileExtension.IndexOf(".bmp") > -1)
                    || (strFileExtension.IndexOf(".gif") > -1)
                    || (strFileExtension.IndexOf(".png") > -1))
                    {
                        pcbImage.Visible = true;
                        wbBrwShowPDF.Visible = false;

                        WriteStreamToFileForViewer(Node.GetFileBLOB(), Node.GetFileExtension());
                        pcbImage.Image = Image.FromFile(m_strTempViewerFile);
                    }
                }

            }

        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/






        /*************************************************************************************************************
        -------------------------------Funktion-zum-Hinzufügen-einer-neuen-Mappe--------------------------------------
        **************************************************************************************************************/
        private void tsbAddFolder_Click(object sender, EventArgs e)
        {
            string strFolderName = "";
 
            int nMaxFolderID = -1;
            int nMaxFolderActionID = -1;
            frmAddNewFolder NewFolder = new frmAddNewFolder();
            NewFolder.ShowDialog();
            
            strFolderName = NewFolder.GetFolderName();

            if(NewFolder.DialogResult == DialogResult.Cancel)
            {
                return;
            }
   
            nMaxFolderID = SqlHelper.GetMaxID("idOrdner", "Ordner");
            nMaxFolderID = nMaxFolderID + 1;

            nMaxFolderActionID = SqlHelper.GetMaxID("idOrdneraktionen", "Ordneraktionen");
            nMaxFolderActionID = nMaxFolderActionID + 1;
            

            DateTime today = DateTime.Now;
            string strDateTimeToday = today.ToString("yyyy-dd-MM HH:mm:ss");


            SqlConnection con = new SqlConnection();
            con.ConnectionString = (SqlHelper.GetSqlConnectionString());
            string strSQL = "insert into Ordner values (@nMaxFolderID, @strFolderName, @strDateTimeToday, @m_nUserID)";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = strSQL;
            cmd.Parameters.AddWithValue("@nMaxFolderID", nMaxFolderID);
            cmd.Parameters.AddWithValue("@strFolderName", strFolderName);
            cmd.Parameters.AddWithValue("@strDateTimeToday", strDateTimeToday);
            cmd.Parameters.AddWithValue("@m_nUserID", m_nUserID);

            cmd.Connection = con;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();




            con = new SqlConnection();
            con.ConnectionString = (SqlHelper.GetSqlConnectionString());
            strSQL = "insert into Ordneraktionen values (@nMaxFolderActionID, @nMaxFolderID, @m_nUserID, 1, 1, 0, @strDateTimeToday)";

            cmd = new SqlCommand();
            cmd.CommandText = strSQL;
            cmd.Parameters.AddWithValue("@nMaxFolderActionID", nMaxFolderActionID);
            cmd.Parameters.AddWithValue("@nMaxFolderID", nMaxFolderID);
            cmd.Parameters.AddWithValue("@m_nUserID", m_nUserID);
            cmd.Parameters.AddWithValue("@strDateTimeToday", strDateTimeToday);

            cmd.Connection = con;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            DateTime dtCreateDate = DateTime.Now;

            myTreeNode NewNode = new myTreeNode(m_nUserID, nMaxFolderID, strFolderName);
            NewNode.SetDates(dtCreateDate, dtCreateDate, dtCreateDate);

            trvFolders.Nodes.Add(NewNode);
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        ----------------------------------Funktion-zum-Hinzufügen-eines-Dokumentes------------------------------------
        **************************************************************************************************************/
        private void tsbAddDocument_Click(object sender, EventArgs e)
        {
            string strDocumentName = "";
            string strDocumentPath = "";
            List<string> strDocumentList;

            myTreeNode Node = (myTreeNode)trvFolders.SelectedNode;

            if (Node != null)
            {
                if ((Node.GetDocumentID() != -1))
                {
                    return;
                }
            }
            else
            {
                return;
            }


            if( (Node.GetUserID() != m_nUserID)
            &&  (m_nRights != (int)enRights.Admin) )
            {
                MessageBox.Show("Diese Mappe gehört einem anderen Benutzer und ist für diese Aktion gesperrt.", "Warnung");
                return;
            }

            frmAddNewDocument NewFolder = new frmAddNewDocument(Node.GetNodeName());
            NewFolder.ShowDialog();

            if(NewFolder.DialogResult == DialogResult.Cancel)
            {
                return;
            }

            
            //Wenn ein einzelnes Dokument zurückgegeben werden soll
            if (NewFolder.ReturnSingleDocument())
            {
                NewFolder.GetSingleDocument(ref strDocumentName, ref strDocumentPath);
                CreateNewDocument(strDocumentName, strDocumentPath);
            }
            else
            {
                strDocumentList = NewFolder.GetDocumentList();
                CreateNewDocuments(strDocumentList);
            }

            Node.Expand();
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        -------------------------------------Erstellt-ein-einzelnes-Dokument------------------------------------------
        **************************************************************************************************************/
        private void CreateNewDocument(string strDocumentName, string strDocumentPath)
        {
            int nMaxDocumentID = SqlHelper.GetMaxID("idDokument", "Dokument");      //Holt sich die höchste ID aus der Tabelle
            nMaxDocumentID = nMaxDocumentID + 1;                                    //Zählt diese um 1 hoch

            //Speichert sich das heutige Datum und die Uhrzeit
            DateTime today = DateTime.Now;
            string strDateTimeToday = today.ToString("yyyy-dd-MM HH:mm:ss");

            //Speichert sich das Erstellungsdatum und das Datum, an dem die Datei zuletzt bearbeitet wurde
            FileInfo fi1 = new FileInfo(strDocumentPath);
            myTreeNode Node = (myTreeNode)trvFolders.SelectedNode;      //Speichert sich die gerade markierte Node

            //Wenn eine Node markiert wurde
            if(Node != null)
            {
                //Und diese einen Ordner darstellt
                if ((Node.GetDocumentID() == -1))
                {                 
                    //In der Datenbank wird ein Eintrag erstellt, der jeweils eine Datei darstellt 
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = (SqlHelper.GetSqlConnectionString());
                    byte[] byDocumentBLOB = GetBLOB(strDocumentPath);

                    string strFileExtension = Path.GetExtension(strDocumentPath);

                    string strChecksum = GetBLOBChecksum(byDocumentBLOB, fi1.CreationTime, fi1.LastWriteTime);
                    string strSQL = "INSERT INTO Dokument VALUES(@nMaxDocumentID, @strDocumentName, @DocumentBLOB, @strFileExtension, @strCreateTime, @strChangeTime, @strDateTimeToday, @NodeGetFolderID, @strChecksum)";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = strSQL;
                    cmd.Parameters.AddWithValue("@nMaxDocumentID", nMaxDocumentID);
                    cmd.Parameters.AddWithValue("@strDocumentName", strDocumentName);
                    cmd.Parameters.AddWithValue("@DocumentBLOB", byDocumentBLOB);
                    cmd.Parameters.AddWithValue("@strFileExtension", strFileExtension);

                    cmd.Parameters.AddWithValue("@strCreateTime", fi1.CreationTime);
                    cmd.Parameters.AddWithValue("@strChangeTime", fi1.LastWriteTime);
                    cmd.Parameters.AddWithValue("@strDateTimeToday", strDateTimeToday);
                    cmd.Parameters.AddWithValue("@NodeGetFolderID", Node.GetFolderID());
                    cmd.Parameters.AddWithValue("@strChecksum", strChecksum);
                    cmd.Connection = con;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    SetDocumentCheckSumInDB(byDocumentBLOB, today);



                    myTreeNode NewNode = new myTreeNode(m_nUserID, Node.GetFolderID(), strDocumentName, true, nMaxDocumentID, strFileExtension, byDocumentBLOB); 
                    NewNode.SetDates(fi1.CreationTime, fi1.LastWriteTime, DateTime.Now);
                    int nNode = Node.Nodes.Add(NewNode);    //Eine neue Node wird erstellt
                    
                    Node.Nodes[nNode].ImageIndex = GetFileImageID(strDocumentPath);
                    Node.Nodes[nNode].SelectedImageIndex = Node.Nodes[nNode].ImageIndex;
                }
            }
            else
            {
                MessageBox.Show("Dokument wurde nicht hinzugefügt. \r\nHaben Sie einen Ordner ausgewählt?", "Warnung");
            }
                
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        -----------------------------Wenn-mehrere-Dokumente-erstellt-werden-sollen------------------------------------
        **************************************************************************************************************/
        private void CreateNewDocuments(List<string> strDocumentList)
        {
            int i = 0;
            int nMaxDocumentID = SqlHelper.GetMaxID("idDokument", "Dokument");  //Holt sich die höchste ID aus der Tabelle
            
            string strDocumentName = "";
           
            

            myTreeNode Node = (myTreeNode)trvFolders.SelectedNode;

            if (Node != null)
            {
                if (Node.GetDocumentID() == -1)
                {
                    for (i = 0; i < strDocumentList.Count; i++)
                    {
                        DateTime dtToday = DateTime.Now;
                        nMaxDocumentID = nMaxDocumentID + 1;
                        strDocumentName = Path.GetFileName(strDocumentList[i]);

                        byte[] byDocumentBLOB = GetBLOB(strDocumentList[i]);
                        string strFileExtension = Path.GetExtension(strDocumentList[i]);
                        


                        FileInfo fi1 = new FileInfo(strDocumentList[i]);
                        string strCreateTime = fi1.CreationTime.ToString("yyyy-dd-MM HH:mm:ss");
                        string strChangeTime = fi1.LastWriteTime.ToString("yyyy-dd-MM HH:mm:ss");

                        string strChecksum = GetBLOBChecksum(byDocumentBLOB, fi1.CreationTime, fi1.LastWriteTime);

                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = (SqlHelper.GetSqlConnectionString());
                        string strSQL = "INSERT INTO Dokument VALUES(@nMaxDocumentID, @strDocumentName, @DocumentBLOB, @strFileExtension, @strCreateTime, @strChangeTime, @strDateTimeToday, @NodeGetFolderID, @strChecksum)";

                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = strSQL;
                        cmd.Parameters.AddWithValue("@nMaxDocumentID", nMaxDocumentID);
                        cmd.Parameters.AddWithValue("@strDocumentName", strDocumentName);
                        cmd.Parameters.AddWithValue("@DocumentBLOB", byDocumentBLOB);
                        cmd.Parameters.AddWithValue("@strFileExtension", strFileExtension);

                        cmd.Parameters.AddWithValue("@strCreateTime", strCreateTime);
                        cmd.Parameters.AddWithValue("@strChangeTime", strChangeTime);
                        cmd.Parameters.AddWithValue("@strDateTimeToday", dtToday);
                        cmd.Parameters.AddWithValue("@NodeGetFolderID", Node.GetFolderID());
                        cmd.Parameters.AddWithValue("@strChecksum", strChecksum);

                        cmd.Connection = con;

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        SetDocumentCheckSumInDB(byDocumentBLOB, dtToday);

                        myTreeNode NewNode = new myTreeNode(m_nUserID, Node.GetFolderID(), strDocumentName, true, nMaxDocumentID, strFileExtension, byDocumentBLOB);
                        NewNode.SetDates(fi1.CreationTime, fi1.LastWriteTime, dtToday);
                        int nNode = Node.Nodes.Add(NewNode);
                     
                        Node.Nodes[nNode].ImageIndex = GetFileImageID(strDocumentList[i]);
                        Node.Nodes[nNode].SelectedImageIndex = Node.Nodes[nNode].ImageIndex;
                    }
                }
            }
            else
            {
                MessageBox.Show("Dokument wurde nicht hinzugefügt. \r\nHaben Sie einen Ordner ausgewählt?", "Warnung");
            }
                
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/


        private void SetDocumentCheckSumInDB(byte[] byDocumentBLOB, DateTime dtAdd)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = (SqlHelper.GetSqlConnectionString());

            string strToday = SqlHelper.GetDateTimeInNumberString(dtAdd);
            int nDocCheckPK = GetBLOBPrimaryKey(byDocumentBLOB, strToday);
            string strCheckSumSimple = GetBLOBChecksumSimple(byDocumentBLOB, dtAdd, nDocCheckPK);

            con = new SqlConnection();
            con.ConnectionString = (SqlHelper.GetSqlConnectionString());
            SqlCommand cmd = new SqlCommand();
            string strSQL = "INSERT INTO DokumentCheck VALUES(@idDokumentCheckPK, @strCheckSum)";

            cmd = new SqlCommand();
            cmd.CommandText = strSQL;
            cmd.Parameters.AddWithValue("@idDokumentCheckPK", nDocCheckPK);
            cmd.Parameters.AddWithValue("@strCheckSum", strCheckSumSimple);

            cmd.Connection = con;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }



        /*************************************************************************************************************
        ------------------------------Wenn-die-Dokumentinformationen-angezeigt-werden-sollen--------------------------
        **************************************************************************************************************/
        private void tsbDocumentInformation_Click(object sender, EventArgs e)
        {
            myTreeNode Node = (myTreeNode)trvFolders.SelectedNode;

            if (Node != null)
            {
                if(Node.GetDocumentID() > -1)
                {
                    frmShowDocumentInfo EditDocument = new frmShowDocumentInfo(m_nUserID, m_nRights, Node.GetDocumentID());
                    EditDocument.LoadDocumentInfo(m_nUserID, Node.GetDocumentID());

                    EditDocument.ShowDialog();
                }

            }

        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        ----------------------------Ruft-den-Dialog-auf,-mit-dem-man-die-Matchcodes-bearbeiten-kann-------------------
        **************************************************************************************************************/
        private void tsbMatchcodes_Click(object sender, EventArgs e)
        {
            frmMatchcodes ObjectMatchcode = new frmMatchcodes();
            ObjectMatchcode.ShowDialog();
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        ----------------------Ruft-die-Funktion-auf,-um-die-Matchcodes-für-das-Objekt-festzulegen---------------------
        **************************************************************************************************************/
        private void tsbAssignMatchcode_Click(object sender, EventArgs e)
        {
            if (trvFolders.SelectedNode != null)
            {
                myTreeNode Node = (myTreeNode)trvFolders.SelectedNode;
                int nFolderID = Node.GetFolderID();
                frmAssignMatchcode AssignMatchcode = new frmAssignMatchcode(nFolderID, Node.GetDocumentID(), Node.GetNodeName());
                AssignMatchcode.ShowDialog();
            }

        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        --------------------------Funktion-zum-Demarkieren-aller-markierten-Items-------------------------------------
        **************************************************************************************************************/
        private void DemarkItems()
        {
            int i = 0;
            int j = 0;

            for (i = 0; i < trvFolders.GetNodeCount(false); i++)
            {
                myTreeNode Node = (myTreeNode)trvFolders.Nodes[i];
                Node.BackColor = Color.White;

                for (j = 0; j < Node.GetNodeCount(false); j++)
                {
                    myTreeNode NodeX = (myTreeNode)trvFolders.Nodes[i].Nodes[j];
                    NodeX.BackColor = Color.White;
                }

            }

        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        -------------------------------------Funktion-zum-Suchen-der-Matchcodes---------------------------------------
        **************************************************************************************************************/
        private void tsbSearchForMatchcodes_Click(object sender, EventArgs e)
        {
            frmSearchForMatchcodes SearchMatchcode = new frmSearchForMatchcodes();
            SearchMatchcode.ShowDialog();

            int i = 0;
            int j = 0;
            int x = 0;

            List<int> nlstFoundFolders;
            List<int> nlstFoundDocuments;

            DemarkItems();

            if (SearchMatchcode.DialogResult == DialogResult.Cancel)
            {
                return;
            }

            if (SearchMatchcode.IsFolderSearch())
            {
                nlstFoundFolders = SearchMatchcode.GetFoundFolders();
                trvFolders.Select();


                for (i = 0; i < trvFolders.GetNodeCount(false); i++)
                {
                    myTreeNode Node = (myTreeNode)trvFolders.Nodes[i];

                    for (j = 0; j < nlstFoundFolders.Count; j++)
                    {
                       // Wenn der Ordner der Suche entspricht
                        if (Node.GetFolderID() == nlstFoundFolders[j])
                        {
                            Node.BackColor = Color.LightGreen;  //Wird der Eintrag im Treeview hellgrün markiert
                        }

                    }

                }

            }
            else
            {
                nlstFoundDocuments = SearchMatchcode.GetFoundDocuments();

                for (i = 0; i < trvFolders.GetNodeCount(false); i++)
                {
                    myTreeNode Node = (myTreeNode)trvFolders.Nodes[i];
                    
                    for (x = 0; x < Node.GetNodeCount(false); x++)
                    {
                        myTreeNode NodeX = (myTreeNode)trvFolders.Nodes[i].Nodes[x];

                        for (j = 0; j < nlstFoundDocuments.Count; j++)
                        {
                            //Wenn das Dokument der Suche entspricht
                            if (NodeX.GetDocumentID() == nlstFoundDocuments[j])
                            {
                                NodeX.BackColor = Color.LightGreen;     //Wird es Hellgrün markiert
                                Node.Expand();
                            }

                        }

                    }

                }

            }

        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        --------------------------------------------Demarkiert-alle-Items---------------------------------------------
        **************************************************************************************************************/
        private void tsbDeleteMarkers_Click(object sender, EventArgs e)
        {
            DemarkItems();
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        --------------------------------Funktion-zum-Hinzufügen-einer-Bearbeitungsreihenfolge-------------------------
        **************************************************************************************************************/
        private void tsbCreateWorkFlow_Click(object sender, EventArgs e)
        {
            myTreeNode Node = (myTreeNode)trvFolders.SelectedNode;

            if (m_nRights == 1)
            {
                if (Node != null)
                {
                    if (Node.GetDocumentID() == -1)
                    {
                        frmCreateWorkflow Workflow = new frmCreateWorkflow(Node.GetFolderID(), Node.GetNodeName());
                        Workflow.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Sie haben keine Mappe ausgewählt.", "Warnung");
                    }
                }
                else
                {
                    MessageBox.Show("Sie haben keine Auswahl getroffen.", "Warnung");
                }
            }
            else
            {
                MessageBox.Show("Sie haben keine Rechte, diese Aktion auszuführen.", "Warnung");
            }
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        ---------------------------------------Funktion-zum-Laden-der-Datenbanktabelle--------------------------------
        **************************************************************************************************************/
        private void tsbLoadDatabase_Click(object sender, EventArgs e)
        {
            CSqlHelper SQLHelper = new CSqlHelper();
            
            FillTreeViewWithDocsAndFolders();
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/


        private void FillTreeViewWithDocsAndFolders()
        {
            this.trvFolders.Nodes.Clear();
            FillTreeViewWithFolders();
            FillTreeViewWithDocuments();
        }



        /*************************************************************************************************************
        -----------------Stell-die-Buttons-je-nach-Berechtigung-des-Benutzers-an-oder-aus-----------------------------
        **************************************************************************************************************/
        private void EditMenu()
        {
            switch(m_nRights)
            {
                //Admin
                case (int)enRights.Admin:
                    this.tsmDelete.Visible = true;
                    this.tsmCopyDocument.Visible = true;
                    this.tsmInsertDocument.Visible = true;

                    this.tsmAddFolder.Visible = true;
                    this.tsmRenameObject.Visible = true;


                    this.tsmmAddNewFolder.Visible = true;
                    this.tsmmDelete.Visible = true;

                    this.tsmmAddUser.Visible = true;
               //     this.tsmmCreateWorkFlow.Visible = true;


                //    this.tsbCreateWorkFlow.Visible = true;
                    this.tsbDelete.Visible = true;
                    this.tsbAddUser.Visible = true;

                    this.tsbAddFolder.Visible = true;

                  
                break;

                //Sonstige Benutzer
                default:
                    this.tsmDelete.Visible = false;
                    this.tsmCopyDocument.Visible = false;
                    this.tsmInsertDocument.Visible = false;

                    this.tsmAddFolder.Visible = false;
                    this.tsmRenameObject.Visible = false;


                    this.tsmmAddNewFolder.Visible = false;
                    this.tsmmDelete.Visible = false;

                    this.tsmmAddUser.Visible = false;
              //      this.tsmmCreateWorkFlow.Visible = false;
                   


              //      this.tsbCreateWorkFlow.Visible = false;
                    this.tsbDelete.Visible = false;
                    this.tsbAddUser.Visible = false;

                    this.tsbAddFolder.Visible = false;
                    
                break;
            }

        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        ----------------------------------Funktion-zum-Aus-und-wieder-Einloggen---------------------------------------
        **************************************************************************************************************/
        private void tsbLogout_Click(object sender, EventArgs e)
        {

            if (SaveDocumentChangesInDataBase() == 1)
            {
                return;
            }



            SetOnlineStatusInDb(0);
            wbBrwShowPDF.Navigate("about:blank");
            DeleteLastTempViewerFile();

            this.Visible = false;
            frmLogin LoginForm = new frmLogin();


            if (LoginForm.ShowDialog() == DialogResult.OK)
            {
                m_nUserID = LoginForm.GetUserId();        //BenutzerID speichern 
                m_nRights = LoginForm.GetRights();        //Benutzerrechte speichern  

                SetOnlineStatusInDb(1);

                this.trvFolders.Nodes.Clear();            //TreeView leeren  
                if (LoginForm.DialogResult == DialogResult.OK)
                {
                    this.Visible = true;
                    EditMenu();
                    DeactivateButtonsOnStart();
                }

                FillTreeViewWithDocsAndFolders();
            }
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/



        /*************************************************************************************************************
        -----------------------------------Funktion-zum-Hinzufügen-von-Ordneraktionen---------------------------------
        **************************************************************************************************************/
        private void tsbFolderAction_Click(object sender, EventArgs e)
        {
            myTreeNode Node = (myTreeNode)trvFolders.SelectedNode;

            //Wenn eine Node ausgewählt ist
            if (Node != null)
            {
                //Wenn die Node einen Ordner darstellt
                if (Node.GetDocumentID() == -1)     
                {
                    //Und der Benutzer der Benutzer ist, der den Ordner erstellt hat
                    if( (Node.GetUserID() != m_nUserID)
                    &&  (m_nRights != (int)enRights.Admin) )
                    {
                        MessageBox.Show("Diese Mappe gehört einem anderen Benutzer und ist für diese Aktion gesperrt.");
                        return;
                    }

                    if (!IsDocumentsNotSavedInFolder(Node))
                    {
                        OpenFolderActionDialog(Node);
                    }
                    else if (MessageBox.Show("Die Dokumente, die diese Mappe enthält wurden noch nicht gespeichert. Wollen Sie die Dokumente speichern und fortfahren?", "Fehler", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {                       
                        if (SaveDocumentChangesInDataBase() == 0)
                        {
                            if (m_lstTempWorkingFiles.Count == 0)
                            {
                                OpenFolderActionDialog(Node);
                            }

                        }

                    }
                    
                }

            }

        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/


        private void OpenFolderActionDialog(myTreeNode Node)
        {
            frmAddFolderAction FolderAction = new frmAddFolderAction(m_nUserID, Node.GetFolderID(), Node.GetNodeName());

            if (FolderAction.ShowDialog() == DialogResult.OK)
            {
                Node.SetUserID(FolderAction.GetNextUserID());

                if (m_nRights == (int)enRights.Admin)
                {
                    if (Node.GetUserID() == m_nUserID)
                    {
                        Node.ForeColor = Color.Black;
                        SetNodeColor(Node, Color.Black);
                    }
                    else
                    {
                        Node.ForeColor = Color.Purple;
                        SetNodeColor(Node, Color.Purple);
                    }
                }
                else
                {
                    Node.Remove();
                }

            }

        }



        /*************************************************************************************************************
        ---------------------------------Funktion-zum-Weiterreichen-eines-Dokumentes----------------------------------
        **************************************************************************************************************/
        private void tsbPassFolder_Click(object sender, EventArgs e)
        {
            
                myTreeNode Node = (myTreeNode)trvFolders.SelectedNode;

                //Wenn eine Node ausgewählt ist
                if (Node != null)
                {
                    //Wenn die Node einen Ordner darstellt
                    if (Node.GetDocumentID() == -1)
                    {
                        //Und der Benutzer der Benutzer ist, der den Ordner besitzt
                        if (Node.GetUserID() != m_nUserID)
                        {
                            MessageBox.Show("Diese Mappe gehört einem anderen Benutzer und ist für diese Aktion gesperrt.");
                            return;
                        }

                       
                        int nFound = PassFolder();

                        if (nFound == 1)
                        {
                            MessageBox.Show("Mappe wurde weiter gereicht.", "Aktion erfolgreich");

                            if (m_nRights == 1)
                            {
                                if (Node.GetUserID() == m_nUserID)
                                {
                                    Node.ForeColor = Color.Black;
                                    SetNodeColor(Node, Color.Black);
                                }
                                else
                                {
                                    Node.ForeColor = Color.Purple;
                                    SetNodeColor(Node, Color.Purple);
                                }
                            }
                            else
                            {
                                Node.Remove();
                            }
                        }
                        else if(nFound == 0)
                        {
                            MessageBox.Show("Es wurde kein weiterer Benutzer gefunden.", "Warnung");
                        }
                        
                        
                    }

                }               
  
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/
        



        /*************************************************************************************************************
        ---------------------------------------Reicht-den-Ordner-weiter-----------------------------------------------
        **************************************************************************************************************/        
        private int PassFolder()
        {
            myTreeNode Node = (myTreeNode)trvFolders.SelectedNode;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = (SqlHelper.GetSqlConnectionString());

            string strSQL = "Select idBenutzerordner, ID_Benutzer, Benutzername From Benutzerordner join Benutzer on idBenutzer = ID_Benutzer Where ID_Ordner = @NodeGetFolderID Order by Position";

            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@NodeGetFolderID", Node.GetFolderID());

            con.Open();


            SqlDataReader reader = cmd.ExecuteReader();
            int nNextUser = -1;
            int nBenutzerordnerID = -1;
            int nFoundUser = 0;
            string strNextUser = "";

            while (reader.Read())
            {
                nBenutzerordnerID = (int)reader["idBenutzerordner"];
                nNextUser = (int)reader["ID_Benutzer"];
                nFoundUser = 1;
                strNextUser = reader["Benutzername"].ToString();

                break;
            }

            reader.Close();
            con.Close();

            DialogResult dialogResult = MessageBox.Show("Sind sie sich sicher, dass Sie die Mappe an \"" + strNextUser + "\" weiterreichen wollen?", "Mappenweitergabe", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.No)
            {
                return -1;
            }

            //Wenn ein Benutzer gefunden wurde
            if (nFoundUser == 1)
            {
                DateTime today = DateTime.Now;
                string strDateTimeToday = today.ToString("yyyy-dd-MM HH:mm:ss");


                SqlHelper.SendQueryToDb("Delete From Benutzerordner Where idBenutzerordner = " + nBenutzerordnerID);
                SqlHelper.SendQueryToDb("Update Ordner Set ID_Benutzer = " + nNextUser + " Where idOrdner = " + Node.GetFolderID());
                
                
                int nMaxFolderActionID = SqlHelper.GetMaxID("idOrdneraktionen", "Ordneraktionen");
                int nFolderReady = 0;
                int nProcessingReason = GetProcessingReason(Node.GetFolderID());
                nMaxFolderActionID = nMaxFolderActionID + 1;

                

                con = new SqlConnection();
                con.ConnectionString = (SqlHelper.GetSqlConnectionString());
                strSQL = "insert into Ordneraktionen values (@nMaxFolderActionID, @NodeGetFolderID, @nNextUser, @nProcessingReason, 1, 0, @strDateTimeToday)";

                cmd = new SqlCommand();
                cmd.CommandText = strSQL;
                cmd.Parameters.AddWithValue("@nMaxFolderActionID", nMaxFolderActionID);
                cmd.Parameters.AddWithValue("@NodeGetFolderID", Node.GetFolderID());
                cmd.Parameters.AddWithValue("@nNextUser", nNextUser);
                cmd.Parameters.AddWithValue("@strDateTimeToday", strDateTimeToday);
                cmd.Parameters.AddWithValue("@nProcessingReason", nProcessingReason);
                cmd.Parameters.AddWithValue("@nFolderReady", nFolderReady);
                cmd.Connection = con;

                int nMaxChonikID = SqlHelper.GetMaxID("idBearbeitungschronik", "Bearbeitungschronik");
                nMaxChonikID = nMaxChonikID + 1;
                int PreviousFolderActionID = GetMaxFolderActionID(Node.GetUserID(), Node.GetFolderID());
                SqlHelper.SendQueryToDb("Insert into Bearbeitungschronik values (" + nMaxChonikID + ", " + Node.GetUserID() + ", " + Node.GetFolderID() + ", " + PreviousFolderActionID + ", '" + strDateTimeToday + "')");
                

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                Node.SetUserID(nNextUser);
            }

            return nFoundUser;

        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/



        /*************************************************************************************************************
        ----------------------Gibt-die-nächste-Aktion-zurück, was-mit-dem-Ordner-geschehen-soll-----------------------
        **************************************************************************************************************/
        private int GetProcessingReason(int nFolderID)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = (SqlHelper.GetSqlConnectionString());

            string strSQL = "Select ID_Naechste_Aktion From Ordneraktionen Where  ID_Ordner = @nFolderID and Erledigt_Am = (Select max(Erledigt_Am) From Ordneraktionen Where ID_Ordner = @nFolderID)";
            int nProcessingReason = -1;

            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@nFolderID", nFolderID);

            con.Open();


            SqlDataReader reader = cmd.ExecuteReader();
            

            while (reader.Read())
            {
                nProcessingReason = (int)reader["ID_Naechste_Aktion"];
            }

            
            reader.Close();
            con.Close();
            return nProcessingReason;
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        --------------------------Zwischenspeichern-der-Dokumentdaten-zum-kopieren------------------------------------
        **************************************************************************************************************/
        private void tsmCopyDocument_Click(object sender, EventArgs e)
        {
            myTreeNode Node = (myTreeNode)trvFolders.SelectedNode;
                
            if(Node != null)
            {
                if(Node.GetDocumentID() > -1)
                {
                    DateTime dtCreateDate = new DateTime();
                    DateTime dtEditDate = new DateTime();
                    DateTime dtAddDate = new DateTime();

                    int nMaxDocumentID = SqlHelper.GetMaxID("idDokument", "Dokument");      //Holt sich die höchste ID aus der Tabelle
                    nMaxDocumentID = nMaxDocumentID + 1;                                    //Zählt diese um 1 hoch

                    m_CopyDocument.m_nDocumentID = nMaxDocumentID;
                    m_CopyDocument.m_nFolderID = Node.GetFolderID();
                    m_CopyDocument.m_nUserID = Node.GetUserID();
                    m_CopyDocument.m_strNodeName = Node.GetNodeName();
                    m_CopyDocument.m_bIsEmpty = false;
                    m_CopyDocument.m_byFileBLOB = Node.GetFileBLOB();
                    
                    m_CopyDocument.m_strFileExtension = Node.GetFileExtension();
                    m_CopyDocument.m_bNodeCreatedInSession = true;

                    Node.GetDates(ref dtCreateDate, ref dtEditDate, ref dtAddDate);
                    m_CopyDocument.SetDates(dtCreateDate, dtEditDate, dtAddDate);
                }
            }
            
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/



        /*************************************************************************************************************
        -------------------------Funktion-zum-Einfügen-des-zu-kopierenden-Dokumentes----------------------------------
        **************************************************************************************************************/
        private void tsmInsertDocument_Click(object sender, EventArgs e)
        {
            myTreeNode Node = (myTreeNode)trvFolders.SelectedNode;

            if (Node != null)
            {
                if( (Node.GetDocumentID() == -1)
                && (m_CopyDocument.m_nDocumentID > -1))
                {
                    myTreeNode NewNode = new myTreeNode(m_CopyDocument.m_nUserID, m_CopyDocument.m_nFolderID, m_CopyDocument.m_strNodeName, true, m_CopyDocument.m_nDocumentID, m_CopyDocument.m_strFileExtension, m_CopyDocument.m_byFileBLOB);
                    Node.Nodes.Add(NewNode);

                    NewNode.ImageIndex = GetFileImageID(m_CopyDocument.m_strFileExtension);
                    NewNode.SelectedImageIndex = GetFileImageID(m_CopyDocument.m_strFileExtension);

                    //Speichert sich das heutige Datum und die Uhrzeit
                    DateTime today = DateTime.Now;

                    DateTime dtCreateTime = new DateTime(m_CopyDocument.m_dtCreateDate.Year, m_CopyDocument.m_dtCreateDate.Month, m_CopyDocument.m_dtCreateDate.Day, m_CopyDocument.m_dtCreateDate.Hour, m_CopyDocument.m_dtCreateDate.Minute, m_CopyDocument.m_dtCreateDate.Second);
                    DateTime dtChangeTime = new DateTime(m_CopyDocument.m_dtEditDate.Year, m_CopyDocument.m_dtEditDate.Month, m_CopyDocument.m_dtEditDate.Day, m_CopyDocument.m_dtEditDate.Hour, m_CopyDocument.m_dtEditDate.Minute, m_CopyDocument.m_dtEditDate.Second);
                    string strCheckSum = GetBLOBChecksum(m_CopyDocument.m_byFileBLOB, dtCreateTime, dtChangeTime);

                    int nMaxDocumentID = SqlHelper.GetMaxID("idDokument", "Dokument");      //Holt sich die höchste ID aus der Tabelle
                    nMaxDocumentID = nMaxDocumentID + 1;                                    //Zählt diese um 1 hoch
                        
                        
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = (SqlHelper.GetSqlConnectionString());
                    string strSQL = "insert into Dokument values(@nMaxDocumentID, @m_CopyDocumentm_strNodeName, @byFileBLOB, @strFileExtension, @dtCreateTime, @dtChangeTime, @dtDateTimeToday, @NodeGetFolderID, @strCheckSum)";
                 
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = strSQL;

                    cmd.Parameters.AddWithValue("@nMaxDocumentID", nMaxDocumentID);
                    cmd.Parameters.AddWithValue("@m_CopyDocumentm_strNodeName ", m_CopyDocument.m_strNodeName);
                    cmd.Parameters.AddWithValue("@byFileBLOB", m_CopyDocument.m_byFileBLOB);
                    cmd.Parameters.AddWithValue("@strFileExtension", m_CopyDocument.m_strFileExtension);

                    cmd.Parameters.AddWithValue("@dtCreateTime", dtCreateTime);
                    cmd.Parameters.AddWithValue("@dtChangeTime", dtChangeTime);
                    cmd.Parameters.AddWithValue("@dtDateTimeToday", today);
                    cmd.Parameters.AddWithValue("@NodeGetFolderID", Node.GetFolderID());
                    cmd.Parameters.AddWithValue("@strCheckSum", strCheckSum);

                    cmd.Connection = con;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    m_CopyDocument.Clear();
                    tsmCopyDocument.BackColor = Color.White;

                }
            }
            
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        ------------------------------------Wenn-ein-Objekt-gelöscht-werden-soll--------------------------------------
        **************************************************************************************************************/
        private void tsbDelete_Click(object sender, EventArgs e)
        {
            myTreeNode Node = (myTreeNode)trvFolders.SelectedNode;
            string strFolderName = "";

            if(Node != null)
            {
                if (m_lstTempWorkingFiles.Count > 0)
                {
                    MessageBox.Show("Speichern Sie zuerst vor dem Löschen.", "Achtung");
                    return;
                }

                //Wenn es ein Dokument ist
                if (Node.GetDocumentID() > -1)
                {
                    //Durchsucht die Baumstruktur nach dem zum Dokument gehörigen Ordner
                    for(int i = 0; i < this.trvFolders.GetNodeCount(false); i++)
                    {
                        myTreeNode TreeNode = (myTreeNode)this.trvFolders.Nodes[i];

                        //Wenn er diesen gefunden hat
                        if(TreeNode.GetFolderID() == Node.GetFolderID())
                        {
                            strFolderName = TreeNode.GetNodeName(); 
                            break;
                        }
                    }

                    DialogResult dialogResult = MessageBox.Show("Wollen Sie das Dokument \"" + Node.GetNodeName() + "\" aus der Mappe \"" + strFolderName + "\" wirklich löschen?", "Löschen", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        string strAddDate = SqlHelper.GetDateTimeInNumberString(Node.GetAddDate());
                        int nDocumentCheckPK = GetBLOBPrimaryKey(Node.GetFileBLOB(), strAddDate);
                        
                        SqlHelper.SendQueryToDb("Delete From Dokument where idDokument = " + Node.GetDocumentID());
                        SqlHelper.SendQueryToDb("Delete From Dokumentinformation where ID_Dokument = " + Node.GetDocumentID());
                        SqlHelper.SendQueryToDb("Delete From Objektmatchcode where ID_Dokument = " + Node.GetDocumentID());
                        
                        SqlHelper.SendQueryToDb("Delete From DokumentCheck Where idDokumentCheck = " + nDocumentCheckPK);
                        trvFolders.Nodes.Remove(Node);
                    }

                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Wollen Sie den Ordner \"" + Node.GetNodeName() + "\" wirklich löschen?", "Löschen", MessageBoxButtons.YesNo);
                    

                    if (dialogResult == DialogResult.Yes)
                    {
                        TraverseRoot(Node);     //Lösche zuerst die Unterknoten

                        
                        //Lösche dann den Ordner aus den Tabellen
                        SqlHelper.SendQueryToDb("Delete From Dokument where ID_Ordner = " + Node.GetFolderID());
                        SqlHelper.SendQueryToDb("Delete From Ordner Where idOrdner = " + Node.GetFolderID());
                        SqlHelper.SendQueryToDb("Delete From Objektmatchcode Where ID_Ordner = " + Node.GetFolderID());
                        SqlHelper.SendQueryToDb("Delete From Benutzerordner Where ID_Ordner = " + Node.GetFolderID());
                        SqlHelper.SendQueryToDb("Delete From Ordneraktionen Where ID_Ordner = " + Node.GetFolderID());
                        SqlHelper.SendQueryToDb("Delete From Bearbeitungschronik where ID_Ordner = " + Node.GetFolderID());

                        trvFolders.Nodes.Remove(Node);      //Lösche die Node im Tree
                    }

                }

            }
      
        }



        /*************************************************************************************************************
        -------------------------------------Geht-rekursiv-in-den-Knoten-rein-----------------------------------------
        **************************************************************************************************************/
        private void TraverseRoot(myTreeNode nd)
        {
            foreach (myTreeNode child in nd.Nodes)
            {
                TraverseRoot(child);

                if (child.GetDocumentID() > -1)
                {
                    SqlHelper.SendQueryToDb("Delete From Dokumentinformation where ID_Dokument = " + child.GetDocumentID());
                    SqlHelper.SendQueryToDb("Delete From Objektmatchcode where ID_Dokument = " + child.GetDocumentID());
                }
            }

            if (nd.GetDocumentID() > -1)
            {
                SqlHelper.SendQueryToDb("Delete From Dokumentinformation where ID_Dokument = " + nd.GetDocumentID());
                SqlHelper.SendQueryToDb("Delete From Objektmatchcode where ID_Dokument = " + nd.GetDocumentID());
            }
            
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        -------------------------------------Geht-rekursiv-in-den-Knoten-rein-----------------------------------------
        **************************************************************************************************************/
        private void SetNodeColor(myTreeNode nd, Color clrNodeColor)
        {
            foreach (myTreeNode child in nd.Nodes)
            {
                SetNodeColor(child, clrNodeColor);

                if (child.GetDocumentID() > -1)
                {
                    child.ForeColor = clrNodeColor;
                }
            }

        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/



        /*************************************************************************************************************
        ----------------------------------Öffnet-den-Benutzerverwaltungsdialog----------------------------------------
        **************************************************************************************************************/
        private void tsbAddUser_Click(object sender, EventArgs e)
        {
            frmAddNewUser AddNewUser = new frmAddNewUser(m_nUserID);
            AddNewUser.ShowDialog();
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/



        /*************************************************************************************************************
        --------------------------------Funktion-zum-Umbenennen-von-Mappen-und-Dokumenten-----------------------------
        **************************************************************************************************************/
        private void tsmRenameObject_Click(object sender, EventArgs e)
        {
            myTreeNode Node = (myTreeNode)trvFolders.SelectedNode;

            frmEditObjectInfo EditObjectInfo = new frmEditObjectInfo(Node.GetNodeName(), Node.GetDocumentID());
            string strObjectName = "";

            if(EditObjectInfo.ShowDialog() == DialogResult.OK)
            {
                strObjectName = EditObjectInfo.GetNewObjectName();
                
                Node.SetNodeName(strObjectName);
                
                //Wenn es ein Dokument ist
                if (Node.GetDocumentID() > -1)
                {
                    Node.ImageIndex = GetFileImageID(Node.GetFileExtension());
                    Node.SelectedImageIndex = Node.ImageIndex;

                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = (SqlHelper.GetSqlConnectionString());
                    string strSQL = "Update Dokument Set Dokumentname = @strObjectName Where idDokument = @NodeGetDocumentID";

                    SqlCommand cmd = new SqlCommand();
                    cmd.Parameters.AddWithValue("@strObjectName", strObjectName);
                    cmd.Parameters.AddWithValue("@NodeGetDocumentID", Node.GetDocumentID());

                    cmd.CommandText = strSQL;
                    cmd.Connection = con;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                else
                {
                    //SqlHelper.SendQueryToDb("Update Ordner Set Ordnername = '"+ strObjectName + "' Where idOrdner = " + Node.GetFolderID());
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = (SqlHelper.GetSqlConnectionString());
                    string strSQL = "Update Ordner Set Ordnername = @strObjectName Where idOrdner = @NodeGetFolderID";

                    SqlCommand cmd = new SqlCommand();
                    cmd.Parameters.AddWithValue("@strObjectName", strObjectName);
                    cmd.Parameters.AddWithValue("@NodeGetFolderID", @Node.GetFolderID());

                    cmd.CommandText = strSQL;
                    cmd.Connection = con;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        --------------------------------------Ordnervergangenheit-anzeigen--------------------------------------------
        **************************************************************************************************************/
        private void tsbFolderChronic_Click(object sender, EventArgs e)
        {
            myTreeNode Node = (myTreeNode)trvFolders.SelectedNode;

            if (Node != null)
            {
                if (Node.GetDocumentID() == -1)
                {
                    frmShowFolderHistory ShowFolderHistory = new frmShowFolderHistory(Node.GetFolderID(), Node.GetNodeName());
                    ShowFolderHistory.ShowDialog();
                }

            }

        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        -----------------------Zeigt-die-persönlichen-Daten-aller-Mitarbeiter-an--------------------------------------
        **************************************************************************************************************/
        private void tsbShowPersonalData_Click(object sender, EventArgs e)
        {
            frmShowStaffData ShowStaffData = new frmShowStaffData();
            ShowStaffData.ShowDialog();
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        ----------------------------------------Setzt-den-Onlinestatus------------------------------------------------
        **************************************************************************************************************/
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            SetOnlineStatusInDb(0);
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/



        /*************************************************************************************************************
        ----------------------------------Funktion-zum-setzen-des-Onlinestatus----------------------------------------
        **************************************************************************************************************/
        private void SetOnlineStatusInDb(int nOnlineStatus)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = (SqlHelper.GetSqlConnectionString());

            DateTime today = DateTime.Now;
            string strDateTimeToday = today.ToString("yyyy-dd-MM HH:mm:ss");

            string strSQL = "Update Benutzer Set Letzte_Anmeldung = @strDateTimeToday, Onlinestatus = @nOnlineStatus Where idBenutzer = @m_nUserID";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = strSQL;
            cmd.Parameters.AddWithValue("@m_nUserID", m_nUserID);
            cmd.Parameters.AddWithValue("@nOnlineStatus", nOnlineStatus);
            cmd.Parameters.AddWithValue("@strDateTimeToday", strDateTimeToday);

            cmd.Connection = con;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        ------------------------Funktion-zum-Anzeigen-des-Benutzers,-der-gerade-die-Mappe-bearbeitet------------------
        **************************************************************************************************************/
        private void tsmShowCurrentFolderUser_Click(object sender, EventArgs e)
        {
            myTreeNode Node = (myTreeNode)trvFolders.SelectedNode;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = (SqlHelper.GetSqlConnectionString());

            string strSQL = "Select Benutzername From Ordner Join Benutzer on ID_Benutzer = idBenutzer Where idOrdner = @NodeGetFolderID";

            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@NodeGetFolderID", Node.GetFolderID());


            con.Open();


            SqlDataReader reader = cmd.ExecuteReader();
            string strUsername = "";

            while (reader.Read())
            {
                strUsername = reader["Benutzername"].ToString();
            }

            MessageBox.Show("Der Benutzer \"" + strUsername + "\" bearbeitet die Mappe.", "Bearbeiter");
            reader.Close();
            con.Close();
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        ---------------------------Zum-ändern-und-hinzufügen-von-Ordneraktionen---------------------------------------
        **************************************************************************************************************/
        private void tsbEditFolderActions_Click(object sender, EventArgs e)
        {
            frmEditFolderActions EditFolderActions = new frmEditFolderActions();
            EditFolderActions.ShowDialog();
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        ----------------Wenn-sich-das-TreeView-Menü-öffnet-werden-manche Buttons unsichtbar---------------------------
        **************************************************************************************************************/
        private void cntMenuTreeView_Opening(object sender, CancelEventArgs e)
        {
            myTreeNode Node = (myTreeNode)this.trvFolders.SelectedNode;

            if (Node != null)
            {
                this.toolStripSeparator5.Visible = true;
                this.toolStripSeparator6.Visible = true;
                this.toolStripSeparator7.Visible = true;
                this.toolStripSeparator8.Visible = true;
                this.toolStripSeparator9.Visible = true;
                this.tsmDelete.Visible = true;
                this.tsmmDelete.Visible = true;

                if (Node.GetDocumentID() > -1)
                {
                    this.tsmAdd.Visible = false;
                    this.tsmAddDocument.Visible = false;
                    this.tsmFolderAction.Visible = false;
                    this.tsmInsertDocument.Visible = false;
                    this.tsmFolderChronic.Visible = false;
                    this.tsmShowCurrentFolderUser.Visible = false;

                    if (m_CopyDocument.m_bIsEmpty == false)
                    {
                        this.toolStripSeparator8.Visible = true;
                    }
                    else
                    {
                        this.toolStripSeparator8.Visible = false;
                    }

                    this.tsmCopyDocument.Visible = true;
                    this.tsmShowDocumentInfo.Visible = true;
                    this.tsmOpen.Visible = true;

                    if (m_nRights != (int)enRights.Admin)
                    {
                        this.tsmDelete.Visible = false;
                        this.tsmmDelete.Visible = false;
                        this.tsbDelete.Visible = false;

                        this.tsmRenameObject.Visible = false;



                        this.tsmmAddUser.Visible = false;
                        this.tsbAddUser.Visible = false;
                        this.tsbAddFolder.Visible = false;



                        if (Node.WasNodeCreatedInSession())
                        {
                            this.tsbDelete.Visible = true;
                            this.tsmmDelete.Visible = true;
                            this.tsmDelete.Visible = true;
                        }

                    }
                }
                else
                {
                    this.tsmAdd.Visible = true;
                    this.tsmAddDocument.Visible = true;
                    this.tsmFolderAction.Visible = true;

                    if (m_CopyDocument.m_bIsEmpty == false)
                    {
                        this.tsmInsertDocument.Visible = true;
                        this.tsmmInsertDocument.Visible = true;
                        this.toolStripSeparator8.Visible = true;
                    }
                    else
                    {
                        this.tsmInsertDocument.Visible = false;
                        this.tsmmInsertDocument.Visible = false;
                        this.toolStripSeparator8.Visible = false;
                    }

                    this.tsmFolderChronic.Visible = true;
                    this.tsmShowCurrentFolderUser.Visible = true;


                    this.tsmCopyDocument.Visible = false;
                    this.tsmShowDocumentInfo.Visible = false;
                    this.tsmOpen.Visible = false;
                }
            }
            else
            {
                this.tsmAddDocument.Visible = false;
                this.tsmFolderAction.Visible = false;
                this.tsmInsertDocument.Visible = false;
                this.tsmFolderChronic.Visible = false;

                this.tsmShowCurrentFolderUser.Visible = false;
                this.tsmCopyDocument.Visible = false;
                this.tsmShowDocumentInfo.Visible = false;
                this.tsmOpen.Visible = false;

                this.tsmInsertDocument.Visible = false;
                this.tsmAssignMatchcode.Visible = false;
                this.tsmRenameObject.Visible = false;
                this.tsmShowCurrentFolderUser.Visible = false;
                
                this.tsmOpen.Visible = false;
                this.tsmAddDocument.Visible = false;
                this.tsmDelete.Visible = false;

                this.toolStripSeparator5.Visible = false;
                this.toolStripSeparator6.Visible = false;
                this.toolStripSeparator7.Visible = false;
                this.toolStripSeparator8.Visible = false;
                this.toolStripSeparator9.Visible = false;

            }
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/



        /*************************************************************************************************************
        -------------------------Sobald-man-ein-Objekt-im-TreeView-ausgewählt-hat-------------------------------------
        **************************************************************************************************************/
        private void trvFolders_AfterSelect(object sender, TreeViewEventArgs e)
        {
            myTreeNode Node = (myTreeNode)this.trvFolders.SelectedNode;
            UsableButtonAuthorization(Node);

            /*
            if (Node != null)
            {
                this.tsmmDelete.Visible = true;

                if(Node.GetDocumentID() > -1)
                {
                    this.tsbAddDocument.Visible = false;
                    this.tsbFolderAction.Visible = false;
                    this.tsbFolderChronic.Visible = false;
                //    this.tsbCreateWorkFlow.Visible = false;
               //     this.tsbPassFolder.Visible = false;

                    this.tsbDocumentInformation.Visible = true;


                    this.tsmmAddNewDocument.Visible = false;
                    this.tsmmFolderChronic.Visible = false;
                //    this.tsmmCreateWorkFlow.Visible = false;
                    this.tsmmSetFolderAction.Visible = false;
               //     this.tsmmPassFolder.Visible = false;
                    this.tsmmFolder.Visible = false;
                    this.tsmmInsertDocument.Visible = false;

                    this.tsmmShowDocumentInfo.Visible = true;
                    this.tsmmCopyDocument.Visible = true;


                    if (m_nRights != (int)enRights.Admin)
                    {
                        this.tsmDelete.Visible = false;
                        this.tsmmDelete.Visible = false;
                        this.tsbDelete.Visible = false;

                        this.tsmRenameObject.Visible = false;



                        this.tsmmAddUser.Visible = false;
                        //    this.tsmmCreateWorkFlow.Visible = false;



                        //   this.tsbCreateWorkFlow.Visible = false;
                        this.tsbAddUser.Visible = false;

                        this.tsbAddFolder.Visible = false;
                        //    this.tsbTransferFolder.Visible = false;

                        if ((Node.GetDocumentID() > -1)
                        && (Node.WasNodeCreatedInSession()))
                        {
                            this.tsbDelete.Visible = true;
                            this.tsmmDelete.Visible = true;
                            this.tsbDelete.Visible = true;
                        }

                    }
                    else
                    {
                        this.tsbDelete.Visible = true;
                        this.tsmmDelete.Visible = true;
                        this.tsbDelete.Visible = true;
                    }
                }
                else
                {
                    this.tsbAddDocument.Visible = true;
                    this.tsbFolderAction.Visible = true;
                    this.tsbFolderChronic.Visible = true;
                  //  this.tsbCreateWorkFlow.Visible = true;
                 //   this.tsbPassFolder.Visible = true;

                    this.tsbDocumentInformation.Visible = false;
                 //   this.tsbTransferFolder.Visible = true;
                    
                    this.tsmmAddNewDocument.Visible = true;
                    this.tsmmFolderChronic.Visible = true;
               //     this.tsmmCreateWorkFlow.Visible = true;
                    this.tsmmSetFolderAction.Visible = true;
               //     this.tsmmPassFolder.Visible = true;
                    this.tsmmFolder.Visible = true;
                    this.tsmmCopyDocument.Visible = false;

                    this.tsmmShowDocumentInfo.Visible = false;

                    if (m_CopyDocument.m_bIsEmpty == false)
                    {
                        this.tsmmInsertDocument.Visible = true;
                    }
                    else
                    {
                        this.tsmmInsertDocument.Visible = false;
                    }



                    if (m_nRights != (int)enRights.Admin)
                    {
                        this.tsmDelete.Visible = false;
                        this.tsmmDelete.Visible = false;
                        this.tsbDelete.Visible = false;

                        this.tsmCopyDocument.Visible = false;
                        this.tsmInsertDocument.Visible = false;

                        this.tsmAddFolder.Visible = false;
                        this.tsmRenameObject.Visible = false;


                        this.tsmmAddNewFolder.Visible = false;
                        

                        this.tsmmAddUser.Visible = false;
                        //    this.tsmmCreateWorkFlow.Visible = false;



                        //   this.tsbCreateWorkFlow.Visible = false;
                        this.tsbDelete.Visible = false;
                        this.tsbAddUser.Visible = false;

                        this.tsbAddFolder.Visible = false;
                        //    this.tsbTransferFolder.Visible = false;

                        if ((Node.GetDocumentID() > -1)
                        && (Node.WasNodeCreatedInSession()))
                        {
                            this.tsbDelete.Visible = true;
                            this.tsmmDelete.Visible = true;
                        }

                    }

                }
            }*/
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        --------------------------------Deaktiviert-beim-Start-direkt-ein-paar-Buttons--------------------------------
        **************************************************************************************************************/
        private void DeactivateButtonsOnStart()
        {
            this.tsbAddDocument.Visible = false;
            this.tsbFolderAction.Visible = false;
            this.tsbFolderChronic.Visible = false;
          //  this.tsbCreateWorkFlow.Visible = false;
          //  this.tsbPassFolder.Visible = false;

            this.tsbDocumentInformation.Visible = false;
         //   this.tsbTransferFolder.Visible = false;

            this.tsmmAddNewDocument.Visible = false;
            this.tsmmFolderChronic.Visible = false;
        //    this.tsmmCreateWorkFlow.Visible = false;
            this.tsmmSetFolderAction.Visible = false;
         //   this.tsmmPassFolder.Visible = false;
            this.tsmmFolder.Visible = false;

            this.tsmmShowDocumentInfo.Visible = false;

            this.tsmmCopyDocument.Visible = false;
            this.tsmmInsertDocument.Visible = false;
            this.tsmmDelete.Visible = false;
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        ----------------------------Wenn-eine-Mappe-direkt-weitergereicht-werden-soll---------------------------------
        **************************************************************************************************************/
        private void tsbTransferFolder_Click(object sender, EventArgs e)
        {
            myTreeNode Node = (myTreeNode)this.trvFolders.SelectedNode;
            int nUserID = -1;

            if( (Node != null)
            &&  (m_nRights == 1))
            {
                if(Node.GetDocumentID() == -1)
                {
                    frmTransferFolder TransferFolder = new frmTransferFolder(Node.GetUserID(), Node.GetNodeName());
                    
                    if(TransferFolder.ShowDialog() == DialogResult.OK)
                    {
                        nUserID = TransferFolder.GetUserID();

                        
                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = (SqlHelper.GetSqlConnectionString());
                        string strSQL = "Update Ordner Set ID_Benutzer = @nUserID Where idOrdner = @NodeFolderID";

                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = strSQL;
                        cmd.Parameters.AddWithValue("@nUserID", nUserID);
                        cmd.Parameters.AddWithValue("@NodeFolderID", Node.GetFolderID());
                        cmd.Connection = con;

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        

                        DateTime today = DateTime.Now;
                        string strDateTimeToday = today.ToString("yyyy-dd-MM HH:mm:ss");




                        int nMaxFolderActionID = SqlHelper.GetMaxID("idOrdneraktionen", "Ordneraktionen");
                        int nFolderReady = 0;
                        int nProcessingReason = GetProcessingReason(Node.GetFolderID());
                        nMaxFolderActionID = nMaxFolderActionID + 1;



                        con = new SqlConnection();
                        con.ConnectionString = (SqlHelper.GetSqlConnectionString());
                        strSQL = "insert into Ordneraktionen values (@nMaxFolderActionID, @NodeGetFolderID, @m_nUserID, @nProcessingReason, 1, 0, @strDateTimeToday)";

                        cmd = new SqlCommand();
                        cmd.CommandText = strSQL;
                        cmd.Parameters.AddWithValue("@nMaxFolderActionID", nMaxFolderActionID);
                        cmd.Parameters.AddWithValue("@NodeGetFolderID", Node.GetFolderID());
                        cmd.Parameters.AddWithValue("@m_nUserID", nUserID);
                        cmd.Parameters.AddWithValue("@strDateTimeToday", strDateTimeToday);
                        cmd.Parameters.AddWithValue("@nProcessingReason", nProcessingReason);
                        cmd.Parameters.AddWithValue("@nFolderReady", nFolderReady);
                        cmd.Connection = con;

                        int nMaxChonikID = SqlHelper.GetMaxID("idBearbeitungschronik", "Bearbeitungschronik");
                        nMaxChonikID = nMaxChonikID + 1;
                        int PreviousFolderActionID = GetMaxFolderActionID(Node.GetUserID(), Node.GetFolderID());

                        SqlHelper.SendQueryToDb("Insert into Bearbeitungschronik values (" + nMaxChonikID + ", " + Node.GetUserID() + ", " + Node.GetFolderID() + ", " + PreviousFolderActionID + ", '" + strDateTimeToday + "')");

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        Node.SetUserID(nUserID);

                        if( (Node.GetUserID() == m_nUserID)
                        ||  (m_nRights == (int)enRights.Admin) )
                        {
                            Node.ForeColor = Color.Black;
                            SetNodeColor(Node, Color.Black);
                        }
                        else if(m_nRights != (int)enRights.Admin)
                        {
                            Node.ForeColor = Color.Purple;
                            SetNodeColor(Node, Color.Purple);
                        }
                        
                    }

                }

            }

        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        ----------------------------------Gibt-die-größte-OrdnerAktion-ID-zurück--------------------------------------
        **************************************************************************************************************/
        private int GetMaxFolderActionID(int nUserID, int nFolderID)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = (SqlHelper.GetSqlConnectionString());

            string strSQL = "Select max(idOrdnerAktionen) as MaxFolderActionID From Ordneraktionen Where ID_Benutzer = @nUserID and ID_Ordner = @nFolderID";

            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@nUserID", nUserID);
            cmd.Parameters.AddWithValue("@nFolderID", nFolderID);

            con.Open();


            SqlDataReader reader = cmd.ExecuteReader();
            int nMaxFolderActionID = -1;

            while (reader.Read())
            {
                nMaxFolderActionID = (int)reader["MaxFolderActionID"];
            }

            
            reader.Close();
            con.Close();

            return nMaxFolderActionID;
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        -----------------------Funktion,-um-aus-einer-Datei-ein-Binary-Large-Objekt-zu-machen-------------------------
        **************************************************************************************************************/
        private byte[] GetBLOB(string strFilePath)
        {
            try
            {
                FileStream fs = new FileStream(strFilePath, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);

                byte[] data = br.ReadBytes((int)fs.Length);
                fs.Close();
                br.Close();

                return data;
            }
            catch
            {
                return null;
            }

        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/



        /*************************************************************************************************************
        ------------Berechnet-sich-eine-Checksumme-aus-dem-Dateiinhalt-und-aus-dem-Erstell/Änderungsdatum-------------
        **************************************************************************************************************/
        private string GetBLOBChecksum(byte[] BLOB, DateTime dtCreateDate, DateTime dtEditDate)
        {
            byte[] FileBLOB = new byte[BLOB.Length];
            BLOB.CopyTo(FileBLOB, 0);

            string strSHA256 = "";
            byte[] byCreateDate = BitConverter.GetBytes(dtCreateDate.Ticks);
            byte[] byEditDate = BitConverter.GetBytes(dtEditDate.Ticks);

            byCreateDate.CopyTo(FileBLOB, 0);
            byEditDate.CopyTo(FileBLOB, 0);


            SHA256 SHA256 = new SHA256CryptoServiceProvider();
            byte[] SHA256Hash = SHA256.ComputeHash(FileBLOB);

            strSHA256 = BitConverter.ToString(SHA256Hash).Replace("-", "").ToLower();
            return strSHA256;
        }




        private int GetBLOBPrimaryKey(byte[] BLOB, string strAddDateTime)
        {
            byte[] FileBLOB = new byte[BLOB.Length];
            BLOB.CopyTo(FileBLOB, 0);

            string strSHA256 = "";
            byte[] byAddDate = System.Text.Encoding.ASCII.GetBytes("k" + strAddDateTime + "l");


            byAddDate.CopyTo(FileBLOB, 0);


            SHA256 SHA256 = new SHA256CryptoServiceProvider();
            byte[] SHA256Hash = SHA256.ComputeHash(FileBLOB);

            strSHA256 = BitConverter.ToString(SHA256Hash).Replace("-", "").ToLower();
            string strNumbers = "";
            int nCharCounter = 0;

            for (int i = 0; i < strSHA256.Length; i++)
            {
                if( (strSHA256[i] >= 48)
                &&  (strSHA256[i]) <= 57 )
                {
                    strNumbers += strSHA256[i];
                    nCharCounter++;
                }

                if (nCharCounter >= 3)
                    break;
            }

            nCharCounter = 0;

            for (int i = strSHA256.Length/2; i < strSHA256.Length; i++)
            { 
                if( (strSHA256[i] >= 48)
                &&  (strSHA256[i]) <= 57 )
                {
                    strNumbers += strSHA256[i];
                    nCharCounter++;
                }

                if (nCharCounter >= 3)
                    break;
            }

            nCharCounter = 0;

            for (int i = strSHA256.Length/3; i < strSHA256.Length; i++ )
            {
                 if( (strSHA256[i] >= 48)
                &&  (strSHA256[i]) <= 57 )
                {
                    strNumbers += strSHA256[i];
                    nCharCounter++;
                }

                 if (nCharCounter >= 3)
                     break;
            }
                
            return Convert.ToInt32(strNumbers);
        }





        private string GetBLOBChecksumSimple(byte[] BLOB, DateTime dtAddDate, int nDokCheckPK)
        {
            byte[] FileBLOB = new byte[BLOB.Length];
            BLOB.CopyTo(FileBLOB, 0);

            string strSHA256 = "";

            byte[] byAddDate = BitConverter.GetBytes(dtAddDate.Ticks);
            byte[] bySomeString = System.Text.Encoding.ASCII.GetBytes("H4l0S");
            byte[] byDokCheckPK = BitConverter.GetBytes(nDokCheckPK);

            byAddDate.CopyTo(FileBLOB, 0);
            bySomeString.CopyTo(FileBLOB, 0);
            byDokCheckPK.CopyTo(FileBLOB, 0);

            SHA256 SHA256 = new SHA256CryptoServiceProvider();
            byte[] SHA256Hash = SHA256.ComputeHash(FileBLOB);

            strSHA256 = BitConverter.ToString(SHA256Hash).Replace("-", "").ToLower();
            return strSHA256;
        }


        private bool IsFileOriginal(byte[] byDocumentBLOB, DateTime dtAddDate)
        {
            string strChecksumDB = "";
            string strChecksumCalc = "";

            byte[] byBLOB = new byte[byDocumentBLOB.Length];
            byDocumentBLOB.CopyTo(byBLOB, 0);
            bool bSameChecksum = false;

            string strAddDate = SqlHelper.GetDateTimeInNumberString(dtAddDate);
            int nDocumentCheckPK = GetBLOBPrimaryKey(byBLOB, strAddDate);
            strChecksumCalc = GetBLOBChecksumSimple(byBLOB, dtAddDate, nDocumentCheckPK);

            SqlConnection con = new SqlConnection();
            con.ConnectionString = SqlHelper.GetSqlConnectionString();
            string strSQL = "SELECT Checksum FROM DokumentCheck WHERE idDokumentCheck = @nDocumentCheckPK";

            

            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@nDocumentCheckPK", nDocumentCheckPK);

            con.Open();


            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                strChecksumDB = (string)reader["Checksum"];
            }

            if (strChecksumDB == strChecksumCalc)
            {
                bSameChecksum = true;
            }


            reader.Close();
            con.Close();

            return bSameChecksum;
        }


        /*************************************************************************************************************
        --------------------Erstellt-aus-dem-Binary-Large-Objekt-wieder-eine-Datei-für-den-Viewer---------------------
        **************************************************************************************************************/
        private void WriteStreamToFileForViewer(byte[] byFileBLOB, string strFileExtension)
        {
            DeleteLastTempViewerFile();
            
            m_strTempViewerFile = m_strTempFolder + "Viewer_Temp" + strFileExtension;
            MemoryStream memStream = new MemoryStream(byFileBLOB);
            Stream strmFile = File.Create(m_strTempViewerFile);
            memStream.CopyTo(strmFile);

            strmFile.Close();
            memStream.Close();
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/



        /*************************************************************************************************************
        --------------------Erstellt-aus-dem-Binary-Large-Objekt-wieder-eine-Datei-für-die-Bearbeitung----------------
        **************************************************************************************************************/
        private string WriteStreamToFile(string strTempFileName, byte[] byFileBLOB)
        {
            string strTempFilePath = m_strTempFolder + strTempFileName;


            try
            {
                MemoryStream memStream = new MemoryStream(byFileBLOB);
                Stream strmFile = File.Create(strTempFilePath);
                memStream.CopyTo(strmFile);

                strmFile.Close();
                memStream.Close();
            }
            catch
            {
                MessageBox.Show("Die Datei ist schon geöffnet", "Fehler");
                return string.Empty;
            }

            return strTempFilePath;
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        ------------------------------Löscht-die-temporär-erzeugte-Datei-für-den-Viewer-------------------------------
        **************************************************************************************************************/
        private void DeleteLastTempViewerFile()
        {
            if (File.Exists(m_strTempViewerFile))
            {
                wbBrwShowPDF.Navigate("about:blank");
            
                while (wbBrwShowPDF.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(100);
                }

                if (pcbImage.Image != null)
                {
                    pcbImage.Image.Dispose();
                    pcbImage.Image = null;
                }

                try
                {
                    File.Delete(m_strTempViewerFile);
                }
                catch
                { 
                
                }
            }
        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/




        /*************************************************************************************************************
        -----------------------------------Löscht-die-temporär-erstellten-Dateien-wieder------------------------------
        **************************************************************************************************************/
        private int DeleteTempFiles()
        {
            string strTempFilePath = "";
            int nFileErrorCount = 0;

            for (int i = 0; i < m_lstTempWorkingFiles.Count; i++)
            {
                strTempFilePath = m_strTempFolder + m_lstTempWorkingFiles[i].GetTempFileName();

                if(File.Exists(strTempFilePath))
                {
                    try
                    {
                        File.Delete(strTempFilePath);
                        m_lstTempWorkingFiles.RemoveAt(i);
                        i--;
                    }
                    catch
                    {
                        nFileErrorCount++;
                    }
                }
            }

            if (m_lstTempWorkingFiles.Count <= 0)
            {
                tsbSaveDocumentsInDatabase.Enabled = false;
            }

            return nFileErrorCount;

        }
       /*************************************************************************************************************
       **************************************************************************************************************
       **************************************************************************************************************/




        /*************************************************************************************************************
        ------------------------------Speichert-die-Dokumente-wieder-in-der-Datenbank-ab------------------------------
        **************************************************************************************************************/
        private int SaveDocumentChangesInDataBase()
        {
            int nDocumentSaveCounter = 0;
            int nFailCounter = 0;

            string strDocuments = "";
            string strTempFilePath = "";
            string strChecksumTempFile = "";
            byte[] byFileBLOB = null;

            List<byte[]> lstFileBLOB = new List<byte[]>();

            for (int i = 0; i < m_lstTempWorkingFiles.Count; i++)
            {
                strTempFilePath = m_strTempFolder + m_lstTempWorkingFiles[i].GetTempFileName();

                FileInfo fi1 = new FileInfo(strTempFilePath);
                byFileBLOB = GetBLOB(strTempFilePath);

                if (byFileBLOB == null)
                {
                    nFailCounter++;
                    lstFileBLOB.Add(null);
                    continue;
                }

                lstFileBLOB.Add(byFileBLOB);
                strChecksumTempFile = GetBLOBChecksum(byFileBLOB, fi1.CreationTime, fi1.LastWriteTime);

                if (strChecksumTempFile != m_lstTempWorkingFiles[i].GetChecksum())
                {
                    strDocuments += "\n     -" + m_lstTempWorkingFiles[i].GetDocumentName();
                    nDocumentSaveCounter++;
                }
                
            }

            if( (nDocumentSaveCounter <= 0)
            &&  (nFailCounter <= 0) )
            {
                DeleteTempFiles();
                return 0;
            }
            else if ((nDocumentSaveCounter <= 0)
            && (nFailCounter > 0))
            {
                if (MessageBox.Show("Alle Dokumente befinden sich im Zugriff. Es wird nichts gespeichert. Trotzdem fortfahren?", "Warnung!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    return 0;
                else 
                    return 1;
            }



            if (MessageBox.Show("Wollen Sie die Änderungen an den Dokumenten bestätigen? Es werden folgende Dokumente geändert: " + strDocuments, "Speichern", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = (SqlHelper.GetSqlConnectionString());
                con.Open();

                DateTime ctEditDate = DateTime.Now;
                string strOpenFiles = "";

                for (int i = 0; i < m_lstTempWorkingFiles.Count; i++)
                {
                    if(lstFileBLOB[i] != null)
                    {
                        byFileBLOB = lstFileBLOB[i];
                        strTempFilePath = m_strTempFolder + m_lstTempWorkingFiles[i].GetTempFileName();

                        myTreeNode DocNode = m_lstTempWorkingFiles[i].GetNode();

                        string strSQL = "";
                        string strAddDate = SqlHelper.GetDateTimeInNumberString(DocNode.GetAddDate());
                        int nOldDocCheckPK = GetBLOBPrimaryKey(DocNode.GetFileBLOB(), strAddDate);
                        int nNewDocCheckPK = GetBLOBPrimaryKey(byFileBLOB, strAddDate);

                        string strChecksumCalc = GetBLOBChecksumSimple(byFileBLOB, DocNode.GetAddDate(), nNewDocCheckPK);
                        SqlCommand cmd = new SqlCommand();

                        if (!IsFileOriginal(DocNode.GetFileBLOB(), DocNode.GetAddDate()))
                        {
                            strSQL = "Insert Into DokumentCheck Values (@nNewidDocCheckPK, @strChecksumCalc)";
                            cmd = new SqlCommand(strSQL, con);

                            cmd.Parameters.AddWithValue("@strChecksumCalc", strChecksumCalc);
                            cmd.Parameters.AddWithValue("@nNewidDocCheckPK", nNewDocCheckPK);
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            strSQL = "Update DokumentCheck Set idDokumentCheck = @nNewidDocCheckPK, Checksum = @strNewChecksum Where idDokumentCheck = @nOldidDocCheckPK";
                            cmd = new SqlCommand(strSQL, con);
                            cmd.Parameters.AddWithValue("@nNewidDocCheckPK", nNewDocCheckPK);
                            cmd.Parameters.AddWithValue("@nOldidDocCheckPK", nOldDocCheckPK);
                            cmd.Parameters.AddWithValue("strNewChecksum", strChecksumCalc);

                            cmd.ExecuteNonQuery();
                        }


                        int nDocumentID = m_lstTempWorkingFiles[i].GetDocumentID();

                        
                        


                        strSQL = "Update Dokument Set Dokument_BLOB = @byFileBLOB, Aenderungsdatum = @ctEditDate  Where idDokument = @nDocumentID";

                        cmd = new SqlCommand(strSQL, con);
                        cmd.Parameters.AddWithValue("@nDocumentID", nDocumentID);
                        cmd.Parameters.AddWithValue("@byFileBLOB", byFileBLOB);
                        cmd.Parameters.AddWithValue("@ctEditDate", ctEditDate);

                        cmd.ExecuteNonQuery();

                        
                        DocNode.SetFileBLOB(byFileBLOB);
                        DocNode.SetEditDate(ctEditDate);
                    }
                }

                con.Close();

                DeleteTempFiles();

                if (m_lstTempWorkingFiles.Count > 0)
                {
                    for (int i = 0; i < m_lstTempWorkingFiles.Count; i++)
                    {
                        strOpenFiles += "       -" + m_lstTempWorkingFiles[i].GetDocumentName() + "\n";
                    }

                    if (MessageBox.Show("Folgende Dokumente konnten weder gespeichert noch gelöscht werden, da sie sich noch im Zugriff befinden:\n" + strOpenFiles + "Trotzdem fortfahren?", "Speichern unvollständig", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return 1;
                    }
                }
            }

            return 0;

        }






        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            int nError = 0;

            if (m_lstTempWorkingFiles.Count > 0)
            {
                nError = SaveDocumentChangesInDataBase();

                if (nError == 1)
                {
                    e.Cancel = true;
                }
            }

            DeleteLastTempViewerFile();
            DeleteTempFiles();
            SetOnlineStatusInDb(0);
            /*
            string strOpenFiles = "";

            if (m_lstTempWorkingFiles.Count > 0)
            {
                SaveDocumentChangesInDataBase();

                if (m_lstTempWorkingFiles.Count > 0)
                {
                    for (int i = 0; i < m_lstTempWorkingFiles.Count; i++)
                    {
                        strOpenFiles += "       -" + m_lstTempWorkingFiles[i].GetDocumentName() + "\n";
                    }

                    if (MessageBox.Show("Folgende Dokumente konnten weder gespeichert noch gelöscht werden, da sie sich noch im Zugriff befinden:\n" + strOpenFiles + "Trotzdem fortfahren?", "Speichern unvollständig", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                }

            }*/
        }




        private void tsbSaveDocumentsInDatabase_Click(object sender, EventArgs e)
        {
            string strOpenFiles = "";

            if (m_lstTempWorkingFiles.Count > 0)
            {
                SaveDocumentChangesInDataBase();

                if (m_lstTempWorkingFiles.Count > 0)
                {
                    for (int i = 0; i < m_lstTempWorkingFiles.Count; i++)
                    {
                        strOpenFiles += "       -" + m_lstTempWorkingFiles[i].GetDocumentName() + "\n";
                    }

                    MessageBox.Show("Folgende Dokumente konnten weder gespeichert noch gelöscht werden, da sie sich noch im Zugriff befinden:\n" + strOpenFiles, "Speichern unvollständig");
                }

            }

        }
        /*************************************************************************************************************
        **************************************************************************************************************
        **************************************************************************************************************/


        private bool IsDocumentsNotSavedInFolder(myTreeNode item)
        {
            for (int i = 0; i < item.Nodes.Count; i++)
            {
                myTreeNode SubItem = (myTreeNode)item.Nodes[i];

                for (int j = 0; j < m_lstTempWorkingFiles.Count; j++)
                {
                    if (m_lstTempWorkingFiles[j].GetDocumentID() == SubItem.GetDocumentID())
                    {
                        return true;
                    }

                }

            }

            return false;

        }



        private void UsableButtonAuthorization(myTreeNode Node)
        {
            if(Node != null)
            {
                if (Node.GetDocumentID() > -1)
                {
                    this.tsbAddDocument.Visible = false;
                    this.tsbFolderAction.Visible = false;
                    this.tsbFolderChronic.Visible = false;

                    this.tsbDocumentInformation.Visible = true;


                    this.tsmmAddNewDocument.Visible = false;
                    this.tsmmFolderChronic.Visible = false;
                    this.tsmmSetFolderAction.Visible = false;
                    this.tsmmFolder.Visible = false;
                    this.tsmmInsertDocument.Visible = false;

                    this.tsmmShowDocumentInfo.Visible = true;
                    this.tsmmCopyDocument.Visible = true;


                    if (m_nRights != (int)enRights.Admin)
                    {
                        this.tsmDelete.Visible = false;
                        this.tsmmDelete.Visible = false;
                        this.tsbDelete.Visible = false;

                        this.tsmRenameObject.Visible = false;



                        this.tsmmAddUser.Visible = false;
                        this.tsbAddUser.Visible = false;
                        this.tsbAddFolder.Visible = false;



                        if(Node.WasNodeCreatedInSession())
                        {
                            this.tsbDelete.Visible = true;
                            this.tsmmDelete.Visible = true;
                            this.tsmDelete.Visible = true;
                        }

                    }

                }
                else
                {
                    this.tsbAddDocument.Visible = true;
                    this.tsbFolderAction.Visible = true;
                    this.tsbFolderChronic.Visible = true;

                    this.tsbDocumentInformation.Visible = false;
                    
                    this.tsmmAddNewDocument.Visible = true;
                    this.tsmmFolderChronic.Visible = true;
                    this.tsmmSetFolderAction.Visible = true;
                    this.tsmmFolder.Visible = true;
                    this.tsmmCopyDocument.Visible = false;

                    this.tsmmShowDocumentInfo.Visible = false;

                    if (m_CopyDocument.m_bIsEmpty == false)
                    {
                        this.tsmmInsertDocument.Visible = true;
                    }
                    else
                    {
                        this.tsmmInsertDocument.Visible = false;
                    }



                    if (m_nRights != (int)enRights.Admin)
                    {
                        this.tsmDelete.Visible = false;
                        this.tsmmDelete.Visible = false;
                        this.tsbDelete.Visible = false;

                        this.tsmCopyDocument.Visible = false;
                        this.tsmInsertDocument.Visible = false;

                        this.tsmAddFolder.Visible = false;
                        this.tsmRenameObject.Visible = false;


                        this.tsmmAddNewFolder.Visible = false;
                        

                        this.tsmmAddUser.Visible = false;
                        //    this.tsmmCreateWorkFlow.Visible = false;



                        //   this.tsbCreateWorkFlow.Visible = false;
                        this.tsbDelete.Visible = false;
                        this.tsbAddUser.Visible = false;

                        this.tsbAddFolder.Visible = false;
                        //    this.tsbTransferFolder.Visible = false;

                     /*   if ((Node.GetDocumentID() > -1)
                        && (Node.WasNodeCreatedInSession()))
                        {
                            this.tsmDelete.Visible = true;
                            this.tsbDelete.Visible = true;
                            this.tsmmDelete.Visible = true;
                        }*/

                    }

                }
            
            }

        }


    }


    
}
