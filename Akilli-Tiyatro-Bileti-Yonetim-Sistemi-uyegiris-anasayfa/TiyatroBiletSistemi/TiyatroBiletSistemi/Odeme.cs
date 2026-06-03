using System;
using System.Drawing;
using System.Windows.Forms;

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

            MessageBox.Show($"Ödeme başarılı!\n{oyunAdi} - Koltuk {koltuk}\nİyi seyirler!");
            this.Close();
        }
    }
}