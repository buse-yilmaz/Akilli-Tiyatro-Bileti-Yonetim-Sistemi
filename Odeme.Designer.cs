namespace TiyatroBiletSistemi
{
    partial class Odeme
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
        {
            this.panelUst = new System.Windows.Forms.Panel();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.panelIcerik = new System.Windows.Forms.Panel();
            this.lblBilgi = new System.Windows.Forms.Label();
            this.lblKartNo = new System.Windows.Forms.Label();
            this.txtKartNo = new System.Windows.Forms.TextBox();
            this.lblIsim = new System.Windows.Forms.Label();
            this.txtIsim = new System.Windows.Forms.TextBox();
            this.lblSKT = new System.Windows.Forms.Label();
            this.txtSKT = new System.Windows.Forms.TextBox();
            this.lblCVV = new System.Windows.Forms.Label();
            this.txtCVV = new System.Windows.Forms.TextBox();
            this.btnOde = new System.Windows.Forms.Button();
            this.panelUst.SuspendLayout();
            this.panelIcerik.SuspendLayout();
            this.SuspendLayout();

            // panelUst
            this.panelUst.BackColor = System.Drawing.Color.Firebrick;
            this.panelUst.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUst.Size = new System.Drawing.Size(500, 80);
            this.panelUst.Controls.Add(this.lblBaslik);

            // lblBaslik
            this.lblBaslik.Text = "🎭 Ödeme Ekranı";
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.ForeColor = System.Drawing.Color.White;
            this.lblBaslik.Location = new System.Drawing.Point(20, 20);
            this.lblBaslik.AutoSize = true;

            // panelIcerik
            this.panelIcerik.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelIcerik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelIcerik.Controls.Add(this.lblBilgi);
            this.panelIcerik.Controls.Add(this.lblKartNo);
            this.panelIcerik.Controls.Add(this.txtKartNo);
            this.panelIcerik.Controls.Add(this.lblIsim);
            this.panelIcerik.Controls.Add(this.txtIsim);
            this.panelIcerik.Controls.Add(this.lblSKT);
            this.panelIcerik.Controls.Add(this.txtSKT);
            this.panelIcerik.Controls.Add(this.lblCVV);
            this.panelIcerik.Controls.Add(this.txtCVV);
            this.panelIcerik.Controls.Add(this.btnOde);

            // lblBilgi
            this.lblBilgi.Text = "";
            this.lblBilgi.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblBilgi.ForeColor = System.Drawing.Color.Firebrick;
            this.lblBilgi.Location = new System.Drawing.Point(30, 20);
            this.lblBilgi.Size = new System.Drawing.Size(420, 30);

            // lblKartNo
            this.lblKartNo.Text = "Kart Numarası";
            this.lblKartNo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblKartNo.Location = new System.Drawing.Point(30, 70);
            this.lblKartNo.AutoSize = true;

            // txtKartNo
            this.txtKartNo.Location = new System.Drawing.Point(30, 95);
            this.txtKartNo.Size = new System.Drawing.Size(420, 30);
            this.txtKartNo.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtKartNo.MaxLength = 16;

            // lblIsim
            this.lblIsim.Text = "Kart Üzerindeki İsim";
            this.lblIsim.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblIsim.Location = new System.Drawing.Point(30, 140);
            this.lblIsim.AutoSize = true;

            // txtIsim
            this.txtIsim.Location = new System.Drawing.Point(30, 165);
            this.txtIsim.Size = new System.Drawing.Size(420, 30);
            this.txtIsim.Font = new System.Drawing.Font("Segoe UI", 11F);

            // lblSKT
            this.lblSKT.Text = "Son Kullanma Tarihi";
            this.lblSKT.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSKT.Location = new System.Drawing.Point(30, 210);
            this.lblSKT.AutoSize = true;

            // txtSKT
            this.txtSKT.Location = new System.Drawing.Point(30, 235);
            this.txtSKT.Size = new System.Drawing.Size(180, 30);
            this.txtSKT.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSKT.MaxLength = 5;

            // lblCVV
            this.lblCVV.Text = "CVV";
            this.lblCVV.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCVV.Location = new System.Drawing.Point(270, 210);
            this.lblCVV.AutoSize = true;

            // txtCVV
            this.txtCVV.Location = new System.Drawing.Point(270, 235);
            this.txtCVV.Size = new System.Drawing.Size(180, 30);
            this.txtCVV.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtCVV.MaxLength = 3;
            this.txtCVV.UseSystemPasswordChar = true;

            // btnOde
            this.btnOde.Text = "Ödemeyi Tamamla";
            this.btnOde.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnOde.BackColor = System.Drawing.Color.Firebrick;
            this.btnOde.ForeColor = System.Drawing.Color.White;
            this.btnOde.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOde.Location = new System.Drawing.Point(30, 300);
            this.btnOde.Size = new System.Drawing.Size(420, 50);
            this.btnOde.Click += new System.EventHandler(this.btnOde_Click);

            // Odeme Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "Ödeme";
            this.ClientSize = new System.Drawing.Size(500, 450);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "Odeme";
            this.Controls.Add(this.panelIcerik);
            this.Controls.Add(this.panelUst);
            this.Load += new System.EventHandler(this.Odeme_Load);
            this.panelUst.ResumeLayout(false);
            this.panelUst.PerformLayout();
            this.panelIcerik.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelUst;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Panel panelIcerik;
        private System.Windows.Forms.Label lblBilgi;
        private System.Windows.Forms.Label lblKartNo;
        private System.Windows.Forms.TextBox txtKartNo;
        private System.Windows.Forms.Label lblIsim;
        private System.Windows.Forms.TextBox txtIsim;
        private System.Windows.Forms.Label lblSKT;
        private System.Windows.Forms.TextBox txtSKT;
        private System.Windows.Forms.Label lblCVV;
        private System.Windows.Forms.TextBox txtCVV;
        private System.Windows.Forms.Button btnOde;
        #endregion
    }
}