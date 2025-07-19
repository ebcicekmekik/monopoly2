using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using monopoly2;

namespace monopoly2
{
    public partial class FormKullaniciDogrulama : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        public FormKullaniciDogrulama()
        {
            InitializeComponent();
        }

        private void FormKullaniciDogrulama_Load(object sender, EventArgs e)
        {

            // Form yüklendiğinde yapılacak işlemler
            txtEmail.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, txtEmail.Width, txtEmail.Height, 15, 15));
            txtSifre.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, txtSifre.Width, txtSifre.Height, 15, 15));
            txtSifreTekrar.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, txtSifreTekrar.Width, txtSifreTekrar.Height, 15, 15));
            txtAd.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, txtAd.Width, txtAd.Height, 15, 15));
            txtSoyad.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, txtSoyad.Width, txtSoyad.Height, 15, 15));
        }

        private async void btnKaydet_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text;
            string email = txtEmail.Text;
            string sifre = txtSifre.Text;
            string sifreTekrar = txtSifreTekrar.Text;
            string ad = txtAd.Text;
            string soyad = txtSoyad.Text;
            string avatarYolu = txtAvatarYolu.Text;

            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(sifre) || string.IsNullOrEmpty(sifreTekrar) ||
                string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(soyad))
            {
                MessageBox.Show("Tüm alanları doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (sifre != sifreTekrar)
            {
                MessageBox.Show("Şifreler eşleşmiyor!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(avatarYolu))
            {
                MessageBox.Show("Lütfen bir avatar seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var loading = new LoadingForm())
            {
                loading.LoadingMessage = "Gönderiliyor...";
                loading.Show();
                loading.Refresh();
                await System.Threading.Tasks.Task.Delay(2000);
                try
                {
                    DatabaseConnection.OpenConnection();
                    // Kullanıcı adı kontrolü
                    string checkUserQuery = "SELECT COUNT(*) FROM Kullanicilar WHERE KullaniciAdi = @kullaniciAdi";
                    using (SqlCommand checkUserCmd = new SqlCommand(checkUserQuery, DatabaseConnection.GetConnection()))
                    {
                        checkUserCmd.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                        int userCount = (int)checkUserCmd.ExecuteScalar();
                        if (userCount > 0)
                        {
                            MessageBox.Show("Bu kullanıcı adı zaten kayıtlı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    // Email kontrolü
                    string checkQuery = "SELECT COUNT(*) FROM Kullanicilar WHERE Email = @email";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, DatabaseConnection.GetConnection()))
                    {
                        checkCmd.Parameters.AddWithValue("@email", email);
                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Bu email adresi zaten kayıtlı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    // Doğrulama kodu oluşturma: Adın ilk 3 harfi + Soyadın son 2 harfi + 2025
                    string dogrulamaKodu = ad.Substring(0, 3).ToLower() + soyad.Substring(soyad.Length - 2).ToLower() + "2025";
                    // Yeni kullanıcı kaydı
                    string insertQuery = "INSERT INTO Kullanicilar (KullaniciAdi, Email, Sifre, Ad, Soyad, DogrulamaKodu, AvatarYolu, IsAdmin, Dogrulandi) VALUES (@kullaniciAdi, @email, @sifre, @ad, @soyad, @dogrulamaKodu, @avatarYolu, 0, 0)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, DatabaseConnection.GetConnection()))
                    {
                        cmd.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@sifre", sifre);
                        cmd.Parameters.AddWithValue("@ad", ad);
                        cmd.Parameters.AddWithValue("@soyad", soyad);
                        cmd.Parameters.AddWithValue("@dogrulamaKodu", dogrulamaKodu);
                        cmd.Parameters.AddWithValue("@avatarYolu", avatarYolu);
                        cmd.ExecuteNonQuery();
                    }
                    // E-posta gönderme
                    new Mail().Send(email, "Doğrulama Kodu", $"Merhaba,\n\nKayıt işleminiz başarıyla başlatıldı. Lütfen aşağıdaki doğrulama kodunu girin:\n\n{dogrulamaKodu}\n\n2025");
                    MessageBox.Show("Kayıt başarıyla tamamlandı! Doğrulama kodu e-posta adresinize gönderildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Doğrulama kodu formuna yönlendir
                    FormDogrulamaKodu dogrulamaForm = new FormDogrulamaKodu(email, dogrulamaKodu);
                    dogrulamaForm.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kayıt olurken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    DatabaseConnection.CloseConnection();
                    loading.Close();
                }
            }
        }

        private void btnAvatarYukle_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string avatarPath = openFileDialog.FileName;
                txtAvatarYolu.Text = avatarPath;

                try
                {
                    picAvatar.Image = new Bitmap(avatarPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Resim yüklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lnkGirisYap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormKullaniciGiris loginForm = new FormKullaniciGiris();
            loginForm.Show();
            this.Hide();
        }

        private void FormKullaniciDogrulama_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormKullaniciGiris loginForm = new FormKullaniciGiris();
            loginForm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
} 