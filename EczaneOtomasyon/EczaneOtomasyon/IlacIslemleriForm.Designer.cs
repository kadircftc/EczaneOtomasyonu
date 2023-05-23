namespace EczaneOtomasyon
{
    partial class IlacIslemleriForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IlacIslemleriForm));
            this.GeributtonDoktor = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.IlacIDText = new System.Windows.Forms.TextBox();
            this.IlacGüncelleButton = new System.Windows.Forms.Button();
            this.IlacSilButton = new System.Windows.Forms.Button();
            this.IlacEkleButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.IlacFormülText = new System.Windows.Forms.TextBox();
            this.IlacMarkaText = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ılacIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formulDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.markaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ılacBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eczaneDataSet = new EczaneOtomasyon.EczaneDataSet();
            this.ilacTableAdapter = new EczaneOtomasyon.EczaneDataSetTableAdapters.IlacTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ılacBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eczaneDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // GeributtonDoktor
            // 
            this.GeributtonDoktor.Image = ((System.Drawing.Image)(resources.GetObject("GeributtonDoktor.Image")));
            this.GeributtonDoktor.Location = new System.Drawing.Point(0, -4);
            this.GeributtonDoktor.Name = "GeributtonDoktor";
            this.GeributtonDoktor.Size = new System.Drawing.Size(42, 40);
            this.GeributtonDoktor.TabIndex = 16;
            this.GeributtonDoktor.UseVisualStyleBackColor = true;
            this.GeributtonDoktor.Click += new System.EventHandler(this.GeributtonDoktor_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.IlacIDText);
            this.groupBox1.Controls.Add(this.IlacGüncelleButton);
            this.groupBox1.Controls.Add(this.IlacSilButton);
            this.groupBox1.Controls.Add(this.IlacEkleButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.IlacFormülText);
            this.groupBox1.Controls.Add(this.IlacMarkaText);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(96, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 317);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "İlaç Ekle/Sil";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "İlaç ID:";
            // 
            // IlacIDText
            // 
            this.IlacIDText.Enabled = false;
            this.IlacIDText.Location = new System.Drawing.Point(130, 40);
            this.IlacIDText.Name = "IlacIDText";
            this.IlacIDText.Size = new System.Drawing.Size(100, 22);
            this.IlacIDText.TabIndex = 7;
            // 
            // IlacGüncelleButton
            // 
            this.IlacGüncelleButton.Location = new System.Drawing.Point(116, 256);
            this.IlacGüncelleButton.Name = "IlacGüncelleButton";
            this.IlacGüncelleButton.Size = new System.Drawing.Size(86, 36);
            this.IlacGüncelleButton.TabIndex = 6;
            this.IlacGüncelleButton.Text = "Güncelle";
            this.IlacGüncelleButton.UseVisualStyleBackColor = true;
            this.IlacGüncelleButton.Click += new System.EventHandler(this.IlacGüncelleButton_Click);
            // 
            // IlacSilButton
            // 
            this.IlacSilButton.Location = new System.Drawing.Point(116, 205);
            this.IlacSilButton.Name = "IlacSilButton";
            this.IlacSilButton.Size = new System.Drawing.Size(86, 36);
            this.IlacSilButton.TabIndex = 5;
            this.IlacSilButton.Text = "Sil";
            this.IlacSilButton.UseVisualStyleBackColor = true;
            this.IlacSilButton.Click += new System.EventHandler(this.IlacSilButton_Click);
            // 
            // IlacEkleButton
            // 
            this.IlacEkleButton.Location = new System.Drawing.Point(116, 154);
            this.IlacEkleButton.Name = "IlacEkleButton";
            this.IlacEkleButton.Size = new System.Drawing.Size(86, 36);
            this.IlacEkleButton.TabIndex = 4;
            this.IlacEkleButton.Text = "Ekle";
            this.IlacEkleButton.UseVisualStyleBackColor = true;
            this.IlacEkleButton.Click += new System.EventHandler(this.IlacEkleButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "İlaç Formül:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Marka:";
            // 
            // IlacFormülText
            // 
            this.IlacFormülText.Location = new System.Drawing.Point(130, 116);
            this.IlacFormülText.Name = "IlacFormülText";
            this.IlacFormülText.Size = new System.Drawing.Size(100, 22);
            this.IlacFormülText.TabIndex = 1;
            // 
            // IlacMarkaText
            // 
            this.IlacMarkaText.Location = new System.Drawing.Point(130, 77);
            this.IlacMarkaText.Name = "IlacMarkaText";
            this.IlacMarkaText.Size = new System.Drawing.Size(100, 22);
            this.IlacMarkaText.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ılacIDDataGridViewTextBoxColumn,
            this.formulDataGridViewTextBoxColumn,
            this.markaDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.ılacBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(426, 64);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(325, 317);
            this.dataGridView1.TabIndex = 18;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // ılacIDDataGridViewTextBoxColumn
            // 
            this.ılacIDDataGridViewTextBoxColumn.DataPropertyName = "IlacID";
            this.ılacIDDataGridViewTextBoxColumn.HeaderText = "IlacID";
            this.ılacIDDataGridViewTextBoxColumn.Name = "ılacIDDataGridViewTextBoxColumn";
            this.ılacIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // formulDataGridViewTextBoxColumn
            // 
            this.formulDataGridViewTextBoxColumn.DataPropertyName = "Formul";
            this.formulDataGridViewTextBoxColumn.HeaderText = "Formul";
            this.formulDataGridViewTextBoxColumn.Name = "formulDataGridViewTextBoxColumn";
            // 
            // markaDataGridViewTextBoxColumn
            // 
            this.markaDataGridViewTextBoxColumn.DataPropertyName = "Marka";
            this.markaDataGridViewTextBoxColumn.HeaderText = "Marka";
            this.markaDataGridViewTextBoxColumn.Name = "markaDataGridViewTextBoxColumn";
            // 
            // ılacBindingSource
            // 
            this.ılacBindingSource.DataMember = "Ilac";
            this.ılacBindingSource.DataSource = this.eczaneDataSet;
            // 
            // eczaneDataSet
            // 
            this.eczaneDataSet.DataSetName = "EczaneDataSet";
            this.eczaneDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ilacTableAdapter
            // 
            this.ilacTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(0, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(42, 40);
            this.button1.TabIndex = 19;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(411, 430);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.Firebrick;
            this.label6.Location = new System.Drawing.Point(435, 430);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(367, 20);
            this.label6.TabIndex = 20;
            this.label6.Text = "TC. SAĞLIK BAKANLIĞI HASTANE HİZMETLERİ";
            // 
            // IlacIslemleriForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GeributtonDoktor);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "IlacIslemleriForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IlacIslemleriForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IlacIslemleriForm_FormClosing_1);
            this.Load += new System.EventHandler(this.IlacIslemleriForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ılacBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eczaneDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GeributtonDoktor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox IlacFormülText;
        private System.Windows.Forms.TextBox IlacMarkaText;
        private System.Windows.Forms.DataGridView dataGridView1;
        private EczaneDataSet eczaneDataSet;
        private System.Windows.Forms.BindingSource ılacBindingSource;
        private EczaneDataSetTableAdapters.IlacTableAdapter ilacTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn ılacIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn formulDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn markaDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button IlacGüncelleButton;
        private System.Windows.Forms.Button IlacSilButton;
        private System.Windows.Forms.Button IlacEkleButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox IlacIDText;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
    }
}