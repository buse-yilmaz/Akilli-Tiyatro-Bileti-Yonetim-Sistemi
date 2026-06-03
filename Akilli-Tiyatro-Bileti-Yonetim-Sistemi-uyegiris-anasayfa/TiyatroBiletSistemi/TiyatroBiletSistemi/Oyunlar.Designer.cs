namespace TiyatroBiletSistemi
{
    partial class Oyunlar
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
            this.label4 = new System.Windows.Forms.Label();
            this.panelFiltre = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.dtTarih = new System.Windows.Forms.DateTimePicker();
            this.cmbIlce = new System.Windows.Forms.ComboBox();
            this.cmbSehir = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flowOyunlar = new System.Windows.Forms.FlowLayoutPanel();
            this.panelUst.SuspendLayout();
            this.panelFiltre.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelUst
            // 
            this.panelUst.BackColor = System.Drawing.Color.Firebrick;
            this.panelUst.Controls.Add(this.label4);
            this.panelUst.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUst.Location = new System.Drawing.Point(0, 0);
            this.panelUst.Name = "panelUst";
            this.panelUst.Size = new System.Drawing.Size(800, 100);
            this.panelUst.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(25, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(362, 41);
            this.label4.TabIndex = 0;
            this.label4.Text = "🎭 Tiyatro Bileti Sistemi";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // panelFiltre
            // 
            this.panelFiltre.BackColor = System.Drawing.Color.Firebrick;
            this.panelFiltre.Controls.Add(this.button1);
            this.panelFiltre.Controls.Add(this.dtTarih);
            this.panelFiltre.Controls.Add(this.cmbIlce);
            this.panelFiltre.Controls.Add(this.cmbSehir);
            this.panelFiltre.Controls.Add(this.label3);
            this.panelFiltre.Controls.Add(this.label2);
            this.panelFiltre.Controls.Add(this.label1);
            this.panelFiltre.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelFiltre.Location = new System.Drawing.Point(0, 100);
            this.panelFiltre.Name = "panelFiltre";
            this.panelFiltre.Size = new System.Drawing.Size(250, 350);
            this.panelFiltre.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.Firebrick;
            this.button1.Location = new System.Drawing.Point(29, 247);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 40);
            this.button1.TabIndex = 6;
            this.button1.Text = "Oyunları Listele";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // dtTarih
            // 
            this.dtTarih.Location = new System.Drawing.Point(29, 186);
            this.dtTarih.Name = "dtTarih";
            this.dtTarih.Size = new System.Drawing.Size(200, 22);
            this.dtTarih.TabIndex = 5;
            // 
            // cmbIlce
            // 
            this.cmbIlce.FormattingEnabled = true;
            this.cmbIlce.Location = new System.Drawing.Point(29, 121);
            this.cmbIlce.Name = "cmbIlce";
            this.cmbIlce.Size = new System.Drawing.Size(121, 24);
            this.cmbIlce.TabIndex = 4;
            // 
            // cmbSehir
            // 
            this.cmbSehir.FormattingEnabled = true;
            this.cmbSehir.Location = new System.Drawing.Point(29, 51);
            this.cmbSehir.Name = "cmbSehir";
            this.cmbSehir.Size = new System.Drawing.Size(121, 24);
            this.cmbSehir.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(28, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tarih";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(27, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "İlçe";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(26, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Şehir";
            // 
            // flowOyunlar
            // 
            this.flowOyunlar.AutoScroll = true;
            this.flowOyunlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowOyunlar.Location = new System.Drawing.Point(250, 100);
            this.flowOyunlar.Name = "flowOyunlar";
            this.flowOyunlar.Size = new System.Drawing.Size(550, 350);
            this.flowOyunlar.TabIndex = 2;
            // 
            // Oyunlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowOyunlar);
            this.Controls.Add(this.panelFiltre);
            this.Controls.Add(this.panelUst);
            this.Name = "Oyunlar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Oyunlar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Oyunlar_Load_1);
            this.panelUst.ResumeLayout(false);
            this.panelUst.PerformLayout();
            this.panelFiltre.ResumeLayout(false);
            this.panelFiltre.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelUst;
        private System.Windows.Forms.Panel panelFiltre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dtTarih;
        private System.Windows.Forms.ComboBox cmbIlce;
        private System.Windows.Forms.ComboBox cmbSehir;
        private System.Windows.Forms.FlowLayoutPanel flowOyunlar;
        private System.Windows.Forms.Label label4;
    }
}