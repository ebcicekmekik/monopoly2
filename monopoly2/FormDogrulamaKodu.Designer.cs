namespace monopoly2
{
    partial class FormDogrulamaKodu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDogrulamaKodu));
            label1 = new Label();
            txtDogrulamaKodu = new TextBox();
            btnDogrula = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 23);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(126, 20);
            label1.TabIndex = 0;
            label1.Text = "Doğrulama Kodu:";
            // 
            // txtDogrulamaKodu
            // 
            txtDogrulamaKodu.Location = new Point(143, 18);
            txtDogrulamaKodu.Margin = new Padding(4, 5, 4, 5);
            txtDogrulamaKodu.Name = "txtDogrulamaKodu";
            txtDogrulamaKodu.Size = new Size(219, 27);
            txtDogrulamaKodu.TabIndex = 1;
            // 
            // btnDogrula
            // 
            btnDogrula.BackgroundImage = (Image)resources.GetObject("btnDogrula.BackgroundImage");
            btnDogrula.BackgroundImageLayout = ImageLayout.Zoom;
            btnDogrula.Location = new Point(306, 55);
            btnDogrula.Margin = new Padding(4, 5, 4, 5);
            btnDogrula.Name = "btnDogrula";
            btnDogrula.Size = new Size(56, 44);
            btnDogrula.TabIndex = 2;
            btnDogrula.UseVisualStyleBackColor = true;
            btnDogrula.Click += btnDogrula_Click;
            // 
            // FormDogrulamaKodu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(379, 112);
            Controls.Add(btnDogrula);
            Controls.Add(txtDogrulamaKodu);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "FormDogrulamaKodu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Doğrulama Kodu";
            Load += FormDogrulamaKodu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDogrulamaKodu;
        private System.Windows.Forms.Button btnDogrula;
    }
} 