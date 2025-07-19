using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using monopoly2;

namespace monopoly2
{
    public partial class FormSifreDegistir : Form
    {
        private string email;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        public FormSifreDegistir(string email)
        {
            InitializeComponent();
            this.email = email;
        }

        private void FormSifreDegistir_Load(object sender, EventArgs e)
        {
            txtYeniSifre.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, txtYeniSifre.Width, txtYeniSifre.Height, 15, 15));
            txtYeniSifreTekrar.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, txtYeniSifreTekrar.Width, txtYeniSifreTekrar.Height, 15, 15));
        }

        private async void btnSifreDegistir_Click(object sender, EventArgs e)
        {
            string yeniSifre = txtYeniSifre.Text;
            string yeniSifreTekrar = txtYeniSifreTekrar.Text;

            if (string.IsNullOrEmpty(yeniSifre) || string.IsNullOrEmpty(yeniSifreTekrar))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (yeniSifre != yeniSifreTekrar)
            {
                MessageBox.Show("Şifreler eşleşmiyor!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var loading = new LoadingForm())
            {
                loading.LoadingMessage = "Gönderiliyor...";
                loading.Show();
                loading.Refresh();
                await Task.Delay(2000);
                try
                {
                    DatabaseConnection.OpenConnection();
                    string updateQuery = "UPDATE Kullanicilar SET Sifre = @sifre WHERE Email = @email";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, DatabaseConnection.GetConnection()))
                    {
                        cmd.Parameters.AddWithValue("@sifre", yeniSifre);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Şifreniz başarıyla değiştirildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Bilgilendirme maili gönder
                    new Mail().Send(email, "Şifre Değişikliği Başarılı", "Şifreniz başarıyla değiştirildi. Şifrenizi girip oyuna başlayabilirsiniz!");
                    
                    // Giriş formuna yönlendir
                    FormKullaniciGiris loginForm = new FormKullaniciGiris();
                    loginForm.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Şifre değiştirme sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    DatabaseConnection.CloseConnection();
                    loading.Close();
                }
            }
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