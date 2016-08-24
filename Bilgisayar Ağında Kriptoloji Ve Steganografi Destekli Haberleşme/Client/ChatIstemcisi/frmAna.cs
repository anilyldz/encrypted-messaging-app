using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ASN.AS;
using ASN.AS.IstemciTarafi;
using System.Threading;

namespace ChatIstemcisi
{
    public partial class frmAna : Form
    {
        string sifrelenmis = "", desifrelenmis = "", sifreli = "";
        string aktif;
        void sifrele()
        {
            try
            {
            
            char[,] tablo = new char[6, 6];
            char[] anahtar = new char[36];//Anahtar için kullanýlacak dizi
            char[] sifrelenmis_dizi = new char[36];//Þifrelenen harflerin yazýlacaðý dizi
            int[,] harfler = new int[2, 2];//Tabloda aranýp bulunun 2 harfin adreslerinin tutulduðu dizi
            char[] alfabe = { 'A', 'B', 'C', 'Ç', 'D', 'E', 'F', 'G', 'Ð', 'H', 'I', 'Ý', 'J', 'K', 'L', 'M', 'N', 'O', 'Ö', 'P', 'R', 'S', 'Þ', 'T', 'U', 'Ü', 'V', 'Y', 'Z', 'W', ' ', 'Q', '/', '*', '-', '?' };
            char[] sifrelenecek_dizi = new char[100];//Þifrelenmek için girilen dizi
            int i, j, k, t, indis;
            int anahtar_dizi_sonu;//Anahtar dizisinin son indisini tutan deðiþken
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
                }//Yanyana bulunan ayný harfleri diziden çýkardýk
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
                }//Girdiðimiz anahtardaki harfleri alfabeden çýkardýk
                for (i = alfabe_sonu; i >= 0; i--)
                {
                    alfabe[i + anahtar_dizi_sonu + 1] = alfabe[i];
                }//Silinen harfler kadar alfabe dizisini saða öteledik ve anahtardaki harflere yer açtýk
                for (i = 0; i <= anahtar_dizi_sonu; i++)
                {
                    alfabe[i] = anahtar[i];
                }//Alfabe dizisinde açtýðýmýz yerlere tekrarsýz anahtar harflerimizi yerleþtiriyoruz
                for (i = 0; i < 6; i++)
                {
                    for (j = 0; j < 6; j++)
                    {
                        tablo[i, j] = alfabe[z];
                        z++;
                    }
                }
                for (int m = 0; m < txtTopluMesaj.Text.Length; m++)
                {
                    sifrelenecek_dizi[m] = txtTopluMesaj.Text[m];
                }
                sifrelenecek_dizi_uzunlugu = txtTopluMesaj.Text.Length;
                indis = 0;
                while (indis < sifrelenecek_dizi_uzunlugu)
                {
                    if (sifrelenecek_dizi[indis] == sifrelenecek_dizi[indis + 1])
                    {
                        for (j = txtTopluMesaj.Text.Length - 1; j > indis; j--)
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
                }//Ayný harf olan ikililer arasýna 'X' yerleþtirdik
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
                    }//En son harf tek kalmýþsa sonuna 'Z' ekledik
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
                    }//Ayný satýrdalarsa
                    else
                    {
                        if (harfler[0, 1] == harfler[1, 1])
                        {
                            sifrelenmis_dizi[i] = tablo[(harfler[0, 0] + 1) % 6, harfler[0, 1]];
                            sifrelenmis_dizi[i + 1] = tablo[(harfler[1, 0] + 1) % 6, harfler[1, 1]];


                        }//Ayný sütundalarsa
                        else
                        {
                            sifrelenmis_dizi[i] = tablo[harfler[0, 0], harfler[1, 1]];
                            sifrelenmis_dizi[i + 1] = tablo[harfler[1, 0], harfler[0, 1]];

                        }//Ayný satýr ve sütunda deðillerse
                    }
                }


                for (int q = 0; q < sifrelenmis_dizi.Length; q++)
                {
                    sifrelenmis += sifrelenmis_dizi[q];
                }
            }
            catch (Exception sorun)
            {

                MessageBox.Show("Hatalý mesaj girdiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            finally {
                txtTopluMesaj.Text = "";
                btngonder.PerformClick();
            }

            
        }

        void desifrele()
        {
            char[,] tablo = new char[6, 6];
            char[] anahtar = new char[36];//Anahtar için kullanýlacak dizi
            char[] sifrelenmis_dizi = new char[36];//Þifrelenen harflerin yazýlacaðý dizi
            int[,] harfler = new int[2, 2];//Tabloda aranýp bulunun 2 harfin adreslerinin tutulduðu dizi
            char[] alfabe = { 'A', 'B', 'C', 'Ç', 'D', 'E', 'F', 'G', 'Ð', 'H', 'I', 'Ý', 'J', 'K', 'L', 'M', 'N', 'O', 'Ö', 'P', 'R', 'S', 'Þ', 'T', 'U', 'Ü', 'V', 'Y', 'Z', 'W', ' ', 'Q', '/', '*', '-', '?' };
            char[] sifrelenecek_dizi = new char[100];//Þifrelenmek için girilen dizi
            int i, j, k, t, indis;
            int anahtar_dizi_sonu;//Anahtar dizisinin son indisini tutan deðiþken
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
            }//Yanyana bulunan ayný harfleri diziden çýkardýk
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
            }//Girdiðimiz anahtardaki harfleri alfabeden çýkardýk
            for (i = alfabe_sonu; i >= 0; i--)
            {
                alfabe[i + anahtar_dizi_sonu + 1] = alfabe[i];
            }//Silinen harfler kadar alfabe dizisini saða öteledik ve anahtardaki harflere yer açtýk
            for (i = 0; i <= anahtar_dizi_sonu; i++)
            {
                alfabe[i] = anahtar[i];
            }//Alfabe dizisinde açtýðýmýz yerlere tekrarsýz anahtar harflerimizi yerleþtiriyoruz
            for (i = 0; i < 6; i++)
            {
                for (j = 0; j < 6; j++)
                {
                    tablo[i, j] = alfabe[z];
                    z++;
                }
            }
            for (int m = 0; m < sifreli.Length; m++)
            {
                sifrelenecek_dizi[m] = sifreli[m];
            }
            sifrelenecek_dizi_uzunlugu = sifreli.Length;
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
            }//Ayný harf olan ikililer arasýna 'X' yerleþtirdik


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
                }//En son harf tek kalmýþsa sonuna 'Z' ekledik
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
                }//Ayný satýrdalarsa
                else
                {
                    if (harfler[0, 1] == harfler[1, 1])
                    {
                        sifrelenmis_dizi[i] = tablo[(harfler[0, 0] + 5) % 6, harfler[0, 1]];
                        sifrelenmis_dizi[i + 1] = tablo[(harfler[1, 0] + 5) % 6, harfler[1, 1]];


                    }//Ayný sütundalarsa
                    else
                    {
                        sifrelenmis_dizi[i] = tablo[harfler[0, 0], harfler[1, 1]];
                        sifrelenmis_dizi[i + 1] = tablo[harfler[1, 0], harfler[0, 1]];

                    }//Ayný satýr ve sütunda deðillerse
                }
                desifrelenmis += sifrelenmis_dizi[i];
                desifrelenmis += sifrelenmis_dizi[i + 1];
                if (sifreli.Split('\0')[0].Length == desifrelenmis.Length) break;
            }           
        }

        /// <summary>
        /// AS kütüphanesini kullanarak AS sunucusuna baðlý olan istemci nesnesi
        /// </summary>
        private ASIstemcisi istemci;

        /// <summary>
        /// Kullanýcýnýn Nick'i
        /// </summary>
        public string Nick
        {
            get { return nick; }
            set { nick = value; }
        }
        private string nick;

        /// <summary>
        /// Rastgele sayý üretmede kullanýlacak bir nesne
        /// </summary>
        private Random rnd = new Random();

        /// <summary>
        /// Özel sohbet yapýlan formlar
        /// </summary>
        private SortedList<string, frmOzelSohbet> ozelSohbetFormlari;

        /// <summary>
        /// Chat ortamýnda bulunan kullanýcý listesi
        /// </summary>
        private List<string> kullanicilar;

        public frmAna()
        {
            ozelSohbetFormlari = new SortedList<string, frmOzelSohbet>();
            kullanicilar = new List<string>();
            InitializeComponent();
        }

        private void frmAna_Shown(object sender, EventArgs e)
        {
            //Giriþ formunu göster
            frmGiris girisFormu = new frmGiris();
            girisFormu.ShowDialog();
            //Eðer giriþ formundan sunucuya doðru baðlanýldýysa sistemi baþlat
            if (girisFormu.GirisYapildi)
            {
                //ASIstemcisi referansýný al
                istemci = girisFormu.Istemci;
                nick = girisFormu.Nick;
                //Olaylara kaydol
                istemci.YeniMesajAlindi += new dgYeniMesajAlindi(istemci_YeniMesajAlindi);
                //Sunucuya giriþ mesajý gönder
                Text = "Chat Ýstemcisi - Baðlanýyor...";
                istemci.MesajYolla("komut=giris&nick=" + nick);
                //textbox'a odaklan
                txtTopluMesaj.Focus();
            }
            //Aksi halde formu kapat
            else
            {
                Close();
            }
        }

        void istemci_YeniMesajAlindi(MesajAlmaArgumanlari e)
        {
            Invoke(new dgYeniMesajAlindi(mesajAlindi), e);
        }

        private void frmAna_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Form kapatýlýrken sunucuya olan baðlantýyý keselim
            if (istemci != null)
            {
                istemci.MesajYolla("komut=cikis");
                istemci.BaglantiyiKes();
            }
        }

        // CHAT MANTIÐININ ÇALIÞTIÐI KODLAR ///////////////////////////////////

        /// <summary>
        /// Sunucudan bir mesaj alýndýðýnda buraya gelir
        /// </summary>
        /// <param name="e">Alýnan mesajla ilgili bilgiler</param>
        private void mesajAlindi(MesajAlmaArgumanlari e)
        {

            //Gelen mesajý & ve = iþaretlerine göre ayrýþtýr
            NameValueCollection parametreler = mesajCoz(e.Mesaj);
            //Ayrýþtýrma baþarýsýzsa çýk
            if (parametreler == null || parametreler.Count < 1)
            {
                return;
            }
            //Ayrýþtýrma sonucunda komuta göre gerekli iþlemleri yap
            switch (parametreler["komut"])
            {
                case "giris": //Yolladýðýmýz giris mesajýna karþýlýk gelen mesaj
                    komut_giris(parametreler["sonuc"]);
                    break;
                case "ozelmesaj": //Bir kiþiden bize gelen özel mesaj
                    komut_ozelmesaj(parametreler["nick"], parametreler["mesaj"]);
                    break;
                case "toplumesaj": //Bir kiþiden tüm gruba gelen mesaj
                    komut_toplumesaj(parametreler["nick"], parametreler["mesaj"]);
                    break;
                case "kullanicigiris": //Bir kiþi girdiðinde bize gelen bilgi
                    komut_kullanicigiris(parametreler["nick"]);
                    break;
                case "kullanicicikis": //Bir kiþi çýktýðýnda bize gelen bilgi
                    komut_kullanicicikis(parametreler["nick"]);
                    break;
                case "kullanicilistesi": //Tüm kullanýcýlarýn listesi
                    komut_kullanicilistesi(parametreler["liste"]);
                    break;
            }

        }

        /// <summary>
        /// giris komutunu uygulayan fonksyon
        /// </summary>
        /// <param name="sonuc">giriþ sonucu</param>
        private void komut_giris(string sonuc)
        {
            //giriþ baþarýlýysa gerekli kontrolleri aktif yap
            if (sonuc == "basarili")
            {
                gbKullanicilar.Enabled = true;
                gbMesajlar.Enabled = true;
                lblNick.Text = nick;
                Text = "Chat Ýstemcisi - Baðlý";
            }
            //giriþ baþarýsýzsa (nick kullanýmdaysa) sonuna 1-9 arasý rastgele bir sayý ekleyip yeniden giriþ yap
            else
            {
                int rs = rnd.Next(1, 9);
                nick += rs.ToString();
                istemci.MesajYolla("komut=giris&nick=" + nick);
            }
        }

        /// <summary>
        /// ozelmesaj komutunu uygulayan fonksyon
        /// </summary>
        /// <param name="nick">mesajý gönderen nick</param>
        /// <param name="mesaj">mesaj içeriði</param>
        private void komut_ozelmesaj(string nick, string mesaj)
        {
            if (nick == aktif)
            {
                MessageBox.Show("Bu Siz'siniz", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                frmOzelSohbet sohbetFormu = null;
                //Eþzamanlý eriþimlere karþý koleksiyonu kilitleyelim
                lock (ozelSohbetFormlari)
                {
                    if (ozelSohbetFormlari.ContainsKey(nick))
                    {
                        sohbetFormu = ozelSohbetFormlari[nick];
                    }
                }
                //Bu kiþiyle bir sohbet penceresi açýk deðilse önce sohbet penceresini oluþturup açalým
                if (sohbetFormu == null)
                {
                    sohbetFormu = new frmOzelSohbet(this, nick);
                    lock (ozelSohbetFormlari)
                    {
                        ozelSohbetFormlari.Add(nick, sohbetFormu);
                    }
                    sohbetFormu.Show();
                }
                //Mesajý bu pencereye yönlendirelim
                sohbetFormu.MesajAl(mesaj);
            }

            
        }

        /// <summary>
        /// toplumesaj komutunu uygulayan fonksyon
        /// </summary>
        /// <param name="nick">Mesajý gönderen kullanýcýnýn nick'i</param>
        /// <param name="mesaj">Gönderilen mesaj</param>
        private void komut_toplumesaj(string nick, string mesaj)
        {
            //gelen mesajý sohbet alanýna ekle
            sifreli = mesaj;

            string mesajlar = txtTopluMesajlar.Text;
            desifrele();
            mesajlar += "\r\n" + nick + ": " + desifrelenmis;

            txtTopluMesajlar.Text = mesajlar;
            desifrelenmis = "";


        }

        /// <summary>
        /// kullanicigiris komutunu uygulayan fonksyon
        /// </summary>
        /// <param name="nick"></param>
        private void komut_kullanicigiris(string nick)
        {
            //Eðer kullanýcý 'kullanýcýlar' listesinde yoksa listeye ekle
            lock (kullanicilar)
            {
                if (!kullanicilar.Contains(nick))
                {
                    kullanicilar.Add(nick);
                }
                kullanicilar.Sort();
            }
            //Ekrandaki listeyi güncelle
            kullaniciListesiniGuncelle();
            //Eðer bu kullanýcýyle bir sohbet penceresi açýksa, pencereye bilgi gönder
            frmOzelSohbet sohbetFormu = null;
            lock (ozelSohbetFormlari)
            {
                if (ozelSohbetFormlari.ContainsKey(nick))
                {
                    sohbetFormu = ozelSohbetFormlari[nick];
                }
            }
            if (sohbetFormu != null)
            {
                sohbetFormu.KullaniciGirdi();
            }
        }

        /// <summary>
        /// kullanicicikis komutunu uygulayan fonksyon
        /// </summary>
        /// <param name="nick"></param>
        private void komut_kullanicicikis(string nick)
        {
            //Eðer kullanýcý 'kullanýcýlar' listesinde varsa listeden sil
            lock (kullanicilar)
            {
                if (kullanicilar.Contains(nick))
                {
                    kullanicilar.Remove(nick);
                }
            }
            //Ekrandaki listeyi güncelle
            kullaniciListesiniGuncelle();
            //Eðer bu kullanýcýyle bir sohbet penceresi açýksa, pencereye bilgi gönder
            frmOzelSohbet sohbetFormu = null;
            lock (ozelSohbetFormlari)
            {
                if (ozelSohbetFormlari.ContainsKey(nick))
                {
                    sohbetFormu = ozelSohbetFormlari[nick];
                }
            }
            if (sohbetFormu != null)
            {
                sohbetFormu.KullaniciCikti();
            }
        }

        /// <summary>
        /// kullanicilistesi komutunu uygulayan fonksyon
        /// </summary>
        /// <param name="liste">Sistemdeki kullanýcýlarýn , ile ayýrýlmýþ listesi</param>
        private void komut_kullanicilistesi(string liste)
        {
            //Tüm kullanýcýlarý temizle ve gelen listeye göre yeniden oluþtur
            try
            {
                //Gelen mesajý , ile ayýr
                string[] kullaniciDizisi = liste.Split(',');
                lock (kullanicilar)
                {
                    //Mevcut listeyi temizle
                    kullanicilar.Clear();
                    //Gelen listeyi ekle
                    kullanicilar.AddRange(kullaniciDizisi);
                }
            }
            catch (Exception)
            {

            }
            //Ekrandaki listeyi güncelle
            kullaniciListesiniGuncelle();
        }

        /// <summary>
        /// Özel Sohbet formlarý vasýtasýyla sunucuya bir mesaj yollamak içindir.
        /// </summary>
        /// <param name="nick">Karþý tarafýn nick'i</param>
        /// <param name="mesaj">Mesaj içeriði</param>
        public void OzelMesajYolla(string nick, string mesaj)
        {
            if (nick == aktif+"(SÝZ)")
            {
                MessageBox.Show("Bu Siz'siniz", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else { 
                istemci.MesajYolla("komut=ozelmesaj&nick=" + nick + "&mesaj=" + mesaj);
            }
            
        }

        /// <summary>
        /// Bir Özel Sohbet formu kapandýðýnda burasý çaðýrýlýr.
        /// </summary>
        /// <param name="nick">Hangi kullanýcý ile yapýlan sohbetin kapatýldýðýný belirtir</param>
        public void OzelSohbetFormuKapandi(string nick)
        {
            lock (ozelSohbetFormlari)
            {
                if (ozelSohbetFormlari.ContainsKey(nick))
                {
                    ozelSohbetFormlari.Remove(nick);
                }
            }
        }

        /// <summary>
        /// lstKullanicilar ListBox'unda kullanicilar listesini gösterir.
        /// </summary>
        private void kullaniciListesiniGuncelle()
        {
            //Kullanýcýlarý bir diziye al
            string[] kullaniciDizisi = null;
            lock (kullanicilar)
            {
                kullaniciDizisi = kullanicilar.ToArray();
            }
            //Listeyi temizle
            lstKullanicilar.Items.Clear();
            //Tüm kullanýcýlarý listeye ekle
            foreach (string kul in kullaniciDizisi)
            {
                if (nick == kul) {
                    lstKullanicilar.Items.Add(kul+"(SÝZ)");
                    aktif = kul;
                }
                else lstKullanicilar.Items.Add(kul);
                
            }
        }

        /// <summary>
        /// ListBox'daki bir kullanýcýya çift týklandýðýnda yeni bir özel sohbet penceresi açmak için kullanýlýr.
        /// </summary>
        private void lstKullanicilar_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Seçilen eleman varsa..
            if (lstKullanicilar.SelectedItems.Count > 0 && lstKullanicilar.SelectedItem != null)
            {
                //Seçilen kullanýcýnýn nick'inin al
                string secilenNick = lstKullanicilar.SelectedItem as string;
                if(nick+"(SÝZ)"!=secilenNick)
                if (secilenNick != null)
                {
                    lock (ozelSohbetFormlari)
                    {
                        //Eðer bu kullanýcý ile bir sohbet formu zaten açýksa formu aktif yap, 
                        //deðilse yeni bir özel sohbet formu aç ve ozelSohbetFormlari listesine ekle
                        if (ozelSohbetFormlari.ContainsKey(secilenNick))
                        {
                            ozelSohbetFormlari[secilenNick].Activate();
                        }
                        else
                        {
                            frmOzelSohbet sohbetFormu = new frmOzelSohbet(this, secilenNick);
                            ozelSohbetFormlari.Add(secilenNick, sohbetFormu);
                            sohbetFormu.Show();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Toplu sohbet penceresindeki alana mesaj yazarken enter'a basýldýðýnda
        /// mesajý sunucuya yollamak içindir.
        /// </summary>
        private void txtTopluMesaj_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Enter'a basýlmýþsa ve textbox'da bir metin varsa sunucuya yolla
            if (e.KeyChar == (char)13 && txtTopluMesaj.Text.Length > 0)
            {
                //Mesajý kontrol et, uygunsa yolla
                if (mesajGonderimeUygun(txtTopluMesaj.Text))
                {
                    //mesajý sunucuya yolla
                    sifrele();
                    istemci.MesajYolla("komut=toplumesaj&mesaj=" + sifrelenmis);
                    //tuþa basýlmayý iptal et ( basýlan enter tuþunu dikkate alma )
                    e.Handled = true;
                    //yazý alanýný bir sonraki mesaj için boþalt                
                    txtTopluMesaj.Text = "";
                    sifrelenmis = "";
                }
                else
                {
                    //Mesaj uygun deðilse uyarý göster
                    MessageBox.Show("Göndermek istediðiniz mesajda uygun olmayan karakterler var. Mesaj içerisinde þu karakterler olamaz: < > & =", "Dikkat!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }



        public NameValueCollection mesajCoz(string mesaj)
        {
            try
            {
                //& iþaretine göre böl ve diziye at
                string[] parametreler = mesaj.Split('&');
                //dönüþ deðeri için bir NameValueCollection oluþtur
                NameValueCollection nvcParametreler = new NameValueCollection(parametreler.Length);
                //bölünen her parametreyi = iþaretine göre yeniden böl ve anahtar/deðer çiftleri üret
                foreach (string parametre in parametreler)
                {
                    string[] esitlik = parametre.Split('=');
                    nvcParametreler.Add(esitlik[0], esitlik[1]);
                }
                //oluþturulan koleksiyonu dönder
                return nvcParametreler;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Mesajýn gönderime uygunluðunu denetler
        /// </summary>
        /// <param name="mesaj">Gönderilecek mesaj</param>
        /// <returns>uygunsa true, aksi halde false</returns>
        private bool mesajGonderimeUygun(string mesaj)
        {
            mesaj = mesaj.ToUpper();
            //Eðer aþaðýdaki karakterlerden birisi varsa mesaj uygun deðildir
            if (mesaj.IndexOfAny(new char[] { '<', '>', '&', '=' }) >= 0)
            {
                
                return false;
            }
            return true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtTopluMesajlar_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTopluMesaj_TextChanged(object sender, EventArgs e)
        {

        }

        private void Mail_Click(object sender, EventArgs e)
        {
            frmStega yeniform = new frmStega();
            yeniform.Show();
        }

        private void frmAna_Load(object sender, EventArgs e)
        {

        }

        private void lstKullanicilar_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
                istemci.MesajYolla("komut=cikis");
                istemci.BaglantiyiKes();
                frmGiris geriye = new frmGiris();
                geriye.Show();
                this.Close();
        }

        private void btngonder_Click(object sender, EventArgs e)
        {
            if (txtTopluMesaj.Text.Length > 0)
            {
                //Mesajý kontrol et, uygunsa yolla               
                if (mesajGonderimeUygun(txtTopluMesaj.Text))
                {
                    //mesajý sunucuya yolla
                    sifrele();
                    istemci.MesajYolla("komut=toplumesaj&mesaj=" + sifrelenmis);             
                    txtTopluMesaj.Text = "";
                    sifrelenmis = "";
                }
                else
                {
                    //Mesaj uygun deðilse uyarý göster
                    MessageBox.Show("Göndermek istediðiniz mesajda uygun olmayan karakterler var. Mesaj içerisinde þu karakterler olamaz: < > & =", "Dikkat!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }


    }
}