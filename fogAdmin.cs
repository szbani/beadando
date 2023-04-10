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
    public partial class fogAdmin : Form
    {
        string tipus;
        int jarat;
        public fogAdmin(string jarat, string tipus)
        {
            this.jarat = Program.db.getJaratId(jarat, tipus);
            this.tipus = tipus;
            InitializeComponent();
            List<int> foglalt = Program.db.getFoglaltak(this.jarat);
            foreach (int hely in foglalt)
            {
                CheckBox ch = (CheckBox)this.Controls.Find("checkBox" + hely.ToString(), true)[0];
                ch.BackColor = Color.Red;
                ch.Enabled = false;
            }
            List<string> megallok = Program.db.getJaratMegallok(this.jarat);
            string vegallomas = megallok[megallok.Count-1];
            List<List<string>> helyadatok = Program.db.getAdminFoglaltak(this.jarat);
            int bevetel = 0;
            foreach (List<string> hely in helyadatok)
            {
                double k = 1;
                string kupon = "nincs";
                if (hely[3].Equals(0.8))
                {
                    kupon = "20%";
                    k = 0.8;
                }
                else if (hely[3].Equals(0.9))
                { 
                    kupon = "10%";
                    k = 0.9;
                }
                int penz = 0;
                if (Int32.Parse(hely[0]) <= 20)
                {
                    if (tipus.Equals("Gyors")) penz += 2000;
                    else penz += 1000;
                }
                else
                {
                    if (tipus.Equals("Gyors")) penz += 1500;
                    else penz += 750;
                }
                penz = Convert.ToInt32(penz * k);
                if (hely[2].Equals(vegallomas)) penz -= 500;
                string helyadat = hely[0] + "; " + hely[1] + "; " + hely[2] + "; " + kupon + "; " + penz.ToString() + ";";
                bevetel += penz;
                foglalasLista.Items.Add(helyadat);
            }
            teljesBevetel.Text = bevetel.ToString();
        }

        private void visszaBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
