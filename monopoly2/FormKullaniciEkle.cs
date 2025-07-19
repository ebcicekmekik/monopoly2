using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Text.RegularExpressions;

namespace monopoly2
{
    public partial class FormKullaniciEkle : Form
    {
        private TextBox txtKullaniciAdi;
        private TextBox txtEmail;
        private TextBox txtAd;
        private TextBox txtSoyad;
        private TextBox txtSifre;
        private CheckBox chkAdmin;
        private Button btnKaydet;
        private Button btnIptal;

        public FormKullaniciEkle()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            this.Text = "Yeni Kullanıcı Ekle";
            this.Size = new System.Drawing.Size(400, 400);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Kullanıcı Adı
            Label lblKullaniciAdi = new Label();
            lblKullaniciAdi.Text = "Kullanıcı Adı:";
            lblKullaniciAdi.Location = new System.Drawing.Point(20, 20);
            lblKullaniciAdi.Size = new System.Drawing.Size(100, 20);
            this.Controls.Add(lblKullaniciAdi);

            txtKullaniciAdi = new TextBox();
            txtKullaniciAdi.Location = new System.Drawing.Point(120, 20);
            txtKullaniciAdi.Size = new System.Drawing.Size(200, 20);
            this.Controls.Add(txtKullaniciAdi);

            // Email
            Label lblEmail = new Label();
            lblEmail.Text = "Email:";
            lblEmail.Location = new System.Drawing.Point(20, 60);
            lblEmail.Size = new System.Drawing.Size(100, 20);
            this.Controls.Add(lblEmail);

            txtEmail = new TextBox();
            txtEmail.Location = new System.Drawing.Point(120, 60);
            txtEmail.Size = new System.Drawing.Size(200, 20);
            this.Controls.Add(txtEmail);

            // Ad
            Label lblAd = new Label();
            lblAd.Text = "Ad:";
            lblAd.Location = new System.Drawing.Point(20, 100);
            lblAd.Size = new System.Drawing.Size(100, 20);
            this.Controls.Add(lblAd);

            txtAd = new TextBox();
            txtAd.Location = new System.Drawing.Point(120, 100);
            txtAd.Size = new System.Drawing.Size(200, 20);
            this.Controls.Add(txtAd);

            // Soyad
            Label lblSoyad = new Label();
            lblSoyad.Text = "Soyad:";
            lblSoyad.Location = new System.Drawing.Point(20, 140);
            lblSoyad.Size = new System.Drawing.Size(100, 20);
            this.Controls.Add(lblSoyad);

            txtSoyad = new TextBox();
            txtSoyad.Location = new System.Drawing.Point(120, 140);
            txtSoyad.Size = new System.Drawing.Size(200, 20);
            this.Controls.Add(txtSoyad);

            // Şifre
            Label lblSifre = new Label();
            lblSifre.Text = "Şifre:";
            lblSifre.Location = new System.Drawing.Point(20, 180);
            lblSifre.Size = new System.Drawing.Size(100, 20);
            this.Controls.Add(lblSifre);

            txtSifre = new TextBox();
            txtSifre.Location = new System.Drawing.Point(120, 180);
            txtSifre.Size = new System.Drawing.Size(200, 20);
            txtSifre.PasswordChar = '*';
            this.Controls.Add(txtSifre);

            // Admin Checkbox
            chkAdmin = new CheckBox();
            chkAdmin.Text = "Admin Yetkisi";
            chkAdmin.Location = new System.Drawing.Point(120, 220);
            chkAdmin.Size = new System.Drawing.Size(200, 20);
            this.Controls.Add(chkAdmin);

            // Kaydet Butonu
            btnKaydet = new Button();
            btnKaydet.Text = "Kaydet";
            btnKaydet.Location = new System.Drawing.Point(120, 260);
            btnKaydet.Size = new System.Drawing.Size(90, 30);
            btnKaydet.Click += btnKaydet_Click;
            this.Controls.Add(btnKaydet);

            // İptal Butonu
            btnIptal = new Button();
            btnIptal.Text = "İptal";
            btnIptal.Location = new System.Drawing.Point(230, 260);
            btnIptal.Size = new System.Drawing.Size(90, 30);
            btnIptal.Click += btnIptal_Click;
            this.Controls.Add(btnIptal);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtAd.Text) ||
                string.IsNullOrWhiteSpace(txtSoyad.Text) ||
                string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Geçerli bir email adresi giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new SqlConnection(DatabaseConnection.GetConnection().ConnectionString))
                {
                    conn.Open();
                    
                    // Email kontrolü
                    string checkQuery = "SELECT COUNT(*) FROM Kullanicilar WHERE Email = @email";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@email", txtEmail.Text);
                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Bu email adresi zaten kullanılıyor!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Kullanıcı adı kontrolü
                    checkQuery = "SELECT COUNT(*) FROM Kullanicilar WHERE KullaniciAdi = @kullaniciAdi";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@kullaniciAdi", txtKullaniciAdi.Text);
                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Bu kullanıcı adı zaten kullanılıyor!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Yeni kullanıcı ekleme
                    string insertQuery = @"INSERT INTO Kullanicilar (KullaniciAdi, Email, Ad, Soyad, Sifre, IsAdmin, Yasakli) 
                                         VALUES (@kullaniciAdi, @email, @ad, @soyad, @sifre, @isAdmin, 0)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@kullaniciAdi", txtKullaniciAdi.Text);
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@ad", txtAd.Text);
                        cmd.Parameters.AddWithValue("@soyad", txtSoyad.Text);
                        cmd.Parameters.AddWithValue("@sifre", txtSifre.Text);
                        cmd.Parameters.AddWithValue("@isAdmin", chkAdmin.Checked);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Kullanıcı başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullanıcı eklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }
    }
} 