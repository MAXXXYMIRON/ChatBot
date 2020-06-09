using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chat;

namespace ChatBot
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

            Autorization AutorizationData = new Autorization();
            Application.Run(AutorizationData);
            if (Autorization.ChoosenBot == null) return;

            Application.Run(new WinChat());
        }
    }
}
