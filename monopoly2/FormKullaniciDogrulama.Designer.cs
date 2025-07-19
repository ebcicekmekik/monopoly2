namespace monopoly2
{
    partial class FormKullaniciDogrulama
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormKullaniciDogrulama));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtEmail = new TextBox();
            txtSifre = new TextBox();
            txtSifreTekrar = new TextBox();
            txtAd = new TextBox();
            txtSoyad = new TextBox();
            btnKaydet = new Button();
            lnkGirisYap = new LinkLabel();
            btnAvatarYukle = new Button();
            picAvatar = new PictureBox();
            txtAvatarYolu = new TextBox();
            pictureBox1 = new PictureBox();
            labelKullaniciAdi = new Label();
            txtKullaniciAdi = new TextBox();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(50, 70);
            label1.Name = "label1";
            label1.Size = new Size(120, 23);
            label1.TabIndex = 17;
            label1.Text = "E-posta:";
            // 
            // label2
            // 
            label2.Location = new Point(50, 110);
            label2.Name = "label2";
            label2.Size = new Size(120, 23);
            label2.TabIndex = 16;
            label2.Text = "Şifre:";
            // 
            // label3
            // 
            label3.Location = new Point(50, 150);
            label3.Name = "label3";
            label3.Size = new Size(120, 23);
            label3.TabIndex = 15;
            label3.Text = "Şifre Tekrar:";
            // 
            // label4
            // 
            label4.Location = new Point(50, 190);
            label4.Name = "label4";
            label4.Size = new Size(120, 23);
            label4.TabIndex = 14;
            label4.Text = "Ad:";
            // 
            // label5
            // 
            label5.Location = new Point(50, 230);
            label5.Name = "label5";
            label5.Size = new Size(120, 23);
            label5.TabIndex = 13;
            label5.Text = "Soyad:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(180, 70);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 27);
            txtEmail.TabIndex = 12;
            // 
            // txtSifre
            // 
            txtSifre.Location = new Point(180, 110);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(200, 27);
            txtSifre.TabIndex = 11;
            // 
            // txtSifreTekrar
            // 
            txtSifreTekrar.Location = new Point(180, 150);
            txtSifreTekrar.Name = "txtSifreTekrar";
            txtSifreTekrar.Size = new Size(200, 27);
            txtSifreTekrar.TabIndex = 10;
            // 
            // txtAd
            // 
            txtAd.Location = new Point(180, 190);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(200, 27);
            txtAd.TabIndex = 9;
            // 
            // txtSoyad
            // 
            txtSoyad.Location = new Point(180, 230);
            txtSoyad.Name = "txtSoyad";
            txtSoyad.Size = new Size(200, 27);
            txtSoyad.TabIndex = 8;
            // 
            // btnKaydet
            // 
            btnKaydet.BackgroundImage = (Image)resources.GetObject("btnKaydet.BackgroundImage");
            btnKaydet.BackgroundImageLayout = ImageLayout.Zoom;
            btnKaydet.Location = new Point(180, 263);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(80, 44);
            btnKaydet.TabIndex = 7;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // lnkGirisYap
            // 
            lnkGirisYap.Location = new Point(180, 310);
            lnkGirisYap.Name = "lnkGirisYap";
            lnkGirisYap.Size = new Size(100, 23);
            lnkGirisYap.TabIndex = 6;
            lnkGirisYap.TabStop = true;
            lnkGirisYap.Text = "Giriş Yap";
            lnkGirisYap.LinkClicked += lnkGirisYap_LinkClicked;
            // 
            // btnAvatarYukle
            // 
            btnAvatarYukle.BackgroundImage = (Image)resources.GetObject("btnAvatarYukle.BackgroundImage");
            btnAvatarYukle.BackgroundImageLayout = ImageLayout.Zoom;
            btnAvatarYukle.Location = new Point(400, 30);
            btnAvatarYukle.Name = "btnAvatarYukle";
            btnAvatarYukle.Size = new Size(85, 34);
            btnAvatarYukle.TabIndex = 5;
            btnAvatarYukle.Click += btnAvatarYukle_Click;
            // 
            // picAvatar
            // 
            picAvatar.Location = new Point(400, 70);
            picAvatar.Name = "picAvatar";
            picAvatar.Size = new Size(100, 100);
            picAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
            picAvatar.TabIndex = 4;
            picAvatar.TabStop = false;
            // 
            // txtAvatarYolu
            // 
            txtAvatarYolu.Location = new Point(400, 180);
            txtAvatarYolu.Name = "txtAvatarYolu";
            txtAvatarYolu.Size = new Size(200, 27);
            txtAvatarYolu.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(560, 10);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(70, 70);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // labelKullaniciAdi
            // 
            labelKullaniciAdi.Location = new Point(50, 30);
            labelKullaniciAdi.Name = "labelKullaniciAdi";
            labelKullaniciAdi.Size = new Size(120, 23);
            labelKullaniciAdi.TabIndex = 18;
            labelKullaniciAdi.Text = "Kullanıcı Adı:";
            // 
            // txtKullaniciAdi
            // 
            txtKullaniciAdi.Location = new Point(180, 30);
            txtKullaniciAdi.Name = "txtKullaniciAdi";
            txtKullaniciAdi.Size = new Size(200, 27);
            txtKullaniciAdi.TabIndex = 19;
            // 
            // FormKullaniciDogrulama
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(645, 379);
            Controls.Add(pictureBox1);
            Controls.Add(txtAvatarYolu);
            Controls.Add(picAvatar);
            Controls.Add(btnAvatarYukle);
            Controls.Add(lnkGirisYap);
            Controls.Add(btnKaydet);
            Controls.Add(txtSoyad);
            Controls.Add(txtAd);
            Controls.Add(txtSifreTekrar);
            Controls.Add(txtSifre);
            Controls.Add(txtEmail);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(labelKullaniciAdi);
            Controls.Add(txtKullaniciAdi);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "FormKullaniciDogrulama";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kullanıcı Kaydı";
            FormClosing += FormKullaniciDogrulama_FormClosing;
            Load += FormKullaniciDogrulama_Load;
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.TextBox txtSifreTekrar;
        private System.Windows.Forms.TextBox txtAd;
        private System.Windows.Forms.TextBox txtSoyad;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.LinkLabel lnkGirisYap;
        private System.Windows.Forms.Button btnAvatarYukle;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.TextBox txtAvatarYolu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelKullaniciAdi;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
    }
} 