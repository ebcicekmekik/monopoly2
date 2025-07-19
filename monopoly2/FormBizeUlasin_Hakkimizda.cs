using System;
using Microsoft.Data.SqlClient;
using System.Net.Mail;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Media;



namespace monopoly2
{
    public partial class FormBizeUlasin_Hakkimizda : Form
    {
        public string KullaniciEmail { get; set; } // Giriş yapan kullanıcının emaili buraya atanacak
        private ToolTip toolTip1;

        private SoundPlayer nasilOynanirPlayer = new SoundPlayer("C:\\Users\\Eren Berat\\Downloads\\nasiloynanir.wav");

        public FormBizeUlasin_Hakkimizda()
        {
            InitializeComponent();
            toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;


            btn_geriDon.BringToFront();
            btn_geriDon.BackColor = System.Drawing.Color.White;
            toolTip1.SetToolTip(btn_geriDon, "Geri Dön");
        }

        public FormBizeUlasin_Hakkimizda(Form previousForm = null, string kullaniciEmail = "") : this()
        {
            this.KullaniciEmail = kullaniciEmail;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabNasilOynanir)
            {
                try
                {
                    nasilOynanirPlayer.Stop(); // Önceki çalmayı durdur
                    nasilOynanirPlayer.Play(); // WAV dosyasını çal
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ses dosyası çalınamadı: " + ex.Message);
                }
            }
            else
            {
                try { nasilOynanirPlayer.Stop(); } catch { }
            }
        }

        private void geriDonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            this.Hide();
        }

        private void btn_geriDon_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu1 = new MainMenu();
            mainMenu1.Show();
            this.Hide();
        }
    }
} 