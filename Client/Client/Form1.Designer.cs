
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.bottone3 = new Client.RJButtons();
            this.bottone2 = new Client.RJButtons();
            this.bottone1 = new Client.RJButtons();
            this.bottone0 = new Client.RJButtons();
            this.rjButtons1 = new Client.RJButtons();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Username = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.Label();
            this.Sign_In = new System.Windows.Forms.Label();
            this.Login = new Client.RJButtons();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.bottone3);
            this.panel1.Controls.Add(this.bottone2);
            this.panel1.Controls.Add(this.bottone1);
            this.panel1.Controls.Add(this.bottone0);
            this.panel1.Controls.Add(this.rjButtons1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1085, 601);
            this.panel1.TabIndex = 0;
            this.panel1.Visible = false;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(320, 116);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(190, 388);
            this.listBox1.TabIndex = 47;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // bottone3
            // 
            this.bottone3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.bottone3.BackColor = System.Drawing.Color.White;
            this.bottone3.FlatAppearance.BorderSize = 0;
            this.bottone3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bottone3.ForeColor = System.Drawing.Color.Black;
            this.bottone3.Location = new System.Drawing.Point(320, 12);
            this.bottone3.Name = "bottone3";
            this.bottone3.Size = new System.Drawing.Size(662, 62);
            this.bottone3.TabIndex = 46;
            this.bottone3.Text = "Ricerca utente";
            this.bottone3.UseVisualStyleBackColor = false;
            this.bottone3.Click += new System.EventHandler(this.bottone3_Click);
            // 
            // bottone2
            // 
            this.bottone2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.bottone2.BackColor = System.Drawing.Color.Black;
            this.bottone2.FlatAppearance.BorderSize = 0;
            this.bottone2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bottone2.ForeColor = System.Drawing.Color.White;
            this.bottone2.Location = new System.Drawing.Point(17, 311);
            this.bottone2.Name = "bottone2";
            this.bottone2.Size = new System.Drawing.Size(249, 47);
            this.bottone2.TabIndex = 45;
            this.bottone2.Text = "In programma";
            this.bottone2.UseVisualStyleBackColor = false;
            this.bottone2.Click += new System.EventHandler(this.bottone2_Click);
            // 
            // bottone1
            // 
            this.bottone1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.bottone1.BackColor = System.Drawing.Color.Black;
            this.bottone1.FlatAppearance.BorderSize = 0;
            this.bottone1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bottone1.ForeColor = System.Drawing.Color.White;
            this.bottone1.Location = new System.Drawing.Point(17, 242);
            this.bottone1.Name = "bottone1";
            this.bottone1.Size = new System.Drawing.Size(249, 47);
            this.bottone1.TabIndex = 44;
            this.bottone1.Text = "In corso";
            this.bottone1.UseVisualStyleBackColor = false;
            this.bottone1.Click += new System.EventHandler(this.bottone1_Click);
            // 
            // bottone0
            // 
            this.bottone0.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.bottone0.BackColor = System.Drawing.Color.Black;
            this.bottone0.FlatAppearance.BorderSize = 0;
            this.bottone0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bottone0.ForeColor = System.Drawing.Color.White;
            this.bottone0.Location = new System.Drawing.Point(17, 174);
            this.bottone0.Name = "bottone0";
            this.bottone0.Size = new System.Drawing.Size(249, 47);
            this.bottone0.TabIndex = 43;
            this.bottone0.Text = "Completato";
            this.bottone0.UseVisualStyleBackColor = false;
            this.bottone0.Click += new System.EventHandler(this.bottone0_Click);
            // 
            // rjButtons1
            // 
            this.rjButtons1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rjButtons1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.rjButtons1.FlatAppearance.BorderSize = 0;
            this.rjButtons1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButtons1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButtons1.ForeColor = System.Drawing.Color.White;
            this.rjButtons1.Location = new System.Drawing.Point(988, 12);
            this.rjButtons1.Name = "rjButtons1";
            this.rjButtons1.Size = new System.Drawing.Size(67, 62);
            this.rjButtons1.TabIndex = 42;
            this.rjButtons1.Text = " +";
            this.rjButtons1.UseVisualStyleBackColor = false;
            this.rjButtons1.Click += new System.EventHandler(this.rjButtons1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(141, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 16);
            this.label2.TabIndex = 26;
            this.label2.Text = "@Username";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(141, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 25;
            this.label1.Text = "Name";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Client.Properties.Resources._default;
            this.pictureBox1.Location = new System.Drawing.Point(17, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 92);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(412, 178);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(248, 22);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(412, 258);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(248, 22);
            this.textBox2.TabIndex = 2;
            // 
            // Username
            // 
            this.Username.AutoSize = true;
            this.Username.ForeColor = System.Drawing.SystemColors.Window;
            this.Username.Location = new System.Drawing.Point(495, 159);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(70, 16);
            this.Username.TabIndex = 3;
            this.Username.Text = "Username";
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.ForeColor = System.Drawing.SystemColors.Window;
            this.Password.Location = new System.Drawing.Point(495, 239);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(67, 16);
            this.Password.TabIndex = 4;
            this.Password.Text = "Password";
            // 
            // Sign_In
            // 
            this.Sign_In.AutoSize = true;
            this.Sign_In.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sign_In.ForeColor = System.Drawing.SystemColors.Window;
            this.Sign_In.Location = new System.Drawing.Point(481, 9);
            this.Sign_In.Name = "Sign_In";
            this.Sign_In.Size = new System.Drawing.Size(102, 32);
            this.Sign_In.TabIndex = 6;
            this.Sign_In.Text = "Sign in";
            // 
            // Login
            // 
            this.Login.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.Login.FlatAppearance.BorderSize = 0;
            this.Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Login.ForeColor = System.Drawing.Color.White;
            this.Login.Location = new System.Drawing.Point(412, 481);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(248, 45);
            this.Login.TabIndex = 5;
            this.Login.Text = "Login";
            this.Login.UseVisualStyleBackColor = false;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // Backlog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Sign_In);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Backlog";
            this.Text = "Backlog";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Backlog_FormClosing);
            this.Load += new System.EventHandler(this.Backlog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private RJButtons bottone3;
        private RJButtons bottone2;
        private RJButtons bottone1;
        private RJButtons bottone0;
        private RJButtons rjButtons1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label Username;
        private System.Windows.Forms.Label Password;
        private RJButtons Login;
        private System.Windows.Forms.Label Sign_In;
        private System.Windows.Forms.ListBox listBox1;
    }
}

