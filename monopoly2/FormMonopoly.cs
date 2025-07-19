using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace monopoly2
{
    public partial class FormMonopoly : Form
    {
        private List<Kare> kareler;
        private List<Oyuncu> oyuncular;
        private int aktifOyuncuIndex;
        private Random random;
        private Dictionary<int, Point> konumlar;
        private const int boardSize = 800;  // Board boyutunu 600'den 800'e çıkardım
        private PictureBox picZar1;
        private PictureBox picZar2;
        private Button btnSoruEvet;
        private Button btnSoruHayir;
        private Action<bool> soruCallback;
        private Panel pnlSoruCevap;
        private Label lblSoruCevap;

        public FormMonopoly()
        {
            InitializeComponent();
            random = new Random();

            // Initialize non-nullable fields to fix CS8618 warnings
            kareler = new List<Kare>();
            oyuncular = new List<Oyuncu>();
            konumlar = new Dictionary<int, Point>();

            // Initialize dice PictureBoxes
            picZar1 = new PictureBox();
            picZar2 = new PictureBox();
            picZar1.Size = new Size(50, 50);
            picZar2.Size = new Size(50, 50);
            picZar1.Location = new Point(lblZar.Location.X, lblZar.Location.Y + 30);
            picZar2.Location = new Point(lblZar.Location.X + 60, lblZar.Location.Y + 30);
            this.Controls.Add(picZar1);
            this.Controls.Add(picZar2);

            pnlSoruCevap = new Panel();
            pnlSoruCevap.Size = new Size(350, 120);
            pnlSoruCevap.Location = new Point(150, 570);
            pnlSoruCevap.BackColor = Color.WhiteSmoke;
            pnlSoruCevap.BorderStyle = BorderStyle.FixedSingle;
            pnlSoruCevap.Visible = false;

            lblSoruCevap = new Label();
            lblSoruCevap.AutoSize = false;
            lblSoruCevap.Size = new Size(330, 50);
            lblSoruCevap.Location = new Point(10, 10);
            lblSoruCevap.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblSoruCevap.TextAlign = ContentAlignment.MiddleCenter;

            btnSoruEvet = new Button();
            btnSoruEvet.Text = "Evet";
            btnSoruEvet.Size = new Size(80, 30);
            btnSoruEvet.Location = new Point(40, 70);
            btnSoruEvet.Visible = false;
            btnSoruEvet.Click += (s, e) => { pnlSoruCevap.Visible = false; soruCallback?.Invoke(true); };

            btnSoruHayir = new Button();
            btnSoruHayir.Text = "Hayır";
            btnSoruHayir.Size = new Size(80, 30);
            btnSoruHayir.Location = new Point(180, 70);
            btnSoruHayir.Visible = false;
            btnSoruHayir.Click += (s, e) => { pnlSoruCevap.Visible = false; soruCallback?.Invoke(false); };

            pnlSoruCevap.Controls.Add(lblSoruCevap);
            pnlSoruCevap.Controls.Add(btnSoruEvet);
            pnlSoruCevap.Controls.Add(btnSoruHayir);
            this.Controls.Add(pnlSoruCevap);

            KareleriOlustur();
            KonumlariOlustur();
            OyunculariOlustur();

            // Form boyutunu PictureBox'a göre ayarla
            this.Size = new Size(picBoard.Width + 250, picBoard.Height + 50);


            OyunTahtasiniCiz();
            OyunculariGuncelle();


            PictureBox picCicekmekik = new PictureBox();
            picCicekmekik.Image = Image.FromFile("monopoly.png");
            picCicekmekik.SizeMode = PictureBoxSizeMode.Zoom;
            picCicekmekik.BackColor = Color.Transparent;
            int kareSize = picBoard.Width / 9;
            picCicekmekik.Location = new Point(kareSize, kareSize);
            picCicekmekik.Size = new Size(kareSize * 7, kareSize * 7);
            picBoard.Controls.Add(picCicekmekik);
            picCicekmekik.BringToFront();
        }

        private void KareleriOlustur()
        {
            kareler = new List<Kare>
            {
                // Alt sıra (soldan sağa, görseldeki gibi)
                new Kare("Başlangıç", 0, 0),// 0 - sol alt köşe
                new Kare("Levent", 300, 32),      // 1
                new Kare("Su Dağıtım", 150, 15),  // 2
                new Kare("Maslak", 280, 30),      // 3
                new Kare("Beşiktaş", 280, 30),    // 4
                new Kare("Bakırköy Garı", 200, 25), // 5
                new Kare("Polis", 0, 0),      // 6 (Sirkeci ile yer değiştirildi)

                // Sol sıra (yukarıdan aşağı, görseldeki gibi)
                new Kare("Akatlar", 350, 40),     // 7 - sol üst köşe
                new Kare("Halkalı Garı", 200, 25), // 8
                new Kare("Köstebek", 0, 0),           // 9
                new Kare("Ulus", 400, 50),        // 10
                new Kare("Lüks Vergisi", -200, 0), // 11
                new Kare("Nişantaşı", 400, 50),   // 12
                new Kare("Sirkeci", 260, 28),     // 13 (Başlangıç ile yer değiştirildi)

                // Üst sıra (soldan sağa, görseldeki gibi)
                new Kare("Taksim", 100, 10),      // 14 - sol üst köşe
                new Kare("Haydarpaşa Garı", 200, 25), // 15
                new Kare("Kadıköy", 120, 15),     // 16
                new Kare("Gelir Vergisi", -100, 0), // 17
                new Kare("Beşiktaş", 120, 15),    // 18
                new Kare("Mecidiyeköy", 140, 17), // 19
                new Kare("Hapishane", 0, 0),      // 20 - sağ üst köşe

                // Sağ sıra (aşağıdan yukarı, görseldeki gibi)
                new Kare("Bedava Park", 0, 0),    // 21 - sağ üst köşe
                new Kare("Karaköy", 220, 24),     // 22
                new Kare("Unkapanı", 200, 22),    // 23
                new Kare("Flappy Bird", 0, 0),      // 24
                new Kare("Eminönü", 200, 22),     // 25
                new Kare("Sirkeci Garı", 200, 25), // 26
                new Kare("Beyoğlu", 180, 20)      // 27 - sağ alt köşe
            };
        }

        private void KonumlariOlustur()
        {
            konumlar = new Dictionary<int, Point>();
            int kareSize = boardSize / 9; // 7 kare + 2 köşe için 9 parçaya böl

            // Alt sıra (soldan sağa, 0-6)
            for (int i = 0; i <= 6; i++)
            {
                konumlar[i] = new Point(
                    i * kareSize,
                    boardSize - kareSize
                );
            }

            // Sol sıra (yukarıdan aşağı, 7-13) - bir kare daha yukarı kaydır
            for (int i = 7; i <= 13; i++)
            {
                konumlar[i] = new Point(
                    0,
                    boardSize - ((i - 7 + 2) * kareSize)
                );
            }

            // Üst sıra (soldan sağa, 14-20)
            for (int i = 14; i <= 20; i++)
            {
                konumlar[i] = new Point(
                    (i - 14) * kareSize,
                    0
                );
            }

            // Sağ sıra (aşağıdan yukarı, 21-27) - hapishane altına hizala
            for (int i = 21; i <= 27; i++)
            {
                konumlar[i] = new Point(
                    6 * kareSize,
                    (i - 21 + 1) * kareSize
                );
            }
        }

        private void OyunTahtasiniCiz()
        {
            if (kareler == null || konumlar == null)
            {
                MessageBox.Show("Oyun tahtası oluşturulamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int kareSize = boardSize / 11;

            Bitmap board = new Bitmap(boardSize, boardSize);
            using (Graphics g = Graphics.FromImage(board))
            {
                g.Clear(Color.White);
                g.DrawRectangle(Pens.Black, 0, 0, boardSize - 1, boardSize - 1);

                foreach (var konum in konumlar)
                {
                    if (konum.Key < kareler.Count)
                    {
                        Rectangle kareRect = new Rectangle(konum.Value.X, konum.Value.Y, kareSize, kareSize);
                        g.DrawRectangle(Pens.Black, kareRect);

                        Kare kare = kareler[konum.Key];

                        // Karenin rengini belirle
                        Color kareRengi = Color.White;

                        // Mekan gruplarına göre renk ataması
                        if (kare.Fiyat > 0)
                        {
                            // İstasyonlar - Gri
                            if (kare.Ad.Contains("Garı"))
                            {
                                kareRengi = Color.Silver;
                            }
                            // Hizmetler - Sarı
                            else if (kare.Ad.Contains("İdaresi") || kare.Ad.Contains("Dağıtım"))
                            {
                                kareRengi = Color.Gold;
                            }
                            // Kahverengi grup (Taksim, Nişantaşı)
                            else if (kare.Fiyat == 100)
                            {
                                kareRengi = Color.SaddleBrown;
                            }
                            // Mor grup (Kadıköy, Beşiktaş, Mecidiyeköy)
                            else if (kare.Fiyat >= 120 && kare.Fiyat <= 140)
                            {
                                kareRengi = Color.Purple;
                            }
                            // Pembe grup (Şişli, Harbiye, Beyoğlu)
                            else if (kare.Fiyat >= 160 && kare.Fiyat <= 180)
                            {
                                kareRengi = Color.DeepPink;
                            }
                            // Turuncu grup (Eminönü, Unkapanı, Karaköy)
                            else if (kare.Fiyat >= 200 && kare.Fiyat <= 220)
                            {
                                kareRengi = Color.DarkOrange;
                            }
                            // Kırmızı grup (Aksaray, Sultanahmet, Sirkeci)
                            else if (kare.Fiyat >= 240 && kare.Fiyat <= 260)
                            {
                                kareRengi = Color.Crimson;
                            }
                            // Yeşil grup (Beşiktaş, Maslak, Levent)
                            else if (kare.Fiyat >= 280 && kare.Fiyat <= 300)
                            {
                                kareRengi = Color.ForestGreen;
                            }
                            // Mavi grup (Bebek, Etiler, Akatlar)
                            else if (kare.Fiyat >= 320 && kare.Fiyat <= 350)
                            {
                                kareRengi = Color.RoyalBlue;
                            }
                            // Lacivert grup (Ulus, Nişantaşı)
                            else if (kare.Fiyat == 400)
                            {
                                kareRengi = Color.MidnightBlue;
                            }
                        }

                        // Karenin üst kısmını renklendir
                        using (SolidBrush brush = new SolidBrush(kareRengi))
                        {
                            g.FillRectangle(brush, kareRect.X, kareRect.Y, kareRect.Width, kareRect.Height / 4);
                        }

                        if (kare.Sahip.HasValue)
                        {
                            using (SolidBrush brush = new SolidBrush(oyuncular[kare.Sahip.Value].Renk))
                            {
                                g.FillRectangle(brush, kareRect.X + 2, kareRect.Y + kareRect.Height - 7, kareRect.Width - 4, 5);
                            }
                        }

                        // Sadece kare adını yaz
                        using (Font font = new Font("Arial", 8))
                        {
                            StringFormat sf = new StringFormat();
                            sf.Alignment = StringAlignment.Center;
                            sf.LineAlignment = StringAlignment.Center;

                            RectangleF textRect = new RectangleF(
                                kareRect.X,
                                kareRect.Y + (kareRect.Height / 4),
                                kareRect.Width,
                                kareRect.Height * 3 / 4
                            );

                            // Özel kareler için farklı renk kullan
                            Brush textBrush = Brushes.Black;
                            if (kare.Fiyat < 0)
                            {
                                textBrush = Brushes.Red;
                            }
                            if (kare.Ad == "Köstebek" || kare.Ad == "Flappy Bird")
                            {
                                textBrush = Brushes.Blue;
                            }
                            g.DrawString(kare.Ad, font, textBrush, textRect, sf);
                        }
                    }
                }
            }
            picBoard.Image = board;
            OyunculariGuncelle();
        }

        private void OyunculariGuncelle()
        {
            int kareSize = boardSize / 9;
            for (int i = 0; i < oyuncular.Count; i++)
            {
                Oyuncu oyuncu = oyuncular[i];
                Point konum = konumlar[oyuncu.Konum];
                PictureBox oyuncuPic = (i == 0) ? picOyuncu1 : picOyuncu2;
                oyuncuPic.Size = new Size(35, 35);
                oyuncuPic.BackColor = oyuncu.Renk;

                int oyuncuX = konum.X;
                int oyuncuY = konum.Y;

                // Oyuncular başlangıç karesinin tam üstünde ve yan yana başlasın
                if (oyuncu.Konum == 0) // Başlangıç karesi alt sırada en sağda (index 6)
                {
                    oyuncuX = konum.X + (i == 0 ? 5 : 45); // Yan yana göster
                    oyuncuY = konum.Y + kareSize / 2 - oyuncuPic.Height / 2;
                }
                else if (oyuncu.Konum <= 0)
                {
                    oyuncuX = konum.X + (i == 0 ? 10 : 45);
                    oyuncuY = boardSize - kareSize + 15;
                }
                else if (oyuncu.Konum <= 13)
                {
                    oyuncuX = 10 + (i == 0 ? 0 : 35);
                    oyuncuY = konum.Y + 15;
                }
                else if (oyuncu.Konum <= 20)
                {
                    oyuncuX = konum.X + (i == 0 ? 10 : 45);
                    oyuncuY = 15;
                }
                else
                {
                    oyuncuX = 6 * kareSize + (i == 0 ? 10 : 45);
                    oyuncuY = konum.Y + 15;
                }
                oyuncuPic.Location = new Point(oyuncuX, oyuncuY);
                oyuncuPic.Visible = true;
                oyuncuPic.BringToFront();
            }
        }

        private void OyunculariOlustur()
        {
            string kullaniciAdi = Properties.Settings.Default.KullaniciAdi;
            oyuncular = new List<Oyuncu>
            {
                new Oyuncu(kullaniciAdi, Color.Blue, 1500),
                new Oyuncu("Rakip", Color.Red, 1500)
            };

            // Oyuncuların başlangıç konumlarını Başlangıç karesinin indeksine ayarla
            foreach (var oyuncu in oyuncular)
            {
                oyuncu.Konum = 6; // Başlangıç karesi (alt sırada en sağda)
            }

            aktifOyuncuIndex = 0;
            lblSira.Text = $"Sıra: {oyuncular[aktifOyuncuIndex].Ad}";
            lblPara1.Text = $"Para: {oyuncular[0].Para}₺";
            lblPara2.Text = $"Para: {oyuncular[1].Para}₺";
            lblZar.Text = "Zar: ";
            lblKonum.Text = "Konum: Başlangıç";

            // İlk konumlandırmayı yap
            OyunculariGuncelle();
        }

        private void btnZarAt_Click(object sender, EventArgs e)
        {
            try
            {
                int zar1 = random.Next(1, 7);
                int zar2 = random.Next(1, 7);
                int toplamZar = zar1 + zar2;

                var zarImage = ZarGorselleri.GetZarGorseli(zar1, zar2);
                if (zarImage != null)
                {
                    pbx_Zar.Image = zarImage;
                    pbx_Zar.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbx_Zar.Visible = true;
                    pbx_Zar.BringToFront();
                }
                else
                {
                    pbx_Zar.Image = null; // Resim yoksa boş bırak
                    MessageBox.Show($"Resim bulunamadı: {System.IO.Path.GetFullPath($"zarlar/{zar1}_{zar2}.png")}");
                }

                lblZar.Text = $"Zar: {zar1} + {zar2} = {toplamZar}";

                Oyuncu aktifOyuncu = oyuncular[aktifOyuncuIndex];
                aktifOyuncu.Konum = (aktifOyuncu.Konum + toplamZar) % kareler.Count;

                Kare gelenKare = kareler[aktifOyuncu.Konum];
                lblKonum.Text = $"Konum: {gelenKare.Ad}";

                if (gelenKare.Fiyat > 0 && !gelenKare.Sahip.HasValue)
                {
                    SoruSor($"{gelenKare.Ad} satın almak ister misiniz? Fiyat: {gelenKare.Fiyat}₺", (evet) =>
                    {
                        if (evet)
                        {
                            if (aktifOyuncu.Para >= gelenKare.Fiyat)
                            {
                                aktifOyuncu.Para -= gelenKare.Fiyat;
                                gelenKare.Sahip = aktifOyuncuIndex;
                                OyunTahtasiniCiz();
                                SoruCevapGoster($"{gelenKare.Ad} satın alındı!");
                            }
                            else
                            {
                                SoruCevapGoster("Yeterli paranız yok!");
                            }
                        }
                    });
                }
                else if (gelenKare.Sahip.HasValue && gelenKare.Sahip.Value != aktifOyuncuIndex)
                {
                    int kira = gelenKare.Kira;
                    aktifOyuncu.Para -= kira;
                    oyuncular[gelenKare.Sahip.Value].Para += kira;
                    SoruCevapGoster($"{oyuncular[gelenKare.Sahip.Value].Ad}'a {kira}₺ kira ödediniz!");
                }
                else if (gelenKare.Ad == "Gelir Vergisi")
                {
                    aktifOyuncu.Para += gelenKare.Fiyat;
                    SoruCevapGoster($"Gelir vergisi ödediniz: {-gelenKare.Fiyat}₺");
                }
                // Şans kutusu
                else if (gelenKare.Ad == "Köstebek")
                {
                    ShowLoadingAndRunGame("Köstebek Oyununa geçiş yapılıyor", Image.FromFile("kstebek.png"), () =>
                    {
                        using (var kostebekForm = new FormKostebek())
                        {
                            if (kostebekForm.ShowDialog() == DialogResult.OK)
                            {
                                int kazanilanPuan = kostebekForm.Puan;
                                aktifOyuncu.Para += kazanilanPuan;
                                MessageBox.Show($"Köstebek oyunundan kazandığınız puan: {kazanilanPuan}₺ paranıza yansıdı!", "Köstebek", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    });
                }
                // Kamu Fonu kutusu
                else if (gelenKare.Ad == "Flappy Bird")
                {
                    ShowLoadingAndRunGame("Flappy Bird Oyununa geçiş yapılıyor", Image.FromFile("flappy.png"), () =>
                    {
                        using (var flappyForm = new FormFlappyBird())
                        {
                            if (flappyForm.ShowDialog() == DialogResult.OK)
                            {
                                int kazanilanPuan = flappyForm.Score * 10;
                                aktifOyuncu.Para += kazanilanPuan;
                                MessageBox.Show($"Flappy Bird oyunundan aldığınız puanın 10 katı ({flappyForm.Score} x 10 = {kazanilanPuan}₺) paranıza eklendi!", "Flappy Bird", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    });
                }

                lblPara1.Text = $"Para: {oyuncular[0].Para}₺";
                lblPara2.Text = $"Para: {oyuncular[1].Para}₺";
                OyunculariGuncelle();

                if (aktifOyuncu.Para < 0)
                {
                    int kazananIndex = (aktifOyuncuIndex + 1) % 2;
                    SoruCevapGoster($"{aktifOyuncu.Ad} iflas etti! Kazanan: {oyuncular[kazananIndex].Ad}");

                    try
                    {
                        DatabaseConnection.OpenConnection();
                        string query = @"INSERT INTO Oyunlar (Email, Skor, Tarih, GunlukSkor, AylikSkor, YillikSkor) 
                                       VALUES (@email, @skor, @tarih, 
                                       CASE WHEN CAST(@tarih AS DATE) = CAST(GETDATE() AS DATE) THEN @skor ELSE NULL END,
                                       CASE WHEN MONTH(@tarih) = MONTH(GETDATE()) AND YEAR(@tarih) = YEAR(GETDATE()) THEN @skor ELSE NULL END,
                                       CASE WHEN YEAR(@tarih) = YEAR(GETDATE()) THEN @skor ELSE NULL END)";
                        using (SqlCommand cmd = new SqlCommand(query, DatabaseConnection.GetConnection()))
                        {
                            cmd.Parameters.AddWithValue("@email", oyuncular[kazananIndex].Ad);
                            cmd.Parameters.AddWithValue("@skor", oyuncular[kazananIndex].Para);
                            cmd.Parameters.AddWithValue("@tarih", DateTime.Now);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Skor kaydedilirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        DatabaseConnection.CloseConnection();
                    }

                    this.Close();
                    return;
                }

                if (zar1 != zar2)
                {
                    aktifOyuncuIndex = (aktifOyuncuIndex + 1) % 2;
                    lblSira.Text = $"Sıra: {oyuncular[aktifOyuncuIndex].Ad}";
                }
                else
                {
                    SoruCevapGoster("Çift attınız! Tekrar zar atabilirsiniz.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Zar atma sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowLoadingAndRunGame(string message, Image loadingImage, Action gameAction)
        {
            using (var loadingForm = new LoadingForm())
            {
                loadingForm.LoadingMessage = message;
                loadingForm.LoadingImage = loadingImage;
                loadingForm.Show();
                Application.DoEvents();
                System.Threading.Thread.Sleep(3000); // 3 saniye bekle
                loadingForm.Close();
                gameAction();
            }
        }

        private void SoruCevapGoster(string mesaj)
        {
            lblSoruCevap.Text = mesaj;
            btnSoruEvet.Visible = false;
            btnSoruHayir.Visible = false;
            pnlSoruCevap.Visible = true;
            pnlSoruCevap.BringToFront();
        }

        private void SoruSor(string soru, Action<bool> callback)
        {
            lblSoruCevap.Text = soru;
            btnSoruEvet.Visible = true;
            btnSoruHayir.Visible = true;
            pnlSoruCevap.Visible = true;
            pnlSoruCevap.BringToFront();
            soruCallback = callback;
        }

        private void btn_cikis_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }

    public class Kare
    {
        public string Ad { get; set; }
        public int Fiyat { get; set; }
        public int Kira { get; set; }
        public int? Sahip { get; set; }

        public Kare(string ad, int fiyat, int kira)
        {
            Ad = ad;
            Fiyat = fiyat;
            Kira = kira;
            Sahip = null;
        }
    }

    public class Oyuncu
    {
        public string Ad { get; set; }
        public Color Renk { get; set; }
        public int Para { get; set; }
        public int Konum { get; set; }

        public Oyuncu(string ad, Color renk, int baslangicParasi)
        {
            Ad = ad;
            Renk = renk;
            Para = baslangicParasi;
            Konum = 0;
        }
    }
} 