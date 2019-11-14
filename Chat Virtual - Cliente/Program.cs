using System;
using System.Windows.Forms;
using Chat_Virtual___Cliente.Backend;
using Chat_Virtual___Cliente.Frontend;

namespace Chat_Virtual___Cliente {
    static class Program {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main() {
            Singleton singleton = Singleton.GetSingleton();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            HomeView login = new HomeView();
            //Frontend.TreeView login = new Frontend.TreeView();
            //LoginWindow login = new LoginWindow();
            login.Show();
            Application.Run();
        }
    }
}
