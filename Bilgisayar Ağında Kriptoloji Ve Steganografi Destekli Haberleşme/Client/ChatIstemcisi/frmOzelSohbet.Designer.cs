namespace ChatIstemcisi
{
    partial class frmOzelSohbet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOzelSohbet));
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbMesajlar = new System.Windows.Forms.GroupBox();
            this.txtOzelMesaj = new System.Windows.Forms.TextBox();
            this.txtOzelMesajlar = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.gbMesajlar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.gbMesajlar);
            this.panel1.Location = new System.Drawing.Point(2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(547, 468);
            this.panel1.TabIndex = 1;
            // 
            // gbMesajlar
            // 
            this.gbMesajlar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbMesajlar.Controls.Add(this.button1);
            this.gbMesajlar.Controls.Add(this.txtOzelMesaj);
            this.gbMesajlar.Controls.Add(this.txtOzelMesajlar);
            this.gbMesajlar.Location = new System.Drawing.Point(9, 3);
            this.gbMesajlar.Name = "gbMesajlar";
            this.gbMesajlar.Size = new System.Drawing.Size(527, 460);
            this.gbMesajlar.TabIndex = 2;
            this.gbMesajlar.TabStop = false;
            this.gbMesajlar.Text = "Mesajlar";
            // 
            // txtOzelMesaj
            // 
            this.txtOzelMesaj.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOzelMesaj.Location = new System.Drawing.Point(9, 349);
            this.txtOzelMesaj.Multiline = true;
            this.txtOzelMesaj.Name = "txtOzelMesaj";
            this.txtOzelMesaj.Size = new System.Drawing.Size(403, 105);
            this.txtOzelMesaj.TabIndex = 1;
            this.txtOzelMesaj.TextChanged += new System.EventHandler(this.txtOzelMesaj_TextChanged);
            this.txtOzelMesaj.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOzelMesaj_KeyPress);
            // 
            // txtOzelMesajlar
            // 
            this.txtOzelMesajlar.BackColor = System.Drawing.Color.Linen;
            this.txtOzelMesajlar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOzelMesajlar.Location = new System.Drawing.Point(9, 22);
            this.txtOzelMesajlar.Multiline = true;
            this.txtOzelMesajlar.Name = "txtOzelMesajlar";
            this.txtOzelMesajlar.ReadOnly = true;
            this.txtOzelMesajlar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOzelMesajlar.Size = new System.Drawing.Size(509, 321);
            this.txtOzelMesajlar.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(418, 416);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 38);
            this.button1.TabIndex = 2;
            this.button1.Text = "G�nder";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmOzelSohbet
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(551, 473);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmOzelSohbet";
            this.Text = "�zel Sohbet";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmOzelSohbet_FormClosed);
            this.Load += new System.EventHandler(this.frmOzelSohbet_Load);
            this.Shown += new System.EventHandler(this.frmOzelSohbet_Shown);
            this.panel1.ResumeLayout(false);
            this.gbMesajlar.ResumeLayout(false);
            this.gbMesajlar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbMesajlar;
        private System.Windows.Forms.TextBox txtOzelMesaj;
        private System.Windows.Forms.TextBox txtOzelMesajlar;
        private System.Windows.Forms.Button button1;
    }
}