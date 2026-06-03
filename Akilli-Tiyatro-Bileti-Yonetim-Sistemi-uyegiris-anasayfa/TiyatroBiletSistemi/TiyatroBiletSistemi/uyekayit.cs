using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            // 1. Alanların boş olup olmadığını kontrol et
            if (string.IsNullOrWhiteSpace(txtAdSoyad.Text) ||
                string.IsNullOrWhiteSpace(txtEposta.Text) ||
                string.IsNullOrWhiteSpace(txtSifre.Text) ||
                string.IsNullOrWhiteSpace(mtxtTelefonNumarasi.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz!", "Uyarı");
                return;
            }
            MessageBox.Show($"Sayın {txtAdSoyad.Text}, kaydınız başarıyla oluşturuldu!");
            FrmGiris frm = new FrmGiris();
            frm.Show();
            this.Hide();

            // 2. E-posta Format Kontrolü (Regex)
            string desen = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(txtEposta.Text, desen))
            {
                MessageBox.Show("Lütfen geçerli bir e-posta adresi giriniz!", "Geçersiz E-posta");
                txtEposta.Focus();
                return;
            }

            // 3. Şifre Uzunluk Kontrolü
            if (txtSifre.Text.Length < 6)
            {
                MessageBox.Show("Şifreniz en az 6 karakter olmalıdır!", "Güvenlik");
                return;
            }

            // 4. Her şey doğruysa kayıt başarılı
            MessageBox.Show($"Sayın {txtAdSoyad.Text}, kaydınız başarıyla oluşturuldu!");

            // Arkadaşının Giriş Formu hazır olduğunda burayı açabilirsin:
            // GirisForm giris = new GirisForm();
            // giris.Show();
            // this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmGiris frm = new FrmGiris();
            frm.Show();
            this.Hide();
        }

        // Aşağıdaki metotlar tasarım hatası almanı engellemek için sadece 1 kez bulunmalı:
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
                // Kutucuk işaretliyse şifre karakterini kaldır (Şifreyi GÖSTER)
                txtSifre.UseSystemPasswordChar = false;
                txtSifre.PasswordChar = '\0';
            }
            else
            {
                // İşaretli değilse şifreyi gizle (Yıldız yap)
                txtSifre.PasswordChar = '*';
            }
        }
    }
}
