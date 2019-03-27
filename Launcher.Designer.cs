using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PointBlank.Launcher
{
    partial class Launcher
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Launcher));
            this.Label = new System.Windows.Forms.Label();
            this.Label_File = new System.Windows.Forms.Label();
            this.Label_Total = new System.Windows.Forms.Label();
            this.Label_Version = new System.Windows.Forms.Label();
            this.Exit = new System.Windows.Forms.PictureBox();
            this.TotalBar = new System.Windows.Forms.PictureBox();
            this.ArchiveBar = new System.Windows.Forms.PictureBox();
            this.FileName = new System.Windows.Forms.Label();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.Minimize = new System.Windows.Forms.PictureBox();
            this.BackGroundWorker = new System.ComponentModel.BackgroundWorker();
            this.Start = new System.Windows.Forms.Button();
            this.UpdatePatch = new System.Windows.Forms.Button();
            this.txt_pass = new System.Windows.Forms.TextBox();
            this.txt_user = new System.Windows.Forms.TextBox();
            this.btn_login = new System.Windows.Forms.Button();
            this.pn_load = new System.Windows.Forms.Panel();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.Exit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArchiveBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minimize)).BeginInit();
            this.pn_load.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label
            // 
            this.Label.BackColor = System.Drawing.Color.Transparent;
            this.Label.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Label.ForeColor = System.Drawing.Color.Transparent;
            this.Label.Location = new System.Drawing.Point(16, 526);
            this.Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(465, 16);
            this.Label.TabIndex = 0;
            this.Label.Text = " ";
            this.Label.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Launcher_MouseDown);
            this.Label.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Launcher_MouseMove);
            // 
            // Label_File
            // 
            this.Label_File.BackColor = System.Drawing.Color.Transparent;
            this.Label_File.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label_File.ForeColor = System.Drawing.Color.Transparent;
            this.Label_File.Location = new System.Drawing.Point(8, 1);
            this.Label_File.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_File.Name = "Label_File";
            this.Label_File.Size = new System.Drawing.Size(38, 16);
            this.Label_File.TabIndex = 1;
            this.Label_File.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Launcher_MouseDown);
            this.Label_File.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Launcher_MouseMove);
            // 
            // Label_Total
            // 
            this.Label_Total.BackColor = System.Drawing.Color.Transparent;
            this.Label_Total.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label_Total.ForeColor = System.Drawing.Color.Transparent;
            this.Label_Total.Location = new System.Drawing.Point(8, 33);
            this.Label_Total.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_Total.Name = "Label_Total";
            this.Label_Total.Size = new System.Drawing.Size(465, 16);
            this.Label_Total.TabIndex = 2;
            this.Label_Total.Text = " ";
            this.Label_Total.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Launcher_MouseDown);
            this.Label_Total.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Launcher_MouseMove);
            // 
            // Label_Version
            // 
            this.Label_Version.BackColor = System.Drawing.Color.Transparent;
            this.Label_Version.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Label_Version.ForeColor = System.Drawing.Color.White;
            this.Label_Version.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label_Version.Location = new System.Drawing.Point(262, 7);
            this.Label_Version.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_Version.Name = "Label_Version";
            this.Label_Version.Size = new System.Drawing.Size(471, 13);
            this.Label_Version.TabIndex = 3;
            this.Label_Version.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.Label_Version.Visible = false;
            this.Label_Version.Click += new System.EventHandler(this.Label_Version_Click);
            this.Label_Version.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Launcher_MouseDown);
            this.Label_Version.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Launcher_MouseMove);
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.White;
            this.Exit.BackgroundImage = global::PointBlank.Launcher.Properties.Resources.Closed_Normal;
            this.Exit.Location = new System.Drawing.Point(754, 3);
            this.Exit.Margin = new System.Windows.Forms.Padding(2);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(23, 23);
            this.Exit.TabIndex = 4;
            this.Exit.TabStop = false;
            this.Exit.Click += new System.EventHandler(this.Closed_Click);
            this.Exit.MouseEnter += new System.EventHandler(this.Closed_MouseMove);
            this.Exit.MouseLeave += new System.EventHandler(this.Closed_MouseLeave);
            // 
            // TotalBar
            // 
            this.TotalBar.BackColor = System.Drawing.Color.Red;
            this.TotalBar.Location = new System.Drawing.Point(10, 50);
            this.TotalBar.Name = "TotalBar";
            this.TotalBar.Size = new System.Drawing.Size(540, 10);
            this.TotalBar.TabIndex = 10;
            this.TotalBar.TabStop = false;
            this.TotalBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Launcher_MouseDown);
            this.TotalBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Launcher_MouseMove);
            // 
            // ArchiveBar
            // 
            this.ArchiveBar.BackColor = System.Drawing.Color.Red;
            this.ArchiveBar.Location = new System.Drawing.Point(9, 18);
            this.ArchiveBar.Name = "ArchiveBar";
            this.ArchiveBar.Size = new System.Drawing.Size(541, 10);
            this.ArchiveBar.TabIndex = 11;
            this.ArchiveBar.TabStop = false;
            this.ArchiveBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Launcher_MouseDown);
            this.ArchiveBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Launcher_MouseMove);
            // 
            // FileName
            // 
            this.FileName.BackColor = System.Drawing.Color.Transparent;
            this.FileName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.FileName.ForeColor = System.Drawing.Color.Transparent;
            this.FileName.Location = new System.Drawing.Point(51, 1);
            this.FileName.Name = "FileName";
            this.FileName.Size = new System.Drawing.Size(422, 16);
            this.FileName.TabIndex = 100;
            this.FileName.Text = " ";
            this.FileName.Visible = false;
            this.FileName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Launcher_MouseDown);
            this.FileName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Launcher_MouseMove);
            // 
            // Timer
            // 
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // Minimize
            // 
            this.Minimize.BackColor = System.Drawing.Color.White;
            this.Minimize.BackgroundImage = global::PointBlank.Launcher.Properties.Resources.Hide_Normal;
            this.Minimize.Location = new System.Drawing.Point(726, 3);
            this.Minimize.Name = "Minimize";
            this.Minimize.Size = new System.Drawing.Size(23, 23);
            this.Minimize.TabIndex = 15;
            this.Minimize.TabStop = false;
            this.Minimize.Click += new System.EventHandler(this.Minimize_Click);
            this.Minimize.MouseLeave += new System.EventHandler(this.Minimize_MouseLeave);
            this.Minimize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Minimize_MouseMove);
            // 
            // Start
            // 
            this.Start.BackgroundImage = global::PointBlank.Launcher.Properties.Resources.btn_stl;
            this.Start.FlatAppearance.BorderSize = 0;
            this.Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Start.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.Start.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(32)))), ((int)(((byte)(45)))));
            this.Start.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Start.Location = new System.Drawing.Point(582, 533);
            this.Start.Margin = new System.Windows.Forms.Padding(0);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(179, 67);
            this.Start.TabIndex = 0;
            this.Start.TabStop = false;
            this.Start.Visible = false;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            this.Start.MouseLeave += new System.EventHandler(this.Start_MouseLeave);
            this.Start.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Start_MouseMove);
            // 
            // UpdatePatch
            // 
            this.UpdatePatch.BackColor = System.Drawing.Color.Transparent;
            this.UpdatePatch.BackgroundImage = global::PointBlank.Launcher.Properties.Resources.btn_ud6;
            this.UpdatePatch.Enabled = false;
            this.UpdatePatch.FlatAppearance.BorderSize = 0;
            this.UpdatePatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdatePatch.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.UpdatePatch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(32)))), ((int)(((byte)(45)))));
            this.UpdatePatch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UpdatePatch.Location = new System.Drawing.Point(307, 464);
            this.UpdatePatch.Margin = new System.Windows.Forms.Padding(0);
            this.UpdatePatch.Name = "UpdatePatch";
            this.UpdatePatch.Size = new System.Drawing.Size(174, 64);
            this.UpdatePatch.TabIndex = 1001;
            this.UpdatePatch.TabStop = false;
            this.UpdatePatch.UseVisualStyleBackColor = false;
            this.UpdatePatch.Visible = false;
            this.UpdatePatch.Click += new System.EventHandler(this.UpdatePatch_Click);
            this.UpdatePatch.MouseLeave += new System.EventHandler(this.UpdatePatch_MouseLeave);
            this.UpdatePatch.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UpdatePatch_MouseMove);
            // 
            // txt_pass
            // 
            this.txt_pass.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_pass.Location = new System.Drawing.Point(226, 413);
            this.txt_pass.Multiline = true;
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.PasswordChar = '*';
            this.txt_pass.Size = new System.Drawing.Size(333, 28);
            this.txt_pass.TabIndex = 1004;
            this.txt_pass.TextChanged += new System.EventHandler(this.txt_pass_TextChanged);
            this.txt_pass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_pass_KeyDown);
            // 
            // txt_user
            // 
            this.txt_user.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_user.Location = new System.Drawing.Point(226, 353);
            this.txt_user.Multiline = true;
            this.txt_user.Name = "txt_user";
            this.txt_user.Size = new System.Drawing.Size(333, 28);
            this.txt_user.TabIndex = 1003;
            // 
            // btn_login
            // 
            this.btn_login.BackColor = System.Drawing.Color.Transparent;
            this.btn_login.BackgroundImage = global::PointBlank.Launcher.Properties.Resources.btn_lg3;
            this.btn_login.FlatAppearance.BorderSize = 0;
            this.btn_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_login.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btn_login.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(32)))), ((int)(((byte)(45)))));
            this.btn_login.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_login.Location = new System.Drawing.Point(335, 462);
            this.btn_login.Margin = new System.Windows.Forms.Padding(0);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(110, 60);
            this.btn_login.TabIndex = 1003;
            this.btn_login.TabStop = false;
            this.btn_login.UseVisualStyleBackColor = false;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            this.btn_login.MouseLeave += new System.EventHandler(this.btn_login_MouseLeave);
            this.btn_login.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btn_login_MouseMove);
            // 
            // pn_load
            // 
            this.pn_load.BackColor = System.Drawing.Color.Transparent;
            this.pn_load.Controls.Add(this.FileName);
            this.pn_load.Controls.Add(this.Label_Total);
            this.pn_load.Controls.Add(this.Label_File);
            this.pn_load.Controls.Add(this.ArchiveBar);
            this.pn_load.Controls.Add(this.TotalBar);
            this.pn_load.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.pn_load.Location = new System.Drawing.Point(29, 531);
            this.pn_load.Name = "pn_load";
            this.pn_load.Size = new System.Drawing.Size(558, 67);
            this.pn_load.TabIndex = 1006;
            this.pn_load.Visible = false;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(38, 364);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.ScrollBarsEnabled = false;
            this.webBrowser1.Size = new System.Drawing.Size(711, 147);
            this.webBrowser1.TabIndex = 1007;
            this.webBrowser1.Url = new System.Uri("http://www.pb-phoenix.com/PhoenixLauncher/news.php", System.UriKind.Absolute);
            this.webBrowser1.Visible = false;
            // 
            // Launcher
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::PointBlank.Launcher.Properties.Resources.bg_update2;
            this.ClientSize = new System.Drawing.Size(783, 652);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.pn_load);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.txt_pass);
            this.Controls.Add(this.txt_user);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.Minimize);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Label_Version);
            this.Controls.Add(this.Label);
            this.Controls.Add(this.UpdatePatch);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Launcher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PBLauncher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.Load += new System.EventHandler(this.Launcher_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Launcher_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Launcher_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.Exit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArchiveBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minimize)).EndInit();
            this.pn_load.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox ArchiveBar;
        private Label FileName;
        private Label Label;
        private Label Label_File;
        private Label Label_Total;
        private Label Label_Version;
        private Point NewPoint;
        private PictureBox Exit;
        private PictureBox Minimize;
        private Timer Timer;
        private PictureBox TotalBar;
        private Button Start;
        private BackgroundWorker BackGroundWorker;
        private Button UpdatePatch;
        private Button btn_login;
        private TextBox txt_pass;
        private TextBox txt_user;
        private Panel pn_load;
        private WebBrowser webBrowser1;
    }
}