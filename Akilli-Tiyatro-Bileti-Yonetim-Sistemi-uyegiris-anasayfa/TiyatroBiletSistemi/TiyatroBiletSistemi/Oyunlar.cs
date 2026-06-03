using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TiyatroBiletSistemi
{
    public partial class Oyunlar : Form
    {
        Dictionary<string, List<string>> sehirler =
        new Dictionary<string, List<string>>()
        {
            {"Bursa", new List<string>{"Nilüfer","Osmangazi","Yıldırım"}},
            {"İstanbul", new List<string>{"Kadıköy","Beşiktaş","Üsküdar"}},
            {"Ankara", new List<string>{"Çankaya","Keçiören","Mamak"}}
        };

        class Oyun
        {
            public string Ad { get; set; }
            public string Salon { get; set; }
            public string Seanslar { get; set; }
            public string Sehir { get; set; }
            public string Ilce { get; set; }
            public DateTime Tarih { get; set; }
            public string Poster { get; set; }
        }

        List<Oyun> oyunlar = new List<Oyun>()
        {
            new Oyun
            {
                Ad="Hamlet",
                Salon="FSM Sahnesi",
                Seanslar="14:00 - 17:00 - 20:00",
                Sehir="Bursa",
                Ilce="Osmangazi",
                Tarih=new DateTime(2026,6,2),

                Poster="hamlet.jpg"
            },

            new Oyun
            {
                Ad="Romeo ve Juliet",
                Salon="Kadıköy Sahnesi",
                Seanslar="15:00 - 18:00 - 21:00",
                Sehir="İstanbul",
                Ilce="Beşiktaş",
                Tarih=new DateTime(2026,6,2),
                Poster="romeo.jpg"
            },

            new Oyun
            {
                Ad="Othello",
                Salon="Çankaya Tiyatro",
                Seanslar="13:00 - 16:00 - 19:00",
                Sehir="Ankara",
                Ilce="Keçiören",
                Tarih=new DateTime(2026,6,2),
                Poster="othello.jpg"
            }
        };

        public Oyunlar()
        {
            InitializeComponent();

            this.Load += Oyunlar_Load;
            cmbSehir.SelectedIndexChanged += cmbSehir_SelectedIndexChanged;
            button1.Click += button1_Click;
        }

        private void Oyunlar_Load(object sender, EventArgs e)
        {
            cmbSehir.Items.Add("Bursa");
            cmbSehir.Items.Add("İstanbul");
            cmbSehir.Items.Add("Ankara");
        }

        private void cmbSehir_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbIlce.Items.Clear();

            string secilenSehir = cmbSehir.SelectedItem.ToString();

            foreach (var ilce in sehirler[secilenSehir])
            {
                cmbIlce.Items.Add(ilce);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flowOyunlar.Controls.Clear();

            if (cmbSehir.SelectedItem == null)
            {
                MessageBox.Show("Lütfen şehir seçiniz.");
                return;
            }

            string secilenSehir = cmbSehir.SelectedItem.ToString();
            string secilenIlce = cmbIlce.Text;
            DateTime secilenTarih = dtTarih.Value.Date;

            var filtreliOyunlar = oyunlar
                .Where(x =>
                    x.Sehir == secilenSehir &&
                    x.Ilce == secilenIlce &&
                    x.Tarih.Date == secilenTarih)
                .ToList();

            if (filtreliOyunlar.Count == 0)
            {
                MessageBox.Show("Seçilen kriterlere uygun oyun bulunamadı.");
                return;
            }

            foreach (var oyun in filtreliOyunlar)
            {
                Panel kart = new Panel();
                kart.Size = new Size(280, 420);
                kart.BackColor = Color.White;
                kart.BorderStyle = BorderStyle.FixedSingle;
                kart.Margin = new Padding(20);

                PictureBox poster = new PictureBox();
                poster.Size = new Size(240, 250);
                poster.Location = new Point(20, 15);
                poster.SizeMode = PictureBoxSizeMode.StretchImage;

                try
                {
                    string yol = System.IO.Path.Combine(
                        Application.StartupPath,
                        @"..\..\Resources",
                        oyun.Poster);

                    poster.Image = Image.FromFile(yol);
                }
                catch
                {
                    // Resim bulunamazsa boş geç
                }

                Label lblAd = new Label();
                lblAd.Text = oyun.Ad;
                lblAd.Font = new Font("Arial", 11, FontStyle.Bold);
                lblAd.Location = new Point(20, 280);
                lblAd.AutoSize = true;

                Label lblSalon = new Label();
                lblSalon.Text = oyun.Salon;
                lblSalon.Location = new Point(20, 315);
                lblSalon.AutoSize = true;

                Label lblSaat = new Label();
                lblSaat.Text = "Seanslar: " + oyun.Seanslar;
                lblSaat.Location = new Point(20, 340);
                lblSaat.Size = new Size(220, 40);

                Button btnBilet = new Button();
                btnBilet.Text = "Bilet Al";
                btnBilet.Size = new Size(100, 35);
                btnBilet.Location = new Point(85, 370);
                btnBilet.BackColor = Color.Firebrick;
                btnBilet.ForeColor = Color.White;
                btnBilet.FlatStyle = FlatStyle.Flat;

                btnBilet.Click += (s, ev) =>
                {
                    KoltukSecim frm = new KoltukSecim();
                    frm.Show();
                };

                kart.Controls.Add(poster);
                kart.Controls.Add(lblAd);
                kart.Controls.Add(lblSalon);
                kart.Controls.Add(lblSaat);
                kart.Controls.Add(btnBilet);

                flowOyunlar.Controls.Add(kart);
            }
        }

        private void Oyunlar_Load_1(object sender, EventArgs e)
        {

        }
    }
}