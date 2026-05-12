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
           
        
            if (txtEposta.Text == "kullanici@gmail.com" &&
               txtSifre.Text == "12345")
            {
                MessageBox.Show("Giriş Başarılı");

                Anasayfa frm = new Anasayfa();
                frm.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("E-Posta veya Şifre Hatalı");
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
    }
}
