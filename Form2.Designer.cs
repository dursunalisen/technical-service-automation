namespace WindowsFormsApplication1
{
    partial class FormAnaSayfa
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
            this.btnArızaÇıkış = new System.Windows.Forms.Button();
            this.btnArızaGiriş = new System.Windows.Forms.Button();
            this.btnMüşteriler = new System.Windows.Forms.Button();
            this.btnPersonel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnArızaÇıkış
            // 
            this.btnArızaÇıkış.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnArızaÇıkış.Image = global::WindowsFormsApplication1.Properties.Resources.tek_WOON_NOTEBOOK_ARIZALAR_VE_TAMIRI;
            this.btnArızaÇıkış.Location = new System.Drawing.Point(12, 180);
            this.btnArızaÇıkış.Name = "btnArızaÇıkış";
            this.btnArızaÇıkış.Size = new System.Drawing.Size(108, 90);
            this.btnArızaÇıkış.TabIndex = 2;
            this.btnArızaÇıkış.Text = "Arıza Çıkış";
            this.btnArızaÇıkış.UseVisualStyleBackColor = true;
            this.btnArızaÇıkış.Click += new System.EventHandler(this.btnArızaÇıkış_Click);
            // 
            // btnArızaGiriş
            // 
            this.btnArızaGiriş.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnArızaGiriş.Image = global::WindowsFormsApplication1.Properties.Resources.teknik_servis;
            this.btnArızaGiriş.Location = new System.Drawing.Point(136, 38);
            this.btnArızaGiriş.Name = "btnArızaGiriş";
            this.btnArızaGiriş.Size = new System.Drawing.Size(106, 94);
            this.btnArızaGiriş.TabIndex = 1;
            this.btnArızaGiriş.Text = "Arıza Giriş";
            this.btnArızaGiriş.UseVisualStyleBackColor = true;
            this.btnArızaGiriş.Click += new System.EventHandler(this.btnArızaGiriş_Click);
            // 
            // btnMüşteriler
            // 
            this.btnMüşteriler.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMüşteriler.Image = global::WindowsFormsApplication1.Properties.Resources.personel;
            this.btnMüşteriler.Location = new System.Drawing.Point(12, 38);
            this.btnMüşteriler.Name = "btnMüşteriler";
            this.btnMüşteriler.Size = new System.Drawing.Size(109, 94);
            this.btnMüşteriler.TabIndex = 0;
            this.btnMüşteriler.Text = "Müşteriler";
            this.btnMüşteriler.UseVisualStyleBackColor = true;
            this.btnMüşteriler.Click += new System.EventHandler(this.btnMüşteriler_Click);
            // 
            // btnPersonel
            // 
            this.btnPersonel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnPersonel.Image = global::WindowsFormsApplication1.Properties.Resources.indir;
            this.btnPersonel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPersonel.Location = new System.Drawing.Point(136, 180);
            this.btnPersonel.Name = "btnPersonel";
            this.btnPersonel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnPersonel.Size = new System.Drawing.Size(106, 90);
            this.btnPersonel.TabIndex = 3;
            this.btnPersonel.Text = "Personel";
            this.btnPersonel.UseVisualStyleBackColor = true;
            this.btnPersonel.Click += new System.EventHandler(this.btnPersonel_Click);
            // 
            // FormAnaSayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 282);
            this.Controls.Add(this.btnArızaÇıkış);
            this.Controls.Add(this.btnArızaGiriş);
            this.Controls.Add(this.btnMüşteriler);
            this.Controls.Add(this.btnPersonel);
            this.Name = "FormAnaSayfa";
            this.Text = "Ana Sayfa";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMüşteriler;
        private System.Windows.Forms.Button btnArızaGiriş;
        private System.Windows.Forms.Button btnArızaÇıkış;
        private System.Windows.Forms.Button btnPersonel;
    }
}