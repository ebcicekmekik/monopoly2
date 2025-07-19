using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace monopoly2
{
    public partial class FormKostebek : Form
    {
        Random rnd = new Random();
        int gorunmeSuresi = 1000;
        GroupBox[] groupBox;
        int puan = 0;
        int kalanSure = 60;  // 60 saniye

        System.Windows.Forms.Timer sureTimer = new System.Windows.Forms.Timer();

        public FormKostebek()
        {
            InitializeComponent();

            groupBox = new GroupBox[] { groupBox1, groupBox2, groupBox3, groupBox4, groupBox5, groupBox6, groupBox7, groupBox8, groupBox9 };

            timer1.Interval = gorunmeSuresi;
            timer1.Tick += timer1_Tick;

            sureTimer.Interval = 1000;  // 1 saniyede bir azalacak
            sureTimer.Tick += SureTimer_Tick;

            pbx_köstebek1.Visible = false;
            pbx_köstebek2.Visible = false;
            pbx_Bomba.Visible = false;

            pbx_köstebek1.Click += KostebekTiklandi;
            pbx_köstebek2.Click += KostebekTiklandi;
            pbx_Bomba.Click += BombaTiklandi;

            this.Load += FormKostebek_Load;
        }

        private void FormKostebek_Load(object sender, EventArgs e)
        {
            lbl_Puan.Text = "Puan: 0";
            lbl_Sure.Text = "Süre: 60";
            timer1.Start();
            sureTimer.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pbx_köstebek1.Visible = false;
            pbx_köstebek2.Visible = false;
            pbx_Bomba.Visible = false;

            bool ikiliMi = rnd.Next(0, 2) == 1;
            bool bombaCikarMi = rnd.Next(0, 2) == 1;

            var karisik = groupBox.OrderBy(x => rnd.Next()).ToArray();

            KostebekYuvasi(pbx_köstebek1, karisik[0]);

            if (ikiliMi)
            {
                KostebekYuvasi(pbx_köstebek2, karisik[1]);
            }

            if (bombaCikarMi)
            {
                KostebekYuvasi(pbx_Bomba, karisik[2]);
            }

            Task.Delay(gorunmeSuresi / 2).ContinueWith(_ =>
            {
                if (!this.IsDisposed)
                {
                    this.Invoke(new Action(() =>
                    {
                        pbx_köstebek1.Visible = false;
                        pbx_köstebek2.Visible = false;
                        pbx_Bomba.Visible = false;
                    }));
                }
            });
        }

        private void KostebekYuvasi(PictureBox nesne, GroupBox yuva)
        {
            nesne.Parent = yuva;
            nesne.Location = new System.Drawing.Point(
                (yuva.Width - nesne.Width) / 2,
                (yuva.Height - nesne.Height) / 2
            );
            nesne.Visible = true;
        }

        private void KostebekTiklandi(object sender, EventArgs e)
        {
            puan += 10;
            lbl_Puan.Text = "Puan: " + puan.ToString();
        }

        private void BombaTiklandi(object sender, EventArgs e)
        {
            puan -= 10;
            lbl_Puan.Text = "Puan: " + puan.ToString();
        }

        private void SureTimer_Tick(object sender, EventArgs e)
        {
            kalanSure--;
            lbl_Sure.Text = "Süre: " + kalanSure.ToString();

            if (kalanSure <= 0)
            {
                timer1.Stop();
                sureTimer.Stop();
                pbx_köstebek1.Visible = false;
                pbx_köstebek2.Visible = false;
                pbx_Bomba.Visible = false;

                MessageBox.Show("Oyun Bitti! Toplam Puanınız: " + puan);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        public int Puan => puan;

        private void pbx_köstebek1_Click(object sender, EventArgs e)
        {

        }
    }
}
