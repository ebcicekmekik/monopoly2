using System;
using System.Data.SqlClient;

namespace Monopoly
{
    public class FormMonopoly : Form
    {
        // ... existing code ...

        private void btnSonuc_Click(object sender, EventArgs e)
        {
            // ... existing code ...

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
            // ... existing code ...
        }
    }
} 