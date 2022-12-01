namespace Client {
    partial class Form3 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.invio = new Client.RJButtons();
            this.SuspendLayout();
            // 
            // invio
            // 
            this.invio.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.invio.FlatAppearance.BorderSize = 0;
            this.invio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.invio.ForeColor = System.Drawing.Color.White;
            this.invio.Location = new System.Drawing.Point(305, 370);
            this.invio.Name = "invio";
            this.invio.Size = new System.Drawing.Size(150, 40);
            this.invio.TabIndex = 0;
            this.invio.Text = "Aggiungi";
            this.invio.UseVisualStyleBackColor = false;
            this.invio.Click += new System.EventHandler(this.invio_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuText;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.invio);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private RJButtons invio;
    }
}