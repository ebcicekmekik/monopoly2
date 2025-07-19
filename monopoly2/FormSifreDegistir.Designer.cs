namespace monopoly2
{
    partial class FormSifreDegistir
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSifreDegistir));
            label1 = new Label();
            label2 = new Label();
            txtYeniSifre = new TextBox();
            txtYeniSifreTekrar = new TextBox();
            btnSifreDegistir = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 23);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 0;
            label1.Text = "Yeni Şifre:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 63);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(127, 20);
            label2.TabIndex = 1;
            label2.Text = "Yeni Şifre (Tekrar):";
            // 
            // txtYeniSifre
            // 
            txtYeniSifre.Location = new Point(143, 18);
            txtYeniSifre.Margin = new Padding(4, 5, 4, 5);
            txtYeniSifre.Name = "txtYeniSifre";
            txtYeniSifre.PasswordChar = '*';
            txtYeniSifre.Size = new Size(219, 27);
            txtYeniSifre.TabIndex = 2;
            // 
            // txtYeniSifreTekrar
            // 
            txtYeniSifreTekrar.Location = new Point(143, 58);
            txtYeniSifreTekrar.Margin = new Padding(4, 5, 4, 5);
            txtYeniSifreTekrar.Name = "txtYeniSifreTekrar";
            txtYeniSifreTekrar.PasswordChar = '*';
            txtYeniSifreTekrar.Size = new Size(219, 27);
            txtYeniSifreTekrar.TabIndex = 3;
            // 
            // btnSifreDegistir
            // 
            btnSifreDegistir.BackgroundImage = (Image)resources.GetObject("btnSifreDegistir.BackgroundImage");
            btnSifreDegistir.BackgroundImageLayout = ImageLayout.Zoom;
            btnSifreDegistir.Location = new Point(286, 98);
            btnSifreDegistir.Margin = new Padding(4, 5, 4, 5);
            btnSifreDegistir.Name = "btnSifreDegistir";
            btnSifreDegistir.Size = new Size(77, 40);
            btnSifreDegistir.TabIndex = 4;
            btnSifreDegistir.UseVisualStyleBackColor = true;
            btnSifreDegistir.Click += btnSifreDegistir_Click;
            // 
            // FormSifreDegistir
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(419, 152);
            Controls.Add(btnSifreDegistir);
            Controls.Add(txtYeniSifreTekrar);
            Controls.Add(txtYeniSifre);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "FormSifreDegistir";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Şifre Değiştir";
            Load += FormSifreDegistir_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtYeniSifre;
        private System.Windows.Forms.TextBox txtYeniSifreTekrar;
        private System.Windows.Forms.Button btnSifreDegistir;
    }
} 