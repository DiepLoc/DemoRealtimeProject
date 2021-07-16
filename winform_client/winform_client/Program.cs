using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform_client
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            UseEnvironment();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static void UseEnvironment()
        {
            Environment.SetEnvironmentVariable("hub-url", @"https://localhost:44318/api/hubs/");
            Environment.SetEnvironmentVariable("api-url", @"https://localhost:44318/api/");
        }
    }
}
