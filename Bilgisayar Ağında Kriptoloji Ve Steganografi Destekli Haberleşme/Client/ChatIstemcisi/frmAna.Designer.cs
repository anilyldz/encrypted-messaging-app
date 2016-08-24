namespace ChatIstemcisi
{
    partial class frmAna
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAna));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btncikis = new System.Windows.Forms.Button();
            this.Mail = new System.Windows.Forms.Button();
            this.lblNick = new System.Windows.Forms.Label();
            this.gbKullanicilar = new System.Windows.Forms.GroupBox();
            this.lstKullanicilar = new System.Windows.Forms.ListBox();
            this.gbMesajlar = new System.Windows.Forms.GroupBox();
            this.btngonder = new System.Windows.Forms.Button();
            this.txtTopluMesaj = new System.Windows.Forms.TextBox();
            this.txtTopluMesajlar = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.gbKullanicilar.SuspendLayout();
            this.gbMesajlar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btncikis);
            this.panel1.Controls.Add(this.Mail);
            this.panel1.Controls.Add(this.lblNick);
            this.panel1.Controls.Add(this.gbKullanicilar);
            this.panel1.Controls.Add(this.gbMesajlar);
            this.panel1.Location = new System.Drawing.Point(2, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(740, 521);
            this.panel1.TabIndex = 0;
            // 
            // btncikis
            // 
            this.btncikis.Image = ((System.Drawing.Image)(resources.GetObject("btncikis.Image")));
            this.btncikis.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btncikis.Location = new System.Drawing.Point(11, 459);
            this.btncikis.Name = "btncikis";
            this.btncikis.Size = new System.Drawing.Size(169, 45);
            this.btncikis.TabIndex = 6;
            this.btncikis.Text = "Çýkýþ";
            this.btncikis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncikis.UseVisualStyleBackColor = true;
            this.btncikis.Click += new System.EventHandler(this.button2_Click);
            // 
            // Mail
            // 
            this.Mail.Image = ((System.Drawing.Image)(resources.GetObject("Mail.Image")));
            this.Mail.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Mail.Location = new System.Drawing.Point(11, 408);
            this.Mail.Name = "Mail";
            this.Mail.Size = new System.Drawing.Size(169, 45);
            this.Mail.TabIndex = 5;
            this.Mail.Text = "Mail Sistemi";
            this.Mail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Mail.UseVisualStyleBackColor = true;
            this.Mail.Click += new System.EventHandler(this.Mail_Click);
            // 
            // lblNick
            // 
            this.lblNick.BackColor = System.Drawing.Color.DarkTurquoise;
            this.lblNick.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNick.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblNick.ForeColor = System.Drawing.Color.White;
            this.lblNick.Location = new System.Drawing.Point(2, 6);
            this.lblNick.Name = "lblNick";
            this.lblNick.Size = new System.Drawing.Size(187, 23);
            this.lblNick.TabIndex = 4;
            this.lblNick.Text = "KULLANICI ADI";
            this.lblNick.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbKullanicilar
            // 
            this.gbKullanicilar.Controls.Add(this.lstKullanicilar);
            this.gbKullanicilar.Enabled = false;
            this.gbKullanicilar.Location = new System.Drawing.Point(2, 32);
            this.gbKullanicilar.Name = "gbKullanicilar";
            this.gbKullanicilar.Size = new System.Drawing.Size(187, 365);
            this.gbKullanicilar.TabIndex = 3;
            this.gbKullanicilar.TabStop = false;
            this.gbKullanicilar.Text = "Kullanýcýlar";
            // 
            // lstKullanicilar
            // 
            this.lstKullanicilar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstKullanicilar.FormattingEnabled = true;
            this.lstKullanicilar.ItemHeight = 16;
            this.lstKullanicilar.Location = new System.Drawing.Point(9, 18);
            this.lstKullanicilar.Name = "lstKullanicilar";
            this.lstKullanicilar.Size = new System.Drawing.Size(169, 338);
            this.lstKullanicilar.TabIndex = 0;
            this.lstKullanicilar.SelectedIndexChanged += new System.EventHandler(this.lstKullanicilar_SelectedIndexChanged_1);
            this.lstKullanicilar.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstKullanicilar_MouseDoubleClick);
            // 
            // gbMesajlar
            // 
            this.gbMesajlar.Controls.Add(this.btngonder);
            this.gbMesajlar.Controls.Add(this.txtTopluMesaj);
            this.gbMesajlar.Controls.Add(this.txtTopluMesajlar);
            this.gbMesajlar.Enabled = false;
            this.gbMesajlar.Location = new System.Drawing.Point(201, 3);
            this.gbMesajlar.Name = "gbMesajlar";
            this.gbMesajlar.Size = new System.Drawing.Size(527, 510);
            this.gbMesajlar.TabIndex = 1;
            this.gbMesajlar.TabStop = false;
            this.gbMesajlar.Text = "Mesajlar";
            // 
            // btngonder
            // 
            this.btngonder.Image = ((System.Drawing.Image)(resources.GetObject("btngonder.Image")));
            this.btngonder.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btngonder.Location = new System.Drawing.Point(423, 456);
            this.btngonder.Name = "btngonder";
            this.btngonder.Size = new System.Drawing.Size(95, 45);
            this.btngonder.TabIndex = 2;
            this.btngonder.Text = "Gönder";
            this.btngonder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btngonder.UseVisualStyleBackColor = true;
            this.btngonder.Click += new System.EventHandler(this.btngonder_Click);
            // 
            // txtTopluMesaj
            // 
            this.txtTopluMesaj.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTopluMesaj.Location = new System.Drawing.Point(9, 405);
            this.txtTopluMesaj.Multiline = true;
            this.txtTopluMesaj.Name = "txtTopluMesaj";
            this.txtTopluMesaj.Size = new System.Drawing.Size(408, 96);
            this.txtTopluMesaj.TabIndex = 1;
            this.txtTopluMesaj.TextChanged += new System.EventHandler(this.txtTopluMesaj_TextChanged);
            this.txtTopluMesaj.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTopluMesaj_KeyPress);
            // 
            // txtTopluMesajlar
            // 
            this.txtTopluMesajlar.BackColor = System.Drawing.Color.Linen;
            this.txtTopluMesajlar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTopluMesajlar.Location = new System.Drawing.Point(9, 22);
            this.txtTopluMesajlar.Multiline = true;
            this.txtTopluMesajlar.Name = "txtTopluMesajlar";
            this.txtTopluMesajlar.ReadOnly = true;
            this.txtTopluMesajlar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTopluMesajlar.Size = new System.Drawing.Size(509, 372);
            this.txtTopluMesajlar.TabIndex = 0;
            this.txtTopluMesajlar.TextChanged += new System.EventHandler(this.txtTopluMesajlar_TextChanged);
            // 
            // frmAna
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(745, 539);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmAna";
            this.Text = "AS Chat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAna_FormClosing);
            this.Load += new System.EventHandler(this.frmAna_Load);
            this.Shown += new System.EventHandler(this.frmAna_Shown);
            this.panel1.ResumeLayout(false);
            this.gbKullanicilar.ResumeLayout(false);
            this.gbMesajlar.ResumeLayout(false);
            this.gbMesajlar.PerformLayout();
            this.ResumeLayout(false);

        }

        private void lstKullanicilar_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbMesajlar;
        private System.Windows.Forms.TextBox txtTopluMesaj;
        private System.Windows.Forms.TextBox txtTopluMesajlar;
        private System.Windows.Forms.Label lblNick;
        private System.Windows.Forms.GroupBox gbKullanicilar;
        private System.Windows.Forms.ListBox lstKullanicilar;
        private System.Windows.Forms.Button Mail;
        private System.Windows.Forms.Button btncikis;
        private System.Windows.Forms.Button btngonder;
    }
}

