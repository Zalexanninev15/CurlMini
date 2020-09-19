using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace CurlMini
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"Software"))
            {
                reg.CreateSubKey("Zalexanninev15");
            }
            using (RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"Software\Zalexanninev15"))
            {
                reg.CreateSubKey("CurlMini");
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
