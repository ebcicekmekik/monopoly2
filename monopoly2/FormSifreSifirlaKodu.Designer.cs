namespace monopoly2
{
    partial class FormSifreSifirlaKodu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSifreSifirlaKodu));
            label1 = new Label();
            txtEmail = new TextBox();
            btnKoduGonder = new Button();
            label2 = new Label();
            txtKoduGir = new TextBox();
            btnKoduDogrula = new Button();
            btn_GeriDon = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 23);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(107, 20);
            label1.TabIndex = 0;
            label1.Text = "E-posta adresi:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(125, 18);
            txtEmail.Margin = new Padding(4, 5, 4, 5);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(239, 27);
            txtEmail.TabIndex = 1;
            // 
            // btnKoduGonder
            // 
            btnKoduGonder.BackgroundImage = (Image)resources.GetObject("btnKoduGonder.BackgroundImage");
            btnKoduGonder.BackgroundImageLayout = ImageLayout.Zoom;
            btnKoduGonder.Location = new Point(298, 51);
            btnKoduGonder.Margin = new Padding(4, 5, 4, 5);
            btnKoduGonder.Name = "btnKoduGonder";
            btnKoduGonder.Size = new Size(66, 50);
            btnKoduGonder.TabIndex = 2;
            btnKoduGonder.UseVisualStyleBackColor = true;
            btnKoduGonder.Click += btnKoduGonder_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 115);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(112, 20);
            label2.TabIndex = 3;
            label2.Text = "Gelen Kodu Gir:";
            // 
            // txtKoduGir
            // 
            txtKoduGir.Enabled = false;
            txtKoduGir.Location = new Point(125, 111);
            txtKoduGir.Margin = new Padding(4, 5, 4, 5);
            txtKoduGir.Name = "txtKoduGir";
            txtKoduGir.Size = new Size(239, 27);
            txtKoduGir.TabIndex = 4;
            // 
            // btnKoduDogrula
            // 
            btnKoduDogrula.BackgroundImage = (Image)resources.GetObject("btnKoduDogrula.BackgroundImage");
            btnKoduDogrula.BackgroundImageLayout = ImageLayout.Zoom;
            btnKoduDogrula.Enabled = false;
            btnKoduDogrula.Location = new Point(298, 151);
            btnKoduDogrula.Margin = new Padding(4, 5, 4, 5);
            btnKoduDogrula.Name = "btnKoduDogrula";
            btnKoduDogrula.Size = new Size(66, 50);
            btnKoduDogrula.TabIndex = 5;
            btnKoduDogrula.UseVisualStyleBackColor = true;
            btnKoduDogrula.Click += btnKoduDogrula_Click;
            // 
            // btn_GeriDon
            // 
            btn_GeriDon.BackgroundImage = (Image)resources.GetObject("btn_GeriDon.BackgroundImage");
            btn_GeriDon.BackgroundImageLayout = ImageLayout.Stretch;
            btn_GeriDon.Location = new Point(13, 151);
            btn_GeriDon.Margin = new Padding(4, 5, 4, 5);
            btn_GeriDon.Name = "btn_GeriDon";
            btn_GeriDon.Size = new Size(53, 50);
            btn_GeriDon.TabIndex = 6;
            btn_GeriDon.UseVisualStyleBackColor = true;
            btn_GeriDon.Click += btn_GeriDon_Click;
            // 
            // FormSifreSifirlaKodu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 215);
            Controls.Add(btn_GeriDon);
            Controls.Add(btnKoduDogrula);
            Controls.Add(txtKoduGir);
            Controls.Add(label2);
            Controls.Add(btnKoduGonder);
            Controls.Add(txtEmail);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "FormSifreSifirlaKodu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Şifre Sıfırlama";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnKoduGonder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKoduGir;
        private System.Windows.Forms.Button btnKoduDogrula;
        private Button btn_GeriDon;
    }
} 