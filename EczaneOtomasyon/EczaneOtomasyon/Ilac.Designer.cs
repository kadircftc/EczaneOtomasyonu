namespace EczaneOtomasyon
{
    partial class Ilac
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ilac));
            this.GeributtonDoktor = new System.Windows.Forms.Button();
            this.IlacFirmasıButton = new System.Windows.Forms.Button();
            this.IlacIslemleriButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GeributtonDoktor
            // 
            this.GeributtonDoktor.Image = ((System.Drawing.Image)(resources.GetObject("GeributtonDoktor.Image")));
            this.GeributtonDoktor.Location = new System.Drawing.Point(0, -5);
            this.GeributtonDoktor.Name = "GeributtonDoktor";
            this.GeributtonDoktor.Size = new System.Drawing.Size(42, 40);
            this.GeributtonDoktor.TabIndex = 15;
            this.GeributtonDoktor.UseVisualStyleBackColor = true;
            this.GeributtonDoktor.Click += new System.EventHandler(this.GeributtonDoktor_Click);
            // 
            // IlacFirmasıButton
            // 
            this.IlacFirmasıButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.IlacFirmasıButton.Location = new System.Drawing.Point(187, 174);
            this.IlacFirmasıButton.Name = "IlacFirmasıButton";
            this.IlacFirmasıButton.Size = new System.Drawing.Size(197, 96);
            this.IlacFirmasıButton.TabIndex = 16;
            this.IlacFirmasıButton.Text = "İlaç Firması İşlemleri";
            this.IlacFirmasıButton.UseVisualStyleBackColor = true;
            this.IlacFirmasıButton.Click += new System.EventHandler(this.IlacFirmasıButton_Click);
            // 
            // IlacIslemleriButton
            // 
            this.IlacIslemleriButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.IlacIslemleriButton.Location = new System.Drawing.Point(445, 174);
            this.IlacIslemleriButton.Name = "IlacIslemleriButton";
            this.IlacIslemleriButton.Size = new System.Drawing.Size(197, 96);
            this.IlacIslemleriButton.TabIndex = 17;
            this.IlacIslemleriButton.Text = "İlaç Ekleme Silme İşlemleri";
            this.IlacIslemleriButton.UseVisualStyleBackColor = true;
            this.IlacIslemleriButton.Click += new System.EventHandler(this.IlacIslemleriButton_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(0, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(42, 40);
            this.button1.TabIndex = 22;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Ilac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.IlacIslemleriButton);
            this.Controls.Add(this.IlacFirmasıButton);
            this.Controls.Add(this.GeributtonDoktor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Ilac";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "İlaç Firma Ve İlaç İşlemleri";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GeributtonDoktor;
        private System.Windows.Forms.Button IlacFirmasıButton;
        private System.Windows.Forms.Button IlacIslemleriButton;
        private System.Windows.Forms.Button button1;
    }
}