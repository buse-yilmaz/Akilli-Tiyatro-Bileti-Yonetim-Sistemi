using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TiyatroBiletSistemi
{
    public partial class Admin_Page : Form
    {
        private Panel pnlUst;
        private Label lblLogo;
        private Button btnCikis;
        private string adminAdi;

        private TabControl tabControl;
        private TabPage tabOyunlar;
        private TabPage tabSeanslar;
        private TabPage tabKullanicilar;
        private TabPage tabRezervasyonlar;

        private DataGridView dgvOyunlar;
        private TextBox txtOyunAdi;
        private TextBox txtSure;
        private Button btnOyunEkle;
        private Button btnOyunSil;
        private Button btnOyunGuncelle;
        private int seciliOyunId = -1;

        private DataGridView dgvSeanslar;
        private ComboBox cmbOyunSec;
        private DateTimePicker dtpTarih;
        private DateTimePicker dtpSaat;
        private Button btnSeansEkle;
        private Button btnSeansSil;
        private Button btnSeansTarihGuncelle;
        private int seciliSeansId = -1;

        private DataGridView dgvKullanicilar;
        private Button btnKullaniciSil;

        private DataGridView dgvRezervasyonlar;

        public Admin_Page(string adminAdi)
        {
            this.adminAdi = adminAdi;
            InitializeComponent();
            FormuOlustur();
        }

        private void FormuOlustur()
        {
            this.Text = "Yönetici Paneli";
            this.Size = new Size(950, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(245, 245, 245);

            pnlUst = new Panel();
            pnlUst.Size = new Size(950, 65);
            pnlUst.Location = new Point(0, 0);
            pnlUst.BackColor = Color.FromArgb(139, 0, 0);

            lblLogo = new Label();
            lblLogo.Text = "🎭 Tiyatro Bileti Yönetim Sistemi  —  Hoş Geldiniz, " + adminAdi + "!";
            lblLogo.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(20, 18);
            lblLogo.Size = new Size(700, 30);

            btnCikis = OlusturButon("Çıkış Yap", Color.FromArgb(220, 80, 80), new Point(825, 15), new Size(95, 35));
            btnCikis.Click += BtnCikis_Click;

            pnlUst.Controls.Add(lblLogo);
            pnlUst.Controls.Add(btnCikis);

            tabControl = new TabControl();
            tabControl.Location = new Point(10, 75);
            tabControl.Size = new Size(920, 530);
            tabControl.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            tabOyunlar = new TabPage("🎭  Oyun Yönetimi");
            tabSeanslar = new TabPage("📅  Seans Yönetimi");
            tabKullanicilar = new TabPage("👥  Kullanıcılar");
            tabRezervasyonlar = new TabPage("🎟  Rezervasyonlar");

            tabOyunlar.BackColor = Color.FromArgb(245, 245, 245);
            tabSeanslar.BackColor = Color.FromArgb(245, 245, 245);
            tabKullanicilar.BackColor = Color.FromArgb(245, 245, 245);
            tabRezervasyonlar.BackColor = Color.FromArgb(245, 245, 245);

            OyunlarSekmesiOlustur();
            SeanslarSekmesiOlustur();
            KullanicilarSekmesiOlustur();
            RezervasyonlarSekmesiOlustur();

            tabControl.TabPages.Add(tabOyunlar);
            tabControl.TabPages.Add(tabSeanslar);
            tabControl.TabPages.Add(tabKullanicilar);
            tabControl.TabPages.Add(tabRezervasyonlar);

            tabControl.SelectedIndexChanged += (s, e) => TabDegisti();

            this.Controls.Add(pnlUst);
            this.Controls.Add(tabControl);

            OyunlariYukle();
            OyunComboGuncelle();
        }

        // ===== VERİTABANI YÜKLEME =====

        private void OyunlariYukle()
        {
            dgvOyunlar.Rows.Clear();
            try
            {
                var conn = VeriTabani.BaglantiAl();
                conn.Open();
                var cmd = new MySqlCommand("SELECT id, oyun_adi, sure_dakika FROM oyunlar", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    dgvOyunlar.Rows.Add(reader["id"], reader["oyun_adi"], reader["sure_dakika"]);
                conn.Close();
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
        }

        private void SeanslarıYukle()
        {
            dgvSeanslar.Rows.Clear();
            try
            {
                var conn = VeriTabani.BaglantiAl();
                conn.Open();
                string sorgu = @"SELECT s.id, o.oyun_adi, s.tarih, s.saat 
                                 FROM seanslar s JOIN oyunlar o ON s.oyun_id = o.id";
                var cmd = new MySqlCommand(sorgu, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    dgvSeanslar.Rows.Add(reader["id"], reader["oyun_adi"],
                        Convert.ToDateTime(reader["tarih"]).ToString("dd.MM.yyyy"),
                        reader["saat"].ToString().Substring(0, 5));
                conn.Close();
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
        }

        private void KullanicilariYukle()
        {
            dgvKullanicilar.Rows.Clear();
            try
            {
                var conn = VeriTabani.BaglantiAl();
                conn.Open();
                var cmd = new MySqlCommand("SELECT id, ad_soyad, email FROM kullanicilar", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    dgvKullanicilar.Rows.Add(reader["id"], reader["ad_soyad"], reader["email"]);
                conn.Close();
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
        }

        private void RezervasyonlariYukle()
        {
            dgvRezervasyonlar.Rows.Clear();
            try
            {
                var conn = VeriTabani.BaglantiAl();
                conn.Open();
                string sorgu = @"SELECT r.id, k.ad_soyad, o.oyun_adi, 
                                 CONCAT(s.tarih, ' ', s.saat) as seans, r.koltuk_no
                                 FROM rezervasyonlar r
                                 JOIN kullanicilar k ON r.kullanici_id = k.id
                                 JOIN seanslar s ON r.seans_id = s.id
                                 JOIN oyunlar o ON s.oyun_id = o.id";
                var cmd = new MySqlCommand(sorgu, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    dgvRezervasyonlar.Rows.Add(reader["id"], reader["ad_soyad"],
                        reader["oyun_adi"], reader["seans"], reader["koltuk_no"]);
                conn.Close();
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
        }

        private void TabDegisti()
        {
            if (tabControl.SelectedTab == tabSeanslar) SeanslarıYukle();
            else if (tabControl.SelectedTab == tabKullanicilar) KullanicilariYukle();
            else if (tabControl.SelectedTab == tabRezervasyonlar) RezervasyonlariYukle();
        }

        // ===== OYUN SEKMESİ =====

        private void OyunlarSekmesiOlustur()
        {
            Panel pnlForm = new Panel();
            pnlForm.Size = new Size(260, 460);
            pnlForm.Location = new Point(10, 10);
            pnlForm.BackColor = Color.White;
            pnlForm.BorderStyle = BorderStyle.FixedSingle;

            Label lblFormBaslik = new Label();
            lblFormBaslik.Text = "OYUN BİLGİLERİ";
            lblFormBaslik.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblFormBaslik.ForeColor = Color.White;
            lblFormBaslik.BackColor = Color.FromArgb(139, 0, 0);
            lblFormBaslik.Size = new Size(260, 35);
            lblFormBaslik.Location = new Point(0, 0);
            lblFormBaslik.TextAlign = ContentAlignment.MiddleCenter;

            Label lblOyunAdi = new Label();
            lblOyunAdi.Text = "Oyun Adı:";
            lblOyunAdi.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblOyunAdi.Location = new Point(15, 55);
            lblOyunAdi.AutoSize = true;

            txtOyunAdi = new TextBox();
            txtOyunAdi.Location = new Point(15, 75);
            txtOyunAdi.Size = new Size(230, 28);
            txtOyunAdi.Font = new Font("Segoe UI", 10);

            Label lblSure = new Label();
            lblSure.Text = "Süre (dakika):";
            lblSure.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblSure.Location = new Point(15, 120);
            lblSure.AutoSize = true;

            txtSure = new TextBox();
            txtSure.Location = new Point(15, 140);
            txtSure.Size = new Size(230, 28);
            txtSure.Font = new Font("Segoe UI", 10);

            btnOyunEkle = OlusturButon("+ Ekle", Color.FromArgb(0, 130, 70), new Point(15, 195), new Size(230, 38));
            btnOyunGuncelle = OlusturButon("Güncelle", Color.FromArgb(0, 100, 180), new Point(15, 245), new Size(230, 38));
            btnOyunSil = OlusturButon("Sil", Color.FromArgb(190, 30, 30), new Point(15, 295), new Size(230, 38));

            pnlForm.Controls.Add(lblFormBaslik);
            pnlForm.Controls.Add(lblOyunAdi);
            pnlForm.Controls.Add(txtOyunAdi);
            pnlForm.Controls.Add(lblSure);
            pnlForm.Controls.Add(txtSure);
            pnlForm.Controls.Add(btnOyunEkle);
            pnlForm.Controls.Add(btnOyunGuncelle);
            pnlForm.Controls.Add(btnOyunSil);

            dgvOyunlar = OlusturDataGridView(new Point(285, 10), new Size(615, 460));
            dgvOyunlar.Columns.Add("ID", "ID");
            dgvOyunlar.Columns.Add("OyunAdi", "Oyun Adı");
            dgvOyunlar.Columns.Add("Sure", "Süre (dk)");
            dgvOyunlar.Columns["ID"].Width = 40;
            dgvOyunlar.Columns["OyunAdi"].Width = 280;
            dgvOyunlar.Columns["Sure"].Width = 100;

            btnOyunEkle.Click += BtnOyunEkle_Click;
            btnOyunGuncelle.Click += BtnOyunGuncelle_Click;
            btnOyunSil.Click += BtnOyunSil_Click;
            dgvOyunlar.SelectionChanged += (s, e) =>
            {
                if (dgvOyunlar.SelectedRows.Count == 0) return;
                var row = dgvOyunlar.SelectedRows[0];
                seciliOyunId = Convert.ToInt32(row.Cells["ID"].Value);
                txtOyunAdi.Text = row.Cells["OyunAdi"].Value?.ToString();
                txtSure.Text = row.Cells["Sure"].Value?.ToString();
            };

            tabOyunlar.Controls.Add(pnlForm);
            tabOyunlar.Controls.Add(dgvOyunlar);
        }

        private void BtnOyunEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOyunAdi.Text) || string.IsNullOrWhiteSpace(txtSure.Text))
            { MessageBox.Show("Oyun adı ve süre boş olamaz!"); return; }

            try
            {
                var conn = VeriTabani.BaglantiAl();
                conn.Open();
                var cmd = new MySqlCommand("INSERT INTO oyunlar (oyun_adi, sure_dakika) VALUES (@ad, @sure)", conn);
                cmd.Parameters.AddWithValue("@ad", txtOyunAdi.Text.Trim());
                cmd.Parameters.AddWithValue("@sure", int.Parse(txtSure.Text.Trim()));
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Oyun eklendi!");
                txtOyunAdi.Clear(); txtSure.Clear();
                OyunlariYukle();
                OyunComboGuncelle();
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
        }

        private void BtnOyunGuncelle_Click(object sender, EventArgs e)
        {
            if (seciliOyunId < 0) { MessageBox.Show("Güncellenecek oyunu seçin!"); return; }
            try
            {
                var conn = VeriTabani.BaglantiAl();
                conn.Open();
                var cmd = new MySqlCommand("UPDATE oyunlar SET oyun_adi=@ad, sure_dakika=@sure WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@ad", txtOyunAdi.Text.Trim());
                cmd.Parameters.AddWithValue("@sure", int.Parse(txtSure.Text.Trim()));
                cmd.Parameters.AddWithValue("@id", seciliOyunId);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Oyun güncellendi!");
                OyunlariYukle();
                OyunComboGuncelle();
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
        }

        private void BtnOyunSil_Click(object sender, EventArgs e)
        {
            if (seciliOyunId < 0) { MessageBox.Show("Silinecek oyunu seçin!"); return; }
            var onay = MessageBox.Show("Bu oyun silinsin mi?", "Onay", MessageBoxButtons.YesNo);
            if (onay != DialogResult.Yes) return;
            try
            {
                var conn = VeriTabani.BaglantiAl();
                conn.Open();
                var cmd = new MySqlCommand("DELETE FROM oyunlar WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@id", seciliOyunId);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Oyun silindi!");
                seciliOyunId = -1;
                txtOyunAdi.Clear(); txtSure.Clear();
                OyunlariYukle();
                OyunComboGuncelle();
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
        }

        // ===== SEANS SEKMESİ =====

        private void SeanslarSekmesiOlustur()
        {
            Panel pnlForm = new Panel();
            pnlForm.Size = new Size(260, 460);
            pnlForm.Location = new Point(10, 10);
            pnlForm.BackColor = Color.White;
            pnlForm.BorderStyle = BorderStyle.FixedSingle;

            Label lblFormBaslik = new Label();
            lblFormBaslik.Text = "SEANS BİLGİLERİ";
            lblFormBaslik.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblFormBaslik.ForeColor = Color.White;
            lblFormBaslik.BackColor = Color.FromArgb(139, 0, 0);
            lblFormBaslik.Size = new Size(260, 35);
            lblFormBaslik.Location = new Point(0, 0);
            lblFormBaslik.TextAlign = ContentAlignment.MiddleCenter;

            Label lblOyun = new Label();
            lblOyun.Text = "Oyun Seç:";
            lblOyun.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblOyun.Location = new Point(15, 55);
            lblOyun.AutoSize = true;

            cmbOyunSec = new ComboBox();
            cmbOyunSec.Location = new Point(15, 75);
            cmbOyunSec.Size = new Size(230, 28);
            cmbOyunSec.Font = new Font("Segoe UI", 10);
            cmbOyunSec.DropDownStyle = ComboBoxStyle.DropDownList;

            Label lblTarih = new Label();
            lblTarih.Text = "Tarih:";
            lblTarih.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblTarih.Location = new Point(15, 120);
            lblTarih.AutoSize = true;

            dtpTarih = new DateTimePicker();
            dtpTarih.Location = new Point(15, 140);
            dtpTarih.Size = new Size(230, 28);
            dtpTarih.Format = DateTimePickerFormat.Short;

            Label lblSaat = new Label();
            lblSaat.Text = "Saat:";
            lblSaat.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblSaat.Location = new Point(15, 185);
            lblSaat.AutoSize = true;

            dtpSaat = new DateTimePicker();
            dtpSaat.Location = new Point(15, 205);
            dtpSaat.Size = new Size(230, 28);
            dtpSaat.Format = DateTimePickerFormat.Time;
            dtpSaat.ShowUpDown = true;

            btnSeansEkle = OlusturButon("+ Seans Ekle", Color.FromArgb(0, 130, 70), new Point(15, 255), new Size(230, 38));
            btnSeansTarihGuncelle = OlusturButon("Tarih/Saat Güncelle", Color.FromArgb(0, 100, 180), new Point(15, 305), new Size(230, 38));
            btnSeansSil = OlusturButon("Seans Sil", Color.FromArgb(190, 30, 30), new Point(15, 355), new Size(230, 38));

            pnlForm.Controls.Add(lblFormBaslik);
            pnlForm.Controls.Add(lblOyun);
            pnlForm.Controls.Add(cmbOyunSec);
            pnlForm.Controls.Add(lblTarih);
            pnlForm.Controls.Add(dtpTarih);
            pnlForm.Controls.Add(lblSaat);
            pnlForm.Controls.Add(dtpSaat);
            pnlForm.Controls.Add(btnSeansEkle);
            pnlForm.Controls.Add(btnSeansTarihGuncelle);
            pnlForm.Controls.Add(btnSeansSil);

            dgvSeanslar = OlusturDataGridView(new Point(285, 10), new Size(615, 460));
            dgvSeanslar.Columns.Add("ID", "ID");
            dgvSeanslar.Columns.Add("Oyun", "Oyun");
            dgvSeanslar.Columns.Add("Tarih", "Tarih");
            dgvSeanslar.Columns.Add("Saat", "Saat");
            dgvSeanslar.Columns["ID"].Width = 40;
            dgvSeanslar.Columns["Oyun"].Width = 200;
            dgvSeanslar.Columns["Tarih"].Width = 120;
            dgvSeanslar.Columns["Saat"].Width = 80;

            btnSeansEkle.Click += BtnSeansEkle_Click;
            btnSeansTarihGuncelle.Click += BtnSeansTarihGuncelle_Click;
            btnSeansSil.Click += BtnSeansSil_Click;
            dgvSeanslar.SelectionChanged += (s, e) =>
            {
                if (dgvSeanslar.SelectedRows.Count > 0)
                    seciliSeansId = Convert.ToInt32(dgvSeanslar.SelectedRows[0].Cells["ID"].Value);
            };

            tabSeanslar.Controls.Add(pnlForm);
            tabSeanslar.Controls.Add(dgvSeanslar);
        }

        private void BtnSeansEkle_Click(object sender, EventArgs e)
        {
            if (cmbOyunSec.SelectedIndex < 0) { MessageBox.Show("Oyun seçin!"); return; }
            try
            {
                var conn = VeriTabani.BaglantiAl();
                conn.Open();

                // Seçilen oyunun id'sini bul
                string oyunAdi = cmbOyunSec.SelectedItem.ToString();
                var idCmd = new MySqlCommand("SELECT id FROM oyunlar WHERE oyun_adi=@ad", conn);
                idCmd.Parameters.AddWithValue("@ad", oyunAdi);
                int oyunId = Convert.ToInt32(idCmd.ExecuteScalar());

                // İlk salonu kullan (salon seçimi sonra eklenebilir)
                var salonCmd = new MySqlCommand("SELECT id FROM salonlar LIMIT 1", conn);
                int salonId = Convert.ToInt32(salonCmd.ExecuteScalar());

                var cmd = new MySqlCommand("INSERT INTO seanslar (oyun_id, salon_id, tarih, saat) VALUES (@oyun, @salon, @tarih, @saat)", conn);
                cmd.Parameters.AddWithValue("@oyun", oyunId);
                cmd.Parameters.AddWithValue("@salon", salonId);
                cmd.Parameters.AddWithValue("@tarih", dtpTarih.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@saat", dtpSaat.Value.ToString("HH:mm:ss"));
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Seans eklendi!");
                SeanslarıYukle();
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
        }

        private void BtnSeansTarihGuncelle_Click(object sender, EventArgs e)
        {
            if (seciliSeansId < 0) { MessageBox.Show("Güncellenecek seansı seçin!"); return; }
            try
            {
                var conn = VeriTabani.BaglantiAl();
                conn.Open();
                var cmd = new MySqlCommand("UPDATE seanslar SET tarih=@tarih, saat=@saat WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@tarih", dtpTarih.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@saat", dtpSaat.Value.ToString("HH:mm:ss"));
                cmd.Parameters.AddWithValue("@id", seciliSeansId);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Seans güncellendi!");
                SeanslarıYukle();
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
        }

        private void BtnSeansSil_Click(object sender, EventArgs e)
        {
            if (seciliSeansId < 0) { MessageBox.Show("Silinecek seansı seçin!"); return; }
            var onay = MessageBox.Show("Bu seans silinsin mi?", "Onay", MessageBoxButtons.YesNo);
            if (onay != DialogResult.Yes) return;
            try
            {
                var conn = VeriTabani.BaglantiAl();
                conn.Open();
                var cmd = new MySqlCommand("DELETE FROM seanslar WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@id", seciliSeansId);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Seans silindi!");
                seciliSeansId = -1;
                SeanslarıYukle();
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
        }

        // ===== KULLANICI SEKMESİ =====

        private void KullanicilarSekmesiOlustur()
        {
            Panel pnlToolbar = new Panel();
            pnlToolbar.Size = new Size(900, 50);
            pnlToolbar.Location = new Point(5, 5);
            pnlToolbar.BackColor = Color.White;
            pnlToolbar.BorderStyle = BorderStyle.FixedSingle;

            Label lblBaslik = new Label();
            lblBaslik.Text = "Kullanıcı Listesi";
            lblBaslik.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblBaslik.ForeColor = Color.FromArgb(139, 0, 0);
            lblBaslik.Location = new Point(15, 13);
            lblBaslik.AutoSize = true;

            btnKullaniciSil = OlusturButon("Seçili Kullanıcıyı Sil", Color.FromArgb(190, 30, 30), new Point(700, 8), new Size(185, 33));

            pnlToolbar.Controls.Add(lblBaslik);
            pnlToolbar.Controls.Add(btnKullaniciSil);

            dgvKullanicilar = OlusturDataGridView(new Point(5, 65), new Size(900, 405));
            dgvKullanicilar.Columns.Add("ID", "ID");
            dgvKullanicilar.Columns.Add("AdSoyad", "Ad Soyad");
            dgvKullanicilar.Columns.Add("Mail", "E-Posta");
            dgvKullanicilar.Columns["ID"].Width = 50;
            dgvKullanicilar.Columns["AdSoyad"].Width = 250;
            dgvKullanicilar.Columns["Mail"].Width = 300;

            btnKullaniciSil.Click += BtnKullaniciSil_Click;

            tabKullanicilar.Controls.Add(pnlToolbar);
            tabKullanicilar.Controls.Add(dgvKullanicilar);
        }

        private void BtnKullaniciSil_Click(object sender, EventArgs e)
        {
            if (dgvKullanicilar.SelectedRows.Count == 0) { MessageBox.Show("Silinecek kullanıcıyı seçin!"); return; }
            string ad = dgvKullanicilar.SelectedRows[0].Cells["AdSoyad"].Value?.ToString();
            int id = Convert.ToInt32(dgvKullanicilar.SelectedRows[0].Cells["ID"].Value);
            var onay = MessageBox.Show($"'{ad}' silinsin mi?", "Onay", MessageBoxButtons.YesNo);
            if (onay != DialogResult.Yes) return;
            try
            {
                var conn = VeriTabani.BaglantiAl();
                conn.Open();
                var cmd = new MySqlCommand("DELETE FROM kullanicilar WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Kullanıcı silindi!");
                KullanicilariYukle();
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
        }

        // ===== REZERVASYON SEKMESİ =====

        private void RezervasyonlarSekmesiOlustur()
        {
            Label lblBaslik = new Label();
            lblBaslik.Text = "Rezervasyon Listesi";
            lblBaslik.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblBaslik.ForeColor = Color.FromArgb(139, 0, 0);
            lblBaslik.Location = new Point(10, 10);
            lblBaslik.AutoSize = true;

            dgvRezervasyonlar = OlusturDataGridView(new Point(5, 40), new Size(900, 430));
            dgvRezervasyonlar.Columns.Add("ID", "ID");
            dgvRezervasyonlar.Columns.Add("Kullanici", "Kullanıcı");
            dgvRezervasyonlar.Columns.Add("Oyun", "Oyun");
            dgvRezervasyonlar.Columns.Add("Seans", "Seans");
            dgvRezervasyonlar.Columns.Add("Koltuk", "Koltuk");
            dgvRezervasyonlar.Columns["ID"].Width = 40;
            dgvRezervasyonlar.Columns["Kullanici"].Width = 200;
            dgvRezervasyonlar.Columns["Oyun"].Width = 200;
            dgvRezervasyonlar.Columns["Seans"].Width = 180;
            dgvRezervasyonlar.Columns["Koltuk"].Width = 80;

            tabRezervasyonlar.Controls.Add(lblBaslik);
            tabRezervasyonlar.Controls.Add(dgvRezervasyonlar);
        }

        // ===== YARDIMCI METOTLAR =====

        private void OyunComboGuncelle()
        {
            cmbOyunSec.Items.Clear();
            try
            {
                var conn = VeriTabani.BaglantiAl();
                conn.Open();
                var cmd = new MySqlCommand("SELECT oyun_adi FROM oyunlar", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    cmbOyunSec.Items.Add(reader["oyun_adi"].ToString());
                conn.Close();
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
        }

        private Button OlusturButon(string text, Color renk, Point konum, Size boyut)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.Location = konum;
            btn.Size = boyut;
            btn.BackColor = renk;
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
            Color hover = Color.FromArgb(
                Math.Max(0, renk.R - 25),
                Math.Max(0, renk.G - 25),
                Math.Max(0, renk.B - 25));
            btn.MouseEnter += (s, e) => btn.BackColor = hover;
            btn.MouseLeave += (s, e) => btn.BackColor = renk;
            return btn;
        }

        private DataGridView OlusturDataGridView(Point konum, Size boyut)
        {
            DataGridView dgv = new DataGridView();
            dgv.Location = konum;
            dgv.Size = boyut;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.RowHeadersVisible = false;
            dgv.Font = new Font("Segoe UI", 9);
            dgv.RowTemplate.Height = 30;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(139, 0, 0);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 35;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(252, 245, 245);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 50, 50);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.GridColor = Color.FromArgb(230, 220, 220);
            return dgv;
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            Admin_Login login = new Admin_Login();
            login.Show();
            this.Close();
        }

        private void Admin_Page_Load(object sender, EventArgs e) { }
    }
}