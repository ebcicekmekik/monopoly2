using System;
using System.Windows.Forms;
using System.Media;
using System.IO;
using System.Runtime.Versioning;

namespace monopoly2
{
    [SupportedOSPlatform("windows")]
    public partial class FormLoading : Form
    {
        private System.Windows.Forms.Timer timer = null!;
        private int progress = 0;
        private SoundPlayer? soundPlayer;
        private DateTime startTime;

        public FormLoading()
        {
            InitializeComponent();
            InitializeLoadingForm();
        }

        private void InitializeLoadingForm()
        {
            // Form ayarları
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new System.Drawing.Size(400, 200);
            this.BackColor = System.Drawing.Color.White;

            // Progress Bar
            progressBar = new ProgressBar();
            progressBar.Location = new System.Drawing.Point(50, 80);
            progressBar.Size = new System.Drawing.Size(300, 30);
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.Maximum = 100;
            this.Controls.Add(progressBar);

            // Label
            Label label = new Label();
            label.Text = "Yükleniyor...";
            label.AutoSize = true;
            label.Location = new System.Drawing.Point(50, 40);
            label.Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold);
            this.Controls.Add(label);

            startTime = DateTime.Now;

            // Ses dosyasını yükle
            try
            {
                string soundPath = Path.Combine(Application.StartupPath, "Resources", "Eren_ses_Nesne.wav");
                if (File.Exists(soundPath))
                {
                    soundPlayer = new SoundPlayer(soundPath);
                    soundPlayer.Play();
                }
                else
                {
                    MessageBox.Show("Ses dosyası bulunamadı: " + soundPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ses dosyası yüklenirken hata oluştu: " + ex.Message);
            }

            // Timer ayarları
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 30; // 30ms aralıklarla güncelle
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            double elapsedSeconds = (DateTime.Now - startTime).TotalSeconds;
            
            if (elapsedSeconds >= 3.0) // 3 saniye
            {
                timer.Stop();
                if (soundPlayer != null)
                {
                    soundPlayer.Stop();
                    soundPlayer.Dispose();
                }
                this.Hide();
                FormKullaniciGiris loginForm = new FormKullaniciGiris();
                loginForm.Show();
            }
            else
            {
                // Progress bar'ı güncelle
                progress = (int)((elapsedSeconds / 3.0) * 100);
                if (progress > 100) progress = 100;
                progressBar.Value = progress;
            }
        }

        private ProgressBar progressBar = null!;
    }
} 