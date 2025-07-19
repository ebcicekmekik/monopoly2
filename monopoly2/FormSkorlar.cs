using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace monopoly2
{
    public partial class FormSkorlar : Form
    {
        private DataTable dtOyunlar;
        private ComboBox cmbSkorFiltre;
        private Label lblFiltre;
        private Button btnMaxSkor;
        private Button btnMinSkor;
        private Label lblMaxSkor;
        private Label lblMinSkor;
        private ListBox lstTop5;
        private DataGridView dgvScores;

        public FormSkorlar()
        {
            this.Text = "Oyun Skorları";
            this.Size = new Size(1200, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            // Başlık
            Label lblTitle = new Label
            {
                Text = "OYUN SKORLARI",
                Font = new Font("Arial", 24, FontStyle.Bold),
                ForeColor = Color.DarkBlue,
                TextAlign = ContentAlignment.TopCenter,
                Padding = new Padding(40, 0, 0, 0),
                Dock = DockStyle.Top,
                Height = 60
            };

            // Filtreleme kontrolleri için panel
            Panel filterPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                Padding = new Padding(10, 0, 10, 0),
                Margin = new Padding(0)
            };

            // Skor filtreleme
            lblFiltre = new Label
            {
                Text = "Skor Filtrele:",
                Location = new Point(10, 2),
                Size = new Size(80, 20)
            };

            cmbSkorFiltre = new ComboBox();
            cmbSkorFiltre.Items.AddRange(new string[] { "Tümü", "Günlük", "Aylık", "Yıllık" });
            cmbSkorFiltre.Location = new Point(100, 2);
            cmbSkorFiltre.Size = new Size(100, 25);
            cmbSkorFiltre.DropDownStyle = ComboBoxStyle.DropDownList;
            if (cmbSkorFiltre.Items.Count > 0)
                cmbSkorFiltre.SelectedIndex = 0;
            cmbSkorFiltre.SelectedIndexChanged += (s, e) => VerileriYukle();

            btnMaxSkor = new Button
            {
                Text = "",
                Location = new Point(390, 2),
                Size = new Size(40, 25),
                BackgroundImage = Image.FromFile("max.png"),
                BackgroundImageLayout = ImageLayout.Zoom
            };
            btnMaxSkor.Click += BtnMaxSkor_Click;

            btnMinSkor = new Button
            {
                Text = "",
                Location = new Point(440, 2),
                Size = new Size(40, 25),
                BackgroundImage = Image.FromFile("min.png"),
                BackgroundImageLayout = ImageLayout.Zoom
            };
            btnMinSkor.Click += BtnMinSkor_Click;

            lblMaxSkor = new Label
            {
                Location = new Point(490, 2),
                Size = new Size(200, 20),
                Text = "En Yüksek Skor: 0"
            };

            lblMinSkor = new Label
            {
                Location = new Point(700, 2),
                Size = new Size(200, 20),
                Text = "En Düşük Skor: 0"
            };

            // Top 5 oyuncu listesi
            lstTop5 = new ListBox
            {
                Dock = DockStyle.Right,
                Width = 200,
                Margin = new Padding(0, 10, 10, 0),
                Padding = new Padding(0, 10, 0, 0),
                Font = new Font("Arial", 10)
            };

            // DataGridView
            dgvScores = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                RowHeadersVisible = false,
                Margin = new Padding(0, 0, 0, 0)
            };

            // Geri dön butonu
            Button btnBack = new Button
            {
                Text = "Geri Dön",
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.DarkBlue,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(50, 25),
                Dock = DockStyle.Bottom
            };
            btnBack.Click += (s, e) =>
            {
                MainMenu mainMenu = new MainMenu();
                mainMenu.Show();
                this.Close();
            };

            // Filtre paneline kontrolleri ekle
            filterPanel.Controls.AddRange(new Control[] {
                lblFiltre, cmbSkorFiltre, btnMaxSkor, btnMinSkor, lblMaxSkor, lblMinSkor
            });

            // Dock ayarları
            btnBack.Dock = DockStyle.Bottom;
            dgvScores.Dock = DockStyle.Fill;
            lstTop5.Dock = DockStyle.Right;
            filterPanel.Dock = DockStyle.Top;
            lblTitle.Dock = DockStyle.Top;

            // Kontrolleri ekleme sırası (önemli!)
            this.Controls.Add(btnBack);      // En altta (DockStyle.Bottom)
            this.Controls.Add(dgvScores);    // Ortada (DockStyle.Fill)
            this.Controls.Add(lstTop5);      // Sağda (DockStyle.Right)
            this.Controls.Add(filterPanel);  // Üstte (DockStyle.Top)
            this.Controls.Add(lblTitle);     // En üstte (DockStyle.Top)

            // Verileri yükle
            VerileriYukle();
        }

        private void VerileriYukle()
        {
            try
            {
                using (var conn = new SqlConnection(DatabaseConnection.GetConnection().ConnectionString))
                {
                    conn.Open();
                    string queryOyunlar = "SELECT * FROM Oyunlar";
                    if (cmbSkorFiltre != null)
                    {
                        switch (cmbSkorFiltre.SelectedIndex)
                        {
                            case 1: // Günlük
                                queryOyunlar = "SELECT * FROM Oyunlar WHERE CAST(Tarih AS DATE) = CAST(GETDATE() AS DATE)";
                                break;
                            case 2: // Aylık
                                queryOyunlar = "SELECT * FROM Oyunlar WHERE MONTH(Tarih) = MONTH(GETDATE()) AND YEAR(Tarih) = YEAR(GETDATE())";
                                break;
                            case 3: // Yıllık
                                queryOyunlar = "SELECT * FROM Oyunlar WHERE YEAR(Tarih) = YEAR(GETDATE())";
                                break;
                        }
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(queryOyunlar, conn))
                    {
                        dtOyunlar = new DataTable();
                        adapter.Fill(dtOyunlar);
                        dgvScores.DataSource = dtOyunlar;
                    }

                    // Top 5 oyuncu
                    string queryTop5 = "SELECT TOP 5 Email, MAX(Skor) as EnYuksekSkor FROM Oyunlar GROUP BY Email ORDER BY EnYuksekSkor DESC";
                    if (cmbSkorFiltre != null)
                    {
                        switch (cmbSkorFiltre.SelectedIndex)
                        {
                            case 1: // Günlük
                                queryTop5 = "SELECT TOP 5 Email, MAX(GunlukSkor) as EnYuksekSkor FROM Oyunlar WHERE GunlukSkor IS NOT NULL AND CAST(Tarih AS DATE) = CAST(GETDATE() AS DATE) GROUP BY Email ORDER BY EnYuksekSkor DESC";
                                break;
                            case 2: // Aylık
                                queryTop5 = "SELECT TOP 5 Email, MAX(AylikSkor) as EnYuksekSkor FROM Oyunlar WHERE AylikSkor IS NOT NULL AND MONTH(Tarih) = MONTH(GETDATE()) AND YEAR(Tarih) = YEAR(GETDATE()) GROUP BY Email ORDER BY EnYuksekSkor DESC";
                                break;
                            case 3: // Yıllık
                                queryTop5 = "SELECT TOP 5 Email, MAX(YillikSkor) as EnYuksekSkor FROM Oyunlar WHERE YillikSkor IS NOT NULL AND YEAR(Tarih) = YEAR(GETDATE()) GROUP BY Email ORDER BY EnYuksekSkor DESC";
                                break;
                        }
                    }

                    using (SqlCommand cmd = new SqlCommand(queryTop5, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        lstTop5.Items.Clear();
                        while (reader.Read())
                        {
                            lstTop5.Items.Add($"{reader["Email"]} - {reader["EnYuksekSkor"]} puan");
                        }
                    }

                    // En yüksek ve en düşük skorlar
                    string queryMaxMin = "SELECT MAX(Skor) as MaxSkor, MIN(Skor) as MinSkor FROM Oyunlar";
                    if (cmbSkorFiltre != null)
                    {
                        switch (cmbSkorFiltre.SelectedIndex)
                        {
                            case 1: // Günlük
                                queryMaxMin = "SELECT MAX(GunlukSkor) as MaxSkor, MIN(GunlukSkor) as MinSkor FROM Oyunlar WHERE GunlukSkor IS NOT NULL AND CAST(Tarih AS DATE) = CAST(GETDATE() AS DATE)";
                                break;
                            case 2: // Aylık
                                queryMaxMin = "SELECT MAX(AylikSkor) as MaxSkor, MIN(AylikSkor) as MinSkor FROM Oyunlar WHERE AylikSkor IS NOT NULL AND MONTH(Tarih) = MONTH(GETDATE()) AND YEAR(Tarih) = YEAR(GETDATE())";
                                break;
                            case 3: // Yıllık
                                queryMaxMin = "SELECT MAX(YillikSkor) as MaxSkor, MIN(YillikSkor) as MinSkor FROM Oyunlar WHERE YillikSkor IS NOT NULL AND YEAR(Tarih) = YEAR(GETDATE())";
                                break;
                        }
                    }

                    using (SqlCommand cmd = new SqlCommand(queryMaxMin, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblMaxSkor.Text = $"En Yüksek Skor: {reader["MaxSkor"]}";
                            lblMinSkor.Text = $"En Düşük Skor: {reader["MinSkor"]}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler yüklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnMaxSkor_Click(object sender, EventArgs e)
        {
            if (dtOyunlar == null || dtOyunlar.Rows.Count == 0) return;
            string skorKolon = GetSkorKolon();
            if (!dtOyunlar.Columns.Contains(skorKolon)) return;
            DataView dv = dtOyunlar.DefaultView;
            dv.Sort = skorKolon + " DESC";
            dtOyunlar = dv.ToTable();
            dgvScores.DataSource = dtOyunlar;
        }

        private void BtnMinSkor_Click(object sender, EventArgs e)
        {
            if (dtOyunlar == null || dtOyunlar.Rows.Count == 0) return;
            string skorKolon = GetSkorKolon();
            if (!dtOyunlar.Columns.Contains(skorKolon)) return;
            DataView dv = dtOyunlar.DefaultView;
            dv.Sort = skorKolon + " ASC";
            dtOyunlar = dv.ToTable();
            dgvScores.DataSource = dtOyunlar;
        }

        private void InitializeComponent()
        {

        }

        private string GetSkorKolon()
        {
            switch (cmbSkorFiltre.SelectedIndex)
            {
                case 1: return "GunlukSkor";
                case 2: return "AylikSkor";
                case 3: return "YillikSkor";
                default: return "Skor";
            }
        }
    }
} 