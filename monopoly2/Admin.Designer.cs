namespace monopoly2
{
    partial class Admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            tabControl1 = new TabControl();
            tabKullanicilar = new TabPage();
            btnKullaniciEkle = new Button();
            dgvKullanicilar = new DataGridView();
            btnKullaniciSil = new Button();
            btnKullaniciDuzenle = new Button();
            btnKullaniciYasakla = new Button();
            tabMesajlar = new TabPage();
            txtCevap = new TextBox();
            btnCevapla = new Button();
            dgvMesajlar = new DataGridView();
            btnMesajSil = new Button();
            tabOyunlar = new TabPage();
            btnOyunGuncelle = new Button();
            btnOyunEkle = new Button();
            btnOyunSil = new Button();
            dgvOyunlar = new DataGridView();
            lstTop5 = new ListBox();
            lblMaxSkor = new Label();
            lblMinSkor = new Label();
            label1 = new Label();
            btnMaxSkor = new Button();
            btnMinSkor = new Button();
            cmbYilFiltre = new ComboBox();
            cmbAyFiltre = new ComboBox();
            btnYenile = new Button();
            tabControl1.SuspendLayout();
            tabKullanicilar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKullanicilar).BeginInit();
            tabMesajlar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMesajlar).BeginInit();
            tabOyunlar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOyunlar).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabKullanicilar);
            tabControl1.Controls.Add(tabMesajlar);
            tabControl1.Controls.Add(tabOyunlar);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1120, 588);
            tabControl1.TabIndex = 0;
            // 
            // tabKullanicilar
            // 
            tabKullanicilar.Controls.Add(btnKullaniciEkle);
            tabKullanicilar.Controls.Add(dgvKullanicilar);
            tabKullanicilar.Controls.Add(btnKullaniciSil);
            tabKullanicilar.Controls.Add(btnKullaniciDuzenle);
            tabKullanicilar.Controls.Add(btnKullaniciYasakla);
            tabKullanicilar.Location = new Point(4, 29);
            tabKullanicilar.Name = "tabKullanicilar";
            tabKullanicilar.Padding = new Padding(3);
            tabKullanicilar.Size = new Size(1112, 555);
            tabKullanicilar.TabIndex = 0;
            tabKullanicilar.Text = "Kullanıcılar";
            tabKullanicilar.UseVisualStyleBackColor = true;
            // 
            // btnKullaniciEkle
            // 
            btnKullaniciEkle.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnKullaniciEkle.BackColor = Color.White;
            btnKullaniciEkle.BackgroundImage = (Image)resources.GetObject("btnKullaniciEkle.BackgroundImage");
            btnKullaniciEkle.BackgroundImageLayout = ImageLayout.Stretch;
            btnKullaniciEkle.Location = new Point(752, 501);
            btnKullaniciEkle.Name = "btnKullaniciEkle";
            btnKullaniciEkle.Size = new Size(60, 46);
            btnKullaniciEkle.TabIndex = 4;
            btnKullaniciEkle.UseVisualStyleBackColor = false;
            btnKullaniciEkle.Click += btnKullaniciEkle_Click;
            // 
            // dgvKullanicilar
            // 
            dgvKullanicilar.AllowUserToAddRows = false;
            dgvKullanicilar.AllowUserToDeleteRows = false;
            dgvKullanicilar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKullanicilar.BackgroundColor = SystemColors.Window;
            dgvKullanicilar.BorderStyle = BorderStyle.Fixed3D;
            dgvKullanicilar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKullanicilar.Location = new Point(0, 0);
            dgvKullanicilar.MultiSelect = false;
            dgvKullanicilar.Name = "dgvKullanicilar";
            dgvKullanicilar.ReadOnly = true;
            dgvKullanicilar.RowHeadersWidth = 51;
            dgvKullanicilar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKullanicilar.Size = new Size(1109, 437);
            dgvKullanicilar.TabIndex = 0;
            // 
            // btnKullaniciSil
            // 
            btnKullaniciSil.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnKullaniciSil.BackgroundImage = (Image)resources.GetObject("btnKullaniciSil.BackgroundImage");
            btnKullaniciSil.BackgroundImageLayout = ImageLayout.Stretch;
            btnKullaniciSil.Location = new Point(1042, 501);
            btnKullaniciSil.Name = "btnKullaniciSil";
            btnKullaniciSil.Size = new Size(52, 46);
            btnKullaniciSil.TabIndex = 1;
            btnKullaniciSil.UseVisualStyleBackColor = true;
            btnKullaniciSil.Click += btnKullaniciSil_Click;
            // 
            // btnKullaniciDuzenle
            // 
            btnKullaniciDuzenle.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnKullaniciDuzenle.BackgroundImage = (Image)resources.GetObject("btnKullaniciDuzenle.BackgroundImage");
            btnKullaniciDuzenle.BackgroundImageLayout = ImageLayout.Stretch;
            btnKullaniciDuzenle.Location = new Point(943, 501);
            btnKullaniciDuzenle.Name = "btnKullaniciDuzenle";
            btnKullaniciDuzenle.Size = new Size(61, 46);
            btnKullaniciDuzenle.TabIndex = 2;
            btnKullaniciDuzenle.UseVisualStyleBackColor = true;
            btnKullaniciDuzenle.Click += btnKullaniciDuzenle_Click;
            // 
            // btnKullaniciYasakla
            // 
            btnKullaniciYasakla.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnKullaniciYasakla.BackgroundImage = (Image)resources.GetObject("btnKullaniciYasakla.BackgroundImage");
            btnKullaniciYasakla.BackgroundImageLayout = ImageLayout.Stretch;
            btnKullaniciYasakla.Location = new Point(845, 501);
            btnKullaniciYasakla.Name = "btnKullaniciYasakla";
            btnKullaniciYasakla.Size = new Size(60, 46);
            btnKullaniciYasakla.TabIndex = 3;
            btnKullaniciYasakla.UseVisualStyleBackColor = true;
            btnKullaniciYasakla.Click += btnKullaniciYasakla_Click;
            // 
            // tabMesajlar
            // 
            tabMesajlar.Controls.Add(txtCevap);
            tabMesajlar.Controls.Add(btnCevapla);
            tabMesajlar.Controls.Add(dgvMesajlar);
            tabMesajlar.Controls.Add(btnMesajSil);
            tabMesajlar.Location = new Point(4, 29);
            tabMesajlar.Name = "tabMesajlar";
            tabMesajlar.Padding = new Padding(3);
            tabMesajlar.Size = new Size(1112, 555);
            tabMesajlar.TabIndex = 1;
            tabMesajlar.Text = "Mesajlar";
            tabMesajlar.UseVisualStyleBackColor = true;
            // 
            // txtCevap
            // 
            txtCevap.Location = new Point(11, 800);
            txtCevap.Multiline = true;
            txtCevap.Name = "txtCevap";
            txtCevap.Size = new Size(800, 35);
            txtCevap.TabIndex = 2;
            // 
            // btnCevapla
            // 
            btnCevapla.BackgroundImage = (Image)resources.GetObject("btnCevapla.BackgroundImage");
            btnCevapla.BackgroundImageLayout = ImageLayout.Stretch;
            btnCevapla.Location = new Point(820, 800);
            btnCevapla.Name = "btnCevapla";
            btnCevapla.Size = new Size(60, 35);
            btnCevapla.TabIndex = 3;
            btnCevapla.UseVisualStyleBackColor = true;
            btnCevapla.Click += btnCevapla_Click;
            // 
            // dgvMesajlar
            // 
            dgvMesajlar.AllowUserToAddRows = false;
            dgvMesajlar.AllowUserToDeleteRows = false;
            dgvMesajlar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMesajlar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMesajlar.BackgroundColor = SystemColors.Window;
            dgvMesajlar.BorderStyle = BorderStyle.Fixed3D;
            dgvMesajlar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMesajlar.Location = new Point(11, 12);
            dgvMesajlar.MultiSelect = false;
            dgvMesajlar.Name = "dgvMesajlar";
            dgvMesajlar.ReadOnly = true;
            dgvMesajlar.RowHeadersWidth = 51;
            dgvMesajlar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMesajlar.Size = new Size(1035, 443);
            dgvMesajlar.TabIndex = 0;
            // 
            // btnMesajSil
            // 
            btnMesajSil.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnMesajSil.BackgroundImage = (Image)resources.GetObject("btnMesajSil.BackgroundImage");
            btnMesajSil.BackgroundImageLayout = ImageLayout.Stretch;
            btnMesajSil.Location = new Point(550, 460);
            btnMesajSil.Name = "btnMesajSil";
            btnMesajSil.Size = new Size(62, 35);
            btnMesajSil.TabIndex = 1;
            btnMesajSil.UseVisualStyleBackColor = true;
            btnMesajSil.Click += btnMesajSil_Click;
            // 
            // tabOyunlar
            // 
            tabOyunlar.Controls.Add(btnOyunGuncelle);
            tabOyunlar.Controls.Add(btnOyunEkle);
            tabOyunlar.Controls.Add(btnOyunSil);
            tabOyunlar.Controls.Add(dgvOyunlar);
            tabOyunlar.Controls.Add(lstTop5);
            tabOyunlar.Controls.Add(lblMaxSkor);
            tabOyunlar.Controls.Add(lblMinSkor);
            tabOyunlar.Controls.Add(label1);
            tabOyunlar.Controls.Add(btnMaxSkor);
            tabOyunlar.Controls.Add(btnMinSkor);
            tabOyunlar.Controls.Add(cmbYilFiltre);
            tabOyunlar.Controls.Add(cmbAyFiltre);
            tabOyunlar.Location = new Point(4, 29);
            tabOyunlar.Name = "tabOyunlar";
            tabOyunlar.Padding = new Padding(3);
            tabOyunlar.Size = new Size(1112, 555);
            tabOyunlar.TabIndex = 2;
            tabOyunlar.Text = "Oyunlar";
            tabOyunlar.UseVisualStyleBackColor = true;
            // 
            // btnOyunGuncelle
            // 
            btnOyunGuncelle.BackColor = Color.White;
            btnOyunGuncelle.BackgroundImage = (Image)resources.GetObject("btnOyunGuncelle.BackgroundImage");
            btnOyunGuncelle.BackgroundImageLayout = ImageLayout.Stretch;
            btnOyunGuncelle.Location = new Point(1185, 833);
            btnOyunGuncelle.Name = "btnOyunGuncelle";
            btnOyunGuncelle.Size = new Size(63, 46);
            btnOyunGuncelle.TabIndex = 0;
            btnOyunGuncelle.UseVisualStyleBackColor = false;
            btnOyunGuncelle.Click += btnOyunGuncelle_Click;
            // 
            // btnOyunEkle
            // 
            btnOyunEkle.BackColor = Color.White;
            btnOyunEkle.BackgroundImage = (Image)resources.GetObject("btnOyunEkle.BackgroundImage");
            btnOyunEkle.BackgroundImageLayout = ImageLayout.Stretch;
            btnOyunEkle.Location = new Point(1120, 833);
            btnOyunEkle.Name = "btnOyunEkle";
            btnOyunEkle.Size = new Size(63, 46);
            btnOyunEkle.TabIndex = 1;
            btnOyunEkle.UseVisualStyleBackColor = false;
            btnOyunEkle.Click += btnOyunEkle_Click;
            // 
            // btnOyunSil
            // 
            btnOyunSil.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOyunSil.BackgroundImage = (Image)resources.GetObject("btnOyunSil.BackgroundImage");
            btnOyunSil.BackgroundImageLayout = ImageLayout.Stretch;
            btnOyunSil.Location = new Point(690, 490);
            btnOyunSil.Name = "btnOyunSil";
            btnOyunSil.Size = new Size(63, 46);
            btnOyunSil.TabIndex = 1;
            btnOyunSil.UseVisualStyleBackColor = true;
            btnOyunSil.Click += btnOyunSil_Click;
            // 
            // dgvOyunlar
            // 
            dgvOyunlar.AllowUserToAddRows = false;
            dgvOyunlar.AllowUserToDeleteRows = false;
            dgvOyunlar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvOyunlar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOyunlar.BackgroundColor = SystemColors.Window;
            dgvOyunlar.BorderStyle = BorderStyle.Fixed3D;
            dgvOyunlar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOyunlar.Location = new Point(11, 12);
            dgvOyunlar.MultiSelect = false;
            dgvOyunlar.Name = "dgvOyunlar";
            dgvOyunlar.ReadOnly = true;
            dgvOyunlar.RowHeadersWidth = 51;
            dgvOyunlar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOyunlar.Size = new Size(667, 443);
            dgvOyunlar.TabIndex = 0;
            // 
            // lstTop5
            // 
            lstTop5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            lstTop5.ItemHeight = 20;
            lstTop5.Location = new Point(685, 45);
            lstTop5.Name = "lstTop5";
            lstTop5.Size = new Size(359, 444);
            lstTop5.TabIndex = 2;
            // 
            // lblMaxSkor
            // 
            lblMaxSkor.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblMaxSkor.AutoSize = true;
            lblMaxSkor.Location = new Point(685, 366);
            lblMaxSkor.Name = "lblMaxSkor";
            lblMaxSkor.Size = new Size(121, 20);
            lblMaxSkor.TabIndex = 3;
            lblMaxSkor.Text = "En Yüksek Skor: 0";
            // 
            // lblMinSkor
            // 
            lblMinSkor.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblMinSkor.AutoSize = true;
            lblMinSkor.Location = new Point(685, 397);
            lblMinSkor.Name = "lblMinSkor";
            lblMinSkor.Size = new Size(117, 20);
            lblMinSkor.TabIndex = 4;
            lblMinSkor.Text = "En Düşük Skor: 0";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(935, 15);
            label1.Name = "label1";
            label1.Size = new Size(109, 20);
            label1.TabIndex = 5;
            label1.Text = "En İyi 5 Oyuncu";
            // 
            // btnMaxSkor
            // 
            btnMaxSkor.Location = new Point(280, 12);
            btnMaxSkor.Name = "btnMaxSkor";
            btnMaxSkor.Size = new Size(80, 40);
            btnMaxSkor.TabIndex = 6;
            btnMaxSkor.Text = "Max";
            btnMaxSkor.UseVisualStyleBackColor = true;
            // 
            // btnMinSkor
            // 
            btnMinSkor.Location = new Point(370, 12);
            btnMinSkor.Name = "btnMinSkor";
            btnMinSkor.Size = new Size(80, 40);
            btnMinSkor.TabIndex = 7;
            btnMinSkor.Text = "Min";
            btnMinSkor.UseVisualStyleBackColor = true;
            // 
            // cmbYilFiltre
            // 
            cmbYilFiltre.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbYilFiltre.Location = new Point(470, 12);
            cmbYilFiltre.Name = "cmbYilFiltre";
            cmbYilFiltre.Size = new Size(80, 28);
            cmbYilFiltre.TabIndex = 8;
            // 
            // cmbAyFiltre
            // 
            cmbAyFiltre.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAyFiltre.Location = new Point(560, 12);
            cmbAyFiltre.Name = "cmbAyFiltre";
            cmbAyFiltre.Size = new Size(80, 28);
            cmbAyFiltre.TabIndex = 9;
            // 
            // btnYenile
            // 
            btnYenile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnYenile.Location = new Point(998, 12);
            btnYenile.Name = "btnYenile";
            btnYenile.Size = new Size(100, 35);
            btnYenile.TabIndex = 1;
            btnYenile.Text = "Yenile";
            btnYenile.UseVisualStyleBackColor = true;
            // 
            // Admin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1120, 588);
            Controls.Add(tabControl1);
            Controls.Add(btnYenile);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Admin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin Paneli";
            tabControl1.ResumeLayout(false);
            tabKullanicilar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvKullanicilar).EndInit();
            tabMesajlar.ResumeLayout(false);
            tabMesajlar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMesajlar).EndInit();
            tabOyunlar.ResumeLayout(false);
            tabOyunlar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOyunlar).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabKullanicilar;
        private System.Windows.Forms.TabPage tabMesajlar;
        private System.Windows.Forms.TabPage tabOyunlar;
        private System.Windows.Forms.DataGridView dgvKullanicilar;
        private System.Windows.Forms.DataGridView dgvMesajlar;
        private System.Windows.Forms.DataGridView dgvOyunlar;
        private System.Windows.Forms.Button btnKullaniciSil;
        private System.Windows.Forms.Button btnMesajSil;
        private System.Windows.Forms.Button btnOyunSil;
        private System.Windows.Forms.Button btnYenile;
        private System.Windows.Forms.ListBox lstTop5;
        private System.Windows.Forms.Label lblMaxSkor;
        private System.Windows.Forms.Label lblMinSkor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnKullaniciDuzenle;
        private System.Windows.Forms.Button btnKullaniciYasakla;
        private System.Windows.Forms.TextBox txtCevap;
        private System.Windows.Forms.Button btnCevapla;
        private System.Windows.Forms.Button btnMaxSkor;
        private System.Windows.Forms.Button btnMinSkor;
        private System.Windows.Forms.ComboBox cmbYilFiltre;
        private System.Windows.Forms.ComboBox cmbAyFiltre;
        private Button btnOyunGuncelle;
        private Button btnOyunEkle;
    }
}