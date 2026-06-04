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
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnGiris_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtEposta.Text) || string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                MessageBox.Show("Lütfen e-posta ve şifre giriniz!");
                return;
            }

            try
            {
                var conn = VeriTabani.BaglantiAl();
                conn.Open();

                string sorgu = "SELECT ad_soyad FROM kullanicilar WHERE email=@email AND sifre=@sifre";
                var cmd = new MySql.Data.MySqlClient.MySqlCommand(sorgu, conn);
                cmd.Parameters.AddWithValue("@email", txtEposta.Text);
                cmd.Parameters.AddWithValue("@sifre", txtSifre.Text);

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string adSoyad = reader["ad_soyad"].ToString();
                    conn.Close();
                    MessageBox.Show($"Hoş geldin, {adSoyad}!");
                    Anasayfa frm = new Anasayfa();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    conn.Close();
                    MessageBox.Show("E-Posta veya Şifre Hatalı!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
        

        private void textEposta_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkGoster_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGoster.Checked)
            {
                txtSifre.UseSystemPasswordChar = false;
            }
            else
            {
                txtSifre.UseSystemPasswordChar = true;
            }
        }

        private void btnGiris_MouseHover(object sender, EventArgs e)
        {
            btnGiris.BackColor = Color.LightBlue;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void linkUyeOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            uyekayit frm = new uyekayit();
            frm.Show();
            this.Hide();
        }
    }
}
