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
        int elsoO = 0, masodO = 0, jarat;
        List<int> foglaltak = new List<int>();
        string tipus;
        double kupon = 1;
        bool vegallomas = true;
        List<string> megallok;
        public foglalas(string jarat, string tipus)
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
                //elso osztaly
                if (hely <= 10)
                {
                    if (hely > 2)
                    {
                        ch = (CheckBox)this.Controls.Find("checkBox" + (hely - 2).ToString(), true)[0];
                        ch.BackColor = Color.Red;
                        ch.Enabled = false;
                    }
                    if (hely % 2 == 0)
                    {
                        ch = (CheckBox)this.Controls.Find("checkBox" + (hely - 1).ToString(), true)[0];
                        ch.BackColor = Color.Red;
                        ch.Enabled = false;
                    }
                    if (hely % 2 == 1)
                    {
                        ch = (CheckBox)this.Controls.Find("checkBox" + (hely + 1).ToString(), true)[0];
                        ch.BackColor = Color.Red;
                        ch.Enabled = false;
                    }
                    if (hely < 9)
                    {
                        ch = (CheckBox)this.Controls.Find("checkBox" + (hely + 2).ToString(), true)[0];
                        ch.BackColor = Color.Red;
                        ch.Enabled = false;
                    }
                }
                else if (hely > 10 && hely < 21)
                {
                    if (hely < 19)
                    {
                        ch = (CheckBox)this.Controls.Find("checkBox" + (hely + 2).ToString(), true)[0];
                        ch.BackColor = Color.Red;
                        ch.Enabled = false;
                    }
                    if (hely % 2 == 0)
                    {
                        ch = (CheckBox)this.Controls.Find("checkBox" + (hely - 1).ToString(), true)[0];
                        ch.BackColor = Color.Red;
                        ch.Enabled = false;
                    }
                    if (hely % 2 == 1)
                    {
                        ch = (CheckBox)this.Controls.Find("checkBox" + (hely + 1).ToString(), true)[0];
                        ch.BackColor = Color.Red;
                        ch.Enabled = false;
                    }
                    if (hely > 12)
                    {
                        ch = (CheckBox)this.Controls.Find("checkBox" + (hely - 2).ToString(), true)[0];
                        ch.BackColor = Color.Red;
                        ch.Enabled = false;
                    }
                }
                //masod osztaly

                else if (hely >= 21 && hely <= 26)
                {
                    if ((hely - 3) >= 21)
                    {
                        ch = (CheckBox)this.Controls.Find("checkBox" + (hely - 3).ToString(), true)[0];
                        ch.BackColor = Color.Red;
                        ch.Enabled = false;
                    }
                    if ((hely + 3) <= 26)
                    {
                        ch = (CheckBox)this.Controls.Find("checkBox" + (hely + 3).ToString(), true)[0];
                        ch.BackColor = Color.Red;
                        ch.Enabled = false;
                    }
                    if ((hely + 1) <= 26 && hely != 23)
                    {
                        ch = (CheckBox)this.Controls.Find("checkBox" + (hely + 1).ToString(), true)[0];
                        ch.BackColor = Color.Red;
                        ch.Enabled = false;
                    }
                    if ((hely - 1) >= 21 && hely != 24)
                    {
                        ch = (CheckBox)this.Controls.Find("checkBox" + (hely - 1).ToString(), true)[0];
                        ch.BackColor = Color.Red;
                        ch.Enabled = false;
                    }
                }
                else if (hely >= 27 && hely <= 32)
                {
                    if ((hely - 3) >= 27)
                    {
                        ch = (CheckBox)this.Controls.Find("checkBox" + (hely - 3).ToString(), true)[0];
                        ch.BackColor = Color.Red;
                        ch.Enabled = false;
                    }
                    if ((hely + 3) <= 32)
                    {
                        ch = (CheckBox)this.Controls.Find("checkBox" + (hely + 3).ToString(), true)[0];
                        ch.BackColor = Color.Red;
                        ch.Enabled = false;
                    }
                    if ((hely + 1) <= 32 && hely != 29)
                    {
                        ch = (CheckBox)this.Controls.Find("checkBox" + (hely + 1).ToString(), true)[0];
                        ch.BackColor = Color.Red;
                        ch.Enabled = false;
                    }
                    if ((hely - 1) >= 27 && hely != 30)
                    {
                        ch = (CheckBox)this.Controls.Find("checkBox" + (hely - 1).ToString(), true)[0];
                        ch.BackColor = Color.Red;
                        ch.Enabled = false;
                    }
                }
                else if (hely >= 33 && hely <= 38)
                {
                    if ((hely - 3) >= 33)
                    {
                        ch = (CheckBox)this.Controls.Find("checkBox" + (hely - 3).ToString(), true)[0];
                        ch.BackColor = Color.Red;
                        ch.Enabled = false;
                    }
                    if ((hely + 3) <= 38)
                    {
                        ch = (CheckBox)this.Controls.Find("checkBox" + (hely + 3).ToString(), true)[0];
                        ch.BackColor = Color.Red;
                        ch.Enabled = false;
                    }
                    if ((hely + 1) <= 38 && hely != 35)
                    {
                        ch = (CheckBox)this.Controls.Find("checkBox" + (hely + 1).ToString(), true)[0];
                        ch.BackColor = Color.Red;
                        ch.Enabled = false;
                    }
                    if ((hely - 1) >= 33 && hely != 36)
                    {
                        ch = (CheckBox)this.Controls.Find("checkBox" + (hely - 1).ToString(), true)[0];
                        ch.BackColor = Color.Red;
                        ch.Enabled = false;
                    }
                }
            }
            megallok = Program.db.getJaratMegallok(this.jarat);
            vegallomasSelect.DataSource = megallok;
            vegallomasSelect.Text = megallok[megallok.Count - 1];
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
            arszamitas();
            elsoLabel.Text = elsoO.ToString();
        }
        public void CheckBox_CheckedChange_SecondClass(object sender, EventArgs e)
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
            arszamitas();
            masodLabel.Text = masodO.ToString();
        }

        private void arszamitas()
        {
            int eAr = 0, mAr = 0;

            if (tipus.Equals("Gyors"))
            {
                eAr = Convert.ToInt32(elsoO * 2000 * kupon);
                mAr = Convert.ToInt32(masodO * 1500 * kupon);
            }
            else
            {
                eAr = Convert.ToInt32(elsoO * 1000 * kupon);
                mAr = Convert.ToInt32(masodO * 750 * kupon);
            }
            if (vegallomas == false && eAr > 0) eAr -= elsoO * 500;
            if (vegallomas == false && mAr > 0) mAr -= masodO * 500;

            elsoAr.Text = eAr.ToString();
            masodAr.Text = mAr.ToString();
            osszAr.Text = (mAr + eAr).ToString();
        }

        private void kuponBtn_Click(object sender, EventArgs e)
        {
            if (kuponInput.Text.Equals("20"))
            {
                kupon = 0.8;
                MessageBox.Show("20%-os kupon aktiválva", "Kupon");
            }
            else if (kuponInput.Text.Equals("10"))
            {
                kupon = 0.9;
                MessageBox.Show("10%-os kupon aktiválva", "Kupon");
            }
            else
            {
                kupon = 1;
                MessageBox.Show("Nincs ilyen kupon", "Kupon");
            }
            arszamitas();
        }

        private void vegallomasSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (vegallomasSelect.Text.Equals(megallok[megallok.Count - 1])) vegallomas = true;
            else vegallomas = false;
            arszamitas();
        }

        private void vasarlasBtn_Click(object sender, EventArgs e)
        {
            if (foglaltak.Count > 0)
            {
                if (nevInput.Text != "")
                {
                    Program.db.vasarlas(jarat, foglaltak, nevInput.Text, vegallomasSelect.Text, kupon);
                    MessageBox.Show("Sikeres vásárlás", "Foglalás");
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
