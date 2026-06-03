using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
namespace TiyatroBiletSistemi
{
    public partial class KoltukSecim : Form

    {
        Button seciliKoltuk = null;
        string oyunAdi;
        public KoltukSecim(string oyunAdi)
        {
            InitializeComponent();
            this.oyunAdi = oyunAdi;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void KoltukSecim_Load(object sender, EventArgs e)
        {
            string[] doluKoltuklar =
{
    "A3",
    "B5",
    "C2",
    "D4"
};

            for (int satir = 0; satir < 5; satir++)
            {
                for (int sutun = 0; sutun < 6; sutun++)
                {
                    Button btn = new Button();

                    char harf = (char)('A' + satir);

                    btn.Text = harf.ToString() + (sutun + 1);

                    btn.Width = 35;
                    btn.Height = 35;

                    btn.Left = sutun * 40 + 15;
                    btn.Top = satir * 40 + 15;

                    btn.Click += KoltukSec;

                    if (doluKoltuklar.Contains(btn.Text))
                    {
                        btn.BackColor = Color.Red;
                        btn.Enabled = false;
                    }
                    else
                    {
                        btn.BackColor = Color.Green;
                    }

                    panelKoltuklar.Controls.Add(btn);
                }
            }
        }
        private void KoltukSec(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (seciliKoltuk == btn)
            {
                btn.BackColor = Color.Green;

                seciliKoltuk = null;

                lblSecilenKoltuk.Text =
                    "Seçilen Koltuk : -";

                return;
            }

            if (seciliKoltuk != null)
            {
                seciliKoltuk.BackColor = Color.Green;
            }

            seciliKoltuk = btn;

            btn.BackColor = Color.Yellow;

            lblSecilenKoltuk.Text =
                "Seçilen Koltuk : " + btn.Text;
        }

        private void btnDevamEt_Click(object sender, EventArgs e)
        {
            if (seciliKoltuk == null)
            {
                MessageBox.Show("Lütfen bir koltuk seçiniz!");
                return;
            }

            Odeme frm = new Odeme(oyunAdi, seciliKoltuk.Text);
            frm.Show();
            this.Hide();
        }
    }
}
