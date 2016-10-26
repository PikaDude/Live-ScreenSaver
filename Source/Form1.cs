using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MjpegProcessor;
using System.Runtime.ExceptionServices;
using System.IO;

namespace Drawn_Screensaver
{
    public partial class Form1 : Form
    {
        public bool IsPreviewMode;
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
            this.Bounds = Bounds;
            stream.Width = Convert.ToInt32(Convert.ToDouble(Bounds.Width) * 1.5);
            stream.Height = Convert.ToInt32(Convert.ToDouble(Bounds.Height) * 1.5);
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            stream.SizeMode = PictureBoxSizeMode.StretchImage;
            NowShowing.SetBounds(NowShowing.Bounds.X, stream.Bounds.Height - 39, stream.Bounds.Width, NowShowing.Bounds.Height);
            Cursor.Hide();
            Display();
        }

        public void Display()
        {
            _mjpeg = new MjpegDecoder();
            string[] streams = { "http://195.235.198.107:3344/axis-cgi/mjpg/video.cgi", "http://217.126.89.102:8020/axis-cgi/mjpg/video.cgi", "http://88.53.197.250/axis-cgi/mjpg/video.cgi", "http://webcam.st-malo.com/axis-cgi/mjpg/video.cgi", "http://195.235.198.107:3346/axis-cgi/mjpg/video.cgi", "http://iris.not.iac.es/axis-cgi/mjpg/video.cgi", "http://cascam.ou.edu/axis-cgi/mjpg/video.cgi", "http://83.61.22.4:8080/axis-cgi/mjpg/video.cgi", "http://217.197.157.7:7070/axis-cgi/mjpg/video.cgi", "http://85.46.64.147/axis-cgi/mjpg/video.cgi", "http://camera1.mairie-brest.fr/mjpg/video.mjpg", "http://82.188.208.242/cgi-bin/mjpg/video.cgi", "http://82.89.169.171/axis-cgi/mjpg/video.cgi", "http://67.141.206.85/axis-cgi/jpg/image.cgi", "http://webcams.hotelcozumel.com.mx:6012/axis-cgi/mjpg/video.cgi", "http://webcams.hotelcozumel.com.mx:6001/axis-cgi/mjpg/video.cgi", "http://webcams.hotelcozumel.com.mx:6003/axis-cgi/mjpg/video.cgi", "http://200.36.58.250/axis-cgi/jpg/image.cgi", "http://royalcam.lazo.ca/cgi-bin/mjpeg", "http://123.243.126.155:8088/snapshot.cgi" };
            string[] locs = { "Cuenca Spain", "Marina in Spain", "Cathedral Italy", "St. Malo France", "Cuenca Spain", "Observatory in Spain", "University of Oklahoma", "Playa de Maspalomas", "Czech Republic", "Venice", "La place de la liberte", "Monteveglio Bologna", "Sorrento Italy", "USA", "Hotel Cozumel Beach Camera", "Hotel Cozumel Lobby Camera", "Hotel Cozumel Pool Camera", "Palladium Resort - Beach Camera", "Unknown", "Hampton Beach" };
            int random = new Random().Next(0, streams.Count());
            _mjpeg.ParseStream(new Uri(streams[random]));
            _mjpeg.FrameReady += mjpeg_FrameReady;
            NowShowing.Text = "Current Location: " + locs[random];
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
            stream.Image = e.Bitmap;
        }
        #region User Input

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //** take this if statement out if your not doing a preview
            if (!IsPreviewMode && e.KeyCode != Keys.Space) //disable exit functions for preview
            {
                Application.Exit();
            }
            if (e.KeyCode == Keys.Space)
            {
                _mjpeg.StopStream();
                Display();
            }
        }

        private void Form1_Click(object sender, MouseEventArgs e)
        {
            //** take this if statement out if your not doing a preview
            if (!IsPreviewMode) //disable exit functions for preview
            {
                Application.Exit();
            }
        }

        //start off OriginalLoction with an X and Y of int.MaxValue, because
        //it is impossible for the cursor to be at that position. That way, we
        //know if this variable has been set yet.
        Point OriginalLocation = new Point(int.MaxValue, int.MaxValue);

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //** take this if statement out if your not doing a preview
            if (!IsPreviewMode) //disable exit functions for preview
            {
                //see if originallocation has been set
                if (OriginalLocation.X == int.MaxValue &
                    OriginalLocation.Y == int.MaxValue)
                {
                    OriginalLocation = e.Location;
                }
                //see if the mouse has moved more than 20 pixels 
                //in any direction. If it has, close the application.
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