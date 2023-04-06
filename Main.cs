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
    public partial class Main : Form
    {
        bool admin;
        string username;
        Database db;
        List<string> jaratokList;
        public Main(string username)
        {
            this.username = username;
            db = new Database();
            admin = db.isAdmin(username);
            InitializeComponent();
            jaratokList = db.getJaratok();
            usernameLabel.Text = username;
            foreach(string jarat in jaratokList)
            {
                jaratokSelect.Items.Add(jarat);
            }
            jaratokSelect.Text = jaratokList[0];
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Program.exit = true;
            Close();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msg = "Készítette:Szabó Dániel(DRMWMX)", title = "Info";
            MessageBox.Show(msg, title);
        }

        private void foglalasBtn_Click(object sender, EventArgs e)
        {
            foglalas fog = new foglalas(jaratokSelect.Text,tipusSelect.Text);
            fog.ShowDialog();
        }
    }
}
