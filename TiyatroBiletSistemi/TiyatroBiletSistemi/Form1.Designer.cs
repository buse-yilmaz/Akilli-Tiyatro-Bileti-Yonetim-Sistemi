namespace TiyatroBiletSistemi
{
    partial class FrmGiris
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGiris = new System.Windows.Forms.Button();
            this.linkUyeOl = new System.Windows.Forms.LinkLabel();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.txtEposta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkGoster = new System.Windows.Forms.CheckBox();
            this.panelSol = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelSol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGiris
            // 
            this.btnGiris.BackColor = System.Drawing.Color.DarkRed;
            this.btnGiris.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGiris.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGiris.ForeColor = System.Drawing.Color.White;
            this.btnGiris.Location = new System.Drawing.Point(419, 281);
            this.btnGiris.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGiris.Name = "btnGiris";
            this.btnGiris.Size = new System.Drawing.Size(251, 28);
            this.btnGiris.TabIndex = 0;
            this.btnGiris.Text = "Giriş Yap";
            this.btnGiris.UseVisualStyleBackColor = false;
            this.btnGiris.Click += new System.EventHandler(this.btnGiris_Click);
            this.btnGiris.MouseHover += new System.EventHandler(this.btnGiris_MouseHover);
            // 
            // linkUyeOl
            // 
            this.linkUyeOl.AutoSize = true;
            this.linkUyeOl.LinkColor = System.Drawing.Color.MediumSlateBlue;
            this.linkUyeOl.Location = new System.Drawing.Point(415, 337);
            this.linkUyeOl.Name = "linkUyeOl";
            this.linkUyeOl.Size = new System.Drawing.Size(163, 16);
            this.linkUyeOl.TabIndex = 1;
            this.linkUyeOl.TabStop = true;
            this.linkUyeOl.Text = "Hesabınız yoksa üye olun.";
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(419, 207);
            this.txtSifre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Size = new System.Drawing.Size(249, 22);
            this.txtSifre.TabIndex = 2;
            this.txtSifre.UseSystemPasswordChar = true;
            // 
            // txtEposta
            // 
            this.txtEposta.Location = new System.Drawing.Point(419, 148);
            this.txtEposta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEposta.Name = "txtEposta";
            this.txtEposta.Size = new System.Drawing.Size(249, 22);
            this.txtEposta.TabIndex = 3;
            this.txtEposta.TextChanged += new System.EventHandler(this.textEposta_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(415, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "E_posta";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(415, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Şifre";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // chkGoster
            // 
            this.chkGoster.AutoSize = true;
            this.chkGoster.ForeColor = System.Drawing.Color.Gray;
            this.chkGoster.Location = new System.Drawing.Point(419, 235);
            this.chkGoster.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkGoster.Name = "chkGoster";
            this.chkGoster.Size = new System.Drawing.Size(109, 20);
            this.chkGoster.TabIndex = 6;
            this.chkGoster.Text = "Şifreyi Göster";
            this.chkGoster.UseVisualStyleBackColor = true;
            this.chkGoster.CheckedChanged += new System.EventHandler(this.checkGoster_CheckedChanged);
            // 
            // panelSol
            // 
            this.panelSol.BackColor = System.Drawing.Color.DarkRed;
            this.panelSol.Controls.Add(this.label4);
            this.panelSol.Controls.Add(this.label3);
            this.panelSol.Controls.Add(this.pictureBox2);
            this.panelSol.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSol.Location = new System.Drawing.Point(0, 0);
            this.panelSol.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelSol.Name = "panelSol";
            this.panelSol.Size = new System.Drawing.Size(349, 453);
            this.panelSol.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(12, 281);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(317, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tiyatro sistemine giriş yapmak için bilgilerinizi giriniz.\r\n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Cornsilk;
            this.label3.Location = new System.Drawing.Point(27, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(293, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tiyatro Bileti Yönetim Sistemi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(413, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "Kullanıcı Girişi";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::TiyatroBiletSistemi.Properties.Resources.pngwing_com;
            this.pictureBox2.Location = new System.Drawing.Point(96, 148);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(145, 89);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // FrmGiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(832, 453);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panelSol);
            this.Controls.Add(this.chkGoster);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEposta);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.linkUyeOl);
            this.Controls.Add(this.btnGiris);
            this.ForeColor = System.Drawing.Color.MidnightBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmGiris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kullanıcı Giriş";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelSol.ResumeLayout(false);
            this.panelSol.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGiris;
        private System.Windows.Forms.LinkLabel linkUyeOl;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.TextBox txtEposta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkGoster;
        private System.Windows.Forms.Panel panelSol;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

