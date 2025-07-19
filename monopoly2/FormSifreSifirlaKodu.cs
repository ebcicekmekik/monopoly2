using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;

namespace monopoly2
{
    public partial class FormSifreSifirlaKodu : Form
    {
        private string dogrulamaKodu = "";
        private string email = "";


        public FormSifreSifirlaKodu(Form previousForm = null)
        {
            InitializeComponent();
        }

        private async void btnKoduGonder_Click(object sender, EventArgs e)
        {
            email = txtEmail.Text.Trim();
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Lütfen kayıtlı e-posta adresinizi giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var loading = new LoadingForm())
            {
                loading.LoadingMessage = "Gönderiliyor...";
                loading.Show();
                loading.Refresh();
                await Task.Delay(2000);
                // E-posta veritabanında var mı kontrolü
                try
                {
                    DatabaseConnection.OpenConnection();
                    string checkQuery = "SELECT COUNT(*) FROM Kullanicilar WHERE Email = @email";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, DatabaseConnection.GetConnection()))
                    {
                        checkCmd.Parameters.AddWithValue("@email", email);
                        int count = (int)checkCmd.ExecuteScalar();
                        if (count == 0)
                        {
                            MessageBox.Show("Bu e-posta ile kayıtlı kullanıcı bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // 5 haneli kod oluştur
                    Random rnd = new Random();
                    dogrulamaKodu = rnd.Next(10000, 99999).ToString();

                    // E-posta gönder
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com"))
                    {
                        smtp.Credentials = new NetworkCredential("ebcaks@gmail.com", "ijhd xhss cxuu wmde");
                        smtp.Port = 587;
                        smtp.EnableSsl = true;

                        MailMessage message = new MailMessage("ebcaks@gmail.com", email);
                        message.Subject = "Şifre Sıfırlama Kodu";
                        message.Body = $"Şifre sıfırlama için doğrulama kodunuz: {dogrulamaKodu}";
                        smtp.Send(message);
                    }

                    MessageBox.Show("Doğrulama kodu e-posta adresinize gönderildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtKoduGir.Enabled = true;
                    btnKoduDogrula.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kod gönderilirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    DatabaseConnection.CloseConnection();
                    loading.Close();
                }
            }
        }

        private void btnKoduDogrula_Click(object sender, EventArgs e)
        {
            if (txtKoduGir.Text.Trim() == dogrulamaKodu)
            {
                MessageBox.Show("Kod doğru! Şifre değiştirme ekranına yönlendiriliyorsunuz.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormSifreDegistir sifreDegistirForm = new FormSifreDegistir(email);
                sifreDegistirForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kod hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_GeriDon_Click(object sender, EventArgs e)
        {
            FormKullaniciGiris formKullaniciGiris = new FormKullaniciGiris();
            formKullaniciGiris.Show();
            this.Hide();
        }
    }
} 