using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlOfPracticalClasses
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>

        //public static MainForm mainForm = new MainForm("15");

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FormEnter());//TOODO
            Application.Run(new MainForm("1"));//TOODO
            //Application.Run(new FormAddGroup());//TOODO
            //Application.Run(new FormAddSubject());//TOODO
            //Application.Run(new FormDelGroup());//TOODO
            //Application.Run(new FormDelSubject());//TOODO
            //Application.Run(new FormAddChat());//TOODO
        }

        public static void Exit()
        {
            Process.GetCurrentProcess().Kill();
        }
    }
}
