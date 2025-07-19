namespace monopoly2
{
    partial class FormMonopoly
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMonopoly));
            picBoard = new PictureBox();
            picOyuncu1 = new PictureBox();
            picOyuncu2 = new PictureBox();
            btnZarAt = new Button();
            lblSira = new Label();
            lblPara1 = new Label();
            lblPara2 = new Label();
            lblZar = new Label();
            lblKonum = new Label();
            pbx_Zar = new PictureBox();
            pictureBox2 = new PictureBox();
            btn_cikis = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picBoard).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picOyuncu1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picOyuncu2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbx_Zar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_cikis).BeginInit();
            SuspendLayout();
            // 
            // picBoard
            // 
            picBoard.Location = new Point(11, 13);
            picBoard.Margin = new Padding(3, 4, 3, 4);
            picBoard.Name = "picBoard";
            picBoard.Size = new Size(705, 1043);
            picBoard.TabIndex = 0;
            picBoard.TabStop = false;
            // 
            // picOyuncu1
            // 
            picOyuncu1.BackColor = Color.Blue;
            picOyuncu1.Location = new Point(11, 13);
            picOyuncu1.Margin = new Padding(3, 4, 3, 4);
            picOyuncu1.Name = "picOyuncu1";
            picOyuncu1.Size = new Size(40, 47);
            picOyuncu1.TabIndex = 1;
            picOyuncu1.TabStop = false;
            // 
            // picOyuncu2
            // 
            picOyuncu2.BackColor = Color.Red;
            picOyuncu2.Location = new Point(51, 13);
            picOyuncu2.Margin = new Padding(3, 4, 3, 4);
            picOyuncu2.Name = "picOyuncu2";
            picOyuncu2.Size = new Size(40, 47);
            picOyuncu2.TabIndex = 2;
            picOyuncu2.TabStop = false;
            // 
            // btnZarAt
            // 
            btnZarAt.BackgroundImage = (Image)resources.GetObject("btnZarAt.BackgroundImage");
            btnZarAt.BackgroundImageLayout = ImageLayout.Stretch;
            btnZarAt.Location = new Point(733, 33);
            btnZarAt.Margin = new Padding(3, 4, 3, 4);
            btnZarAt.Name = "btnZarAt";
            btnZarAt.Size = new Size(229, 115);
            btnZarAt.TabIndex = 3;
            btnZarAt.UseVisualStyleBackColor = true;
            btnZarAt.Click += btnZarAt_Click;
            // 
            // lblSira
            // 
            lblSira.AutoSize = true;
            lblSira.Location = new Point(763, 151);
            lblSira.Name = "lblSira";
            lblSira.Size = new Size(41, 20);
            lblSira.TabIndex = 4;
            lblSira.Text = "Sıra: ";
            // 
            // lblPara1
            // 
            lblPara1.AutoSize = true;
            lblPara1.BackColor = Color.Transparent;
            lblPara1.ForeColor = Color.Blue;
            lblPara1.Location = new Point(763, 186);
            lblPara1.Name = "lblPara1";
            lblPara1.Size = new Size(52, 20);
            lblPara1.TabIndex = 5;
            lblPara1.Text = "Para1: ";
            // 
            // lblPara2
            // 
            lblPara2.AutoSize = true;
            lblPara2.ForeColor = Color.Red;
            lblPara2.Location = new Point(763, 219);
            lblPara2.Name = "lblPara2";
            lblPara2.Size = new Size(52, 20);
            lblPara2.TabIndex = 6;
            lblPara2.Text = "Para2: ";
            // 
            // lblZar
            // 
            lblZar.AutoSize = true;
            lblZar.Location = new Point(763, 251);
            lblZar.Name = "lblZar";
            lblZar.Size = new Size(38, 20);
            lblZar.TabIndex = 7;
            lblZar.Text = "Zar: ";
            // 
            // lblKonum
            // 
            lblKonum.AutoSize = true;
            lblKonum.Location = new Point(763, 286);
            lblKonum.Name = "lblKonum";
            lblKonum.Size = new Size(63, 20);
            lblKonum.TabIndex = 8;
            lblKonum.Text = "Konum: ";
            // 
            // pbx_Zar
            // 
            pbx_Zar.BackColor = Color.Transparent;
            pbx_Zar.Location = new Point(743, 342);
            pbx_Zar.Name = "pbx_Zar";
            pbx_Zar.Size = new Size(218, 171);
            pbx_Zar.SizeMode = PictureBoxSizeMode.StretchImage;
            pbx_Zar.TabIndex = 9;
            pbx_Zar.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(743, 542);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(219, 155);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 10;
            pictureBox2.TabStop = false;
            // 
            // btn_cikis
            // 
            btn_cikis.Image = (Image)resources.GetObject("btn_cikis.Image");
            btn_cikis.Location = new Point(935, 1016);
            btn_cikis.Name = "btn_cikis";
            btn_cikis.Size = new Size(54, 42);
            btn_cikis.SizeMode = PictureBoxSizeMode.StretchImage;
            btn_cikis.TabIndex = 11;
            btn_cikis.TabStop = false;
            btn_cikis.Click += btn_cikis_Click;
            // 
            // FormMonopoly
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1045, 1055);
            Controls.Add(btn_cikis);
            Controls.Add(pictureBox2);
            Controls.Add(pbx_Zar);
            Controls.Add(lblKonum);
            Controls.Add(lblZar);
            Controls.Add(lblPara2);
            Controls.Add(lblPara1);
            Controls.Add(lblSira);
            Controls.Add(btnZarAt);
            Controls.Add(picOyuncu2);
            Controls.Add(picOyuncu1);
            Controls.Add(picBoard);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormMonopoly";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Monopoly";
            ((System.ComponentModel.ISupportInitialize)picBoard).EndInit();
            ((System.ComponentModel.ISupportInitialize)picOyuncu1).EndInit();
            ((System.ComponentModel.ISupportInitialize)picOyuncu2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbx_Zar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_cikis).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox picBoard;
        private System.Windows.Forms.PictureBox picOyuncu1;
        private System.Windows.Forms.PictureBox picOyuncu2;
        private System.Windows.Forms.Button btnZarAt;
        private System.Windows.Forms.Label lblSira;
        private System.Windows.Forms.Label lblPara1;
        private System.Windows.Forms.Label lblPara2;
        private System.Windows.Forms.Label lblZar;
        private System.Windows.Forms.Label lblKonum;
        private PictureBox pbx_Zar;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox btn_cikis;
    }
} 