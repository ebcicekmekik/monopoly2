using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace monopoly2
{
    public partial class FormKullaniciGiris : Form
    {
        public FormKullaniciGiris()
        {
            InitializeComponent();
            // Beni Hatırla özelliği için kayıtlı bilgileri yükle
            if (Properties.Settings.Default.BeniHatirla)
            {
                txtKullaniciAdi.Text = Properties.Settings.Default.KullaniciAdi;
                txtSifre.Text = Properties.Settings.Default.Sifre;
                chkBeniHatirla.Checked = true;
            }
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text.Trim();
            string sifre = txtSifre.Text.Trim();

            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Kullanıcı adı ve şifre alanları boş bırakılamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                DatabaseConnection.OpenConnection();

                // Kullanıcı adı kontrolü
                string checkQuery = "SELECT COUNT(*) FROM Kullanicilar WHERE KullaniciAdi = @kullaniciAdi";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, DatabaseConnection.GetConnection()))
                {
                    checkCmd.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                    int userCount = (int)checkCmd.ExecuteScalar();

                    if (userCount == 0)
                    {
                        MessageBox.Show("Bu kullanıcı adı ile kayıtlı kullanıcı bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Şifre kontrolü
                string query = "SELECT Id, KullaniciAdi, IsAdmin, Email FROM Kullanicilar WHERE KullaniciAdi = @kullaniciAdi AND Sifre = @sifre";
                using (SqlCommand cmd = new SqlCommand(query, DatabaseConnection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                    cmd.Parameters.AddWithValue("@sifre", sifre);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                int userId = Convert.ToInt32(reader["Id"]);
                                string userName = reader["KullaniciAdi"]?.ToString() ?? string.Empty;
                                bool isAdmin = Convert.ToBoolean(reader["IsAdmin"]);
                                string userEmail = "";
                                // Email alanı varsa oku
                                try { userEmail = reader["Email"].ToString(); } catch { }

                                // Beni Hatırla
                                if (chkBeniHatirla.Checked)
                                {
                                    Properties.Settings.Default.KullaniciAdi = kullaniciAdi;
                                    Properties.Settings.Default.Sifre = sifre;
                                    Properties.Settings.Default.BeniHatirla = true;
                                    Properties.Settings.Default.KullaniciEmail = userEmail;
                                    Properties.Settings.Default.Save();
                                }
                                else
                                {
                                    Properties.Settings.Default.KullaniciAdi = "";
                                    Properties.Settings.Default.Sifre = "";
                                    Properties.Settings.Default.BeniHatirla = false;
                                    Properties.Settings.Default.KullaniciEmail = userEmail;
                                    Properties.Settings.Default.Save();
                                }

                                MessageBox.Show($"Giriş başarılı!\nHoş geldiniz, {userName}!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                if (isAdmin)
                                {
                                    Admin adminPanel = new Admin();
                                    adminPanel.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    MainMenu mainMenu = new MainMenu();
                                    mainMenu.Show();
                                    this.Hide();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Giriş yapılırken bir hata oluştu:\n\nHata Mesajı: {ex.Message}\n\n" +
                              $"Hata Detayı: {ex.StackTrace}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
        }

        private void lnkKayitOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormKullaniciDogrulama kayitForm = new FormKullaniciDogrulama();
            kayitForm.Show();
            this.Hide();
        }

        private void lnkSifremiUnuttum_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormSifreSifirlaKodu sifreSifirlaKoduForm = new FormSifreSifirlaKodu();
            sifreSifirlaKoduForm.Show();
            this.Hide();
        }

        private void FormKullaniciGiris_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
} 