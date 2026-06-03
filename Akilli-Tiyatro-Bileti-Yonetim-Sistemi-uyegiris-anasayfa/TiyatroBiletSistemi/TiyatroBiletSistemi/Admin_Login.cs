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
    public partial class Admin_Login : Form
    {

        private Panel pnlSol;
        private Panel pnlSag;
        private Label lblIkon;
        private Label lblBaslik;
        private Label lblAltBaslik;
        private Label lblBaslikSag;
        private Label lblAltBaslikSag;
        private Label lblKullanici;
        private Label lblSifre;
        private TextBox txtKullanici;
        private TextBox txtSifre;
        private Button btnGiris;
        private Label lblHata;
        public Admin_Login()
        {
            InitializeComponent();
            FormuOlustur(); ;
        }

        private void FormuOlustur()
        {
            this.Text = "Yönetici Girişi";
            this.Size = new Size(700, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;

            // Sol kırmızı panel
            pnlSol = new Panel();
            pnlSol.Size = new Size(280, 450);
            pnlSol.Location = new Point(0, 0);
            pnlSol.BackColor = Color.FromArgb(139, 0, 0); // Koyu kırmızı

            lblIkon = new Label();
            lblIkon.Text = "🎭";
            lblIkon.Font = new Font("Segoe UI", 36);
            lblIkon.ForeColor = Color.White;
            lblIkon.Size = new Size(280, 70);
            lblIkon.Location = new Point(0, 100);
            lblIkon.TextAlign = ContentAlignment.MiddleCenter;

            lblBaslik = new Label();
            lblBaslik.Text = "Tiyatro Bileti\nYönetim Sistemi";
            lblBaslik.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblBaslik.ForeColor = Color.White;
            lblBaslik.Size = new Size(260, 60);
            lblBaslik.Location = new Point(10, 185);
            lblBaslik.TextAlign = ContentAlignment.MiddleCenter;

            lblAltBaslik = new Label();
            lblAltBaslik.Text = "Yönetici paneline erişmek için\nlütfen giriş yapınız.";
            lblAltBaslik.Font = new Font("Segoe UI", 9);
            lblAltBaslik.ForeColor = Color.FromArgb(255, 180, 180); // Açık kırmızı
            lblAltBaslik.Size = new Size(260, 50);
            lblAltBaslik.Location = new Point(10, 255);
            lblAltBaslik.TextAlign = ContentAlignment.MiddleCenter;

            pnlSol.Controls.Add(lblIkon);
            pnlSol.Controls.Add(lblBaslik);
            pnlSol.Controls.Add(lblAltBaslik);

            // Sağ açık panel
            pnlSag = new Panel();
            pnlSag.Size = new Size(420, 450);
            pnlSag.Location = new Point(280, 0);
            pnlSag.BackColor = Color.FromArgb(245, 245, 245); // Açık gri/beyaz

            lblBaslikSag = new Label();
            lblBaslikSag.Text = "Yönetici Girişi";
            lblBaslikSag.Font = new Font("Segoe UI", 15, FontStyle.Bold);
            lblBaslikSag.ForeColor = Color.FromArgb(139, 0, 0); // Kırmızı başlık
            lblBaslikSag.Size = new Size(360, 35);
            lblBaslikSag.Location = new Point(30, 60);

            lblAltBaslikSag = new Label();
            lblAltBaslikSag.Text = "Devam etmek için bilgilerinizi giriniz";
            lblAltBaslikSag.Font = new Font("Segoe UI", 9);
            lblAltBaslikSag.ForeColor = Color.FromArgb(150, 100, 100); // Kırmızımsı gri
            lblAltBaslikSag.Size = new Size(360, 25);
            lblAltBaslikSag.Location = new Point(30, 98);

            lblKullanici = new Label();
            lblKullanici.Text = "KULLANICI ADI";
            lblKullanici.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            lblKullanici.ForeColor = Color.FromArgb(139, 0, 0); // Kırmızı
            lblKullanici.Location = new Point(30, 150);
            lblKullanici.Size = new Size(360, 20);

            txtKullanici = new TextBox();
            txtKullanici.Location = new Point(30, 173);
            txtKullanici.Size = new Size(360, 32);
            txtKullanici.Font = new Font("Segoe UI", 11);
            txtKullanici.BorderStyle = BorderStyle.FixedSingle;
            txtKullanici.BackColor = Color.White;
            txtKullanici.ForeColor = Color.FromArgb(40, 35, 80);

            lblSifre = new Label();
            lblSifre.Text = "ŞİFRE";
            lblSifre.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            lblSifre.ForeColor = Color.FromArgb(139, 0, 0); // Kırmızı
            lblSifre.Location = new Point(30, 220);
            lblSifre.Size = new Size(360, 20);

            txtSifre = new TextBox();
            txtSifre.Location = new Point(30, 243);
            txtSifre.Size = new Size(360, 32);
            txtSifre.Font = new Font("Segoe UI", 11);
            txtSifre.PasswordChar = '*';
            txtSifre.BorderStyle = BorderStyle.FixedSingle;
            txtSifre.BackColor = Color.White;
            txtSifre.ForeColor = Color.FromArgb(40, 35, 80);

            lblHata = new Label();
            lblHata.Text = "";
            lblHata.ForeColor = Color.FromArgb(220, 80, 80);
            lblHata.Font = new Font("Segoe UI", 9);
            lblHata.Location = new Point(30, 285);
            lblHata.Size = new Size(360, 22);

            btnGiris = new Button();
            btnGiris.Text = "Giriş Yap";
            btnGiris.Location = new Point(30, 315);
            btnGiris.Size = new Size(360, 42);
            btnGiris.BackColor = Color.FromArgb(139, 0, 0); // Kırmızı buton
            btnGiris.ForeColor = Color.White;
            btnGiris.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnGiris.FlatStyle = FlatStyle.Flat;
            btnGiris.FlatAppearance.BorderSize = 0;
            btnGiris.Cursor = Cursors.Hand;
            btnGiris.Click += BtnGiris_Click;

            btnGiris.MouseEnter += (s, e) => btnGiris.BackColor = Color.FromArgb(180, 0, 0); // Hover: daha açık kırmızı
            btnGiris.MouseLeave += (s, e) => btnGiris.BackColor = Color.FromArgb(139, 0, 0); // Normal: koyu kırmızı

            pnlSag.Controls.Add(lblBaslikSag);
            pnlSag.Controls.Add(lblAltBaslikSag);
            pnlSag.Controls.Add(lblKullanici);
            pnlSag.Controls.Add(txtKullanici);
            pnlSag.Controls.Add(lblSifre);
            pnlSag.Controls.Add(txtSifre);
            pnlSag.Controls.Add(lblHata);
            pnlSag.Controls.Add(btnGiris);

            Button btnCikis = new Button();
            btnCikis.Text = "Ana Sayfaya Dön";
            btnCikis.Location = new Point(30, 365);
            btnCikis.Size = new Size(360, 35);
            btnCikis.BackColor = Color.FromArgb(245, 245, 245);
            btnCikis.ForeColor = Color.FromArgb(139, 0, 0);
            btnCikis.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnCikis.FlatStyle = FlatStyle.Flat;
            btnCikis.FlatAppearance.BorderColor = Color.FromArgb(139, 0, 0);
            btnCikis.Cursor = Cursors.Hand;
            btnCikis.Click += btnCikis_Click;

            pnlSag.Controls.Add(btnCikis);

            this.Controls.Add(pnlSol);
            this.Controls.Add(pnlSag);
        }
        private void BtnGiris_Click(object sender, EventArgs e)
        {
            string kullanici = txtKullanici.Text.Trim();
            string sifre = txtSifre.Text;

            if (kullanici == "admin1" && sifre == "1234")
            {
                Admin_Page panel = new Admin_Page(kullanici);
                panel.Show();
                this.Hide();
            }
            else
            {
                lblHata.Text = "Kullanıcı adı veya şifre hatalı!";
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            // Tüm açık formları kontrol et, Anasayfa'yı göster
            foreach (Form f in Application.OpenForms)
            {
                if (f is Anasayfa)
                {
                    f.Show();
                    break;
                }
            }
            this.Close();
        }
    }
}
