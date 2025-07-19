using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using monopoly2;

namespace monopoly2
{
    public partial class FormMesajCevapla : Form
    {
        private int mesajId;
        private string kullaniciEmail;
        private string kullaniciMesaj;

        public FormMesajCevapla(int mesajId, string kullaniciEmail, string kullaniciMesaj)
        {
            this.mesajId = mesajId;
            this.kullaniciEmail = kullaniciEmail;
            this.kullaniciMesaj = kullaniciMesaj;

            InitializeComponent();
            this.Text = "Mesajı Cevapla";
            this.Size = new System.Drawing.Size(500, 400);

            Label lblMesaj = new Label { Text = "Kullanıcı Mesajı:", Location = new System.Drawing.Point(20, 20), AutoSize = true };
            TextBox txtKullaniciMesaj = new TextBox { Text = kullaniciMesaj, Location = new System.Drawing.Point(20, 50), Size = new System.Drawing.Size(440, 80), Multiline = true, ReadOnly = true };
            Label lblCevap = new Label { Text = "Cevabınız:", Location = new System.Drawing.Point(20, 150), AutoSize = true };
            TextBox txtCevap = new TextBox { Location = new System.Drawing.Point(20, 180), Size = new System.Drawing.Size(440, 80), Multiline = true };
            Button btnGonder = new Button { Text = "CEVABI GÖNDER", Location = new System.Drawing.Point(150, 300), Size = new System.Drawing.Size(200, 40) };

            btnGonder.Click += (s, e) =>
            {
                using (var loading = new LoadingForm())
                {
                    loading.LoadingMessage = "Gönderiliyor...";
                    loading.Show();
                    loading.Refresh();
                    try
                    {
                        // Veritabanına cevabı kaydet
                        DatabaseConnection.OpenConnection();
                        string updateQuery = "UPDATE Mesajlar SET AdminCevap = @cevap WHERE Id = @id";
                        using (SqlCommand cmd = new SqlCommand(updateQuery, DatabaseConnection.GetConnection()))
                        {
                            cmd.Parameters.AddWithValue("@cevap", txtCevap.Text);
                            cmd.Parameters.AddWithValue("@id", mesajId);
                            cmd.ExecuteNonQuery();
                        }
                        DatabaseConnection.CloseConnection();

                        // Kullanıcıya mail gönder
                        new Mail().Send(kullaniciEmail, "Mesajınıza Yönetici Cevabı", txtCevap.Text);

                        MessageBox.Show("Cevabınız gönderildi ve kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    finally
                    {
                        loading.Close();
                    }
                }
            };

            this.Controls.Add(lblMesaj);
            this.Controls.Add(txtKullaniciMesaj);
            this.Controls.Add(lblCevap);
            this.Controls.Add(txtCevap);
            this.Controls.Add(btnGonder);
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // FormMesajCevapla
            // 
            ClientSize = new Size(282, 253);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormMesajCevapla";
            ResumeLayout(false);
        }
    }
} 