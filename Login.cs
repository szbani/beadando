using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beadando
{
    public partial class Login : Form
    {
        string username;
        string pass;
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            username = username_input.Text;
            pass = password_input.Text;
            if (Program.db.Login(username, pass))
            {   
                this.Hide();
                Main main = new Main(username);
                main.ShowDialog();
                if (Program.exit) Close();
                else this.Show();
            }
            else error.Show();
        }
    }
}
