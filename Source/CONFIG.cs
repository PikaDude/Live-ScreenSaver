using System;
using System.IO;
using System.Windows.Forms;

namespace Live_Screensaver
{
    public partial class CONFIG : Form
    {
        private string rootDir = @"C:\Users\" + Environment.UserName + @"\AppData\Local\LiveScreenSaver\";
        private bool isWaitingForKey = false;
        public CONFIG()
        {
            InitializeComponent();
        }

        private void CONFIG_Load(object sender, EventArgs e)
        {
            string key = File.ReadAllText(rootDir + "key.dat");
            Current.Text = "Current Keybind: " + key;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Current.Text = "Press a key... (ESC to disable feature)";
            isWaitingForKey = true;
        }

        private void keypress(object sender, KeyEventArgs e)
        {
            if (isWaitingForKey == true)
            {
            }
        }
    }
}
