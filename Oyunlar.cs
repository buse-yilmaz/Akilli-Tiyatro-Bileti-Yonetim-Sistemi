using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TiyatroBiletSistemi
{
    public partial class Oyunlar : Form
    {
        public Oyunlar()
        {
            InitializeComponent();
            this.Load += Oyunlar_Load;
            cmbSehir.SelectedIndexChanged += cmbSehir_SelectedIndexChanged;
            button1.Click += button1_Click;
        }

        private void Oyunlar_Load(object sender, EventArgs e)
        {
            try
            {
                var conn = VeriTabani.BaglantiAl();
                conn.Open();
                string sorgu = "SELECT sehir_adi FROM sehirler";
                var cmd = new MySqlCommand(sorgu, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    cmbSehir.Items.Add(reader["sehir_adi"].ToString());
                conn.Close();
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
        }

        private void cmbSehir_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbIlce.Items.Clear();
            try
            {
                var conn = VeriTabani.BaglantiAl();
                conn.Open();
                string sorgu = "SELECT ilce_adi FROM ilceler WHERE sehir_id = (SELECT id FROM sehirler WHERE sehir_adi = @sehir)";
                var cmd = new MySqlCommand(sorgu, conn);
                cmd.Parameters.AddWithValue("@sehir", cmbSehir.SelectedItem.ToString());
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    cmbIlce.Items.Add(reader["ilce_adi"].ToString());
                conn.Close();
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flowOyunlar.Controls.Clear();

            if (cmbSehir.SelectedItem == null)
            {
                MessageBox.Show("Lütfen şehir seçiniz.");
                return;
            }

            try
            {
                var conn = VeriTabani.BaglantiAl();
                conn.Open();

                string sorgu = @"
                    SELECT o.oyun_adi, o.poster, sl.salon_adi, s.saat, s.id as seans_id
                    FROM seanslar s
                    JOIN oyunlar o ON s.oyun_id = o.id
                    JOIN salonlar sl ON s.salon_id = sl.id
                    JOIN sehirler sh ON sl.sehir_id = sh.id
                    JOIN ilceler i ON sl.ilce_id = i.id
                    WHERE sh.sehir_adi = @sehir
                    AND i.ilce_adi = @ilce
                    AND s.tarih = @tarih";

                var cmd = new MySqlCommand(sorgu, conn);
                cmd.Parameters.AddWithValue("@sehir", cmbSehir.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@ilce", cmbIlce.Text);
                cmd.Parameters.AddWithValue("@tarih", dtTarih.Value.Date.ToString("yyyy-MM-dd"));

                var reader = cmd.ExecuteReader();
                bool oyunVar = false;

                while (reader.Read())
                {
                    oyunVar = true;
                    string oyunAdi = reader["oyun_adi"].ToString();
                    string salonAdi = reader["salon_adi"].ToString();
                    string saat = reader["saat"].ToString();
                    string posterDosya = reader["poster"]?.ToString();

                    Panel kart = new Panel();
                    kart.Size = new Size(280, 420);
                    kart.BackColor = Color.White;
                    kart.BorderStyle = BorderStyle.FixedSingle;
                    kart.Margin = new Padding(20);

                    // Poster resmi
                    PictureBox pb = new PictureBox();
                    pb.Size = new Size(240, 250);
                    pb.Location = new Point(20, 15);
                    pb.SizeMode = PictureBoxSizeMode.StretchImage;
                    try
                    {
                        string yol = System.IO.Path.Combine(
                            Application.StartupPath, @"..\..\Resources", posterDosya);
                        pb.Image = Image.FromFile(yol);
                    }
                    catch { pb.BackColor = Color.LightGray; }

                    Label lblAd = new Label();
                    lblAd.Text = oyunAdi;
                    lblAd.Font = new Font("Arial", 11, FontStyle.Bold);
                    lblAd.Location = new Point(20, 275);
                    lblAd.AutoSize = true;

                    Label lblSalon = new Label();
                    lblSalon.Text = salonAdi;
                    lblSalon.Location = new Point(20, 305);
                    lblSalon.AutoSize = true;

                    Label lblSaat = new Label();
                    lblSaat.Text = "Seans: " + saat;
                    lblSaat.Location = new Point(20, 330);
                    lblSaat.AutoSize = true;

                    Button btnBilet = new Button();
                    btnBilet.Text = "Bilet Al";
                    btnBilet.Size = new Size(100, 35);
                    btnBilet.Location = new Point(85, 365);
                    btnBilet.BackColor = Color.Firebrick;
                    btnBilet.ForeColor = Color.White;
                    btnBilet.FlatStyle = FlatStyle.Flat;

                    string _oyunAdi = oyunAdi;
                    btnBilet.Click += (s, ev) =>
                    {
                        KoltukSecim frm = new KoltukSecim(_oyunAdi);
                        frm.Show();
                    };

                    kart.Controls.Add(pb);
                    kart.Controls.Add(lblAd);
                    kart.Controls.Add(lblSalon);
                    kart.Controls.Add(lblSaat);
                    kart.Controls.Add(btnBilet);
                    flowOyunlar.Controls.Add(kart);
                }
                conn.Close();

                if (!oyunVar)
                    MessageBox.Show("Seçilen kriterlere uygun oyun bulunamadı.");
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
        }

        private void Oyunlar_Load_1(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { }
        private void flowOyunlar_Paint(object sender, PaintEventArgs e) { }

        private void panelUst_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}