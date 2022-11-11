
namespace Client
{
    partial class Backlog
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bottone3 = new Client.RJButtons();
            this.bottone2 = new Client.RJButtons();
            this.bottone1 = new Client.RJButtons();
            this.bottone0 = new Client.RJButtons();
            this.rjButtons1 = new Client.RJButtons();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Client.Properties.Resources._default;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(105, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(105, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "@Username";
            // 
            // bottone3
            // 
            this.bottone3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bottone3.BackColor = System.Drawing.Color.White;
            this.bottone3.FlatAppearance.BorderSize = 0;
            this.bottone3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bottone3.ForeColor = System.Drawing.Color.Black;
            this.bottone3.Location = new System.Drawing.Point(239, 10);
            this.bottone3.Margin = new System.Windows.Forms.Padding(2);
            this.bottone3.Name = "bottone3";
            this.bottone3.Size = new System.Drawing.Size(496, 50);
            this.bottone3.TabIndex = 23;
            this.bottone3.Text = "Ricerca utente";
            this.bottone3.UseVisualStyleBackColor = false;
            this.bottone3.Click += new System.EventHandler(this.rjButtons5_Click);
            // 
            // bottone2
            // 
            this.bottone2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.bottone2.BackColor = System.Drawing.Color.Black;
            this.bottone2.FlatAppearance.BorderSize = 0;
            this.bottone2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bottone2.ForeColor = System.Drawing.Color.White;
            this.bottone2.Location = new System.Drawing.Point(12, 253);
            this.bottone2.Margin = new System.Windows.Forms.Padding(2);
            this.bottone2.Name = "bottone2";
            this.bottone2.Size = new System.Drawing.Size(187, 38);
            this.bottone2.TabIndex = 22;
            this.bottone2.Text = "In programma";
            this.bottone2.UseVisualStyleBackColor = false;
            this.bottone2.Click += new System.EventHandler(this.rjButtons4_Click);
            // 
            // bottone1
            // 
            this.bottone1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.bottone1.BackColor = System.Drawing.Color.Black;
            this.bottone1.FlatAppearance.BorderSize = 0;
            this.bottone1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bottone1.ForeColor = System.Drawing.Color.White;
            this.bottone1.Location = new System.Drawing.Point(12, 197);
            this.bottone1.Margin = new System.Windows.Forms.Padding(2);
            this.bottone1.Name = "bottone1";
            this.bottone1.Size = new System.Drawing.Size(187, 38);
            this.bottone1.TabIndex = 21;
            this.bottone1.Text = "In corso";
            this.bottone1.UseVisualStyleBackColor = false;
            this.bottone1.Click += new System.EventHandler(this.rjButtons3_Click);
            // 
            // bottone0
            // 
            this.bottone0.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.bottone0.BackColor = System.Drawing.Color.Black;
            this.bottone0.FlatAppearance.BorderSize = 0;
            this.bottone0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bottone0.ForeColor = System.Drawing.Color.White;
            this.bottone0.Location = new System.Drawing.Point(12, 141);
            this.bottone0.Margin = new System.Windows.Forms.Padding(2);
            this.bottone0.Name = "bottone0";
            this.bottone0.Size = new System.Drawing.Size(187, 38);
            this.bottone0.TabIndex = 20;
            this.bottone0.Text = "Completato";
            this.bottone0.UseVisualStyleBackColor = false;
            this.bottone0.Click += new System.EventHandler(this.rjButtons2_Click);
            // 
            // rjButtons1
            // 
            this.rjButtons1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rjButtons1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.rjButtons1.FlatAppearance.BorderSize = 0;
            this.rjButtons1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButtons1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButtons1.ForeColor = System.Drawing.Color.White;
            this.rjButtons1.Location = new System.Drawing.Point(740, 10);
            this.rjButtons1.Margin = new System.Windows.Forms.Padding(2);
            this.rjButtons1.Name = "rjButtons1";
            this.rjButtons1.Size = new System.Drawing.Size(50, 50);
            this.rjButtons1.TabIndex = 19;
            this.rjButtons1.Text = " +";
            this.rjButtons1.UseVisualStyleBackColor = false;
            // 
            // Backlog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bottone3);
            this.Controls.Add(this.bottone2);
            this.Controls.Add(this.bottone1);
            this.Controls.Add(this.bottone0);
            this.Controls.Add(this.rjButtons1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Backlog";
            this.Text = "Backlog";
            this.Load += new System.EventHandler(this.Backlog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private RJButtons rjButtons1;
        private RJButtons bottone0;
        private RJButtons bottone1;
        private RJButtons bottone2;
        private RJButtons bottone3;
    }
}

