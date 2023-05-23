namespace EczaneOtomasyon
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.IlacIslemleriButton = new System.Windows.Forms.Button();
            this.Eczanebutton = new System.Windows.Forms.Button();
            this.DoktorYetkilibutton = new System.Windows.Forms.Button();
            this.HastaIslemleributton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // IlacIslemleriButton
            // 
            this.IlacIslemleriButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IlacIslemleriButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.IlacIslemleriButton.Location = new System.Drawing.Point(615, 290);
            this.IlacIslemleriButton.Name = "IlacIslemleriButton";
            this.IlacIslemleriButton.Size = new System.Drawing.Size(149, 63);
            this.IlacIslemleriButton.TabIndex = 8;
            this.IlacIslemleriButton.Text = "İlaç İşlemleri";
            this.IlacIslemleriButton.UseVisualStyleBackColor = true;
            this.IlacIslemleriButton.Click += new System.EventHandler(this.IlacIslemleriButton_Click);
            // 
            // Eczanebutton
            // 
            this.Eczanebutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Eczanebutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Eczanebutton.Location = new System.Drawing.Point(420, 290);
            this.Eczanebutton.Name = "Eczanebutton";
            this.Eczanebutton.Size = new System.Drawing.Size(149, 63);
            this.Eczanebutton.TabIndex = 7;
            this.Eczanebutton.Text = "Eczane İşlemleri";
            this.Eczanebutton.UseVisualStyleBackColor = true;
            this.Eczanebutton.Click += new System.EventHandler(this.Eczanebutton_Click);
            // 
            // DoktorYetkilibutton
            // 
            this.DoktorYetkilibutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoktorYetkilibutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.DoktorYetkilibutton.Location = new System.Drawing.Point(224, 290);
            this.DoktorYetkilibutton.Name = "DoktorYetkilibutton";
            this.DoktorYetkilibutton.Size = new System.Drawing.Size(149, 63);
            this.DoktorYetkilibutton.TabIndex = 6;
            this.DoktorYetkilibutton.Text = "Doktor İşlemleri";
            this.DoktorYetkilibutton.UseVisualStyleBackColor = true;
            this.DoktorYetkilibutton.Click += new System.EventHandler(this.DoktorYetkilibutton_Click);
            // 
            // HastaIslemleributton
            // 
            this.HastaIslemleributton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HastaIslemleributton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.HastaIslemleributton.Location = new System.Drawing.Point(36, 290);
            this.HastaIslemleributton.Name = "HastaIslemleributton";
            this.HastaIslemleributton.Size = new System.Drawing.Size(149, 63);
            this.HastaIslemleributton.TabIndex = 5;
            this.HastaIslemleributton.Text = "Hasta İşlemleri";
            this.HastaIslemleributton.UseVisualStyleBackColor = true;
            this.HastaIslemleributton.Click += new System.EventHandler(this.HastaIslemleributton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Firebrick;
            this.label1.Location = new System.Drawing.Point(69, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(683, 36);
            this.label1.TabIndex = 9;
            this.label1.Text = "TC. SAĞLIK BAKANLIĞI HASTANE HİZMETLERİ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(191, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(435, 162);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IlacIslemleriButton);
            this.Controls.Add(this.Eczanebutton);
            this.Controls.Add(this.DoktorYetkilibutton);
            this.Controls.Add(this.HastaIslemleributton);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hastane Hizmetleri";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button IlacIslemleriButton;
        private System.Windows.Forms.Button Eczanebutton;
        private System.Windows.Forms.Button DoktorYetkilibutton;
        private System.Windows.Forms.Button HastaIslemleributton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

