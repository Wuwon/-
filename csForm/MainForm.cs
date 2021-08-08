using CefSharp;
using CefSharp.WinForms;
using Cafe_Solution.Handlers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe_Solution.csForm
{
    public partial class MainForm : Form
    {
        static ChromiumWebBrowser chromeBrowser;
        private KeyboardHandler keyboardHandler;
        public static double Main_opacity;

        static string CitroOrder_URL = "https://naver.com/";
        public MainForm()
        {
            InitializeComponent();
            setChromium();
            InitHotkeys();
            adminview();
        }

        private void setChromium()
        {

            CefSettings cefSettings = new CefSettings();
            Cef.Initialize(cefSettings);
            CefSharpSettings.LegacyJavascriptBindingEnabled = true;
            
            chromeBrowser = new ChromiumWebBrowser(CitroOrder_URL);
            //chromeBrowser.Dock = DockStyle.Fill;  // Form창에 가득 채우기
            this.Controls.Add(chromeBrowser);
        }



        private void InitHotkeys()
        {
            
            keyboardHandler = new KeyboardHandler(this);
            KeyboardHandler.AddHotKey(this, adminview, Keys.F12, true, true);

            KeyboardHandler.AddHotKey(this, opacity_down, Keys.F1, false, false); // 불투명도 낮추기 
            KeyboardHandler.AddHotKey(this, opacity_up, Keys.F2, false, false); // 불투명도 높히기
            KeyboardHandler.AddHotKey(this, hide_title, Keys.F3, false, false); // 타이틀바 숨기기
            KeyboardHandler.AddHotKey(this, url_view, Keys.F4, false, false); // URL 검색
            KeyboardHandler.AddHotKey(this, control_opacity,Keys.Z,true, false); // 불투명도5,100으로 전환
            KeyboardHandler.AddHotKey(this, backs, Keys.B, true, false); //뒤로가기
            KeyboardHandler.AddHotKey(this, powerOff, Keys.W, true, false); // 종료
            chromeBrowser.KeyboardHandler = keyboardHandler;
            this.Controls.Add(chromeBrowser);
            //this.ClientSize = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);// 최대긴한데 내 모니터 해상도에 맞춰주질 않음
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; //위에 뭐냐 그 닫기 버튼이랑 타이틀 써져있는 바  그거 없애는거
            //this.WindowState = FormWindowState.Maximized; //창 최대화 

            chromeBrowser.Select();
            chromeBrowser.Focus();
        }
        private void opacity_up()
        {   
            this.Opacity += 0.05;
            if(this.Opacity >= 1)
            {
                this.Opacity = 1;
            }
        }
        private void opacity_down()
        {
            this.Opacity -= 0.05;
            if (this.Opacity <= 0.05)
            {
                this.Opacity = 0.05;
            }
        }

        private void adminview()
        {
            Point parentPoint = this.Location;
            AdminForm adminform = new AdminForm();
            //adminform.Location = new Point(parentPoint.X + 8, parentPoint.Y + 30);
            adminform.Location = new Point(parentPoint.X+50, parentPoint.Y+50);
            adminform.Show();
        }
        private void url_view()
        {
            Point parentPoint = this.Location;
            UrlForm urlForm = new UrlForm();
            urlForm.StartPosition = FormStartPosition.Manual;
            urlForm.Location = new Point(parentPoint.X + 8, parentPoint.Y + 30);
            urlForm.Show(this);
        }
        public static void loadUrl(String url)
        {
            chromeBrowser.Load(url);
        }

        private void hide_title()
        {
            if (!this.FormBorderStyle.Equals(System.Windows.Forms.FormBorderStyle.None))
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            }
            else
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            }
        }

        private void control_opacity()
        {
            if(this.Opacity == 1.0)
            {
                this.Opacity = 0.05;
            }
            else
            {
                this.Opacity = 1.0;
            }
            Main_opacity = this.Opacity;
        }
        private void backs()
        {
            if (chromeBrowser.CanGoBack)
            {
                chromeBrowser.Back();
            }
        }
        private void powerOff()
        {
            this.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }
        // --------JavaScript Method Call ---------------//


    }
}
