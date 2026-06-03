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
    public partial class Admin_Page : Form
    {
        private Panel pnlUst;
        private Label lblLogo;
        private Button btnCikis;
        private string adminAdi;

        // TabControl
        private TabControl tabControl;
        private TabPage tabOyunlar;
        private TabPage tabSeanslar;
        private TabPage tabKullanicilar;
        private TabPage tabRezervasyonlar;

        // Oyun Yönetimi
        private DataGridView dgvOyunlar;
        private TextBox txtOyunAdi;
        private TextBox txtSure;
        private Button btnOyunEkle;
        private Button btnOyunSil;
        private Button btnOyunGuncelle;
        private int seciliOyunIndex = -1;

        // Seans Yönetimi
        private DataGridView dgvSeanslar;
        private ComboBox cmbOyunSec;
        private DateTimePicker dtpTarih;
        private DateTimePicker dtpSaat;
        private Button btnSeansEkle;
        private Button btnSeansSil;
        private Button btnSeansTarihGuncelle;
        private int seciliSeansIndex = -1;

        // Kullanıcılar
        private DataGridView dgvKullanicilar;
        private Button btnKullaniciSil;

        // Rezervasyonlar
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
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(245, 245, 245);

            // ===== ÜST PANEL =====
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

            btnCikis = new Button();
            btnCikis.Text = "Çıkış Yap";
            btnCikis.Location = new Point(825, 15);
            btnCikis.Size = new Size(95, 35);
            btnCikis.BackColor = Color.FromArgb(220, 80, 80);
            btnCikis.ForeColor = Color.White;
            btnCikis.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnCikis.FlatStyle = FlatStyle.Flat;
            btnCikis.FlatAppearance.BorderSize = 0;
            btnCikis.Cursor = Cursors.Hand;
            btnCikis.Click += BtnCikis_Click;
            btnCikis.MouseEnter += (s, e) => btnCikis.BackColor = Color.FromArgb(200, 50, 50);
            btnCikis.MouseLeave += (s, e) => btnCikis.BackColor = Color.FromArgb(220, 80, 80);

            pnlUst.Controls.Add(lblLogo);
            pnlUst.Controls.Add(btnCikis);

            // ===== TAB CONTROL =====
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

            this.Controls.Add(pnlUst);
            this.Controls.Add(tabControl);
        }

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
            lblOyunAdi.ForeColor = Color.FromArgb(80, 80, 80);
            lblOyunAdi.Location = new Point(15, 55);
            lblOyunAdi.AutoSize = true;

            txtOyunAdi = new TextBox();
            txtOyunAdi.Location = new Point(15, 75);
            txtOyunAdi.Size = new Size(230, 28);
            txtOyunAdi.Font = new Font("Segoe UI", 10);
            txtOyunAdi.BorderStyle = BorderStyle.FixedSingle;

            Label lblSure = new Label();
            lblSure.Text = "Süre (dakika):";
            lblSure.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblSure.ForeColor = Color.FromArgb(80, 80, 80);
            lblSure.Location = new Point(15, 120);
            lblSure.AutoSize = true;

            txtSure = new TextBox();
            txtSure.Location = new Point(15, 140);
            txtSure.Size = new Size(230, 28);
            txtSure.Font = new Font("Segoe UI", 10);
            txtSure.BorderStyle = BorderStyle.FixedSingle;

            btnOyunEkle = OlusturButon("+ Ekle", Color.FromArgb(0, 130, 70), new Point(15, 195), new Size(230, 38));
            btnOyunGuncelle = OlusturButon("Güncelle", Color.FromArgb(0, 100, 180), new Point(15, 245), new Size(230, 38));
            btnOyunSil = OlusturButon("Sil", Color.FromArgb(190, 30, 30), new Point(15, 295), new Size(230, 38));

            Label lblSecili = new Label();
            lblSecili.Name = "lblOyunSecili";
            lblSecili.Text = "Seçili: —";
            lblSecili.Font = new Font("Segoe UI", 8, FontStyle.Italic);
            lblSecili.ForeColor = Color.Gray;
            lblSecili.Location = new Point(15, 350);
            lblSecili.Size = new Size(230, 20);

            pnlForm.Controls.Add(lblFormBaslik);
            pnlForm.Controls.Add(lblOyunAdi);
            pnlForm.Controls.Add(txtOyunAdi);
            pnlForm.Controls.Add(lblSure);
            pnlForm.Controls.Add(txtSure);
            pnlForm.Controls.Add(btnOyunEkle);
            pnlForm.Controls.Add(btnOyunGuncelle);
            pnlForm.Controls.Add(btnOyunSil);
            pnlForm.Controls.Add(lblSecili);

            dgvOyunlar = OlusturDataGridView(new Point(285, 10), new Size(615, 460));
            dgvOyunlar.Columns.Add("ID", "ID");
            dgvOyunlar.Columns.Add("OyunAdi", "Oyun Adı");
            dgvOyunlar.Columns.Add("Sure", "Süre (dk)");
            dgvOyunlar.Columns["ID"].Width = 40;
            dgvOyunlar.Columns["OyunAdi"].Width = 280;
            dgvOyunlar.Columns["Sure"].Width = 100;

            dgvOyunlar.Rows.Add(1, "Hamlet", 180);
            dgvOyunlar.Rows.Add(2, "Macbeth", 160);
            dgvOyunlar.Rows.Add(3, "Romeo ve Juliet", 150);
            dgvOyunlar.Rows.Add(4, "Othello", 170);

            btnOyunEkle.Click += BtnOyunEkle_Click;
            btnOyunGuncelle.Click += BtnOyunGuncelle_Click;
            btnOyunSil.Click += BtnOyunSil_Click;
            dgvOyunlar.SelectionChanged += dgvOyunlar_SelectionChanged;

            tabOyunlar.Controls.Add(pnlForm);
            tabOyunlar.Controls.Add(dgvOyunlar);
        }

        private void dgvOyunlar_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOyunlar.SelectedRows.Count == 0) return;
            seciliOyunIndex = dgvOyunlar.SelectedRows[0].Index;
            var row = dgvOyunlar.SelectedRows[0];
            txtOyunAdi.Text = row.Cells["OyunAdi"].Value?.ToString();
            txtSure.Text = row.Cells["Sure"].Value?.ToString();
            var lbl = tabOyunlar.Controls.Find("lblOyunSecili", true);
            if (lbl.Length > 0) lbl[0].Text = "Seçili: " + txtOyunAdi.Text;
        }

        private void BtnOyunEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOyunAdi.Text) || string.IsNullOrWhiteSpace(txtSure.Text))
            { MessageBox.Show("Oyun adı ve süre boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            int yeniId = dgvOyunlar.Rows.Count + 1;
            dgvOyunlar.Rows.Add(yeniId, txtOyunAdi.Text.Trim(), txtSure.Text.Trim());
            OyunComboGuncelle();
            txtOyunAdi.Clear(); txtSure.Clear();
            MessageBox.Show("Oyun eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnOyunGuncelle_Click(object sender, EventArgs e)
        {
            if (seciliOyunIndex < 0) { MessageBox.Show("Güncellenecek oyunu seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (string.IsNullOrWhiteSpace(txtOyunAdi.Text)) { MessageBox.Show("Oyun adı boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            dgvOyunlar.Rows[seciliOyunIndex].Cells["OyunAdi"].Value = txtOyunAdi.Text.Trim();
            dgvOyunlar.Rows[seciliOyunIndex].Cells["Sure"].Value = txtSure.Text.Trim();
            OyunComboGuncelle();
            MessageBox.Show("Oyun güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnOyunSil_Click(object sender, EventArgs e)
        {
            if (seciliOyunIndex < 0) { MessageBox.Show("Silinecek oyunu seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            string oyunAdi = dgvOyunlar.Rows[seciliOyunIndex].Cells["OyunAdi"].Value?.ToString();
            var onay = MessageBox.Show($"'{oyunAdi}' silinsin mi?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (onay != DialogResult.Yes) return;
            dgvOyunlar.Rows.RemoveAt(seciliOyunIndex);
            seciliOyunIndex = -1;
            txtOyunAdi.Clear(); txtSure.Clear();
            OyunComboGuncelle();
            MessageBox.Show("Oyun silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

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
            lblOyun.ForeColor = Color.FromArgb(80, 80, 80);
            lblOyun.Location = new Point(15, 55);
            lblOyun.AutoSize = true;

            cmbOyunSec = new ComboBox();
            cmbOyunSec.Location = new Point(15, 75);
            cmbOyunSec.Size = new Size(230, 28);
            cmbOyunSec.Font = new Font("Segoe UI", 10);
            cmbOyunSec.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOyunSec.Items.AddRange(new object[] { "Hamlet", "Macbeth", "Romeo ve Juliet", "Othello" });

            Label lblTarih = new Label();
            lblTarih.Text = "Tarih:";
            lblTarih.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblTarih.ForeColor = Color.FromArgb(80, 80, 80);
            lblTarih.Location = new Point(15, 120);
            lblTarih.AutoSize = true;

            dtpTarih = new DateTimePicker();
            dtpTarih.Location = new Point(15, 140);
            dtpTarih.Size = new Size(230, 28);
            dtpTarih.Font = new Font("Segoe UI", 10);
            dtpTarih.Format = DateTimePickerFormat.Short;

            Label lblSaat = new Label();
            lblSaat.Text = "Saat:";
            lblSaat.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblSaat.ForeColor = Color.FromArgb(80, 80, 80);
            lblSaat.Location = new Point(15, 185);
            lblSaat.AutoSize = true;

            dtpSaat = new DateTimePicker();
            dtpSaat.Location = new Point(15, 205);
            dtpSaat.Size = new Size(230, 28);
            dtpSaat.Font = new Font("Segoe UI", 10);
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

            dgvSeanslar.Rows.Add(1, "Hamlet", "15.06.2026", "20:00");
            dgvSeanslar.Rows.Add(2, "Hamlet", "20.06.2026", "19:30");
            dgvSeanslar.Rows.Add(3, "Macbeth", "18.06.2026", "20:00");
            dgvSeanslar.Rows.Add(4, "Romeo ve Juliet", "22.06.2026", "18:00");

            btnSeansEkle.Click += BtnSeansEkle_Click;
            btnSeansTarihGuncelle.Click += BtnSeansTarihGuncelle_Click;
            btnSeansSil.Click += BtnSeansSil_Click;
            dgvSeanslar.SelectionChanged += (s, e) =>
            {
                if (dgvSeanslar.SelectedRows.Count > 0)
                    seciliSeansIndex = dgvSeanslar.SelectedRows[0].Index;
            };

            tabSeanslar.Controls.Add(pnlForm);
            tabSeanslar.Controls.Add(dgvSeanslar);
        }

        private void BtnSeansEkle_Click(object sender, EventArgs e)
        {
            if (cmbOyunSec.SelectedIndex < 0) { MessageBox.Show("Oyun seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            int yeniId = dgvSeanslar.Rows.Count + 1;
            dgvSeanslar.Rows.Add(yeniId, cmbOyunSec.SelectedItem.ToString(),
                dtpTarih.Value.ToString("dd.MM.yyyy"), dtpSaat.Value.ToString("HH:mm"));
            MessageBox.Show("Seans eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSeansTarihGuncelle_Click(object sender, EventArgs e)
        {
            if (seciliSeansIndex < 0) { MessageBox.Show("Güncellenecek seansı seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            dgvSeanslar.Rows[seciliSeansIndex].Cells["Tarih"].Value = dtpTarih.Value.ToString("dd.MM.yyyy");
            dgvSeanslar.Rows[seciliSeansIndex].Cells["Saat"].Value = dtpSaat.Value.ToString("HH:mm");
            MessageBox.Show("Seans güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSeansSil_Click(object sender, EventArgs e)
        {
            if (seciliSeansIndex < 0) { MessageBox.Show("Silinecek seansı seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            var onay = MessageBox.Show("Bu seans silinsin mi?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (onay != DialogResult.Yes) return;
            dgvSeanslar.Rows.RemoveAt(seciliSeansIndex);
            seciliSeansIndex = -1;
            MessageBox.Show("Seans silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

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

            dgvKullanicilar.Rows.Add(1, "Ahmet Yılmaz", "ahmet@mail.com");
            dgvKullanicilar.Rows.Add(2, "Ayşe Demir", "ayse@mail.com");
            dgvKullanicilar.Rows.Add(3, "Mehmet Kaya", "mehmet@mail.com");
            dgvKullanicilar.Rows.Add(4, "Fatma Çelik", "fatma@mail.com");

            btnKullaniciSil.Click += BtnKullaniciSil_Click;

            tabKullanicilar.Controls.Add(pnlToolbar);
            tabKullanicilar.Controls.Add(dgvKullanicilar);
        }

        private void BtnKullaniciSil_Click(object sender, EventArgs e)
        {
            if (dgvKullanicilar.SelectedRows.Count == 0) { MessageBox.Show("Silinecek kullanıcıyı seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            string ad = dgvKullanicilar.SelectedRows[0].Cells["AdSoyad"].Value?.ToString();
            var onay = MessageBox.Show($"'{ad}' silinsin mi?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (onay != DialogResult.Yes) return;
            dgvKullanicilar.Rows.Remove(dgvKullanicilar.SelectedRows[0]);
            MessageBox.Show("Kullanıcı silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

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

            dgvRezervasyonlar.Rows.Add(1, "Ahmet Yılmaz", "Hamlet", "15.06.2026 - 20:00", "A1");
            dgvRezervasyonlar.Rows.Add(2, "Ayşe Demir", "Hamlet", "15.06.2026 - 20:00", "A2");
            dgvRezervasyonlar.Rows.Add(3, "Mehmet Kaya", "Macbeth", "18.06.2026 - 20:00", "B5");
            dgvRezervasyonlar.Rows.Add(4, "Fatma Çelik", "Romeo ve Juliet", "22.06.2026 - 18:00", "C3");

            tabRezervasyonlar.Controls.Add(lblBaslik);
            tabRezervasyonlar.Controls.Add(dgvRezervasyonlar);
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

        private void OyunComboGuncelle()
        {
            cmbOyunSec.Items.Clear();
            foreach (DataGridViewRow row in dgvOyunlar.Rows)
            {
                if (row.Cells["OyunAdi"].Value != null)
                    cmbOyunSec.Items.Add(row.Cells["OyunAdi"].Value.ToString());
            }
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            // Eğer Admin_Login'i parametresiz yaptıysak bu kullanım doğrudur
            Admin_Login login = new Admin_Login();
            login.Show();
            this.Close();
        }

        private void Admin_Page_Load(object sender, EventArgs e)
        {

        }
    }
}
