#pragma warning disable CA1416
using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using monopoly2;

namespace monopoly2
{
    public partial class Feedback : Form
    {
        // Giriş yapan kullanıcının emaili bu property ile alınacak
        public string KullaniciEmail { get; set; }

        public Feedback(string kullaniciEmail = "")
        {

            this.Text = "Dilek/Şikayet/Öneri";
            this.Size = new Size(600, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
            this.KullaniciEmail = kullaniciEmail;

            // Başlık
            Label lblTitle = new Label
            {
                Text = "Dilek/Şikayet/Öneri",
                Font = new Font("Arial", 20, FontStyle.Bold),
                ForeColor = Color.DarkBlue,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 50
            };

            // Kategori label
            Label lblCategory = new Label
            {
                Text = "Kategori:",
                Font = new Font("Arial", 12, FontStyle.Bold),
                Location = new Point(120, 70),
                AutoSize = true
            };

            // Kategori ComboBox
            ComboBox cmbCategory = new ComboBox
            {
                Location = new Point(220, 65),
                Size = new Size(200, 30),
                Font = new Font("Arial", 12),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbCategory.Items.AddRange(new string[] { "Dilek", "Şikayet", "Öneri" });

            // Mesaj alanı
            Label lblMessage = new Label
            {
                Text = "Mesajınız:",
                Font = new Font("Arial", 12, FontStyle.Bold),
                Location = new Point(20, 120),
                AutoSize = true
            };

            TextBox txtMessage = new TextBox
            {
                Location = new Point(20, 150),
                Size = new Size(540, 200),
                Multiline = true,
                Font = new Font("Arial", 12),
                ScrollBars = ScrollBars.Vertical
            };

            // Gönder butonu
            Button btnSubmit = new Button
            {
                Text = "GÖNDER",
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.DarkGreen,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(200, 40),
                Location = new Point(180, 370)
            };

            // Ana menüye dön butonu
            Button btnBack = new Button
            {
                Text = "ANA MENÜ",
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.DarkBlue,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(200, 40),
                Location = new Point(180, 420)
            };

            // Gönder butonu tıklama olayı
            btnSubmit.Click += async (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtMessage.Text))
                {
                    MessageBox.Show("Lütfen bir mesaj giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbCategory.SelectedIndex == -1)
                {
                    MessageBox.Show("Lütfen bir kategori seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var loading = new LoadingForm())
                {
                    loading.LoadingMessage = "Gönderiliyor...";
                    try
                    {
                        loading.LoadingImage = Image.FromFile("Çiçekmekik.png");
                    }
                    catch { /* Dosya yoksa hata verme */ }
                    loading.Show();
                    loading.Refresh();
                    await System.Threading.Tasks.Task.Delay(2000);
                    try
                    {
                        DatabaseConnection.OpenConnection();
                        string query = "INSERT INTO Mesajlar (Kategori, Mesaj, Tarih, Email) VALUES (@kategori, @mesaj, @tarih, @email)";
                        using (SqlCommand cmd = new SqlCommand(query, DatabaseConnection.GetConnection()))
                        {
                            cmd.Parameters.AddWithValue("@kategori", cmbCategory.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@mesaj", txtMessage.Text);
                            cmd.Parameters.AddWithValue("@tarih", DateTime.Now);
                            cmd.Parameters.AddWithValue("@email", this.KullaniciEmail);
                            cmd.ExecuteNonQuery();
                        }

                        // Admin'e mail gönder
                        new Mail().Send("ebcaks@gmail.com", $"Yeni {cmbCategory.SelectedItem} Mesajı", $"Kategori: {cmbCategory.SelectedItem}\nMesaj: {txtMessage.Text}\nTarih: {DateTime.Now}\nKullanıcı Email: {this.KullaniciEmail}");

                        MessageBox.Show("Mesajınız başarıyla gönderildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMessage.Clear();
                        cmbCategory.SelectedIndex = -1;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Mesaj gönderilirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        DatabaseConnection.CloseConnection();
                        loading.Close();
                    }
                }
            };

            // Ana menüye dön butonu tıklama olayı
            btnBack.Click += (s, e) =>
            {
                MainMenu mainMenu = new MainMenu();
                mainMenu.Show();
                this.Close();
            };

            // Form kontrollerini ekle
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblCategory);
            this.Controls.Add(cmbCategory);
            this.Controls.Add(lblMessage);
            this.Controls.Add(txtMessage);
            this.Controls.Add(btnSubmit);
            this.Controls.Add(btnBack);
        }

        private void InitializeComponent()
        {

        }
    }
} 