using Ionic.Zip;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.Devices;
using Microsoft.VisualBasic.FileIO;
using PointBlank.DLL;
using PointBlank.DLL.Modul;
using PointBlank.DLL.Xml;
using PointBlank.Launcher.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Reflection;

namespace PointBlank.Launcher
{
    
    public partial class Launcher : Form
    {

        public Connection Connection;
        public WebClient GameUpdate;
        public Computer Computer;
        public WebClient Web;
        private AuthModul AuthModul;
        private bool Value = true;
        CookieContainer Cookie = null;
        private string token = "";
        private string HWIDs = "";

        public Launcher(Connection Connection, AuthModul AuthModul)
        {
            this.GameUpdate = new WebClient();
            this.Computer = new Computer();
            this.Web = new WebClient();
            this.Connection = Connection;
            this.AuthModul = AuthModul;
            InitializeComponent();
            this.GameUpdate.DownloadFileCompleted += new AsyncCompletedEventHandler(this.GameUpdate_DownloadCompleted);
            this.GameUpdate.DownloadProgressChanged += new DownloadProgressChangedEventHandler(this.GameUpdate_DownloadProgressChanged);
        }

        private void Logger(string Text)
        {
            string Path = Application.StartupPath + "\\PBLauncher.log";
            DateTime Now = DateTime.Now;
            StreamWriter Writer = new StreamWriter(Path, true);
            Writer.WriteLine(Text);
            Writer.Flush();
            Writer.Close();
        }

        [DllImport("kernel32.dll")]
        static extern IntPtr LoadLibrary(string dllName);
        
        public void Launcher_Load(object sender, EventArgs e)
        {           
            try
            {
                HWIDs = cHWID.getUniqueID();
            }
            catch (Exception)
            {
                string message = "ไม่สารถตรวจสอบเครื่องท่านได้ กรุณาติดต่อทีมงาน";
                string caption = "แจ้งเตือน";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
            }

            Cookie = new CookieContainer(); // important
            SearchFileExtension();

            //label1.Visible = false;
            this.BackgroundImage = Resources.back_login2;
            this.KeyPreview = true;
            int Button = int.Parse(this.Web.DownloadString(Modul.WEB + "launcher/status/button.txt"));
            //this.Label.Text = " ";
            this.Label_File.Text = "ไฟล์";
            this.Label_Total.Text = "ทั้งหมด";
            base.WindowState = FormWindowState.Normal;
            base.Visible = true;
            this.Label_Version.Visible = false; // 
            this.Start.Visible = true;
            LauncherModul.LastVersion = int.Parse(this.Web.DownloadString(Modul.WEB + "launcher/versions/last_client_version.txt"));
            this.Label_Version.Text = "เวอร์ชั่นแพทช์: " + File.ReadAllText(Application.StartupPath + @"\pbphonixclient.version") + "/" + LauncherModul.LastVersion.ToString();
            this.Start.Enabled = false;
            if (this.Computer.FileSystem.DirectoryExists(Application.StartupPath + @"\_LauncherPatchFiles"))
            {
                this.Computer.FileSystem.DeleteDirectory(Application.StartupPath + @"\_LauncherPatchFiles", DeleteDirectoryOption.DeleteAllContents);
            }
            //this.Label.Text = "คุณสามารถเริ่มเกมได้ในขณะนี้!";
            if (Button == 1)
            {
                this.Start.Enabled = true;
            }
            else if (Button == 2)
            {
                this.Start.BackgroundImage = Resources.Start_Disable;
                this.Start.Enabled = false;
            }
            else if (Button == 3)
            {
                this.Start.Enabled = true;
            }
            else if (Button == 4)
            {
                this.Start.Enabled = true;
            }

            this.pn_load.Visible = false;
            this.Start.Visible = false;

            if (LauncherModul.LastVersion.ToString() == File.ReadAllText(Application.StartupPath + @"\pbphonixclient.version"))
            {
                this.XmlLoad();
            }
            else if (LauncherModul.LastVersion < int.Parse(File.ReadAllText(Application.StartupPath + @"\pbphonixclient.version")))
            {
                File.WriteAllText(Application.StartupPath + @"\pbphonixclient.version", (0).ToString());
                Value = true;
                //this.label1.Text = "กรุณาอัปเดตตัวเกมส์ของคุณ.";
                this.ArchiveBar.Width = 0;
                this.TotalBar.Width = 0;

                this.BackgroundImage = Resources.back_starting;
                this.txt_user.Visible = false;
                this.txt_pass.Visible = false;
                this.btn_login.Visible = false;
                this.pn_load.Visible = false;
                this.Start.Visible = false;

                this.Start.Visible = false;
                this.Start.Enabled = true;
                this.UpdatePatch.Enabled = true;
                this.UpdatePatch.Visible = true;
            }
            else
            {
                Value = true;
                //this.label1.Text = "กรุณาอัปเดตตัวเกมส์ของคุณ.";
                this.ArchiveBar.Width = 0;
                this.TotalBar.Width = 0;

                this.BackgroundImage = Resources.back_starting;
                this.txt_user.Visible = false;
                this.txt_pass.Visible = false;
                this.btn_login.Visible = false;
                this.pn_load.Visible = false;
                this.Start.Visible = false;

                this.Start.Visible = false;
                this.Start.Enabled = true;
                this.UpdatePatch.Enabled = true;
                this.UpdatePatch.Visible = true;
            }
        }
        
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            if (Value == false)
            {
                Environment.Exit(0);
            }
            else
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    DialogResult Result = MessageBox.Show("ต้องการจะปิดโปรแกรมใช่หรือไม่?", Modul.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (Result == DialogResult.Yes)
                    {
                        this.Logger("PBLauncher End - " + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss"));
                        Environment.Exit(0);
                    }
                    else
                    {
                        e.Cancel = Value;
                    }
                }
                else
                {
                    e.Cancel = Value;
                }
            }
        }
        
        private void Launcher_MouseDown(object sender, MouseEventArgs e)
        {
            if (Control.MouseButtons == MouseButtons.Left)
            {
                this.NewPoint.X = base.Left - Control.MousePosition.X;
                this.NewPoint.Y = base.Top - Control.MousePosition.Y;
            }
        }
        
        private void Launcher_MouseMove(object sender, MouseEventArgs e)
        {
            if (Control.MouseButtons == MouseButtons.Left)
            {
                base.Left = this.NewPoint.X + Control.MousePosition.X;
                base.Top = this.NewPoint.Y + Control.MousePosition.Y;
            }
        }
        
        private void Closed_Click(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                bool flag = Operators.CompareString(process.ProcessName, "PHOENIXLauncher", false) == 0;
                if (flag)
                {
                    process.Kill();
                }
            }
        }

        private void Closed_MouseLeave(object sender, EventArgs e)
        {
            this.Exit.Image = Resources.Closed_Normal;
            this.Exit.BackColor = System.Drawing.Color.Transparent;
        }

        private void Closed_MouseMove(object sender, EventArgs e)
        {
            this.Exit.Image = Resources.Closed_Over;
            this.Exit.BackColor = System.Drawing.Color.Transparent;
        }

        private void Minimize_Click(object sender, EventArgs e)
        {
            base.WindowState = FormWindowState.Minimized;
        }

        private void Minimize_MouseLeave(object sender, EventArgs e)
        {
            this.Minimize.BackgroundImage = Resources.Hide_Normal;
            this.Minimize.BackColor = System.Drawing.Color.Transparent;
        }

        private void Minimize_MouseMove(object sender, MouseEventArgs e)
        {
            this.Minimize.BackgroundImage = Resources.Hide_Over;
            this.Minimize.BackColor = System.Drawing.Color.Transparent;
        }

        private void Verif_Click(object sender, EventArgs e)
        {
            try
            {
                this.FileName.Enabled = true;
                this.FileName.Visible = true;

                int Button = int.Parse(this.GameUpdate.DownloadString(Modul.WEB + "launcher/status/button.txt"));
                string Check = this.GameUpdate.DownloadString(Modul.WEB + "launcher/status/check.txt");
                string Text = this.GameUpdate.DownloadString(Modul.WEB + "launcher/status/text.txt");

                if (Button == 1)
                {

                }
                else if (Button == 2)
                {
                    if (MessageBox.Show(Text.ToString(), Modul.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                    {

                    }
                    else if (MessageBox.Show(Text.ToString(), Modul.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                    {

                    }
                    this.Logger("# PBLauncher Status - " + Text.ToString());
                }
                else if (Button == 3)
                {
                    MessageBox.Show(Check.ToString(), Modul.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }
            }
            catch
            {
                MessageBox.Show("เกิดข้อผิดพลาดที่ไม่ทราบสาเหตุ. กรุณาลองใหม่ในภายหลัง...", Modul.Name, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
            }
        }

        private void Check_MouseLeave(object sender, EventArgs e)
        {
        }

        private void Check_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private bool value = true;
        private static Properties.Settings settings = Properties.Settings.Default;

        
        Process[] processes = Process.GetProcesses();
        private void Start_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Application.StartupPath + @"\PB-INDY.exe", " /GameID:GarenaPB /Token: " + token);

                foreach (Process process in processes)
                {

                    bool flag55 = Operators.CompareString(process.ProcessName, "PBINDYLauncher", false) == 0;
                    if (flag55)
                    {
                        process.Kill();
                        MessageBox.Show("ปิดเกมก่อนเปิดตัวเข้าเกมส์!", Modul.Name, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("Error : " + ee.ToString());
            }
        }
        private void btn_login_MouseLeave(object sender, EventArgs e)
        {
            this.btn_login.BackgroundImage = Resources.btn_lg3;
        }

        private void btn_login_MouseMove(object sender, MouseEventArgs e)
        {
            this.btn_login.BackgroundImage = Resources.btn_lghv;
        }

        private void Start_MouseLeave(object sender, EventArgs e)
        {
            this.Start.BackgroundImage = Resources.btn_stl;
        }

        private void Start_MouseMove(object sender, MouseEventArgs e)
        {
            this.Start.BackgroundImage = Resources.btn_stlh;
        }

        public void Bar1SetProgress(long received, long maximum, bool progress)
        {
            this.ArchiveBar.Width = (int)((received * 463) / maximum);
        }

        public void Bar2SetProgress(ulong received, ulong maximum)
        {
            this.TotalBar.Width = (int)((received * ((ulong)463)) / maximum);
        }

        private void UpdatePatch_MouseLeave(object sender, EventArgs e)
        {
            this.UpdatePatch.BackgroundImage = Resources.btn_ud6;
        }

        private void UpdatePatch_MouseMove(object sender, MouseEventArgs e)
        {
            this.UpdatePatch.BackgroundImage = Resources.btn_ud7;
        }

        private List<XMLModel> Parse(string Path)
        {
            List<XMLModel> List = new List<XMLModel>();
            XmlDocument Document = new XmlDocument();
            FileStream Stream = new FileStream(Path, FileMode.Open);
            if (Stream.Length == 0L)
            {
                this.Logger("[ERROR] CODE PAUSE");
            }
            else
            {
                try
                {
                    Document.Load(Stream);
                    for (XmlNode Node = Document.FirstChild; Node != null; Node = Node.NextSibling)
                    {
                        if ("List".Equals(Node.Name))
                        {
                            for (XmlNode Node2 = Node.FirstChild; Node2 != null; Node2 = Node2.NextSibling)
                            {
                                if ("File".Equals(Node2.Name))
                                {
                                    XmlNamedNodeMap attributes = Node2.Attributes;
                                    List.Add(new XMLModel(attributes.GetNamedItem("Name").Value));
                                }
                            }
                        }
                    }
                }
                catch (XmlException exception)
                {
                    MessageBox.Show(exception.ToString());
                }
            }
            Stream.Dispose();
            Stream.Close();
            return List;
        }

        public void XmlLoad()
        {
            try
            {
                if (File.Exists(Application.StartupPath + @"\Removes.xml"))
                {
                    List<XMLModel> List = this.Parse(Application.StartupPath + @"\Removes.xml");
                    int Total = 0;
                    //this.Label.Text = "กำลังลบไฟล์ที่ไม่ได้ใช้.";
                    this.FileName.Visible = true;
                    foreach (XMLModel Model in List)
                    {
                        Total++;
                        if (File.Exists(Application.StartupPath + Model.Name))
                        {
                            this.FileName.Text = Model.Name;
                            File.Delete(Application.StartupPath + Model.Name);
                        }
                        this.Bar2SetProgress((ulong)Total, (ulong)List.Count);
                    }
                    File.Delete(Application.StartupPath + @"\Removes.xml");
                    //this.Label.Text = "คุณสามารถเริ่มเกมได้ในขณะนี้!";
                    this.FileName.Visible = false;
                    this.Start.Enabled = true;
                    this.Start.BackgroundImage = Resources.Start_Normal;
                }
            }
            catch
            {
                MessageBox.Show("เกิดข้อผิดพลาดที่ไม่ทราบสาเหตุ. กรุณาลองใหม่ในภายหลัง...", Modul.Name, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
            }
        }

        private void GameUpdate_DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                if (e.Error == null)
                {
                    int Num = int.Parse(File.ReadAllText(Application.StartupPath + @"\pbphonixclient.version"));
                    int Version = Num + 1;
                    this.ArchiveBar.Width = 0;
                    this.Unzip(Application.StartupPath, string.Concat(new object[] { Application.StartupPath, @"\_DownloadPatchFiles\UpdatePatch_Client_", Version, ".zip" }));
                    this.Timer.Start();
                    Directory.Delete(Application.StartupPath + @"\_DownloadPatchFiles", true);
                    this.ArchiveBar.Width = 463;
                }
            }
            catch
            {
                MessageBox.Show("เกิดข้อผิดพลาดที่ไม่ทราบสาเหตุ. กรุณาลองใหม่ในภายหลัง...", Modul.Name, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
            }
        }

        private void GameUpdate_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.Bar1SetProgress(e.BytesReceived, e.TotalBytesToReceive, false);
        }

        private void Unzip_ExtractProgressChanged(object sender, ExtractProgressEventArgs e)
        {
            if (e.TotalBytesToTransfer != 0L)
            {
                this.Bar1SetProgress(e.BytesTransferred, e.TotalBytesToTransfer, false);
            }
            this.ArchiveBar.Refresh();
            this.ArchiveBar.Update();
        }

        public void Unzip(string TargetDir, string ZipToUnpack)
        {
            try
            {
                SearchFileExtension();

                //this.Label.Text = "กำลังติดตั้ง...";
                Value = true;
                using (ZipFile File = ZipFile.Read(ZipToUnpack))
                {
                    File.ExtractProgress += new EventHandler<ExtractProgressEventArgs>(this.Unzip_ExtractProgressChanged);
                    int Total = 0;
                    int Count = 0;
                    foreach (ZipEntry Entry in File)
                    {
                        if (!Entry.IsDirectory)
                        {
                            Count++;
                        }
                    }
                    foreach (ZipEntry Entry in File)
                    {
                        string FileName = Entry.FileName;
                        if (FileName.Contains("/"))
                        {
                            int Num = FileName.LastIndexOf("/");
                            FileName = FileName.Substring(Num + 1);
                        }
                        if (!Entry.IsDirectory)
                        {
                            if (FileName != "pbphonixclient.version")
                            {
                                this.Logger("# Patch file Update Exception # FileName : " + FileName);
                            }
                            base.Update();
                            this.Refresh();
                            this.Bar2SetProgress((ulong)(++Total), (ulong)Count);
                        }
                        Entry.Extract(TargetDir, ExtractExistingFileAction.OverwriteSilently);
                    }
                }
            }
            catch
            {
                MessageBox.Show("เกิดข้อผิดพลาดที่ไม่ทราบสาเหตุ. กรุณาลองใหม่ในภายหลัง...", Modul.Name, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                LauncherModul.LastVersion = int.Parse(this.Web.DownloadString(Modul.WEB + "launcher/versions/last_client_version.txt"));

                if (LauncherModul.LastVersion == int.Parse(File.ReadAllText(Application.StartupPath + @"\pbphonixclient.version")))
                {
                    this.KeyPreview = true;
                    int Button = int.Parse(this.Web.DownloadString(Modul.WEB + "launcher/status/button.txt"));
                    base.Visible = true;
                    this.Label_Version.Visible = false; // 
                    this.Start.Visible = true;
                    this.UpdatePatch.Visible = false;
                    LauncherModul.LastVersion = int.Parse(this.Web.DownloadString(Modul.WEB + "launcher/versions/last_client_version.txt"));
                    this.Label_Version.Text = "เวอร์ชั่นแพทช์: " + File.ReadAllText(Application.StartupPath + @"\pbphonixclient.version") + "/" + LauncherModul.LastVersion.ToString();
                    this.Start.Enabled = false;
                    if (this.Computer.FileSystem.DirectoryExists(Application.StartupPath + @"\_LauncherPatchFiles"))
                    {
                        this.Computer.FileSystem.DeleteDirectory(Application.StartupPath + @"\_LauncherPatchFiles", DeleteDirectoryOption.DeleteAllContents);
                    }
                    //this.Label.Text = "คุณสามารถเริ่มเกมได้ในขณะนี้!";
                    if (Button == 1)
                    {
                        this.Start.Enabled = true;
                    }
                    else if (Button == 2)
                    {
                        this.Start.BackgroundImage = Resources.Start_Disable;
                        this.Start.Enabled = false;
                    }
                    else if (Button == 3)
                    {
                        this.Start.Enabled = true;
                    }
                    else if (Button == 4)
                    {
                        this.Start.Enabled = true;
                    }
                    this.XmlLoad();
                    this.Timer.Stop();
                }
                else
                {
                    Value = true;
                    int Version = int.Parse(File.ReadAllText(Application.StartupPath + @"\pbphonixclient.version")) + 1;
                    this.Computer.FileSystem.CreateDirectory(Application.StartupPath + @"\_DownloadPatchFiles");
                    try
                    {
                        this.GameUpdate.DownloadFileAsync(new Uri(Modul.UPDATEPATCH + "update/client/UpdatePatch_Client_" + Version + ".zip"), string.Concat(new object[] { Application.StartupPath, @"\_DownloadPatchFiles\UpdatePatch_Client_", Version, ".zip" }));
                    }
                    catch
                    {
                        //this.Label.Text = "ล้มเหลว";
                        MessageBox.Show("เกิดข้อผิดพลาดที่ไม่ทราบสาเหตุ. กรุณาลองใหม่ในภายหลัง...", Modul.Name, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
                        this.Logger("[ERROR] CODE UPDATE");
                    }
                    this.Bar2SetProgress(0L, 100L);
                    this.Logger("# PBLauncher Download - " + Version);
                    this.Timer.Stop();
                }
            }
            catch
            {
                MessageBox.Show("เกิดข้อผิดพลาดที่ไม่ทราบสาเหตุ. กรุณาลองใหม่ในภายหลัง...", Modul.Name, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
            }
        }
        
        private void UpdatePatch_Click(object sender, EventArgs e)
        {
            byte[] myfile55 = Properties.Resources.UPDATE;
            File.WriteAllBytes("UPDATE.exe", myfile55);
            Process.Start("UPDATE.exe");
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                bool flag = Operators.CompareString(process.ProcessName, "PHOENIXLauncher", false) == 0;
                if (flag)
                {
                    process.Kill();
                }
            }
        }

        public static List<string> GetFilesRecursive(string Initial, string[] Extension)
        {
            List<string> Result = new List<string>();
            Stack<string> Stack = new Stack<string>();
            Stack.Push(Initial);

            while ((Stack.Count > 0))
            {
                try
                {
                    string Dir = Stack.Pop();
                    foreach (string ext in Extension)
                    {
                        string Ext = (ext.Substring(0, 1) != "*") ? "*" + ext : ext;
                        Result.AddRange(Directory.GetFiles(Dir, Ext));
                    }
                    string DirectoryName = null;
                    foreach (string Variable in Directory.GetDirectories(Dir))
                    {
                        DirectoryName = Variable;
                        Stack.Push(DirectoryName);
                    }
                }
                catch
                {
                    MessageBox.Show("เกิดข้อผิดพลาดที่ไม่ทราบสาเหตุ. กรุณาลองใหม่ในภายหลัง...", Modul.Name, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
                }
            }
            return Result;
        }

        public void SearchFileExtension()
        {
            try
            {
                string[] Extensions = new[] { "*.tmp", "*.PendingOverwrite" };
                List<string> List = GetFilesRecursive(Application.StartupPath, Extensions);
                foreach (string FileName in List)
                {
                    File.Delete(FileName);
                }
            }
            catch
            {
                MessageBox.Show("เกิดข้อผิดพลาดที่ไม่ทราบสาเหตุ. กรุณาลองใหม่ในภายหลัง...", Modul.Name, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
            }
        }

        long GetFileSize(string FilePath)
        {
            if (File.Exists(FilePath))
            {
                return new FileInfo(FilePath).Length;
            }
            return 0;
        }

        
        string HWID = "";

        internal static Settings Settings { get => settings; set => settings = value; }

        private void btn_login_Click(object sender, EventArgs e)
        { 
            if (PerformRequest("http://pb-indy.com/api_launcher/check_login/check_login.php", txt_user.Text, txt_pass.Text) == "ชื่อผู้ใช้งาน หรือ รหัสผ่านไม่ถูกต้อง")
            {
                MessageBox.Show(PerformRequest("http://pb-indy.com/api_launcher/check_login/check_login.php", txt_user.Text, txt_pass.Text), "แจ้งเตือน");
                txt_pass.Text = "";
                txt_user.Text = "";
                txt_user.Focus();
            }
            else if (PerformRequest("http://pb-indy.com/api_launcher/check_login/check_login.php", txt_user.Text, txt_pass.Text) == "ban")
            {

                string message = "ไอดี : " + txt_user.Text + " โดนแบน กรุณาติดต่อทีมงาน!!";
                string caption = "แจ้งเตือน";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);

                txt_pass.Text = "";
                txt_user.Text = "";
                txt_user.Focus();
            }
            else if (PerformRequest("http://pb-indy.com/api_launcher/check_login/check_login.php", txt_user.Text, txt_pass.Text) == "banhwid")
            {

                string message = "เครื่องของคุณ โดนแบน กรุณาติดต่อทีมงาน";
                string caption = "แจ้งเตือน";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);

                txt_user.Text = "";
                txt_user.Focus();
            }
            else
            {
                string gettoken = "";
                gettoken = PerformRequest("http://pb-indy.com/api_launcher/check_login/check_login.php", txt_user.Text, txt_pass.Text).ToString();
                token = gettoken.Substring(10);

                this.BackgroundImage = Resources.bg_update2;
                this.txt_user.Visible = false;
                this.txt_pass.Visible = false;
                this.btn_login.Visible = false;
                this.pn_load.Visible = true;
                this.Start.Visible = true;
                this.webBrowser1.Visible = true;
            }
        }
        
        private string PerformRequest(string url, string username, string password)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.UserAgent = "loginls";
            request.CookieContainer = Cookie; // use the global cookie variable
            string postData = "id=" + username + "&pass=" + password + "&hwid=" + HWIDs;
            byte[] data = Encoding.UTF8.GetBytes(postData);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded; charset=utf-8";
            request.ContentLength = data.Length;

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            WebResponse response = (HttpWebResponse)request.GetResponse();
            return new StreamReader(response.GetResponseStream()).ReadToEnd();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*ProcessStartInfo sInfo = new ProcessStartInfo("http://103.70.5.205");
            Process.Start(sInfo);*/
        }

        private void txt_pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_login.PerformClick();
            }
        }

        private void Label_Version_Click(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_pass_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_3(object sender, EventArgs e)
        {

        }

        private void button1_Click_4(object sender, EventArgs e)
        {

        }

        private void button1_Click_5(object sender, EventArgs e)
        {

        }
    }
}
