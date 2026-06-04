using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TiyatroBiletSistemi
{
    public partial class Odeme : Form
    {
        string oyunAdi;
        string koltuk;

        public Odeme(string oyunAdi, string koltuk)
        {
            InitializeComponent();
            this.oyunAdi = oyunAdi;
            this.koltuk = koltuk;
        }

        private void Odeme_Load(object sender, EventArgs e)
        {
            lblBilgi.Text = $"Oyun: {oyunAdi}  |  Koltuk: {koltuk}";
        }

        private void btnOde_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKartNo.Text) ||
                string.IsNullOrWhiteSpace(txtIsim.Text) ||
                string.IsNullOrWhiteSpace(txtSKT.Text) ||
                string.IsNullOrWhiteSpace(txtCVV.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz!");
                return;
            }

            if (txtKartNo.Text.Length != 16)
            {
                MessageBox.Show("Kart numarası 16 haneli olmalıdır!");
                return;
            }

            try
            {
                var conn = VeriTabani.BaglantiAl();
                conn.Open();

                // Oyun id'sini bul
                string oyunSorgu = "SELECT id FROM oyunlar WHERE oyun_adi = @oyunAdi";
                var oyunCmd = new MySqlCommand(oyunSorgu, conn);
                oyunCmd.Parameters.AddWithValue("@oyunAdi", oyunAdi);
                var oyunId = oyunCmd.ExecuteScalar();

                if (oyunId == null)
                {
                    MessageBox.Show("Oyun bulunamadı!");
                    conn.Close();
                    return;
                }

                // İlk uygun seansı bul
                string seansSorgu = "SELECT id FROM seanslar WHERE oyun_id = @oyunId LIMIT 1";
                var seansCmd = new MySqlCommand(seansSorgu, conn);
                seansCmd.Parameters.AddWithValue("@oyunId", oyunId);
                var seansId = seansCmd.ExecuteScalar();

                if (seansId == null)
                {
                    MessageBox.Show("Seans bulunamadı!");
                    conn.Close();
                    return;
                }

                // Rezervasyonu ekle (kullanici_id şimdilik 1, giriş sistemi entegre edilince güncellenecek)
                string rezervasyonSorgu = @"INSERT INTO rezervasyonlar 
                    (kullanici_id, seans_id, koltuk_no, durum) 
                    VALUES (@kullaniciId, @seansId, @koltuk, @durum)";
                var rezervasyonCmd = new MySqlCommand(rezervasyonSorgu, conn);
                rezervasyonCmd.Parameters.AddWithValue("@kullaniciId", 1);
                rezervasyonCmd.Parameters.AddWithValue("@seansId", seansId);
                rezervasyonCmd.Parameters.AddWithValue("@koltuk", koltuk);
                rezervasyonCmd.Parameters.AddWithValue("@durum", "onaylandi");
                rezervasyonCmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show($"Ödeme başarılı!\n{oyunAdi} - Koltuk {koltuk}\nRezervasyonunuz oluşturuldu!\nİyi seyirler!");
                Anasayfa frm = new Anasayfa();
                frm.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
    }
}