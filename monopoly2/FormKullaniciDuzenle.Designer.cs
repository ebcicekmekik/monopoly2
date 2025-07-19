namespace monopoly2
{
    partial class FormKullaniciDuzenle
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtAd;
        private System.Windows.Forms.TextBox txtSoyad;
        private System.Windows.Forms.CheckBox chkIsAdmin;
        private System.Windows.Forms.CheckBox chkYasakli;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Label lblKullaniciAdi;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblAd;
        private System.Windows.Forms.Label lblSoyad;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormKullaniciDuzenle));
            txtKullaniciAdi = new TextBox();
            txtEmail = new TextBox();
            txtAd = new TextBox();
            txtSoyad = new TextBox();
            chkIsAdmin = new CheckBox();
            chkYasakli = new CheckBox();
            btnKaydet = new Button();
            lblKullaniciAdi = new Label();
            lblEmail = new Label();
            lblAd = new Label();
            lblSoyad = new Label();
            SuspendLayout();
            // 
            // txtKullaniciAdi
            // 
            txtKullaniciAdi.Location = new Point(160, 26);
            txtKullaniciAdi.Margin = new Padding(4, 5, 4, 5);
            txtKullaniciAdi.Name = "txtKullaniciAdi";
            txtKullaniciAdi.Size = new Size(265, 27);
            txtKullaniciAdi.TabIndex = 1;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(160, 80);
            txtEmail.Margin = new Padding(4, 5, 4, 5);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(265, 27);
            txtEmail.TabIndex = 3;
            // 
            // txtAd
            // 
            txtAd.Location = new Point(160, 134);
            txtAd.Margin = new Padding(4, 5, 4, 5);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(265, 27);
            txtAd.TabIndex = 5;
            // 
            // txtSoyad
            // 
            txtSoyad.Location = new Point(160, 188);
            txtSoyad.Margin = new Padding(4, 5, 4, 5);
            txtSoyad.Name = "txtSoyad";
            txtSoyad.Size = new Size(265, 27);
            txtSoyad.TabIndex = 7;
            // 
            // chkIsAdmin
            // 
            chkIsAdmin.AutoSize = true;
            chkIsAdmin.Location = new Point(160, 246);
            chkIsAdmin.Margin = new Padding(4, 5, 4, 5);
            chkIsAdmin.Name = "chkIsAdmin";
            chkIsAdmin.Size = new Size(103, 24);
            chkIsAdmin.TabIndex = 8;
            chkIsAdmin.Text = "Admin mi?";
            // 
            // chkYasakli
            // 
            chkYasakli.AutoSize = true;
            chkYasakli.Location = new Point(293, 246);
            chkYasakli.Margin = new Padding(4, 5, 4, 5);
            chkYasakli.Name = "chkYasakli";
            chkYasakli.Size = new Size(75, 24);
            chkYasakli.TabIndex = 9;
            chkYasakli.Text = "Yasaklı";
            // 
            // btnKaydet
            // 
            btnKaydet.BackgroundImage = (Image)resources.GetObject("btnKaydet.BackgroundImage");
            btnKaydet.BackgroundImageLayout = ImageLayout.Zoom;
            btnKaydet.Location = new Point(186, 301);
            btnKaydet.Margin = new Padding(4, 5, 4, 5);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(167, 46);
            btnKaydet.TabIndex = 10;
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // lblKullaniciAdi
            // 
            lblKullaniciAdi.AutoSize = true;
            lblKullaniciAdi.Location = new Point(27, 31);
            lblKullaniciAdi.Margin = new Padding(4, 0, 4, 0);
            lblKullaniciAdi.Name = "lblKullaniciAdi";
            lblKullaniciAdi.Size = new Size(95, 20);
            lblKullaniciAdi.TabIndex = 0;
            lblKullaniciAdi.Text = "Kullanıcı Adı:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(27, 85);
            lblEmail.Margin = new Padding(4, 0, 4, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(49, 20);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email:";
            // 
            // lblAd
            // 
            lblAd.AutoSize = true;
            lblAd.Location = new Point(27, 138);
            lblAd.Margin = new Padding(4, 0, 4, 0);
            lblAd.Name = "lblAd";
            lblAd.Size = new Size(31, 20);
            lblAd.TabIndex = 4;
            lblAd.Text = "Ad:";
            // 
            // lblSoyad
            // 
            lblSoyad.AutoSize = true;
            lblSoyad.Location = new Point(27, 192);
            lblSoyad.Margin = new Padding(4, 0, 4, 0);
            lblSoyad.Name = "lblSoyad";
            lblSoyad.Size = new Size(53, 20);
            lblSoyad.TabIndex = 6;
            lblSoyad.Text = "Soyad:";
            // 
            // FormKullaniciDuzenle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(467, 385);
            Controls.Add(lblKullaniciAdi);
            Controls.Add(txtKullaniciAdi);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblAd);
            Controls.Add(txtAd);
            Controls.Add(lblSoyad);
            Controls.Add(txtSoyad);
            Controls.Add(chkIsAdmin);
            Controls.Add(chkYasakli);
            Controls.Add(btnKaydet);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormKullaniciDuzenle";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Kullanıcıyı Düzenle";
            ResumeLayout(false);
            PerformLayout();
        }
    }
} 