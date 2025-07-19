using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Linq;
using System.Drawing;
using monopoly2;

namespace monopoly2
{
    public partial class Admin : Form
    {
        private DataTable dtKullanicilar;
        private DataTable dtMesajlar;
        private DataTable dtOyunlar;
        private ComboBox cmbSkorFiltre;
        private Label lblFiltre;
        private Button btnOyunaGec;
        private TextBox txtKullaniciAra;
        private Button btnKullaniciAra;
        private Button btnKullaniciEkle;
        private ToolTip toolTip;

        public Admin()
        {
            InitializeComponent();
            toolTip = new ToolTip();
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 500;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;

            dtKullanicilar = new DataTable();
            dtMesajlar = new DataTable();
            dtOyunlar = new DataTable();
            dgvKullanicilar.AutoGenerateColumns = true;
            dgvMesajlar.AutoGenerateColumns = true;
            dgvOyunlar.AutoGenerateColumns = true;
            this.Load += Admin_Load;
            btnYenile.Click += btnYenile_Click;
            dgvKullanicilar.SelectionChanged += dgvKullanicilar_SelectionChanged;
            btnCevapla.Click += btnCevapla_Click;
            lblFiltre = new Label();
            lblFiltre.Text = "Skor Filtrele:";
            lblFiltre.Location = new System.Drawing.Point(11, 12);
            lblFiltre.Size = new System.Drawing.Size(80, 30);
            cmbSkorFiltre = new ComboBox();
            cmbSkorFiltre.Items.AddRange(new string[] { "Tümü", "Günlük", "Aylık", "Yıllık" });
            cmbSkorFiltre.SelectedIndex = 0;
            cmbSkorFiltre.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSkorFiltre.Location = new System.Drawing.Point(110, 12);
            cmbSkorFiltre.Size = new System.Drawing.Size(120, 30);
            cmbSkorFiltre.SelectedIndexChanged += (s, e) => VerileriYukle();
            tabOyunlar.Controls.Add(lblFiltre);
            tabOyunlar.Controls.Add(cmbSkorFiltre);
            if (dgvOyunlar != null)
            {
                dgvOyunlar.Location = new System.Drawing.Point(11, 50);
            }
            btnOyunaGec = new Button();            
            btnOyunaGec.BackColor = System.Drawing.Color.White;
            btnOyunaGec.Size = new System.Drawing.Size(50, 50);
            btnOyunaGec.Location = new System.Drawing.Point(10, tabKullanicilar.Height - btnOyunaGec.Height - 10);
            btnOyunaGec.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnOyunaGec.Click += btnOyunaGec_Click;
            btnOyunaGec.BackgroundImage = Image.FromFile("monopoly.png");
            btnOyunaGec.BackgroundImageLayout = ImageLayout.Stretch;
            toolTip.SetToolTip(btnOyunaGec, "Oyuna Geç");
            tabKullanicilar.Controls.Add(btnOyunaGec);
            btnOyunaGec.BringToFront();

            // Yeni arama kutusu ve butonu ekle (daha büyük ve görünür)
            txtKullaniciAra = new TextBox();
            txtKullaniciAra.Name = "txtKullaniciAra";
            txtKullaniciAra.Size = new System.Drawing.Size(280, 35);
            txtKullaniciAra.Location = new System.Drawing.Point(20, 20);
            txtKullaniciAra.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            toolTip.SetToolTip(txtKullaniciAra, "Kullanıcı Ara");
            tabKullanicilar.Controls.Add(txtKullaniciAra);
            txtKullaniciAra.BringToFront();

            btnKullaniciAra = new Button();
            btnKullaniciAra.Name = "btnKullaniciAra";
            btnKullaniciAra.BackColor = System.Drawing.Color.White;
            btnKullaniciAra.BackgroundImage = Image.FromFile("arama.png");
            btnKullaniciAra.BackgroundImageLayout= ImageLayout.Zoom;            
            btnKullaniciAra.Size = new System.Drawing.Size(50, 35);
            btnKullaniciAra.Location = new System.Drawing.Point(320, 15);
            btnKullaniciAra.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnKullaniciAra.Click += BtnKullaniciAra_Click;
            toolTip.SetToolTip(btnKullaniciAra, "Kullanıcı Ara");
            tabKullanicilar.Controls.Add(btnKullaniciAra);
            btnKullaniciAra.BringToFront();

            


            // DataGridView'i daha aşağıya çek
            dgvKullanicilar.Location = new System.Drawing.Point(0, 70);
            dgvKullanicilar.Size = new System.Drawing.Size(1250, 500);

            // Formu büyüt
            this.Size = new System.Drawing.Size(1300, 700);

            // Oyunlar sekmesi event handlerlarını bağla
            btnMaxSkor.Click += BtnMaxSkor_Click;
            btnMaxSkor.Text = "";
            btnMaxSkor.Location = new System.Drawing.Point(250, 10);
            btnMaxSkor.BackColor = System.Drawing.Color.White;
            btnMaxSkor.BackgroundImage = Image.FromFile("max.png");
            btnMaxSkor.BackgroundImageLayout = ImageLayout.Zoom;
            btnMaxSkor.Size = new System.Drawing.Size(40, 35);
            btnMaxSkor.BringToFront();

            btnMinSkor.Click += BtnMinSkor_Click;
            btnMinSkor.Text = "";
            btnMinSkor.Location = new System.Drawing.Point(300, 10);
            btnMinSkor.BackColor = System.Drawing.Color.White;
            btnMinSkor.BackgroundImage = Image.FromFile("min.png");
            btnMinSkor.BackgroundImageLayout = ImageLayout.Zoom;
            btnMinSkor.Size = new System.Drawing.Size(40, 35);
            btnMinSkor.BringToFront();
            toolTip.SetToolTip(btnMaxSkor, "En Yüksek Skorları Göster");
            toolTip.SetToolTip(btnMinSkor, "En Düşük Skorları Göster");
            toolTip.SetToolTip(btnYenile, "Tabloları Yenile");
            toolTip.SetToolTip(btnKullaniciSil, "Kullanıcıyı Sil");
            toolTip.SetToolTip(btnKullaniciDuzenle, "Kullanıcıyı Düzenle");
            toolTip.SetToolTip(btnKullaniciYasakla, "Kullanıcıyı Yasakla/Yasağını Kaldır");
            toolTip.SetToolTip(btnMesajSil, "Mesajı Sil");
            toolTip.SetToolTip(btnOyunSil, "Oyun Kaydını Sil");
            toolTip.SetToolTip(btnOyunGuncelle, "Oyun Kaydını Güncelle");
            toolTip.SetToolTip(btnOyunEkle, "Yeni Oyun Kaydı Ekle");
            toolTip.SetToolTip(btnCevapla, "Mesaja Cevap Ver");
            toolTip.SetToolTip(btnKullaniciEkle, "Yeni Kullanıcı Ekle");
            toolTip.SetToolTip(cmbYilFiltre, "Yıl Filtresi");
            toolTip.SetToolTip(cmbAyFiltre, "Ay Filtresi");
            toolTip.SetToolTip(cmbSkorFiltre, "Skor Filtresi");
            cmbSkorFiltre.SelectedIndexChanged += CmbSkorFiltre_SelectedIndexChanged;

            // Ay combobox'unu doldur
            cmbAyFiltre.Items.Clear();
            for (int i = 1; i <= 12; i++)
                cmbAyFiltre.Items.Add(i.ToString());
            cmbAyFiltre.SelectedIndex = 0;
            // Yıl combobox'unu doldur (veritabanından)
            FillYearComboBox();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            tabControl1.Visible = true;
            tabControl1.BringToFront();
            tabControl1.SelectedIndex = 0;
            VerileriYukle();
        }

        private void FillYearComboBox()
        {
            cmbYilFiltre.Items.Clear();
            using (var conn = new SqlConnection(DatabaseConnection.GetConnection().ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT YEAR(Tarih) as Yil FROM Oyunlar ORDER BY Yil DESC", conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmbYilFiltre.Items.Add(reader["Yil"].ToString());
                    }
                }
            }
            if (cmbYilFiltre.Items.Count > 0)
                cmbYilFiltre.SelectedIndex = 0;
        }

        private void VerileriYukle()
        {
            try
            {
                // Kullanıcılar tablosu
                using (var conn = new SqlConnection(DatabaseConnection.GetConnection().ConnectionString))
                {
                    conn.Open();
                    string queryKullanicilar = "SELECT * FROM Kullanicilar";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(queryKullanicilar, conn))
                    {
                        dtKullanicilar = new DataTable();
                        adapter.Fill(dtKullanicilar);
                        dgvKullanicilar.DataSource = null;
                        dgvKullanicilar.DataSource = dtKullanicilar;
                        dgvKullanicilar.Refresh();
                    }
                }
                // Mesajlar tablosu
                using (var conn = new SqlConnection(DatabaseConnection.GetConnection().ConnectionString))
                {
                    conn.Open();
                    string queryMesajlar = "SELECT * FROM Mesajlar ORDER BY Tarih DESC";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(queryMesajlar, conn))
                    {
                        dtMesajlar = new DataTable();
                        adapter.Fill(dtMesajlar);
                        dgvMesajlar.DataSource = null;
                        dgvMesajlar.DataSource = dtMesajlar;
                        // Configure columns
                        dgvMesajlar.Columns["Id"].Visible = false;
                        dgvMesajlar.Columns["Email"].HeaderText = "Gönderen Email";
                        dgvMesajlar.Columns["Mesaj"].HeaderText = "Mesaj İçeriği";
                        dgvMesajlar.Columns["Tarih"].HeaderText = "Gönderim Tarihi";
                        dgvMesajlar.Columns["AdminCevap"].HeaderText = "Admin Cevabı";
                        dgvMesajlar.Refresh();
                    }
                }
                // Oyunlar tablosu
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
                                if (cmbYilFiltre.SelectedItem != null && cmbAyFiltre.SelectedItem != null)
                                {
                                    string yil = cmbYilFiltre.SelectedItem.ToString();
                                    string ay = cmbAyFiltre.SelectedItem.ToString();
                                    queryOyunlar = $"SELECT * FROM Oyunlar WHERE MONTH(Tarih) = {ay} AND YEAR(Tarih) = {yil}";
                                }
                                else
                                {
                                    queryOyunlar = "SELECT * FROM Oyunlar WHERE MONTH(Tarih) = MONTH(GETDATE()) AND YEAR(Tarih) = YEAR(GETDATE())";
                                }
                                break;
                            case 3: // Yıllık
                                if (cmbYilFiltre.SelectedItem != null)
                                {
                                    string yil = cmbYilFiltre.SelectedItem.ToString();
                                    queryOyunlar = $"SELECT * FROM Oyunlar WHERE YEAR(Tarih) = {yil}";
                                }
                                else
                                {
                                    queryOyunlar = "SELECT * FROM Oyunlar WHERE YEAR(Tarih) = YEAR(GETDATE())";
                                }
                                break;
                            default:
                                queryOyunlar = "SELECT * FROM Oyunlar";
                                break;
                        }
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(queryOyunlar, conn))
                    {
                        dtOyunlar = new DataTable();
                        adapter.Fill(dtOyunlar);
                        dgvOyunlar.DataSource = null;
                        dgvOyunlar.DataSource = dtOyunlar;
                        dgvOyunlar.Refresh();
                    }
                }
                // Top 5 oyuncu
                using (var conn = new SqlConnection(DatabaseConnection.GetConnection().ConnectionString))
                {
                    conn.Open();
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
                }
                // En yüksek ve en düşük skorlar
                using (var conn = new SqlConnection(DatabaseConnection.GetConnection().ConnectionString))
                {
                    conn.Open();
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
                MessageBox.Show($"Veriler yüklenirken bir hata oluştu:\n\nHata Mesajı: {ex.Message}\n\nStack Trace: {ex.StackTrace}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            VerileriYukle();
        }

        private void dgvKullanicilar_SelectionChanged(object sender, EventArgs e)
        {
            // Alt kutular kaldırıldığı için bu fonksiyon artık boş.
        }

        private void btnKullaniciDuzenle_Click(object sender, EventArgs e)
        {
            if (dgvKullanicilar.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvKullanicilar.SelectedRows[0];
                int id = Convert.ToInt32(row.Cells["Id"].Value);
                string kullaniciAdi = row.Cells["KullaniciAdi"].Value?.ToString() ?? "";
                string email = row.Cells["Email"].Value?.ToString() ?? "";
                string ad = row.Cells["Ad"].Value?.ToString() ?? "";
                string soyad = row.Cells["Soyad"].Value?.ToString() ?? "";
                string rol = row.Cells["IsAdmin"].Value != DBNull.Value && Convert.ToBoolean(row.Cells["IsAdmin"].Value) ? "Admin" : "Kullanici";
                bool yasakli = row.Cells["Yasakli"].Value != DBNull.Value && Convert.ToBoolean(row.Cells["Yasakli"].Value);
                FormKullaniciDuzenle frm = new FormKullaniciDuzenle(id, kullaniciAdi, email, ad, soyad, rol, yasakli);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    VerileriYukle();
                }
            }
        }

        private async void btnCevapla_Click(object sender, EventArgs e)
        {
            if (dgvMesajlar.SelectedRows.Count > 0)
            {
                int mesajId = Convert.ToInt32(dgvMesajlar.SelectedRows[0].Cells["Id"].Value);
                string cevap = txtCevap.Text.Trim();
                if (string.IsNullOrEmpty(cevap))
                {
                    MessageBox.Show("Cevap boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                using (var loading = new LoadingForm())
                {
                    loading.LoadingMessage = "Gönderiliyor...";
                    loading.Show();
                    loading.Refresh();
                    await System.Threading.Tasks.Task.Delay(2000);
                    try
                    {
                        string kullaniciEmail = "";
                        // 1. Mesajı atan kullanıcının emailini çek
                        using (var conn = new SqlConnection(DatabaseConnection.GetConnection().ConnectionString))
                        {
                            conn.Open();
                            string emailQuery = "SELECT Email FROM Mesajlar WHERE Id = @id";
                            using (SqlCommand cmd = new SqlCommand(emailQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@id", mesajId);
                                var result = cmd.ExecuteScalar();
                                if (result != null)
                                    kullaniciEmail = result.ToString();
                            }
                        }

                        // 2. Cevabı veritabanına kaydet
                        using (var conn = new SqlConnection(DatabaseConnection.GetConnection().ConnectionString))
                        {
                            conn.Open();
                            string query = "UPDATE Mesajlar SET AdminCevap = @admincevap WHERE Id = @id";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@admincevap", cevap);
                                cmd.Parameters.AddWithValue("@id", mesajId);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // 3. Kullanıcıya mail gönder
                        if (!string.IsNullOrEmpty(kullaniciEmail))
                        {
                            try
                            {
                                new Mail().Send(kullaniciEmail, "Mesajınıza Yönetici Cevabı", cevap);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Mail gönderilemedi: " + ex.Message, "Mail Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }

                        MessageBox.Show("Cevap başarıyla kaydedildi ve kullanıcıya mail gönderildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        VerileriYukle();
                        txtCevap.Text = "";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Cevap kaydedilirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        loading.Close();
                    }
                }
            }
        }

        private void btnOyunaGec_Click(object sender, EventArgs e)
        {
            var oyunFormu = new FormMonopoly();
            this.Hide();
            oyunFormu.Show();
        }

        private void BtnKullaniciAra_Click(object sender, EventArgs e)
        {
            string aranan = txtKullaniciAra.Text.Trim().ToLower();
            if (dtKullanicilar == null || dtKullanicilar.Rows.Count == 0)
                return;

            if (!dtKullanicilar.Columns.Contains("KullaniciAdi"))
            {
                string cols = string.Join(", ", dtKullanicilar.Columns.Cast<DataColumn>().Select(c => c.ColumnName));
                MessageBox.Show($"KullaniciAdi adında bir sütun bulunamadı!\nMevcut sütunlar: {cols}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(aranan))
            {
                dgvKullanicilar.DataSource = dtKullanicilar;
                return;
            }

            var filtered = dtKullanicilar.AsEnumerable()
                .Where(row => !string.IsNullOrEmpty(row.Field<string>("KullaniciAdi")) && row.Field<string>("KullaniciAdi").ToLower().Contains(aranan));

            if (filtered.Any())
                dgvKullanicilar.DataSource = filtered.CopyToDataTable();
            else
                dgvKullanicilar.DataSource = null;
        }

        private void BtnMaxSkor_Click(object sender, EventArgs e)
        {
            if (dtOyunlar == null || dtOyunlar.Rows.Count == 0) return;
            string skorKolon = GetSkorKolon();
            if (!dtOyunlar.Columns.Contains(skorKolon)) return;
            DataView dv = dtOyunlar.DefaultView;
            dv.Sort = skorKolon + " DESC";
            dtOyunlar = dv.ToTable();
            dgvOyunlar.DataSource = dtOyunlar;
            dgvOyunlar.ClearSelection();
            if (dtOyunlar.Rows.Count > 0)
            {
                dgvOyunlar.Rows[0].Selected = true;
                dgvOyunlar.FirstDisplayedScrollingRowIndex = 0;
            }
        }

        private void BtnMinSkor_Click(object sender, EventArgs e)
        {
            if (dtOyunlar == null || dtOyunlar.Rows.Count == 0) return;
            string skorKolon = GetSkorKolon();
            if (!dtOyunlar.Columns.Contains(skorKolon)) return;
            DataView dv = dtOyunlar.DefaultView;
            dv.Sort = skorKolon + " ASC";
            dtOyunlar = dv.ToTable();
            dgvOyunlar.DataSource = dtOyunlar;
            dgvOyunlar.ClearSelection();
            if (dtOyunlar.Rows.Count > 0)
            {
                dgvOyunlar.Rows[0].Selected = true;
                dgvOyunlar.FirstDisplayedScrollingRowIndex = 0;
            }
        }

        // Seçili filtreye göre skor kolonunu döndürür
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

        // Filtre comboboxları değişince tabloyu güncelle
        private void CmbYilFiltre_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerileriYukle();
        }
        private void CmbAyFiltre_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerileriYukle();
        }
        private void CmbSkorFiltre_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerileriYukle();
        }

        private void btnKullaniciSil_Click(object sender, EventArgs e)
        {
            if (dgvKullanicilar.SelectedRows.Count > 0)
            {
                try
                {
                    DatabaseConnection.OpenConnection();
                    string email = dgvKullanicilar.SelectedRows[0].Cells["Email"].Value.ToString();
                    string query = "DELETE FROM Kullanicilar WHERE Email = @email";
                    using (SqlCommand cmd = new SqlCommand(query, DatabaseConnection.GetConnection()))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.ExecuteNonQuery();
                    }
                    VerileriYukle();
                    MessageBox.Show("Kullanıcı başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kullanıcı silinirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    DatabaseConnection.CloseConnection();
                }
            }
        }

        private void btnKullaniciYasakla_Click(object sender, EventArgs e)
        {
            if (dgvKullanicilar.SelectedRows.Count > 0)
            {
                try
                {
                    DatabaseConnection.OpenConnection();
                    int id = Convert.ToInt32(dgvKullanicilar.SelectedRows[0].Cells["Id"].Value);
                    bool yasakli = dgvKullanicilar.SelectedRows[0].Cells["Yasakli"].Value != DBNull.Value && Convert.ToBoolean(dgvKullanicilar.SelectedRows[0].Cells["Yasakli"].Value);
                    string query = "UPDATE Kullanicilar SET Yasakli = @yasakli WHERE Id = @id";
                    using (SqlCommand cmd = new SqlCommand(query, DatabaseConnection.GetConnection()))
                    {
                        cmd.Parameters.AddWithValue("@yasakli", !yasakli);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                    VerileriYukle();
                    MessageBox.Show(yasakli ? "Kullanıcının yasağı kaldırıldı." : "Kullanıcı yasaklandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Yasaklama işlemi sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    DatabaseConnection.CloseConnection();
                }
            }
        }

        private void btnMesajSil_Click(object sender, EventArgs e)
        {
            if (dgvMesajlar.SelectedRows.Count > 0)
            {
                try
                {
                    DatabaseConnection.OpenConnection();
                    int id = Convert.ToInt32(dgvMesajlar.SelectedRows[0].Cells["Id"].Value);
                    string query = "DELETE FROM Mesajlar WHERE Id = @id";
                    using (SqlCommand cmd = new SqlCommand(query, DatabaseConnection.GetConnection()))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                    VerileriYukle();
                    MessageBox.Show("Mesaj başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Mesaj silinirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    DatabaseConnection.CloseConnection();
                }
            }
        }

        private void btnOyunSil_Click(object sender, EventArgs e)
        {
            if (dgvOyunlar.SelectedRows.Count > 0)
            {
                try
                {
                    DatabaseConnection.OpenConnection();
                    int id = Convert.ToInt32(dgvOyunlar.SelectedRows[0].Cells["Id"].Value);
                    string query = "DELETE FROM Oyunlar WHERE Id = @id";
                    using (SqlCommand cmd = new SqlCommand(query, DatabaseConnection.GetConnection()))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                    VerileriYukle();
                    MessageBox.Show("Oyun kaydı başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Oyun kaydı silinirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    DatabaseConnection.CloseConnection();
                }
            }
        }

        private void btnKullaniciEkle_Click(object sender, EventArgs e)
        {
            using (var frm = new FormKullaniciEkle())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    VerileriYukle();
                }
            }
        }

        private void btnOyunGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvOyunlar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellenecek bir oyun kaydı seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvOyunlar.SelectedRows[0];
            int id = Convert.ToInt32(row.Cells["Id"].Value);
            string email = row.Cells["Email"].Value.ToString();
            int eskiSkor = Convert.ToInt32(row.Cells["Skor"].Value);
            DateTime eskiTarih = Convert.ToDateTime(row.Cells["Tarih"].Value);

            // Yeni skor ve tarih al
            string skorStr = Microsoft.VisualBasic.Interaction.InputBox("Yeni skoru giriniz:", "Oyun Skoru Güncelle", eskiSkor.ToString());
            if (!int.TryParse(skorStr, out int yeniSkor))
            {
                MessageBox.Show("Geçerli bir skor giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DateTime yeniTarih = eskiTarih; // İsterseniz tarih de güncellenebilir

            try
            {
                DatabaseConnection.OpenConnection();
                string query = @"UPDATE Oyunlar SET Skor=@skor, Tarih=@tarih, GunlukSkor=@gunlukSkor, AylikSkor=@aylikSkor, YillikSkor=@yillikSkor WHERE Id=@id";
                using (SqlCommand cmd = new SqlCommand(query, DatabaseConnection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@skor", yeniSkor);
                    cmd.Parameters.AddWithValue("@tarih", yeniTarih);
                    cmd.Parameters.AddWithValue("@gunlukSkor", yeniSkor);
                    cmd.Parameters.AddWithValue("@aylikSkor", yeniSkor);
                    cmd.Parameters.AddWithValue("@yillikSkor", yeniSkor);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Oyun skoru başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                VerileriYukle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oyun güncellenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
        }

        private void btnOyunEkle_Click(object sender, EventArgs e)
        {
            // Kullanıcı seçimi için bir liste oluştur
            string email = "";
            using (var conn = new SqlConnection(DatabaseConnection.GetConnection().ConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT Email FROM Kullanicilar WHERE Yasakli = 0", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        MessageBox.Show("Eklenebilecek kullanıcı yok!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    // Basit seçim için ilk kullanıcıyı al
                    reader.Read();
                    email = reader["Email"].ToString();
                }
            }

            // Skor ve tarih bilgisi al
            string skorStr = Microsoft.VisualBasic.Interaction.InputBox("Skor giriniz:", "Oyun Skoru Ekle", "0");
            if (!int.TryParse(skorStr, out int skor))
            {
                MessageBox.Show("Geçerli bir skor giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DateTime tarih = DateTime.Now;

            try
            {
                DatabaseConnection.OpenConnection();
                string query = @"INSERT INTO Oyunlar (Email, Skor, Tarih, GunlukSkor, AylikSkor, YillikSkor)
                         VALUES (@email, @skor, @tarih, @gunlukSkor, @aylikSkor, @yillikSkor)";
                using (SqlCommand cmd = new SqlCommand(query, DatabaseConnection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@skor", skor);
                    cmd.Parameters.AddWithValue("@tarih", tarih);
                    cmd.Parameters.AddWithValue("@gunlukSkor", skor);
                    cmd.Parameters.AddWithValue("@aylikSkor", skor);
                    cmd.Parameters.AddWithValue("@yillikSkor", skor);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Oyun skoru başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                VerileriYukle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oyun eklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
        }
    }
}
