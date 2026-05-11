using System;
using System.Drawing;
using System.Windows.Forms;

namespace TiyatroBiletiYonetimSistemi
{
    public partial class Admin_Page : Form
    {
        private Panel pnlUst;
        private Panel pnlIcerik;
        private Label lblLogo;
        private Label lblBaslik;
        private Label lblHosgeldın;
        private Label lblAltYazi;
        private Button btnCikis;
        private string adminAdi;

        public Admin_Page(string adminAdi)
        {
            this.adminAdi = adminAdi;
            InitializeComponent();
            FormuOlustur();
        }

        private void FormuOlustur()
        {
            this.Text = "Admin Paneli";
            this.Size = new Size(700, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(245, 245, 245);

            // Üst panel
            pnlUst = new Panel();
            pnlUst.Size = new Size(700, 65);
            pnlUst.Location = new Point(0, 0);
            pnlUst.BackColor = Color.FromArgb(139, 0, 0);

            lblLogo = new Label();
            lblLogo.Text = "🎭 Tiyatro Bileti Yönetim Sistemi";
            lblLogo.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(20, 18);
            lblLogo.Size = new Size(400, 30);

            btnCikis = new Button();
            btnCikis.Text = "Çıkış Yap";
            btnCikis.Location = new Point(580, 15);
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

            // İçerik paneli
            pnlIcerik = new Panel();
            pnlIcerik.Size = new Size(620, 120);
            pnlIcerik.Location = new Point(40, 110);
            pnlIcerik.BackColor = Color.FromArgb(139, 0, 0);

            lblHosgeldın = new Label();
            lblHosgeldın.Text = "Hoş Geldiniz, " + adminAdi + "!";
            lblHosgeldın.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblHosgeldın.ForeColor = Color.White;
            lblHosgeldın.Location = new Point(30, 20);
            lblHosgeldın.Size = new Size(560, 40);

            lblAltYazi = new Label();
            lblAltYazi.Text = "Sisteme başarıyla giriş yaptınız. Yönetim paneline erişebilirsiniz.";
            lblAltYazi.Font = new Font("Segoe UI", 9);
            lblAltYazi.ForeColor = Color.FromArgb(255, 180, 180);
            lblAltYazi.Location = new Point(30, 65);
            lblAltYazi.Size = new Size(560, 25);

            pnlIcerik.Controls.Add(lblHosgeldın);
            pnlIcerik.Controls.Add(lblAltYazi);

            this.Controls.Add(pnlUst);
            this.Controls.Add(pnlIcerik);
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            Admin_Login login = new Admin_Login();
            login.Show();
            this.Close();
        }
    }
}
