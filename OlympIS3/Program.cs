using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OlympIS3
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {   
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Autorization());
        }
    }

    class Data
    {
        private static string connection = "Data Source = DESKTOP-9KROQIJ;initial catalog = ElLibrary;integrated security = true;";

        public static string Connection { get { return connection; }}

        public static int UserType { get; set; }

        public static string User_Add { get; set; }
        public static string User_Delete { get; set; }
        public static string User_Edit { get; set; }
        public static string User_View { get; set; }
        public static string User_ViewExport { get; set; }
        public static string User_Export { get; set; }
    }
}
