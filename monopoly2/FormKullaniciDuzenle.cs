using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

namespace monopoly2
{
    public partial class FormKullaniciDuzenle : Form
    {
        private int kullaniciId;
        public FormKullaniciDuzenle(int id, string kullaniciAdi, string email, string ad, string soyad, string rol, bool yasakli)
        {
            InitializeComponent();
            kullaniciId = id;
            txtKullaniciAdi.Text = kullaniciAdi;
            txtEmail.Text = email;
            txtAd.Text = ad;
            txtSoyad.Text = soyad;
            chkIsAdmin.Checked = rol == "Admin";
            chkYasakli.Checked = yasakli;
        }

        private async void btnKaydet_Click(object sender, EventArgs e)
        {
            using (var loading = new LoadingForm())
            {
                loading.Show();
                loading.Refresh();
                await Task.Delay(2000);
                try
                {
                    DatabaseConnection.OpenConnection();
                    string query = "UPDATE Kullanicilar SET KullaniciAdi=@kullaniciAdi, Email=@email, Ad=@ad, Soyad=@soyad, IsAdmin=@isAdmin, Yasakli=@yasakli WHERE Id=@id";
                    using (SqlCommand cmd = new SqlCommand(query, DatabaseConnection.GetConnection()))
                    {
                        cmd.Parameters.AddWithValue("@kullaniciAdi", txtKullaniciAdi.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@ad", txtAd.Text.Trim());
                        cmd.Parameters.AddWithValue("@soyad", txtSoyad.Text.Trim());
                        cmd.Parameters.AddWithValue("@isAdmin", chkIsAdmin.Checked);
                        cmd.Parameters.AddWithValue("@yasakli", chkYasakli.Checked);
                        cmd.Parameters.AddWithValue("@id", kullaniciId);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Kullanıcı bilgileri güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kullanıcı güncellenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    DatabaseConnection.CloseConnection();
                    loading.Close();
                }
            }
        }
    }
} 