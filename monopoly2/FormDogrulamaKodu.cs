using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using monopoly2;

namespace monopoly2
{
    public partial class FormDogrulamaKodu : Form
    {
        private string email;
        private string dogrulamaKodu;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        public FormDogrulamaKodu(string email, string dogrulamaKodu)
        {
            InitializeComponent();
            this.email = email;
            this.dogrulamaKodu = dogrulamaKodu;
           
        }

        private void FormDogrulamaKodu_Load(object sender, EventArgs e)
        {
            txtDogrulamaKodu.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, txtDogrulamaKodu.Width, txtDogrulamaKodu.Height, 15, 15));
        }

        private void btnDogrula_Click(object sender, EventArgs e)
        {
            string girilenKod = txtDogrulamaKodu.Text;

            if (string.IsNullOrEmpty(girilenKod))
            {
                MessageBox.Show("Lütfen doğrulama kodunu giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (girilenKod == dogrulamaKodu)
            {
                try
                {
                    using (var loading = new LoadingForm())
                    {
                        loading.LoadingMessage = "Gönderiliyor...";
                        loading.Show();
                        loading.Refresh();
                        DatabaseConnection.OpenConnection();
                        string updateQuery = "UPDATE Kullanicilar SET Dogrulandi = 1 WHERE Email = @email";
                        using (SqlCommand cmd = new SqlCommand(updateQuery, DatabaseConnection.GetConnection()))
                        {
                            cmd.Parameters.AddWithValue("@email", email);
                            cmd.ExecuteNonQuery();
                        }

                        // Bilgilendirme maili gönder
                        new Mail().Send(email, "Kayıt Başarılı", "Tebrikler! Kaydınız başarıyla tamamlandı. Artık oyuna giriş yapabilirsiniz.\n\nKeyifli oyunlar!");

                        MessageBox.Show("Doğrulama başarılı! Şimdi şifrenizi belirleyebilirsiniz.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Şifre değiştirme formuna yönlendir
                        FormSifreDegistir sifreDegistirForm = new FormSifreDegistir(email);
                        sifreDegistirForm.Show();
                        this.Hide();
                        loading.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Doğrulama sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    DatabaseConnection.CloseConnection();
                }
            }
            else
            {
                MessageBox.Show("Doğrulama kodu hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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