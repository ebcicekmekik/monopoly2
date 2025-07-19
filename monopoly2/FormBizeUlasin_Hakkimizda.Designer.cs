namespace monopoly2
{
    partial class FormBizeUlasin_Hakkimizda
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBizeUlasin_Hakkimizda));
            tabControl1 = new TabControl();
            tabHakkimizda = new TabPage();
            pictureBox1 = new PictureBox();
            btn_geriDon = new Button();
            txtHakkimizda = new TextBox();
            tabNasilOynanir = new TabPage();
            pictureBox2 = new PictureBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            geriDonToolStripMenuItem = new ToolStripMenuItem();
            tabControl1.SuspendLayout();
            tabHakkimizda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabNasilOynanir.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabHakkimizda);
            tabControl1.Controls.Add(tabNasilOynanir);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Margin = new Padding(4, 5, 4, 5);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(767, 555);
            tabControl1.TabIndex = 0;
            // 
            // tabHakkimizda
            // 
            tabHakkimizda.Controls.Add(pictureBox1);
            tabHakkimizda.Controls.Add(btn_geriDon);
            tabHakkimizda.Controls.Add(txtHakkimizda);
            tabHakkimizda.Location = new Point(4, 29);
            tabHakkimizda.Margin = new Padding(4, 5, 4, 5);
            tabHakkimizda.Name = "tabHakkimizda";
            tabHakkimizda.Padding = new Padding(4, 5, 4, 5);
            tabHakkimizda.Size = new Size(759, 522);
            tabHakkimizda.TabIndex = 1;
            tabHakkimizda.Text = "Hakkımızda";
            tabHakkimizda.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(756, 517);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // btn_geriDon
            // 
            btn_geriDon.BackgroundImage = (Image)resources.GetObject("btn_geriDon.BackgroundImage");
            btn_geriDon.BackgroundImageLayout = ImageLayout.Zoom;
            btn_geriDon.Location = new Point(0, 483);
            btn_geriDon.Name = "btn_geriDon";
            btn_geriDon.Size = new Size(60, 39);
            btn_geriDon.TabIndex = 1;
            btn_geriDon.UseVisualStyleBackColor = true;
            btn_geriDon.Click += btn_geriDon_Click;
            // 
            // txtHakkimizda
            // 
            txtHakkimizda.Dock = DockStyle.Fill;
            txtHakkimizda.Location = new Point(4, 5);
            txtHakkimizda.Margin = new Padding(4, 5, 4, 5);
            txtHakkimizda.Multiline = true;
            txtHakkimizda.Name = "txtHakkimizda";
            txtHakkimizda.ReadOnly = true;
            txtHakkimizda.Size = new Size(751, 512);
            txtHakkimizda.TabIndex = 0;
            // 
            // tabNasilOynanir
            // 
            tabNasilOynanir.Controls.Add(pictureBox2);
            tabNasilOynanir.Location = new Point(4, 29);
            tabNasilOynanir.Margin = new Padding(4, 5, 4, 5);
            tabNasilOynanir.Name = "tabNasilOynanir";
            tabNasilOynanir.Padding = new Padding(4, 5, 4, 5);
            tabNasilOynanir.Size = new Size(759, 522);
            tabNasilOynanir.TabIndex = 2;
            tabNasilOynanir.Text = "Nasıl Oynanır?";
            tabNasilOynanir.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            pictureBox2.Dock = DockStyle.Fill;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(4, 5);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(751, 512);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { geriDonToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(138, 28);
            // 
            // geriDonToolStripMenuItem
            // 
            geriDonToolStripMenuItem.Name = "geriDonToolStripMenuItem";
            geriDonToolStripMenuItem.Size = new Size(137, 24);
            geriDonToolStripMenuItem.Text = "Geri Don";
            geriDonToolStripMenuItem.Click += geriDonToolStripMenuItem_Click;
            // 
            // FormBizeUlasin_Hakkimizda
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(767, 555);
            ContextMenuStrip = contextMenuStrip1;
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "FormBizeUlasin_Hakkimizda";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bize Ulaşın & Hakkımızda";
            tabControl1.ResumeLayout(false);
            tabHakkimizda.ResumeLayout(false);
            tabHakkimizda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabNasilOynanir.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabHakkimizda;
        private System.Windows.Forms.TabPage tabNasilOynanir;
        private System.Windows.Forms.TextBox txtHakkimizda;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem geriDonToolStripMenuItem;
        private Button btn_geriDon;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
} 