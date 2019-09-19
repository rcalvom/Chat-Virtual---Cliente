using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_Virtual___Cliente {

    public partial class LoginWindow : Form {
        public LoginWindow() {
            InitializeComponent();
        }

        private void SingIn_Click(object sender, EventArgs e)
        {
            username = user.Text;
            userPassword = password.Text;
            user.Clear();
            password.Clear();
        }

        private void SingUp_Click(object sender, EventArgs e)
        {

        }
    }
}
