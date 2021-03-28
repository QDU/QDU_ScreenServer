using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.KeyPreview = true;
            this.Location = new Point(0, 0);
            this.Size = new Size(
                   Screen.PrimaryScreen.Bounds.Width,
                   Screen.PrimaryScreen.Bounds.Height);
            webBrowser1.Location = this.Location;
            webBrowser1.Size = this.Size;
            webBrowser1.Url = new Uri("https://www.qdu.edu.cn");
        }



        private void webBrowser1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private WebBrowser webBrowser1;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser1.Location = new System.Drawing.Point(-2, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(284, 261);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.TabStop = false;
            this.webBrowser1.WebBrowserShortcutsEnabled = false;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.webBrowser1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load1);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.timer1.Tick += Timer1_Tick;

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (webBrowser1.Bounds.Contains(this.PointToClient(Cursor.Position)))
            {
                int n_x = webBrowser1.PointToClient(Cursor.Position).X;
                int n_y = webBrowser1.PointToClient(Cursor.Position).Y;
                
                dis = Math.Sqrt(Math.Abs(n_x - x) * Math.Abs(n_x - x) + Math.Abs(n_y - y) * Math.Abs(n_y - y));

                if (dis > 600)
                {
                    Close();
                }
                x = n_x;
                y = n_y;

            }
        }

        private void Form1_Load1(object sender, EventArgs e)
        {
            
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Close();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlDocument htmlDoc = webBrowser1.Document;
            htmlDoc.Click += new HtmlElementEventHandler(htmlDoc_Click);
            timer1.Start();
        }
        private void htmlDoc_Click(object sender, HtmlElementEventArgs e)
        {
            HtmlDocument doc = sender as HtmlDocument;
            HtmlElement ele = doc.GetElementFromPoint(e.ClientMousePosition);
            Close();
        }

        private Timer timer1;
        private IContainer components;
        private double x =0;
        double dis = 0;
        private double y =0;
                
    }
}