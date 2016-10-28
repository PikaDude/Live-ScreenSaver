using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MjpegProcessor;
using System.IO;
using System.Xml.Linq;

namespace Drawn_Screensaver
{
    public partial class Form1 : Form
    {
        public DateTime update;
        public bool IsPreviewMode;
        public bool isPinging;
        public string good = "Good.png";
        public string medium = "Medium.png";
        public string bad = "Bad.png";
        public Image EEEMAGE;
        public int wewlad;
        string[] OLDSTREAMS = { "http://195.235.198.107:3344/axis-cgi/mjpg/video.cgi", "http://217.126.89.102:8020/axis-cgi/mjpg/video.cgi", "http://88.53.197.250/axis-cgi/mjpg/video.cgi", "http://webcam.st-malo.com/axis-cgi/mjpg/video.cgi", "http://195.235.198.107:3346/axis-cgi/mjpg/video.cgi", "http://iris.not.iac.es/axis-cgi/mjpg/video.cgi", "http://cascam.ou.edu/axis-cgi/mjpg/video.cgi", "http://83.61.22.4:8080/axis-cgi/mjpg/video.cgi", "http://217.197.157.7:7070/axis-cgi/mjpg/video.cgi", "http://85.46.64.147/axis-cgi/mjpg/video.cgi", "http://camera1.mairie-brest.fr/mjpg/video.mjpg", "http://82.188.208.242/cgi-bin/mjpg/video.cgi", "http://82.89.169.171/axis-cgi/mjpg/video.cgi", "http://67.141.206.85/axis-cgi/jpg/image.cgi", "http://webcams.hotelcozumel.com.mx:6012/axis-cgi/mjpg/video.cgi", "http://webcams.hotelcozumel.com.mx:6001/axis-cgi/mjpg/video.cgi", "http://webcams.hotelcozumel.com.mx:6003/axis-cgi/mjpg/video.cgi", "http://200.36.58.250/axis-cgi/jpg/image.cgi", "http://royalcam.lazo.ca/cgi-bin/mjpeg", "http://123.243.126.155:8088/snapshot.cgi", "http://96.10.1.168/mjpg/1/video.mjpg", "http://110.22.193.84:81/videostream.cgi?loginuse=admin&loginpas=", "http://184.7.223.151/mjpg/video.mjpg", "http://128.210.133.202/mjpg/video.mjpg", "http://118.69.187.169:82/nphMotionJpeg?Quality=Standard", "http://91.201.117.136/mjpg/video.mjpg", "http://74.76.247.25:1024/img/video.mjpeg" };
        string[] OLDLOCS = { "Cuenca, Spain", "Marina in Spain", "Cathedral, Italy", "St. Malo France", "Cuenca, Spain", "Observatory in Spain", "University of Oklahoma", "Playa de Maspalomas", "Czech Republic", "Venice", "La place de la liberte", "Monteveglio Bologna", "Sorrento, Italy", "USA", "Hotel Cozumel Beach Camera", "Hotel Cozumel Lobby Camera", "Hotel Cozumel Pool Camera", "Palladium Resort - Beach Camera", "Unknown", "Hampton Beach", "Unknown", "Melbourne, Victoria", "Louisiana, Monroe, USA", "Indiana, West Lafayette, US", "Ho Chi Minh, Thanh Pho Ho Chi Min, Vietnam", "Pskov, Russian Federation", "Albany, New York, US" };
        MjpegDecoder _mjpeg;
        #region Preview API's

        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern bool GetClientRect(IntPtr hWnd, out Rectangle lpRect);

        #endregion
        public Form1(Rectangle Bounds)
        {
            InitializeComponent();
            ping.ImageLocation = @"C:\Users\" + Environment.UserName + @"\AppData\Local\LiveScreenSaver\Pinging.gif";
            ping.BackColor = Color.Transparent;
            this.Bounds = Bounds;
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            stream.SizeMode = PictureBoxSizeMode.StretchImage;
            stream.SetBounds(Convert.ToInt32(Convert.ToDouble(Bounds.Width) - Convert.ToDouble(Bounds.Width) * 0.9) / 2, 0, Convert.ToInt32(Convert.ToDouble(Bounds.Width) * 1.4), Convert.ToInt32(Convert.ToDouble(Bounds.Height) * 1.4));
            NowShowing.SetBounds(Convert.ToInt32(Convert.ToDouble(Bounds.Width) - Convert.ToDouble(Bounds.Width) * 0.9) / 2, Bounds.Height * 2 - 433, stream.Width - 100, NowShowing.Height);
            ping.SetBounds(Bounds.Width - Convert.ToInt32(Convert.ToDouble(Bounds.Width) - Convert.ToDouble(Bounds.Width) * 1.4), Bounds.Height * 2 - 430, ping.Width, ping.Height);
            Console.WriteLine(NowShowing.Location.Y);
            Cursor.Hide();
            isPinging = false;
            Display();
        }

        public void Display()
        {
            isPinging = true;
            good = "Pinging.gif";
            medium = "Pinging.gif";
            bad = "Pinging.gif";
            ping.ImageLocation = @"C:\Users\" + Environment.UserName + @"\AppData\Local\LiveScreenSaver\Pinging.gif";
            _mjpeg = new MjpegDecoder();
            ping.ImageLocation = @"C:\Users\" + Environment.UserName + @"\AppData\Local\LiveScreenSaver\Pinging.gif";
            string countRead = File.ReadAllText(@"C:\Users\" + Environment.UserName + @"\AppData\Local\LiveScreenSaver\list.xml");
            int count = countRead.Replace("<url>", "|").Count(f => f == '|');
            int random = new Random().Next(0, count);
            XDocument xml = XDocument.Load(@"C:\Users\" + Environment.UserName + @"\AppData\Local\LiveScreenSaver\list.xml");
            var url = xml.Descendants("url").ToArray()[random].Value;
            var location = xml.Descendants("location").ToArray()[random].Value;
            _mjpeg.ParseStream(new Uri(url));
            ping.ImageLocation = @"C:\Users\" + Environment.UserName + @"\AppData\Local\LiveScreenSaver\Pinging.gif";
            _mjpeg.FrameReady += mjpeg_FrameReady;
            ping.ImageLocation = @"C:\Users\" + Environment.UserName + @"\AppData\Local\LiveScreenSaver\Pinging.gif";
            isPinging = false;
            good = "Good.png";
            medium = "Medium.png";
            bad = "Bad.png";
            NowShowing.Text = location;
            update = DateTime.Now;
            EEEMAGE = stream.Image;
        }
        public Form1(IntPtr PreviewHandle)
        {
            InitializeComponent();
            SetParent(Handle, PreviewHandle);
            SetWindowLong(Handle, -16,
                  new IntPtr(GetWindowLong(Handle, -16) | 0x40000000));
            Rectangle ParentRect;
            GetClientRect(PreviewHandle, out ParentRect);
            Size = ParentRect.Size;
            Location = new Point(0, 0);
            IsPreviewMode = true;
        }

        public void mjpeg_FrameReady(object sender, FrameReadyEventArgs e)
        {
            if (isPinging == true) return;
            stream.Image = e.Bitmap;
            if (DateTime.Now.Subtract(update).TotalMilliseconds < 500) ping.ImageLocation = @"C:\Users\SKon7\AppData\Local\LiveScreenSaver\" + good;
            if (DateTime.Now.Subtract(update).TotalMilliseconds > 500 && DateTime.Now.Subtract(update).TotalMilliseconds < 1000) ping.ImageLocation = @"C:\Users\SKon7\AppData\Local\LiveScreenSaver\" + medium;
            if (DateTime.Now.Subtract(update).TotalMilliseconds > 1000) ping.ImageLocation = @"C:\Users\SKon7\AppData\Local\LiveScreenSaver\" + bad;
            update = DateTime.Now;
        }
        #region User Input

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!IsPreviewMode && e.KeyCode != Keys.Space && e.KeyCode != Keys.Enter)
            {
                Application.Exit();
            }
            if (e.KeyCode == Keys.Space)
            {
                if (isPinging == true) return;
                isPinging = true;
                _mjpeg.StopStream();
                _mjpeg = null;
                Display();
            }
            if (e.KeyCode == Keys.Return)
            {
                if (isPinging == true) return;
                isPinging = true;
                _mjpeg.StopStream();
                _mjpeg = null;
                _mjpeg = new MjpegDecoder();
                _mjpeg.ParseStream(new Uri("http://74.76.247.25:1024/img/video.mjpeg"));
                _mjpeg.FrameReady += mjpeg_FrameReady;
                isPinging = false;
                NowShowing.Text = "DOGS";
                update = DateTime.Now;
                EEEMAGE = stream.Image;
            }
        }

        private void Form1_Click(object sender, MouseEventArgs e)
        {
            if (!IsPreviewMode)
            {
                Application.Exit();
            }
        }
        Point OriginalLocation = new Point(int.MaxValue, int.MaxValue);

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!IsPreviewMode)
            {
                if (OriginalLocation.X == int.MaxValue &
                    OriginalLocation.Y == int.MaxValue)
                {
                    OriginalLocation = e.Location;
                }
                if (Math.Abs(e.X - OriginalLocation.X) > 20 |
                    Math.Abs(e.Y - OriginalLocation.Y) > 20)
                {
                    Application.Exit();
                }
            }
        }
        #endregion
    }
}