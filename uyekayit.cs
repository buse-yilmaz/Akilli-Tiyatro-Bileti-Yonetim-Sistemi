using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TiyatroBiletSistemi
{
    public partial class uyekayit : Form
    {
        public uyekayit()
        {
            InitializeComponent();
        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            // 1. Boş alan kontrolü
            if (string.IsNullOrWhiteSpace(txtAdSoyad.Text) ||
                string.IsNullOrWhiteSpace(txtEposta.Text) ||
                string.IsNullOrWhiteSpace(txtSifre.Text) ||
                string.IsNullOrWhiteSpace(mtxtTelefonNumarasi.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz!", "Uyarı");
                return;
            }

            // 2. E-posta kontrolü
            string desen = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(txtEposta.Text, desen))
            {
                MessageBox.Show("Lütfen geçerli bir e-posta adresi giriniz!", "Geçersiz E-posta");
                txtEposta.Focus();
                return;
            }

            // 3. Şifre kontrolü
            if (txtSifre.Text.Length < 6)
            {
                MessageBox.Show("Şifreniz en az 6 karakter olmalıdır!", "Güvenlik");
                return;
            }

            // 4. Veritabanına kaydet
            try
            {
                var conn = VeriTabani.BaglantiAl();
                conn.Open();

                string sorgu = "INSERT INTO kullanicilar (ad_soyad, email, sifre, rol) VALUES (@ad, @email, @sifre, @rol)";
                var cmd = new MySqlCommand(sorgu, conn);
                cmd.Parameters.AddWithValue("@ad", txtAdSoyad.Text);
                cmd.Parameters.AddWithValue("@email", txtEposta.Text);
                cmd.Parameters.AddWithValue("@sifre", txtSifre.Text);
                cmd.Parameters.AddWithValue("@rol", "kullanici");
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show($"Sayın {txtAdSoyad.Text}, kaydınız başarıyla oluşturuldu!");
                FrmGiris frm = new FrmGiris();
                frm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmGiris frm = new FrmGiris();
            frm.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtSifre.PasswordChar = '*';
        }

        private void mtxtTelefonNumarasi_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) { }

        private void checkBoxSifreGoster_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSifreGoster.Checked)
            {
                txtSifre.UseSystemPasswordChar = false;
                txtSifre.PasswordChar = '\0';
            }
            else
            {
                txtSifre.PasswordChar = '*';
            }
        }
    }
}