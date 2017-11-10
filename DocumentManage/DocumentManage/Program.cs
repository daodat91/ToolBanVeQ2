using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DocumentManage
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormLogin formLogin = new FormLogin();
            DialogResult dialogResult = formLogin.ShowDialog();
            bool flag = dialogResult == DialogResult.OK;
            if (flag)
            {
                Application.Run(new FormMain());
            }
            string path = Application.StartupPath + "\\Temp";
            bool flag2 = Directory.Exists(path);
            if (flag2)
            {
                Directory.Delete(path, true);
            }
            Application.Exit();
            Environment.Exit(0);
        }
    }
}
