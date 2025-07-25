using System;
using System.Windows.Forms;
using System.Drawing;

namespace monopoly2
{
    public partial class FormFlappyBird : Form
    {
        // Oyun değişkenleri
        int pipeSpeed = 8;
        int gravity = 8;
        int score = 0;
        bool gameOver = false;

        public int Score { get; private set; } // Skoru dışarıdan okunabilir yap

        public FormFlappyBird()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreText.Text = "Score: " + score;

            if (pipeBottom.Left < -150)
            {
                pipeBottom.Left = 800;
                score++;
            }
            if (pipeTop.Left < -180)
            {
                pipeTop.Left = 950;
                score++;
            }

            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds) ||
                flappyBird.Top < -25)
            {
                endGame();
            }

            if (score > 5)
            {
                pipeSpeed = 15;
            }
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -8;
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 8;
            }
        }

        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += "  Game Over!";
            gameOver = true;
            Score = score; // Skoru property'ye ata
            this.DialogResult = DialogResult.OK; // Form kapatıldığında ShowDialog için OK dön
        }
    }
} 