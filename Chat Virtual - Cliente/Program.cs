using System;
using System.Windows.Forms;
using Chat_Virtual___Cliente.Backend;

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
            LoginWindow login = new LoginWindow();
            login.Show();
            Application.Run();
        }
    }
}
