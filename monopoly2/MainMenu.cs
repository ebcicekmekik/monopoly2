using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace monopoly2
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            this.Text = "Monopoly - Ana Menü";
            this.Size = new Size(818, 390);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            // Ana başlık
            Label lblTitle = new Label
            {
                Text = "MONOPOLY",
                Font = new Font("Arial", 36, FontStyle.Bold),
                ForeColor = Color.DarkBlue,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 100
            };

            // Butonlar için panel
            Panel buttonPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20)
            };

            // Oyun başlat butonu
            Button btnPlay = CreateMenuButton("OYNA", Color.DarkGreen);
            btnPlay.Click += async (s, e) => 
            {
                // Yasaklı kontrolü
                bool yasakli = false;
                string kullaniciAdi = Properties.Settings.Default.KullaniciAdi;
                using (var conn = new Microsoft.Data.SqlClient.SqlConnection(DatabaseConnection.GetConnection().ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT Yasakli FROM Kullanicilar WHERE KullaniciAdi = @kullaniciAdi";
                    using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                        var result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                            yasakli = Convert.ToBoolean(result);
                    }
                }
                if (yasakli)
                {
                    MessageBox.Show("Hesabınız banlanmıştır, oyuna giremezsiniz. Lütfen admin ile iletişime geçin.", "Banlı Hesap", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Oyun formunu aç
                using (var loading = new LoadingForm())
                {
                    loading.LoadingMessage = "Oyun Açılıyor...";
                    loading.LoadingImage = Image.FromFile("Çiçekmekik.png");
                    loading.Show();
                    loading.Refresh();
                    await System.Threading.Tasks.Task.Delay(2000);
                    FormMonopoly gameForm = new FormMonopoly();
                    gameForm.Show();
                    this.Hide();
                }
            };

            // Dilek/Şikayet/Öneri butonu
            Button btnFeedback = CreateMenuButton("DİLEK/ŞİKAYET/ÖNERİ", Color.DarkOrange);
            btnFeedback.Click += (s, e) => 
            {
                // Feedback formunu aç
                var feedbackForm = new Feedback(Properties.Settings.Default.KullaniciEmail);
                feedbackForm.Show();
                this.Hide();
            };

            // Skorlar butonu
            Button btnScores = CreateMenuButton("SKORLAR", Color.Purple);
            btnScores.Click += (s, e) => 
            {
                // Skorlar formunu aç
                FormSkorlar scoresForm = new FormSkorlar();
                scoresForm.Show();
                this.Hide();
            };

            // Ayarlar butonu
            Button btnSettings = CreateMenuButton("\nHAKKIMIZDA/NASIL OYNANIR", Color.DarkBlue);
            btnSettings.Click += (s, e) => 
            {
                // Ayarlar formunu aç
                FormBizeUlasin_Hakkimizda settingsForm = new FormBizeUlasin_Hakkimizda();
                settingsForm.Show();
                this.Hide();
            };

            // Çıkış butonu
            Button btnExit = CreateMenuButton("ÇIKIŞ", Color.DarkRed);
            btnExit.Click += (s, e) => Application.Exit();

            // Butonları panele ekle
            buttonPanel.Controls.Add(btnPlay);
            buttonPanel.Controls.Add(btnFeedback);
            buttonPanel.Controls.Add(btnScores);
            buttonPanel.Controls.Add(btnSettings);
            buttonPanel.Controls.Add(btnExit);

            // Form kontrollerini ekle
            this.Controls.Add(lblTitle);
            this.Controls.Add(buttonPanel);

            // Form kapatıldığında uygulamayı kapat
            this.FormClosing += (s, e) => Application.Exit();
        }

        private Button CreateMenuButton(string text, Color color)
        {
            Button btn = new Button
            {
                Text = text,
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = color,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(300, 60),
                Margin = new Padding(10),
                Dock = DockStyle.Top
            };

            // Hover efekti
            btn.MouseEnter += (s, e) => btn.BackColor = ControlPaint.Light(color);
            btn.MouseLeave += (s, e) => btn.BackColor = color;

            return btn;
        }
    }
} 