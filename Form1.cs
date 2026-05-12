using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            public string Saat { get; set; }
            public string Sehir { get; set; }
            public string Poster { get; set; }
        }
        List<Oyun> oyunlar = new List<Oyun>()
        {
            new Oyun
            {
                Ad="Hamlet",
                Salon="FSM Sahnesi",
                Saat="20:00",
                Sehir="Bursa",
                Poster="hamlet.jpg"
            },

            new Oyun
            {
                Ad="Macbeth",
                Salon="Konak Sahnesi",
                Saat="19:30",
                Sehir="İzmir",
                Poster="macbeth.jpg"
            },

            new Oyun
            {
                Ad="Romeo ve Juliet",
                Salon="Kadıköy Sahnesi",
                Saat="21:00",
                Sehir="İstanbul",
                Poster="romeo.jpg"
            },

            new Oyun
            {
                Ad="Othello",
                Salon="Çankaya Tiyatro",
                Saat="18:00",
                Sehir="Ankara",
                Poster="othello.jpg"
            }
        };




        public Oyunlar()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
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

        private void btnListele_Click(object sender, EventArgs e)
        {
            flowOyunlar.Controls.Clear();

            string secilenSehir = cmbSehir.SelectedItem.ToString();

            var filtreliOyunlar = oyunlar.Where(x => x.Sehir == secilenSehir).ToList();

            foreach (var oyun in filtreliOyunlar)
            {
                Panel kart = new Panel();
                kart.Size = new Size(220, 320);
                kart.BackColor = Color.White;
                kart.BorderStyle = BorderStyle.FixedSingle;
                kart.Margin = new Padding(20);

                PictureBox poster = new PictureBox();
                poster.Size = new Size(180, 180);
                poster.Location = new Point(20, 10);
                poster.SizeMode = PictureBoxSizeMode.StretchImage;

                poster.Image = Image.FromFile(oyun.Poster);

                Label lblAd = new Label();
                lblAd.Text = oyun.Ad;
                lblAd.Font = new Font("Arial", 12, FontStyle.Bold);
                lblAd.Location = new Point(20, 200);
                lblAd.AutoSize = true;

                Label lblSalon = new Label();
                lblSalon.Text = oyun.Salon;
                lblSalon.Location = new Point(20, 230);
                lblSalon.AutoSize = true;

                Label lblSaat = new Label();
                lblSaat.Text = oyun.Saat;
                lblSaat.Location = new Point(20, 255);
                lblSaat.AutoSize = true;

                Button btnBilet = new Button();
                btnBilet.Text = "Bilet Al";
                btnBilet.Size = new Size(100, 35);
                btnBilet.Location = new Point(55, 280);
                btnBilet.BackColor = Color.Firebrick;
                btnBilet.ForeColor = Color.White;
                btnBilet.FlatStyle = FlatStyle.Flat;

                kart.Controls.Add(poster);
                kart.Controls.Add(lblAd);
                kart.Controls.Add(lblSalon);
                kart.Controls.Add(lblSaat);
                kart.Controls.Add(btnBilet);

                flowOyunlar.Controls.Add(kart);
            }
        }
    }
}
