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
    public partial class foglalas : Form
    {
        int elsoO = 0, masodO = 0;
        List<int> foglaltak = new List<int>();
        Database db = new Database();
        int jarat;
        public foglalas(string jarat, string tipus)
        {
            this.jarat = db.getJaratId(jarat, tipus);
            InitializeComponent();
            List<int> foglalt = db.getFoglaltak(this.jarat);
            foreach(int hely in foglalt)
            {
                CheckBox ch = (CheckBox)this.Controls.Find("checkBox"+hely.ToString(), true)[0];
                ch.BackColor = Color.Red;
                ch.Enabled = false;
            }
        }
        public void CheckBox_CheckedChanged_FirstClass(object sender, EventArgs e)
        {
            CheckBox ch = (CheckBox)sender;
            if (ch.Checked)
            {
                elsoO++;
                ch.BackColor = Color.Gold;
                foglaltak.Add(Int32.Parse(ch.Name.Substring(8)));
            }
            else
            {
                elsoO--;
                ch.BackColor = Color.LawnGreen;
                foglaltak.Remove(Int32.Parse(ch.Name.Substring(8)));
            }
            elsoLabel.Text = elsoO.ToString();
        }
        public void CheckBox_CheckedChange_SecondClass(object sender , EventArgs e) 
        {
            CheckBox ch = (CheckBox)sender;
            if (ch.Checked)
            {
                masodO++;
                ch.BackColor = Color.Gold;
                foglaltak.Add(Int32.Parse(ch.Name.Substring(8)));
            }
            else
            {
                masodO--;
                ch.BackColor = Color.LawnGreen;
                foglaltak.Remove(Int32.Parse(ch.Name.Substring(8)));
            }
            masodLabel.Text = masodO.ToString();
        }

        private void vasarlasBtn_Click(object sender, EventArgs e)
        {
            if(foglaltak.Count > 0) 
            {
                if(nevInput.Text != "")
                {
                    db.vasarlas(jarat, foglaltak, nevInput.Text);
                    Close();
                }
                else
                {
                    string msg = "Nincs megadva név", title = "Hiba";
                    MessageBox.Show(msg, title);
                }
            }
            else
            {
                string msg = "Nincs kiválasztva ülés", title = "Hiba";
                MessageBox.Show(msg, title);
            }
        }

        private void visszaBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
