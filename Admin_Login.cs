using System;
using System.Drawing;
using System.Windows.Forms;

namespace TiyatroBiletiYonetimSistemi
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
            FormuOlustur();
        }

        private void FormuOlustur()
        {
            this.Text = "Admin Girişi";
            this.Size = new Size(700, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Sizable; 
            this.MaximizeBox = true;
            // Sol mor panel
            pnlSol = new Panel();
            pnlSol.Size = new Size(280, 450);
            pnlSol.Location = new Point(0, 0);
            pnlSol.BackColor = Color.FromArgb(83, 74, 183);

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
            lblAltBaslik.Text = "Admin paneline erişmek için\nlütfen giriş yapınız.";
            lblAltBaslik.Font = new Font("Segoe UI", 9);
            lblAltBaslik.ForeColor = Color.FromArgb(200, 195, 240);
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
            pnlSag.BackColor = Color.FromArgb(245, 243, 255);

            lblBaslikSag = new Label();
            lblBaslikSag.Text = "Admin Girişi";
            lblBaslikSag.Font = new Font("Segoe UI", 15, FontStyle.Bold);
            lblBaslikSag.ForeColor = Color.FromArgb(40, 35, 80);
            lblBaslikSag.Size = new Size(360, 35);
            lblBaslikSag.Location = new Point(30, 60);

            lblAltBaslikSag = new Label();
            lblAltBaslikSag.Text = "Devam etmek için kimlik bilgilerinizi giriniz";
            lblAltBaslikSag.Font = new Font("Segoe UI", 9);
            lblAltBaslikSag.ForeColor = Color.FromArgb(150, 145, 180);
            lblAltBaslikSag.Size = new Size(360, 25);
            lblAltBaslikSag.Location = new Point(30, 98);

            lblKullanici = new Label();
            lblKullanici.Text = "KULLANICI ADI";
            lblKullanici.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            lblKullanici.ForeColor = Color.FromArgb(150, 145, 180);
            lblKullanici.Location = new Point(30, 150);
            lblKullanici.Size = new Size(360, 20);

            txtKullanici = new TextBox();
            txtKullanici.Location = new Point(30, 173);
            txtKullanici.Size = new Size(360, 32);
            txtKullanici.Font = new Font("Segoe UI", 11);
            txtKullanici.BorderStyle = BorderStyle.FixedSingle;
            txtKullanici.BackColor = Color.FromArgb(235, 233, 255);
            txtKullanici.ForeColor = Color.FromArgb(40, 35, 80);

            lblSifre = new Label();
            lblSifre.Text = "ŞİFRE";
            lblSifre.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            lblSifre.ForeColor = Color.FromArgb(150, 145, 180);
            lblSifre.Location = new Point(30, 220);
            lblSifre.Size = new Size(360, 20);

            txtSifre = new TextBox();
            txtSifre.Location = new Point(30, 243);
            txtSifre.Size = new Size(360, 32);
            txtSifre.Font = new Font("Segoe UI", 11);
            txtSifre.PasswordChar = '*';
            txtSifre.BorderStyle = BorderStyle.FixedSingle;
            txtSifre.BackColor = Color.FromArgb(235, 233, 255);
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
            btnGiris.BackColor = Color.FromArgb(83, 74, 183);
            btnGiris.ForeColor = Color.White;
            btnGiris.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnGiris.FlatStyle = FlatStyle.Flat;
            btnGiris.FlatAppearance.BorderSize = 0;
            btnGiris.Cursor = Cursors.Hand;
            btnGiris.Click += BtnGiris_Click;

            btnGiris.MouseEnter += (s, e) => btnGiris.BackColor = Color.FromArgb(127, 119, 221);
            btnGiris.MouseLeave += (s, e) => btnGiris.BackColor = Color.FromArgb(83, 74, 183);

            pnlSag.Controls.Add(lblBaslikSag);
            pnlSag.Controls.Add(lblAltBaslikSag);
            pnlSag.Controls.Add(lblKullanici);
            pnlSag.Controls.Add(txtKullanici);
            pnlSag.Controls.Add(lblSifre);
            pnlSag.Controls.Add(txtSifre);
            pnlSag.Controls.Add(lblHata);
            pnlSag.Controls.Add(btnGiris);

            this.Controls.Add(pnlSol);
            this.Controls.Add(pnlSag);
        }

        private void BtnGiris_Click(object sender, EventArgs e)
        {
            string kullanici = txtKullanici.Text.Trim();
            string sifre = txtSifre.Text;

            if (kullanici == "admin" && sifre == "1234")
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
    }
}