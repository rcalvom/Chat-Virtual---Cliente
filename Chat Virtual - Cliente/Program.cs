using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chat_Virtual___Cliente.Frontend;

namespace Chat_Virtual___Cliente {
    static class Program {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            HomeView h = new HomeView();
            h.Show();
            /*LoginWindow login = new LoginWindow();
            login.Show();*/
            Application.Run();
        }
    }
}
