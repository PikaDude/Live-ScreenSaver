using System;
using System.Windows.Forms;

namespace Drawn_Screensaver
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                if (args[0].ToLower().Trim().Substring(0, 2) == "/s") //show
                {
                    //show screensaver
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    ShowScreenSaver();
                    Application.Run();
                }
                else if (args[0].ToLower().Trim().Substring(0, 2) == "/p") //preview
                {
                    //preview screensaver
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1(new IntPtr(long.Parse(args[1]))));
                }
                else if (args[0].ToLower().Trim().Substring(0, 2) == "/c") //configure
                {
                    //configure screensaver
                    MessageBox.Show("This screensaver has no options that you can set at the current point of time.",
                        "Drawn Screensaver",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    //i'll get to this later
                }
            }
            else
            {
                //no arguments were passed but im just gonna show the screensaver anyway
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                ShowScreenSaver();
                Application.Run();
            }
        }

        static void ShowScreenSaver()
        {
            foreach (Screen screen in Screen.AllScreens)
            {
                Form1 screensaver = new Form1(screen.Bounds);
                screensaver.Show();
            }
        }
    }
}
