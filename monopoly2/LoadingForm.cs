using System.Windows.Forms;
using System.Drawing;

namespace monopoly2
{
    public class LoadingForm : Form
    {
        private Label lbl;
        private PictureBox pictureBox;

        public string LoadingMessage
        {
            get => lbl.Text;
            set => lbl.Text = value;
        }

        public Image LoadingImage
        {
            get => pictureBox.Image;
            set => pictureBox.Image = value;
        }

        public LoadingForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(400, 300);
            this.BackColor = Color.White;

            // Panel for better organization
            Panel mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20)
            };

            // Label for loading message
            lbl = new Label()
            {
                Text = "Gönderiliyor...",
                Font = new Font("Arial", 14, FontStyle.Bold),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 50
            };

            // PictureBox for the image
            pictureBox = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Dock = DockStyle.Fill,
                Padding = new Padding(10)
            };

            // Add controls to panel
            mainPanel.Controls.Add(pictureBox);
            mainPanel.Controls.Add(lbl);

            // Add panel to form
            this.Controls.Add(mainPanel);
            this.TopMost = true;
            this.ShowInTaskbar = false;
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // LoadingForm
            // 
            ClientSize = new Size(400, 300);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoadingForm";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
        }
    }
} 