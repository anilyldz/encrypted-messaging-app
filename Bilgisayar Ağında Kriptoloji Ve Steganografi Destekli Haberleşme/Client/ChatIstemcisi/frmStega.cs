using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
//using System.Linq;
using System.Security.Cryptography;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Net.Mail;
using System.Drawing.Imaging;
using System.Net;

namespace ChatIstemcisi
{

    public partial class frmStega : Form
    {
        private Bitmap bmp = null;
        int sayac = 0;
        string sifrelenmis = "", desifrelenmis = "", sifreli = "";
        void sifrele()
        {
            char[,] tablo = new char[6, 6];
            char[] anahtar = new char[36];//Anahtar için kullanılacak dizi
            char[] sifrelenmis_dizi = new char[36];//Şifrelenen harflerin yazılacağı dizi
            int[,] harfler = new int[2, 2];//Tabloda aranıp bulunun 2 harfin adreslerinin tutulduğu dizi
            char[] alfabe = { 'A', 'B', 'C', 'Ç', 'D', 'E', 'F', 'G', 'Ğ', 'H', 'I', 'İ', 'J', 'K', 'L', 'M', 'N', 'O', 'Ö', 'P', 'R', 'S', 'Ş', 'T', 'U', 'Ü', 'V', 'Y', 'Z', 'W', ' ', 'Q', '/', '*', '-', '?' };
            char[] sifrelenecek_dizi = new char[100];//Şifrelenmek için girilen dizi
            int i, j, k, t, indis;
            int anahtar_dizi_sonu;//Anahtar dizisinin son indisini tutan değişken
            int alfabe_sonu = 35;
            int sifrelenecek_dizi_uzunlugu;
            int z = 0;
            string anahtarlar = "AS";
            for (int m = 0; m < anahtarlar.Length; m++)
            {
                anahtar[m] = anahtarlar[m];
            }
            anahtar_dizi_sonu = anahtarlar.Length - 1;
            i = 1;
            while (i <= anahtar_dizi_sonu)
            {
                j = 0;
                while (anahtar[j] != anahtar[i] && j < i)
                {
                    j++;
                }
                if (j != i)
                {
                    for (k = i; k < anahtar_dizi_sonu; k++)
                    {
                        anahtar[k] = anahtar[k + 1];
                    }
                    anahtar_dizi_sonu--;
                    i--;
                }
                i++;
            }//Yanyana bulunan aynı harfleri diziden çıkardık
            for (i = 0; i <= anahtar_dizi_sonu; i++)
            {
                j = 0;
                while (anahtar[i] != alfabe[j])
                {
                    j++;
                }
                for (k = j; k < alfabe_sonu; k++)
                {
                    alfabe[k] = alfabe[k + 1];
                }
                alfabe_sonu--;
            }//Girdiğimiz anahtardaki harfleri alfabeden çıkardık
            for (i = alfabe_sonu; i >= 0; i--)
            {
                alfabe[i + anahtar_dizi_sonu + 1] = alfabe[i];
            }//Silinen harfler kadar alfabe dizisini sağa öteledik ve anahtardaki harflere yer açtık
            for (i = 0; i <= anahtar_dizi_sonu; i++)
            {
                alfabe[i] = anahtar[i];
            }//Alfabe dizisinde açtığımız yerlere tekrarsız anahtar harflerimizi yerleştiriyoruz
            for (i = 0; i < 6; i++)
            {
                for (j = 0; j < 6; j++)
                {
                    tablo[i, j] = alfabe[z];
                    z++;
                }
            }
            for (int m = 0; m < sifresizmesaj.Text.Length; m++)
            {
                sifrelenecek_dizi[m] = sifresizmesaj.Text[m];
            }
            sifrelenecek_dizi_uzunlugu = sifresizmesaj.Text.Length;
            indis = 0;
            while (indis < sifrelenecek_dizi_uzunlugu)
            {
                if (sifrelenecek_dizi[indis] == sifrelenecek_dizi[indis + 1])
                {
                    for (j = sifresizmesaj.Text.Length - 1; j > indis; j--)
                    {
                        sifrelenecek_dizi[j + 1] = sifrelenecek_dizi[j];
                    }
                    sifrelenecek_dizi_uzunlugu++;
                    sifrelenecek_dizi[indis + 1] = 'X';
                }
                else
                {
                    indis = indis + 2;
                }
            }//Aynı harf olan ikililer arasına 'X' yerleştirdik
            if (sifrelenecek_dizi_uzunlugu % 2 == 1)
            {
                if (sifrelenecek_dizi[sifrelenecek_dizi_uzunlugu - 1] == '?')
                {
                    sifrelenecek_dizi[sifrelenecek_dizi_uzunlugu] = 'X';
                    sifrelenecek_dizi_uzunlugu++;
                }//En son harf 'Z' ise sonuna 'x' ekledik
                else
                {
                    sifrelenecek_dizi[sifrelenecek_dizi_uzunlugu] = 'Z';
                    sifrelenecek_dizi_uzunlugu++;
                    sayac++;
                }//En son harf tek kalmışsa sonuna 'Z' ekledik
            }
            for (i = 0; i < sifrelenecek_dizi_uzunlugu; i = i + 2)
            {
                for (k = i; k < i + 2; k++)
                {
                    t = 0;
                    while (sifrelenecek_dizi[k] != tablo[t / 6, t % 6])
                    {
                        t++;
                    }
                    harfler[k % 2, 0] = t / 6;
                    harfler[k % 2, 1] = t % 6;

                }
                if (harfler[0, 0] == harfler[1, 0])
                {
                    sifrelenmis_dizi[i] = tablo[harfler[0, 0], (harfler[0, 1] + 1) % 6];
                    sifrelenmis_dizi[i + 1] = tablo[harfler[1, 0], (harfler[1, 1] + 1) % 6];
                }//Aynı satırdalarsa
                else
                {
                    if (harfler[0, 1] == harfler[1, 1])
                    {
                        sifrelenmis_dizi[i] = tablo[(harfler[0, 0] + 1) % 6, harfler[0, 1]];
                        sifrelenmis_dizi[i + 1] = tablo[(harfler[1, 0] + 1) % 6, harfler[1, 1]];


                    }//Aynı sütundalarsa
                    else
                    {
                        sifrelenmis_dizi[i] = tablo[harfler[0, 0], harfler[1, 1]];
                        sifrelenmis_dizi[i + 1] = tablo[harfler[1, 0], harfler[0, 1]];

                    }//Aynı satır ve sütunda değillerse
                }
            }
            for (int q = 0; q < sifrelenmis_dizi.Length; q++)
            {
                sifrelenmis += sifrelenmis_dizi[q];
            }
            sifrelimesaj.Text = sifrelenmis;
        }

        void desifrele()
        {
            char[,] tablo = new char[6, 6];
            char[] anahtar = new char[36];//Anahtar için kullanılacak dizi
            char[] sifrelenmis_dizi = new char[36];//Şifrelenen harflerin yazılacağı dizi
            int[,] harfler = new int[2, 2];//Tabloda aranıp bulunun 2 harfin adreslerinin tutulduğu dizi
            char[] alfabe = { 'A', 'B', 'C', 'Ç', 'D', 'E', 'F', 'G', 'Ğ', 'H', 'I', 'İ', 'J', 'K', 'L', 'M', 'N', 'O', 'Ö', 'P', 'R', 'S', 'Ş', 'T', 'U', 'Ü', 'V', 'Y', 'Z', 'W', ' ', 'Q', '/', '*', '-', '?' };
            char[] sifrelenecek_dizi = new char[100];//Şifrelenmek için girilen dizi
            int i, j, k, t, indis;
            int anahtar_dizi_sonu;//Anahtar dizisinin son indisini tutan değişken
            int alfabe_sonu = 35;
            int sifrelenecek_dizi_uzunlugu;
            int z = 0;
            string anahtarlar = "AS";
            for (int m = 0; m < anahtarlar.Length; m++)
            {
                anahtar[m] = anahtarlar[m];
            }
            anahtar_dizi_sonu = anahtarlar.Length - 1;
            i = 1;
            while (i <= anahtar_dizi_sonu)
            {
                j = 0;
                while (anahtar[j] != anahtar[i] && j < i)
                {
                    j++;
                }
                if (j != i)
                {
                    for (k = i; k < anahtar_dizi_sonu; k++)
                    {
                        anahtar[k] = anahtar[k + 1];
                    }
                    anahtar_dizi_sonu--;
                    i--;
                }
                i++;
            }//Yanyana bulunan aynı harfleri diziden çıkardık
            for (i = 0; i <= anahtar_dizi_sonu; i++)
            {
                j = 0;
                while (anahtar[i] != alfabe[j])
                {
                    j++;
                }
                for (k = j; k < alfabe_sonu; k++)
                {
                    alfabe[k] = alfabe[k + 1];
                }
                alfabe_sonu--;
            }//Girdiğimiz anahtardaki harfleri alfabeden çıkardık
            for (i = alfabe_sonu; i >= 0; i--)
            {
                alfabe[i + anahtar_dizi_sonu + 1] = alfabe[i];
            }//Silinen harfler kadar alfabe dizisini sağa öteledik ve anahtardaki harflere yer açtık
            for (i = 0; i <= anahtar_dizi_sonu; i++)
            {
                alfabe[i] = anahtar[i];
            }//Alfabe dizisinde açtığımız yerlere tekrarsız anahtar harflerimizi yerleştiriyoruz
            for (i = 0; i < 6; i++)
            {
                for (j = 0; j < 6; j++)
                {
                    tablo[i, j] = alfabe[z];
                    z++;
                }
            }
            for (int m = 0; m < sifrelimesaj.Text.Length; m++)
            {
                sifrelenecek_dizi[m] = sifrelimesaj.Text[m];
            }
            sifrelenecek_dizi_uzunlugu = sifrelimesaj.Text.Length;
            indis = 0;
            while (indis < sifrelenecek_dizi_uzunlugu)
            {
                if (sifrelenecek_dizi[indis] == sifrelenecek_dizi[indis + 1])
                {
                    for (j = sifreli.Length - 1; j > indis; j--)
                    {
                        sifrelenecek_dizi[j + 1] = sifrelenecek_dizi[j];
                    }
                    sifrelenecek_dizi_uzunlugu++;
                    sifrelenecek_dizi[indis + 1] = 'X';
                }
                else
                {
                    indis = indis + 2;
                }
            }//Aynı harf olan ikililer arasına 'X' yerleştirdik


            if (sifrelenecek_dizi_uzunlugu % 2 == 1)
            {
                if (sifrelenecek_dizi[sifrelenecek_dizi_uzunlugu - 1] == '?')
                {
                    sifrelenecek_dizi[sifrelenecek_dizi_uzunlugu] = 'X';
                    sifrelenecek_dizi_uzunlugu++;
                }//En son harf 'Z' ise sonuna 'x' ekledik
                else
                {
                    sifrelenecek_dizi[sifrelenecek_dizi_uzunlugu] = 'Z';
                    sifrelenecek_dizi_uzunlugu++;
                }//En son harf tek kalmışsa sonuna 'Z' ekledik
            }


            for (i = 0; i < sifrelenecek_dizi_uzunlugu; i += 2)
            {
                for (k = i; k < i + 2; k++)
                {
                    t = 0;
                    while (sifrelenecek_dizi[k] != tablo[t / 6, t % 6])
                    {
                        t++;
                    }
                    harfler[k % 2, 0] = t / 6;
                    harfler[k % 2, 1] = t % 6;

                }
                if (harfler[0, 0] == harfler[1, 0])
                {
                    sifrelenmis_dizi[i] = tablo[harfler[0, 0], (harfler[0, 1] + 5) % 6];
                    sifrelenmis_dizi[i + 1] = tablo[harfler[1, 0], (harfler[1, 1] + 5) % 6];
                }//Aynı satırdalarsa
                else
                {
                    if (harfler[0, 1] == harfler[1, 1])
                    {
                        sifrelenmis_dizi[i] = tablo[(harfler[0, 0] + 5) % 6, harfler[0, 1]];
                        sifrelenmis_dizi[i + 1] = tablo[(harfler[1, 0] + 5) % 6, harfler[1, 1]];


                    }//Aynı sütundalarsa
                    else
                    {
                        sifrelenmis_dizi[i] = tablo[harfler[0, 0], harfler[1, 1]];
                        sifrelenmis_dizi[i + 1] = tablo[harfler[1, 0], harfler[0, 1]];

                    }//Aynı satır ve sütunda değillerse
                }
                
                desifrelenmis += sifrelenmis_dizi[i];
                desifrelenmis += sifrelenmis_dizi[i + 1];
                
                if (sifrelimesaj.Text.Split('\0')[0].Length == desifrelenmis.Length) break;
            }
            if (sayac == 1)
            {            
                desifrelenmis = desifrelenmis.Substring(0, desifrelenmis.Length - 1);
            }
            sifresizmesaj.Text = desifrelenmis;

        }
        public frmStega()
        {
            InitializeComponent();
        }
        private string smalldecimal(string inp, int dec)
        {
            int i;
            for (i = inp.Length - 1; i > 0; i--)
                if (inp[i] == '.')
                    break;
            try
            {
                return inp.Substring(0, i + dec + 1);
            }
            catch
            {
                return inp;
            }
        }
        private void resimsecbtn_Click(object sender, EventArgs e)
        {
            
        }

        private void sifrelebtn_Click(object sender, EventArgs e)
        {
            sayac = 0;
            sifrelenmis = "";
            sifrele();
        }

        private void sifrecozbtn_Click(object sender, EventArgs e)
        {
            desifrelenmis = "";
            desifrele();
        }

        private void gizlebtn_Click(object sender, EventArgs e)
        {
            
        }

        private void cıkarbtn_Click(object sender, EventArgs e)
        {
            
            
        }

        private void resimkaydetbtn_Click(object sender, EventArgs e)
        {
            
        }        
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Picturebox'da Resim yok!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                pictureBox2.Image = pictureBox1.Image;
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                tabControl1.SelectedTab = tabPage2;
            }
        }

        private void resimsecbtn_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog resimekle = new OpenFileDialog();
            resimekle.Title = "Resim Seç";
            resimekle.Filter = "(*.bmp)|*.bmp";

            if (resimekle.ShowDialog() == DialogResult.OK)
            {
                this.pictureBox1.Image = new Bitmap(resimekle.OpenFile());
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                boyutlbl.Text = pictureBox1.Image.Size.ToString();
                yuksekliklbl.Text = pictureBox1.Image.Height.ToString() + " Pixel";
                genisliklbl.Text = pictureBox1.Image.Width.ToString() + " Pixel";

                FileInfo imginf = new FileInfo(resimekle.FileName);
                float fs = (float)imginf.Length / 1024;
                boyutlbl.Text = smalldecimal(fs.ToString(), 2) + " KB";

                int Depth = System.Drawing.Bitmap.GetPixelFormatSize(pictureBox1.Image.PixelFormat);
                if (Depth < 9)
                {
                    MessageBox.Show("Resim Pixel Formatı Çok Düşük. Lütfen Farklı Bir Resim Seçiniz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    pictureBox1.Image = null;
                    return;
                }
            }

        }

        private void gizlebtn_Click_1(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Resim Alanı Boş. Lüfen Bir Resim Seçiniz.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bmp = (Bitmap)pictureBox1.Image;

                string text = sifrelimesaj.Text;

                if (text.Equals(String.Empty))
                {
                    MessageBox.Show("Gizlemek istediğiniz metni boş olamaz", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
                else
                    bmp = clsStega.embedText(text, bmp);
                MessageBox.Show("Metin görüntüye başarıyla gizlendi !", "Bitti", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cıkarbtn_Click_1(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Lütfen Resim Seçiniz. ", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bmp = (Bitmap)pictureBox1.Image;

                string cıkarılmısmetin = clsStega.metnicıkar(bmp);
                cıkarılmısmetin = cıkarılmısmetin.Replace("0", "İ");
                cıkarılmısmetin = cıkarılmısmetin.Replace("^", "Ş");
                cıkarılmısmetin = cıkarılmısmetin.Replace(" ", "Ğ");
                sifrelimesaj.Text = cıkarılmısmetin;
            }

        }

        private void resimkaydetbtn_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Picturebox'da Resim yok!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                sfd.Filter = "(*.bmp)|*.bmp";
                sfd.Title = "Resimi Kayıt";
                sfd.FileName = "Şifreli Resim";

                DialogResult sonuc = sfd.ShowDialog();

                if (sonuc == DialogResult.OK)
                {
                    pictureBox1.Image.Save(sfd.FileName);
                    MessageBox.Show("Resim Kaydedildi. ", "TAMAM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void mailgonderbtn_Click(object sender, EventArgs e)
        {

        }

        private void mailgonderbtn_Click_1(object sender, EventArgs e)
        {
            try
            {
                SmtpClient smtpmail = new SmtpClient();
                MailMessage mail = new MailMessage();
                smtpmail.Host = "smtp.live.com";
                smtpmail.Port = 587;
                smtpmail.Credentials = new NetworkCredential(gondericimailadresi.Text, mailsifre.Text);
                smtpmail.EnableSsl = true;


                MailAddress to = new MailAddress(alicimail.Text);
                mail.From = new MailAddress(gondericimailadresi.Text, gondericimailadresi.Text);
                mail.To.Add(to);
                mail.Subject = mesajkonusu.Text;
                mail.Body = mesaj.Text;
                mail.IsBodyHtml = true;
                MemoryStream ms = new MemoryStream();

                pictureBox2.Image.Save(ms, ImageFormat.Bmp);
                Attachment attach = new Attachment(ms, "image.bmp", "image/bmp");
                mail.Attachments.Add(attach);
                smtpmail.Send(mail);
                MessageBox.Show("Mail Gönderildi.", "Tamam", MessageBoxButtons.OK, MessageBoxIcon.Information);






            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilgiler Eksik Veya Hatali. \nBilgilerinizi Kontrol Ediniz. \nGirdilerin Eksiksiz Oldugundan Emin Olunuz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmStega_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
        }
    }
