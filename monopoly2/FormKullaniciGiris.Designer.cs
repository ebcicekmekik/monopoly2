namespace monopoly2
{
    partial class FormKullaniciGiris
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormKullaniciGiris));
            label1 = new Label();
            label2 = new Label();
            txtKullaniciAdi = new TextBox();
            txtSifre = new TextBox();
            btnGiris = new Button();
            lnkKayitOl = new LinkLabel();
            chkBeniHatirla = new CheckBox();
            lnkSifremiUnuttum = new LinkLabel();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.Black;
            label1.Location = new Point(16, 34);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(95, 20);
            label1.TabIndex = 0;
            label1.Text = "Kullanıcı Adı:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.ForeColor = Color.Black;
            label2.Location = new Point(67, 72);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(42, 20);
            label2.TabIndex = 1;
            label2.Text = "Şifre:";
            // 
            // txtKullaniciAdi
            // 
            txtKullaniciAdi.Location = new Point(117, 29);
            txtKullaniciAdi.Margin = new Padding(4, 5, 4, 5);
            txtKullaniciAdi.Name = "txtKullaniciAdi";
            txtKullaniciAdi.Size = new Size(229, 27);
            txtKullaniciAdi.TabIndex = 2;
            // 
            // txtSifre
            // 
            txtSifre.Location = new Point(117, 69);
            txtSifre.Margin = new Padding(4, 5, 4, 5);
            txtSifre.Name = "txtSifre";
            txtSifre.PasswordChar = '*';
            txtSifre.Size = new Size(229, 27);
            txtSifre.TabIndex = 3;
            // 
            // btnGiris
            // 
            btnGiris.BackColor = Color.White;
            btnGiris.BackgroundImage = (Image)resources.GetObject("btnGiris.BackgroundImage");
            btnGiris.BackgroundImageLayout = ImageLayout.Stretch;
            btnGiris.Location = new Point(259, 106);
            btnGiris.Margin = new Padding(4, 5, 4, 5);
            btnGiris.Name = "btnGiris";
            btnGiris.Size = new Size(87, 60);
            btnGiris.TabIndex = 4;
            btnGiris.UseVisualStyleBackColor = false;
            btnGiris.Click += btnGiris_Click;
            // 
            // lnkKayitOl
            // 
            lnkKayitOl.AutoSize = true;
            lnkKayitOl.BackColor = Color.Transparent;
            lnkKayitOl.ForeColor = Color.Black;
            lnkKayitOl.LinkColor = Color.Black;
            lnkKayitOl.Location = new Point(117, 135);
            lnkKayitOl.Margin = new Padding(4, 0, 4, 0);
            lnkKayitOl.Name = "lnkKayitOl";
            lnkKayitOl.Size = new Size(102, 20);
            lnkKayitOl.TabIndex = 5;
            lnkKayitOl.TabStop = true;
            lnkKayitOl.Text = "Hesap Oluştur";
            lnkKayitOl.LinkClicked += lnkKayitOl_LinkClicked;
            // 
            // chkBeniHatirla
            // 
            chkBeniHatirla.AutoSize = true;
            chkBeniHatirla.BackColor = Color.Transparent;
            chkBeniHatirla.ForeColor = Color.Black;
            chkBeniHatirla.Location = new Point(117, 106);
            chkBeniHatirla.Margin = new Padding(4, 5, 4, 5);
            chkBeniHatirla.Name = "chkBeniHatirla";
            chkBeniHatirla.Size = new Size(109, 24);
            chkBeniHatirla.TabIndex = 6;
            chkBeniHatirla.Text = "Beni Hatırla";
            chkBeniHatirla.UseVisualStyleBackColor = false;
            // 
            // lnkSifremiUnuttum
            // 
            lnkSifremiUnuttum.AutoSize = true;
            lnkSifremiUnuttum.BackColor = Color.Transparent;
            lnkSifremiUnuttum.ForeColor = Color.Black;
            lnkSifremiUnuttum.LinkColor = Color.Black;
            lnkSifremiUnuttum.Location = new Point(117, 164);
            lnkSifremiUnuttum.Name = "lnkSifremiUnuttum";
            lnkSifremiUnuttum.Size = new Size(124, 20);
            lnkSifremiUnuttum.TabIndex = 7;
            lnkSifremiUnuttum.TabStop = true;
            lnkSifremiUnuttum.Text = "Şifremi Unuttum?";
            lnkSifremiUnuttum.LinkClicked += lnkSifremiUnuttum_LinkClicked;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(651, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(151, 141);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // FormKullaniciGiris
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(801, 406);
            Controls.Add(pictureBox1);
            Controls.Add(lnkSifremiUnuttum);
            Controls.Add(chkBeniHatirla);
            Controls.Add(lnkKayitOl);
            Controls.Add(btnGiris);
            Controls.Add(txtSifre);
            Controls.Add(txtKullaniciAdi);
            Controls.Add(label2);
            Controls.Add(label1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "FormKullaniciGiris";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kullanıcı Girişi";
            FormClosing += FormKullaniciGiris_FormClosing;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.Button btnGiris;
        private System.Windows.Forms.LinkLabel lnkKayitOl;
        private System.Windows.Forms.CheckBox chkBeniHatirla;
        private System.Windows.Forms.LinkLabel lnkSifremiUnuttum;
        private PictureBox pictureBox1;
    }
} 