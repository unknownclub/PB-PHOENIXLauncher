using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.Devices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using PointBlank.Launcher.Properties;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Reflection;

namespace PointBlank.Launcher
{
    [Obfuscation(Feature = "virtualization", Exclude = false)]
    public partial class Connection : Form
    {
        private bool Flag = true;
        public WebClient Web = new WebClient();

        public Connection()
        {
            InitializeComponent();
            try
            {
                this.Web.DownloadFileCompleted += new AsyncCompletedEventHandler(this.Web_DownloadCompleted);
                this.Label.Text = "กำลังเปิดโปรแกรม...";
            }
            catch
            {
                this.Label.Text = "การเชื่อมต่อล้มเหลว...";
                if (MessageBox.Show("การเชื่อมต่อกับเซิร์ฟเวอร์ล้มเหลว.", Modul.Name, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    base.Close();
                    base.Dispose();
                }
                this.Logger("# PBLauncher Status - " + "การเชื่อมต่อกับเซิร์ฟเวอร์ล้มเหลว.");
                this.Logger("PBLauncher End - " + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss"));
            }
        }

        internal static Settings Settings { get => settings; set => settings = value; }
        private static Properties.Settings settings = Properties.Settings.Default;

        [Obfuscation(Feature = "virtualization", Exclude = false)]
        private void Connection_Load(object sender, EventArgs e)
        {
            string path = "Phoenix_Client.xml";
            string clientTxt = File.ReadAllText(path);

            Processos = Process.GetProcessesByName("PHOENIXLauncher");
            Process[] processes = Process.GetProcesses();
            Computer computer = new Computer();
            if (!computer.FileSystem.FileExists(Application.StartupPath + "\\" + Modul.Name + ".log"))
            {
                new StreamWriter(Application.StartupPath + "\\" + Modul.Name + ".log").Close();
            }
            Logger("");
            Logger("");
            Logger("");
            Logger(Modul.Name + " Start - " + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss"));
            Logger("## " + Modul.Name + " Ver " + Version.getVersion().ToString());
            if (Processos.Length > 1)
            {
                if (MessageBox.Show("ไม่สามารถเปิด " + Modul.Name + " ได้สองโปรแกรม!", Modul.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    base.Close();
                    base.Dispose();
                }
                Flag = false;
            }
            else
            {
                foreach (Process process in processes)
                {

                    bool flag55 = Operators.CompareString(process.ProcessName, "PHOENIX-PBS", false) == 0;
                    if (flag55)
                    {
                        process.Kill();
                        MessageBox.Show("ปิดเกมก่อนเปิดตัวเข้าเกมส์!", Modul.Name, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                    }

                    bool killClient = Operators.CompareString(process.ProcessName, clientTxt, false) == 0;
                    if (killClient)
                    {

                        process.Kill();
                        //MessageBox.Show("ปิดเกมก่อนเปิดตัวเข้าเกมส์!", Modul.Name, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                    }

                    bool killMiniGuard = Operators.CompareString(process.ProcessName, "MiniGuard", false) == 0;
                    if (killMiniGuard)
                    {

                        process.Kill();
                        //MessageBox.Show("ปิดเกมก่อนเปิดตัวเข้าเกมส์!", Modul.Name, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                    }
                }
            }
            Check();
        }

        [Obfuscation(Feature = "virtualization", Exclude = false)]
        public static string rantitle()
        {
            string textx = "ฟห你好ฟหกาこんにちはปผื543မြန်မာ565หกาaskjasd#$@@#hrwks"; //ข้อความที่จะให้สุ่ม
            Random ran = new Random();
            StringBuilder str = new StringBuilder();
            for (int i = 1; i <= 45; i++) //แสดงที่ title 20 ตัวอักษร
            {
                int od = ran.Next(0, 45); //สุ่ม 35 ตัวอักษร
                str.Append(textx.Substring(od, 1));
            }
            return str.ToString();
        }

        [Obfuscation(Feature = "virtualization", Exclude = false)]
        private void Web_DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                base.ShowInTaskbar = false;
                base.Visible = false;
                MessageBox.Show("เกิดข้อผิดพลาดในการอ่านข้อมูล", Modul.Name, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        [Obfuscation(Feature = "virtualization", Exclude = false)]
        private void Logger(string Text)
        {
            string Path = Application.StartupPath + "\\PBLauncher.log";
            DateTime Now = DateTime.Now;
            StreamWriter Writer = new StreamWriter(Path, true);
            Writer.WriteLine(Text);
            Writer.Flush();
            Writer.Close();
        }

        [Obfuscation(Feature = "virtualization", Exclude = false)]
        private void Check()
        {
            if (Flag)
            {
                try
                {
                    int num = int.Parse(this.Web.DownloadString(Modul.WEB + "launcher/status/status.txt"));
                    string text = this.Web.DownloadString(Modul.WEB + "launcher/status/text.txt");

                    if (num == 1)
                    {
                        this.Start.RunWorkerAsync();
                    }
                    else
                    {
                        switch (num)
                        {
                            case 0:
                                this.Label.Text = "ไม่สามารถเข้าเกมได้ในขณะนี้...";
                                if (MessageBox.Show("ไม่สามารถเข้าเกมได้ในขณะนี้.", Modul.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                                {
                                    base.Close();
                                    base.Dispose();
                                }
                                this.Logger("# PBLauncher Status - " + "ไม่สามารถเข้าเกมได้ในขณะนี้.");
                                this.Logger("PBLauncher End - " + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss"));
                                return;
                            case 2:
                                this.Label.Text = "เซิร์ฟเวอร์ปิดปรับปรุง...";
                                if (MessageBox.Show(text.ToString(), Modul.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                                {
                                    base.Close();
                                    base.Dispose();
                                }
                                this.Logger("# PBLauncher Status - " + text.ToString());
                                this.Logger("PBLauncher End - " + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss"));
                                return;
                        }
                    }
                }
                catch
                {
                    this.Label.Text = "ไม่สามารถเชื่อมต่อกับเซิร์ฟเวอร์ได้...";
                    if (MessageBox.Show("ไม่สามารถเชื่อมต่อกับเซิร์ฟเวอร์ได้.", Modul.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                    {
                        base.Close();
                        base.Dispose();
                    }
                    this.Logger("# PBLauncher Status - " + "ไม่สามารถเชื่อมต่อกับเซิร์ฟเวอร์ได้.");
                    this.Logger("PBLauncher End - " + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss"));
                }
            }
        }

        [Obfuscation(Feature = "virtualization", Exclude = false)]
        public void Start_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Label.Text = "กรุณารอซักครู่...";
            Thread.Sleep(900);
        }
        [Obfuscation(Feature = "virtualization", Exclude = false)]
        public void Start_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            base.DialogResult = DialogResult.OK;
            base.Close();
        }

        public Process[] Processos;
    }
}
