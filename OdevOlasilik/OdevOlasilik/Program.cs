using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OdevOlasilik
{
    internal class Program
    {
         static void sro()
        {
            Random rnd=new Random();
            int N,n,k;
            while (true) {
                Console.WriteLine("lütfen evreninizin büyüklüğünü giriniz");
                N = int.Parse(Console.ReadLine());
                Console.WriteLine("lütfen örneklem hacmini giriniz");
                n = int.Parse(Console.ReadLine());
                if(n==0||n>N)
                {
                    Console.WriteLine("lütfen girdiğiniz örneklem hacmi evrenden büyük olmasın ve 0 dan farklı bir sayı olsun");
                }
                else
                {
                    break;
                }
            } 
            k = N / n;
            int[] kume = new int[n];
            int bsg = rnd.Next(1,k);
            for(int i = 0;i<n;i++)
            {
                kume[i] = bsg;
                Console.WriteLine(kume[i]);
                bsg +=  k;
            }
            //return 1;
        }
        static void bs()
        {
            int adet;
            while (true)
            {  
                Console.WriteLine("Lütfen kaç adet veri gireceğinizi yazınız");
                adet=int.Parse(Console.ReadLine());
                if (adet < 0)
                {
                    Console.WriteLine("lütfen 0 dan büyük bir sayı giribiz");
                }
                else if (adet == 0)
                { Console.WriteLine("fonksiyondan çıkarıldınız"); return ; }
                else
                {
                    break;
                }
            }
            double[] dizi = new double[adet];
            int x;
            for(int i = 0;i<dizi.Length;i++)
            {
                Console.WriteLine("lütfen "+i+".indise girilecek sayıyı giriniz");
                x=int.Parse(Console.ReadLine()) ;
                dizi[i] = x;
            }
            dizi = kabarcik_siralama(dizi);
            for (int i = 0; i < dizi.Length; i++)
            {
                Console.Write(+dizi[i]+" ");
            }
        }
        static void bro()
        {
            Random rnd = new Random();
            int k, b;
            while(true)
            {
                Console.WriteLine("alt sınırı giriniz");
                k=int.Parse(Console.ReadLine());
                Console.WriteLine("üst sınırı giriniz");
                b = int.Parse(Console.ReadLine());
                if (k<0)
                {
                    Console.WriteLine("sıfırdan küçük bir alt sınır giremezsiniz");
                    continue;
                }
                else { break; }
            }
            Console.WriteLine("üretilecek sayı adedini giriniz");
            int n=int.Parse(Console.ReadLine());
            int[] dizi=new int[n];
            int s;
            int t;
            t = (b - k) + 1;
            bool mevcut;
            int sayac = 0;
            if(n<= t)
            {
                while(sayac<n)
                {
                    s = rnd.Next(k, b+1);
                    mevcut = false;
                    for (int i = 0; i < n; i++)
                    {
                        if (dizi[i]==s)
                        {
                            mevcut=true;
                            break;
                        }

                    }
                    if(!mevcut)
                    {
                        dizi[sayac] = s;
                        sayac++;
                    }
                }
            }
            else if(n> t)
            {
                for (int i = 0;i<n;i++)
                {
                    
                    dizi[i]=rnd.Next(k, b+1);
                }
            }
            for(int i = 0;i<n ; i++)
            {
                Console.WriteLine(dizi[i]+" ");
            }
        }
        static void fs()
        {
            int adet;
            while (true)
            {
                Console.WriteLine("lütfen kac adet sayı gireceğinizi yaziniz");
                 adet = int.Parse(Console.ReadLine());
                if (adet == 0)
                { Console.WriteLine("fonksiyondan çıkarılıyorsunuz."); break; }
                else if (adet < 0)
                { Console.WriteLine("0 dan büyük sayi giriniz");continue; }
                else { break; }
            }
            double[] tarama = new double[adet];
            for (int i = 0;i<adet;i++)
            {
                Console.WriteLine((i)+".sayıyı giriniz");
                tarama[i] = int.Parse(Console.ReadLine());
            }
            double[,] dönen =frekans(tarama, adet);
           

            for (int i = 0; i < dönen.GetLength(0); i++)
            {
                Console.WriteLine($"{dönen[i, 0]}\t{dönen[i, 1]}");
            }
            /*int say=0;
           int[,] dizi = new int[adet, 2];
           for (int i = 0; i<adet;i++)
           {
               int sayi=tarama[i];
               bool varmi = false;
               for(int j = 0;j<say;j++)
               {
                   if (dizi[j,0]==sayi)
                   {
                       dizi[j, 1]++;
                       varmi = true;
                       break;
                   }
               }
               if(!varmi)
               {
                   dizi[say, 0] = sayi;
                   dizi[say, 1] = 1;
                   say++;
               }
           }
           say = 0;*/
        }
        static double[] frekans_tablosu()
        {
            int adet;
            while (true)
            {
                Console.WriteLine("Lütfen kaç adet veri gireceğinizi yazınız");
                adet = int.Parse(Console.ReadLine());
                if (adet < 0)
                {
                    Console.WriteLine("lütfen 0 dan büyük bir sayı giribiz");
                }
                else if (adet == 0)
                { Console.WriteLine("fonksiyondan çıkarıldınız"); return null; }
                else
                {
                    break;
                }
                //Console.Clear();
            }
            int a = 1;
            double[] dizi = new double[adet];
            for (int i = 0; i < adet; i++)
            {
                Console.Write(a + ".Veriyi giriniz -->");
                dizi[i] = double.Parse(Console.ReadLine());
                a++;
            }
            a = 0;
            List<int> cd = new List<int>();
            dizi = kabarcik_siralama(dizi);
            for (int i = 1; i <= adet; i++)
            {
                if (adet % i == 0)
                {
                    cd.Add(i);
                }
            }
            int[] carpan = cd.ToArray();
            //carpan = kabarcik_siralama(carpan);
            cd.Clear();
            int[,] satir_sutun = new int[1, 2];
            satir_sutun = ssh(carpan, adet);// satır ve sütunu fonksiyona hesaplatıp döndürttük ve dizimize atadık.
                                            // devamında verilerimizi tablo olarak yazdıracağız ve işlemlerimize devam edeceğiz.
                                            // Console.WriteLine($"Satır: {satir_sutun[0, 0]}, Sütun: {satir_sutun[0, 1]}");
            int x = satir_sutun[0, 0];
            int y = satir_sutun[0, 1];
            int c = 0;
            double[,] tablodizi = new double[y, x];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    tablodizi[j, i] = dizi[c];
                    c++;
                }
            }
            c = 0;
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    Console.Write(tablodizi[i, j] + "   ");
                }
                Console.WriteLine("\n");
            }
            double k = Math.Sqrt(adet);
            k = Math.Ceiling(k);
            double R = dizi[adet - 1] - dizi[0];
            double h = R / k;
            h = Math.Ceiling(h);
            int z = (int)k;
            Console.WriteLine("k="+k+"  h="+h);
            Console.WriteLine("Sınıf Sınırları      Sınıf Limitleri       Frekans        SON        E.F.       O.F.      E.O.F");
            Console.WriteLine("alt        üst        alt          üst        -            -          -          -         -");
            double[,] tablo = new double[z, 9];
            double sa = dizi[0];
            for(int i = 0;i<z;i++)
            {
                tablo[i, 0] = sa;
                sa = sa + h;
            }
            sa = tablo[1, 0] - 1;
            for (int i = 0;i<z; i++)
            {
                tablo[i, 1] = sa;
                sa = sa + h;
            }
            sa=(tablo[1, 0] + tablo[0,1])/2;
            for (int i = 0; i < z; i++)
            {
                tablo[i, 3] = sa;
                sa = sa + h;
            }
            sa = tablo[0,3] -h;
            for (int i = 0; i < z; i++)
            {
                tablo[i, 2] = sa;
                sa = sa + h;
            }
            for(int i=0;i<z;i++)
            {
                for(int j=0;j<adet;j++)
                {
                    if (tablo[i, 2] < dizi[j] && tablo[i, 3] > dizi[j])
                    {
                        tablo[i, 4]++;
                    }
                }
            }
            for (int i = 0; i < z; i++)
            {
                sa = (tablo[i, 2] + tablo[i,3])/2;
                tablo[i, 5] = sa;
            }
            sa = tablo[0, 4];
            tablo[0, 6] = sa;
            a = 0;
            for (int i = 1; i < z; i++)
            {
                tablo[i, 6] = tablo[i, 4] + tablo[a,6];
                a++;
            }
            for(int i=0;i<z;i++)
            {
                if (tablo[i, 4] != 0)
                    tablo[i, 7] = Math.Round((tablo[i, 4] / adet), 2);
                else
                    tablo[i, 4] = 0;
            }

            for (int i = 0; i < z; i++)
            {
                tablo[i, 8] = Math.Round((tablo[i, 6] / adet), 2);
            }
            for (int i = 0; i < z; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(tablo[i, j] + "         ");
                }
                Console.WriteLine("\n");
            }
            return dizi;
        }
        static void geometrik()
        {
            int adet;
            while (true)
            {
                Console.WriteLine("Lütfen kaç adet veri gireceğinizi yazınız");
                adet = int.Parse(Console.ReadLine());
                if (adet < 0)
                {
                    Console.WriteLine("lütfen 0 dan büyük bir sayı giribiz");
                }
                else if (adet == 0)
                { Console.WriteLine("fonksiyondan çıkarıldınız"); }
                else
                {
                    break;
                }
            }
            int a = 1;
            double[] dizi = new double[adet];
            for (int i = 0; i < adet; i++)
            {
                Console.Write(a + ".Veriyi giriniz -->");
                dizi[i] = double.Parse(Console.ReadLine());
                a++;
            }
            Console.WriteLine("Geometrik Ortalamanız= "+ Math.Round(geohesap(dizi),3));
        }
        static void harmonikOrtalama()
        {
            int adet;
            while (true)
            {
                Console.WriteLine("Lütfen kaç adet veri gireceğinizi yazınız");
                adet = int.Parse(Console.ReadLine());
                if (adet < 0)
                {
                    Console.WriteLine("lütfen 0 dan büyük bir sayı giribiz");
                }
                else if (adet == 0)
                { Console.WriteLine("fonksiyondan çıkarıldınız"); }
                else
                {
                    break;
                }
            }
            int a = 1;
            double[] dizi = new double[adet];
            for (int i = 0; i < adet; i++)
            {
                Console.Write(a + ".Veriyi giriniz -->");
                dizi[i] = double.Parse(Console.ReadLine());
                a++;
            }
            Console.WriteLine("Harmonik Ortalamanız=>"+ Math.Round(harmonik(dizi, adet),2));
        }
        static double orneklemvaryans()
        {
            int adet;
            while (true)
            {
                Console.WriteLine("Lütfen kaç adet veri gireceğinizi yazınız");
                adet = int.Parse(Console.ReadLine());
                if (adet < 0)
                {
                    Console.WriteLine("lütfen 0 dan büyük bir sayı giribiz");
                }
                else if (adet == 0)
                { Console.WriteLine("fonksiyondan çıkarıldınız"); }
                else
                {
                    break;
                }
            }
            int a = 1;
            double top = 0;
            double[] dizi = new double[adet];
            for (int i = 0; i < adet; i++)
            {
                Console.Write(a + ".Veriyi giriniz -->");
                dizi[i] = double.Parse(Console.ReadLine());
                top += dizi[i];
                a++;
            }
            double ao;
            // Math.Round((ao = top / adet),2);
            ao = top / adet;
            top = 0;
            for(int i = 0;i < dizi.Length;i++)
            {
                top += Math.Pow((dizi[i] - ao),2.0);
            }
            double sonuc=top / (adet - 1);
            //sonuc = Math.Round(sonuc,2);
            return sonuc;
        }
        static double Sapma()
        {
            int adet;
            while (true)
            {
                Console.WriteLine("Lütfen kaç adet veri gireceğinizi yazınız");
                adet = int.Parse(Console.ReadLine());
                if (adet < 0)
                {
                    Console.WriteLine("lütfen 0 dan büyük bir sayı giribiz");
                }
                else if (adet == 0)
                { Console.WriteLine("fonksiyondan çıkarıldınız"); }
                else
                {
                    break;
                }
            }
            int a = 1;
            double top = 0;
            double[] dizi = new double[adet];
            for (int i = 0; i < adet; i++)
            {
                Console.Write(a + ".Veriyi giriniz -->");
                dizi[i] = double.Parse(Console.ReadLine());
                top += dizi[i];
                a++;
            }
            double ao;
            Math.Round((ao = top / adet), 2);
            top = 0;
            for (int i = 0; i < dizi.Length; i++)
            {
                top += Math.Pow((dizi[i] - ao), 2.0);
            }
            double sonuc;
            sonuc = top / (adet - 1);
            Math.Round(sonuc,2);
            return Math.Sqrt(sonuc);
        }
        static double OMS()
        {
            int adet;
            while (true)
            {
                Console.WriteLine("Lütfen kaç adet veri gireceğinizi yazınız");
                adet = int.Parse(Console.ReadLine());
                if (adet < 0)
                {
                    Console.WriteLine("lütfen 0 dan büyük bir sayı giribiz");
                }
                else if (adet == 0)
                { Console.WriteLine("fonksiyondan çıkarıldınız"); }
                else
                {
                    break;
                }
            }
            int a = 1;
            double top = 0;
            double[] dizi = new double[adet];
            for (int i = 0; i < adet; i++)
            {
                Console.Write(a + ".Veriyi giriniz -->");
                dizi[i] = double.Parse(Console.ReadLine());
                top += dizi[i];
                a++;
            }
            double ao;
            Math.Round((ao = top / adet), 2);
            top = 0;
            for (int i = 0; i < dizi.Length; i++)
            {
                top += Math.Abs(dizi[i]-ao);
            }
            double sonuc = top / adet;
            return Math.Round(sonuc,2);
        }
        static double m3()
        {
            int adet;
            while (true)
            {
                Console.WriteLine("Lütfen kaç adet veri gireceğinizi yazınız");
                adet = int.Parse(Console.ReadLine());
                if (adet < 0)
                {
                    Console.WriteLine("lütfen 0 dan büyük bir sayı giribiz");
                }
                else if (adet == 0)
                { Console.WriteLine("fonksiyondan çıkarıldınız"); }
                else
                {
                    break;
                }
            }
            int a = 1;
            double top = 0;
            double[] dizi = new double[adet];
            for (int i = 0; i < adet; i++)
            {
                Console.Write(a + ".Veriyi giriniz -->");
                dizi[i] = double.Parse(Console.ReadLine());
                top += dizi[i];
                a++;
            }
            double ao;
            ao = Math.Round(( top / adet), 2);
            top = 0;
            for (int i = 0; i < dizi.Length; i++)
            {
                top += Math.Pow((dizi[i] - ao),3.0);
            }
            double sonuc= top / (adet-1);
            sonuc=Math.Round(sonuc, 2);
            return sonuc;
        }
        static double m4()
        {
            int adet;
            while (true)
            {
                Console.WriteLine("Lütfen kaç adet veri gireceğinizi yazınız");
                adet = int.Parse(Console.ReadLine());
                if (adet < 0)
                {
                    Console.WriteLine("lütfen 0 dan büyük bir sayı giribiz");
                }
                else if (adet == 0)
                { Console.WriteLine("fonksiyondan çıkarıldınız"); }
                else
                {
                    break;
                }
            }
            int a = 1;
            double top = 0;
            double[] dizi = new double[adet];
            for (int i = 0; i < adet; i++)
            {
                Console.Write(a + ".Veriyi giriniz -->");
                dizi[i] = double.Parse(Console.ReadLine());
                top += dizi[i];
                a++;
            }
            double ao;
            ao = Math.Round((top / adet), 2);
            top = 0;
            for (int i = 0; i < dizi.Length; i++)
            {
                top += Math.Pow((dizi[i] - ao), 4.0);
            }
            double sonuc = top / (adet - 1);

            return Math.Round(sonuc, 2);
        }
        static double Degisim_Katsayisi()
        {
            int adet;
            while (true)
            {
                Console.WriteLine("Lütfen kaç adet veri gireceğinizi yazınız");
                adet = int.Parse(Console.ReadLine());
                if (adet < 0)
                {
                    Console.WriteLine("lütfen 0 dan büyük bir sayı giribiz");
                }
                else if (adet == 0)
                { Console.WriteLine("fonksiyondan çıkarıldınız"); }
                else
                {
                    break;
                }
            }
            int a = 1;
            double top = 0;
            double[] dizi = new double[adet];
            for (int i = 0; i < adet; i++)
            {
                Console.Write(a + ".Veriyi giriniz -->");
                dizi[i] = double.Parse(Console.ReadLine());
                top += dizi[i];
                a++;
            }
            double spm=Sapma(dizi,adet);
            double aritmetik = AritmetikOrt(dizi);
            return (spm/aritmetik)*100;
        }
        static double[] Dortte_Birlik()
        {
            double adet;
            while (true)
             {
                 Console.WriteLine("Lütfen kaç adet veri gireceğinizi yazınız");
                 adet = int.Parse(Console.ReadLine());
                 if (adet < 0)
                 {
                     Console.WriteLine("lütfen 0 dan büyük bir sayı giribiz");
                 }
                 else if (adet == 0)
                 { Console.WriteLine("fonksiyondan çıkarıldınız"); }
                 else
                 {
                     break;
                 }
             }
            double alt = 0;
            double üst = 0; 
            Console.WriteLine("kac adet aralık gireceğinizi yazınız");
            int snradet=int.Parse(Console.ReadLine());
            Console.WriteLine("Artış Miktarını Giriniz ('h')");
            double h=double.Parse(Console.ReadLine());
            double[,] sinif_aralik=new double[snradet,3];
            for (int i = 0;i<snradet;i++)
            {
                Console.WriteLine("alt sınır giriniz");
                alt = double.Parse(Console.ReadLine());
                sinif_aralik[i,0] = alt;
                Console.WriteLine("üst sınır giriniz");
                üst = double.Parse(Console.ReadLine());
                sinif_aralik[i, 1] = üst;
                Console.WriteLine("bu aralıktaki sayı frekansını giriniz");
                double aralik=double.Parse(Console.ReadLine());
                sinif_aralik[i,2]=aralik;
            }
            //q1
            int p = 0;
            double fresinir =adet/4.0;
            double fretop = 0;
            for (p = 0; p < snradet; p++)
            { 
            
                if (fretop + sinif_aralik[p, 2] >= fresinir)
                    break;

                fretop += sinif_aralik[p, 2]; 
 
            }
            double j_1 = fresinir - fretop;
            double[] db = new double[2];
            db[0] = sinif_aralik[p, 0] + ((j_1 * h) / (sinif_aralik[p, 2]));
            //q3
            fresinir = (3.0 * adet) / 4;
            fretop = 0;
            for (p = 0; p < snradet; p++)
            {

                if (fretop + sinif_aralik[p, 2] >= fresinir)
                    break;

                fretop += sinif_aralik[p, 2];

            }
            double j_3 = fresinir - fretop;
            db[1]= sinif_aralik[p, 0] + ((j_3 * h) / (sinif_aralik[p, 2]));
            return db;
        }
        static void tba()
        {
            
                string[] Toplam_Olasilik = { "durumuna", "göre", "şu", "şartlar", "altında", "her", "biri", "farklı", "olasılıkla", "koşuluyla", "nin", "birlikte", "olasılığı", "nedir", "koşuluyla", "tüm", "senaryolar", "örnek", "uzayı", "katkısıyla", "durumlarına", "ayrık", "ön", "bilgi", "genel", "hesaplayın", "toplam" };
                string[] Bayes = { "olduğu", "bilindiğine", "göre", "sonradan", "öğreniliyor", "hatalı", "olma", "hangi", "fabrikadan", "olabilir", "ters", "olasılık", "koşullu", "görülüyor", "seçiliyor", "geriye", "dönük", "biliniyor", "verilen", "göre", "güncelleme", "ters", "tanı", "testleri", "pozitif", "negatif", "tıbbi", "istatistiksel", "önsel", "sonsal", "inanç", "veriye", "dayalı" };

                string alinancumle = null;
                int d1 = 1;
                int d2 = 1;
                string hesaplanan_kelime = null;

                while (true)
                {
                    Console.WriteLine("Lütfen Yapmak İstediğiniz İşlemi Bir Kaç Kelime ile Anlatınız (ENTER ile bitirin)");

                   
                    StringBuilder sb = new StringBuilder();
                    ConsoleKeyInfo key;
                    while (true)
                    {
                        key = Console.ReadKey(intercept: true);
                        if (key.Key == ConsoleKey.Enter)
                            break;

                        sb.Append(key.KeyChar);
                        Console.Write(key.KeyChar);
                    }
                    Console.WriteLine(); 

                    alinancumle = sb.ToString();

                    char[] harfler = alinancumle.ToCharArray();
                    Array.Resize(ref harfler, harfler.Length + 1);
                    harfler[harfler.Length - 1] = '\0';

                    int adet = 1;
                    for (int i = 0; i < harfler.Length; i++)
                    {
                        if (harfler[i] == ' ')
                        {
                            adet++;
                        }
                    }

                    int boyut = adet;
                    string[] alinan_veri = new string[boyut];
                    int j = 0;
                    hesaplanan_kelime = null;

                    foreach (char c in harfler)
                    {
                        if (c == ' ' || c == '\0')
                        {
                            alinan_veri[j] = hesaplanan_kelime;
                            j++;
                            hesaplanan_kelime = null;
                            continue;
                        }
                        hesaplanan_kelime += c;
                    }

                    for (int i = 0; i < 13; i++)
                    {
                        for (int k = 0; k < boyut; k++)
                        {
                            if (alinan_veri[k] == Toplam_Olasilik[i])
                            {
                                d1++;
                            }
                            if (alinan_veri[k] == Bayes[i])
                            {
                                d2++;
                            }
                        }
                    }

                    if (3 < d1)
                    {
                        Console.WriteLine("Toplam Olasılık Teoremi");
                        d1 = 0;
                        return;
                    }
                    else if (3 < d2)
                    {
                        Console.WriteLine("Bayes Teoremi");
                        d2 = 0;
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Lütfen biraz daha anahtar kelime kullanarak anlatın !");
                    }
                }
        }
        static void dk()
        {
            int adet;
            while (true)
            {
                Console.WriteLine("Lütfen kaç adet veri gireceğinizi yazınız");
                adet = int.Parse(Console.ReadLine());
                if (adet < 0)
                {
                    Console.WriteLine("lütfen 0 dan büyük bir sayı giribiz");
                }
                else if (adet == 0)
                { Console.WriteLine("fonksiyondan çıkarıldınız"); }
                else
                {
                    break;
                }
            }
            int a = 1;
            double[] dizi = new double[adet];
            for (int i = 0; i < adet; i++)
            {
                Console.WriteLine(a + ".sayıyı giriniz");
                dizi[i]=int.Parse(Console.ReadLine());
            }
            double ao=AritmetikOrt(dizi);
            double sapma=Sapma(dizi,adet);
            double sonuc=sapma/ao;
            sonuc=Math.Round(sonuc,2);
            Console.WriteLine("Değişim Katsayısı =>"+sonuc);
        }
        static void Main(string[] args)
        {
            int secim;
            while(true)
            {
                Console.WriteLine("Lütfen yapmak istediğiniz işlemi rakam ile seçiniz\n1.Sistematik Rastgele Örnekleme\n2.Basit Rastgele Örnekelem\n3.Basit Seri\n4.Frekans Seri\n5.Frekans Tablosu\n6. Frekans Tablosu(Tüm Bileşenleriyle Birlikte)\n7.Aritmetik Ortalama\n8.Mod\n9.Medyan\n10.Geometrik Ortalama\n11.Harmonik Ortalama\n12.Orneklem Varyans\n13.Standart Sapma\n14.OMS\n15.Çarpıklık Ölçütü\n16.Sivrilik Ölçütü\n17.Değişim Katsayısı\n18.Dörtte Birlikler\n19.Değişim Katsayısı\n20.Toplam Olasılık veya Bayes Anlayan Fonksiyon");
                secim=int.Parse(Console.ReadLine());
                switch (secim)
                {
                    case 1:
                        sro();
                        break;
                    case 2:
                        bro();
                        break;
                    case 3:
                        bs();
                        break;
                    case 4:
                        fs();
                        break;
                    case 5:
                        frekans_tablosu();
                        break;
                    case 6:
                        double[] dizi = frekans_tablosu();
                        Console.WriteLine("\nAritmetikOrtalama=>" + AritmetikOrt(dizi));
                        Console.WriteLine("Medyan=>"+medyan(dizi,dizi.Length));
                        Console.WriteLine("Mod=>"+mod(dizi,dizi.Length));
                        Console.WriteLine("Geometik Ortalama =>"+geohesap(dizi));
                        Console.WriteLine("Harmonik Ortalama =>"+ harmonik(dizi,dizi.Length));
                        Console.WriteLine("Varyans =>"+orneklemvaryans(dizi,dizi.Length));
                        Console.WriteLine("Standart Sapma =>"+ Sapma(dizi,dizi.Length));
                        Console.WriteLine("OMS =>"+ OMS(dizi,dizi.Length));
                        Console.WriteLine("Çarpıklık Ölçütü =>"+ m3(dizi,dizi.Length));
                        Console.WriteLine("Sivrilik Ölçütü =>"+ m4(dizi,dizi.Length));
                        Console.WriteLine("Değişim Katsayısı =>"+dk(dizi,dizi.Length));
                        Console.WriteLine("\n\n");
                        break;
                    case 7:
                        AritmetikOrt();
                        break;
                    case 8:
                        mod();
                        break;
                    case 9:
                        medyan();
                        break;
                    case 10:
                        geometrik();
                        break;
                    case 11:
                        harmonikOrtalama();
                        break;
                    case 12:
                        double sonuc = orneklemvaryans();
                        Console.WriteLine("Varyans =>" + sonuc);
                        Console.WriteLine("Sapması hesaplansın mı ?\n1-)evet\n2-)hayır");
                        int al = int.Parse(Console.ReadLine());
                        if (al == 1)
                        {
                            Console.WriteLine("Sapma =>" + Sapma(sonuc)); 
                        }
                        break;
                    case 13:
                        Console.WriteLine("Sapma =>"+ Sapma()); 
                        break;
                     case 14:
                        Console.WriteLine("OMS =>"+OMS());
                        break;
                     case 15:
                        Console.WriteLine("Çarpıklık Ölçütü =>"+m3());
                        break;
                     case 16:
                        Console.WriteLine("Sivrilik Ölçütü =>" + m4());
                        break;
                    case 17:
                        Console.WriteLine("Değişim Katsayısı"+Degisim_Katsayisi());
                        break;
                    case 18:
                        double[] dbdizi = Dortte_Birlik();
                        double q1 = Math.Round(dbdizi[0],3);
                        double q3=Math.Round(dbdizi[1],3);
                        Console.WriteLine("Dörtte Birlikler\nQ1=>" + q1 + "\nQ3=>" + q3);
                        break;
                    case 19:
                        dk();
                        break;
                    case 20:
                        tba();
                        break;
                    default:
                        Console.WriteLine("lütfen geçerli bir sayı giriniz");
                        break;
                }
            }
        }
        static int[,] ssh(int[] dizi,int adet)
        {
            int satir = 0;
            int sutun = 0;
            for (int i = 0; i < adet; i++)
            {
                for (int j = 0; j < adet; j++)
                {
                    if (i * j == adet)
                    {
                        if (satir == 0 && sutun == 0)
                        {
                            satir = i;
                            sutun = j;
                        }
                        else if (Math.Abs(i - j) < Math.Abs(satir - sutun))
                        {
                            satir = i;
                            sutun = j;
                        }
                    }
                }
            }
            int[,] x = new int[1,2];
            x[0, 0] = satir;
            x[0, 1] = sutun;
            return x;
        }
        static double dk(double[] dizi,int adet)
        {
            double ao=AritmetikOrt(dizi);
            double sapma=Sapma(dizi,adet);
            double sonuc = sapma / ao;
            //sonuc= Math.Round(sonuc,2);
            return sonuc;
        }
        static double[] kabarcik_siralama(double[] gelendizi)
        {
            double swp;
            for (int i = 0; i < gelendizi.Length; i++)//kabarcık sıralama 
            {
                for (int j = 0; j < gelendizi.Length; j++)
                {
                    if (j != gelendizi.Length - 1)
                    {
                        if (gelendizi[j] < gelendizi[j + 1])
                        {
                            continue;
                        }
                        else if (gelendizi[j] > gelendizi[j + 1])
                        {
                            swp = gelendizi[j];
                            gelendizi[j] = gelendizi[j + 1];
                            gelendizi[j + 1] = swp;
                        }
                    }

                }
            }
            return gelendizi;
        }
        static double[,] frekans(double[] gelendizi,int adet)
        {
            int say = 0;
            double[,] dizi = new double[adet, 2];
            for (int i = 0; i < adet; i++)
            {
                double sayi = gelendizi[i];
                bool varmi = false;
                for (int j = 0; j < say; j++)
                {
                    if (dizi[j, 0] == sayi)
                    {
                        dizi[j, 1]++;
                        varmi = true;
                        break;
                    }
                }
                if (!varmi)
                {
                    dizi[say, 0] = sayi;
                    dizi[say, 1] = 1;
                    say++;
                }
            }
            return dizi;
        }
        static double m3(double[] dizi, int adet)
        {
            int a = 1;
            double top = 0;
            for (int i = 0; i < adet; i++)
            {
                top += dizi[i];
            }
            double ao;
            ao = top/adet;
            top = 0;
            for (int i = 0; i < dizi.Length; i++)
            {
                top += Math.Pow((dizi[i] - ao), 3.0);
            }
            double sonuc = top / (adet - 1);
            //sonuc = Math.Round(sonuc, 2);
            return sonuc;
        }
        static double OMS(double[] dizi,int adet)
        {
            double top = 0;
            for (int i = 0; i < adet; i++)
            {
                top += dizi[i];
            }
            double ao;
            //Math.Round((ao = top / adet), 2);
            ao = top / adet;
            top = 0;
            for (int i = 0; i < dizi.Length; i++)
            {
                top += Math.Abs(dizi[i] - ao);
            }
            double sonuc = top / adet;
            return sonuc;
        }
        static double m4(double[] dizi,int adet)
        {
            int a = 1;
            double top = 0;
            for (int i = 0; i < adet; i++)
            {
                top += dizi[i];
            }
            double ao;
            ao = Math.Round((top / adet), 2);
            top = 0;
            for (int i = 0; i < dizi.Length; i++)
            {
                top += Math.Pow((dizi[i] - ao), 4.0);
            }
            double sonuc = top / (adet - 1);

            return sonuc;
        }
        static double Sapma(double sayi)
        {
            return Math.Round(Math.Sqrt(sayi),2);
        }
        static double orneklemvaryans(double[] dizi, int adet)
        {
            double top = 0;
            double ao;
            for (int i = 0; i < adet; i++)
            {
                top += dizi[i];
            }
           // Math.Round((ao = top / adet), 2);
            ao = top / adet;
            top = 0;
            for (int i = 0; i < dizi.Length; i++)
            {
                top += Math.Pow((dizi[i] - ao), 2.0);
            }
            double sonuc = top / (adet - 1);
            //sonuc = Math.Round(sonuc, 2);
            return sonuc;
        }
        static double geohesap(double[] dizi)
        {
            double carp = 1;
            int üs = 0;
            for(int i = 0;i<dizi.Length;i++)
            {
                carp *= dizi[i];
                üs++;
            }
            double sonuc=Math.Pow(carp,1.0/üs);
            return sonuc;
        }
        static double harmonik(double[] dizi,int adet)
        {
            double top = 0;
            double sonuc ;
            for(int i = 0;i<dizi.Length;i++)
            {
                top += 1 / dizi[i];
            }
            sonuc = adet / top;
            return sonuc;
        }
        static double AritmetikOrt(double[] gelendizi)
        {
            double top=0;
            for(int i = 0;i < gelendizi.Length;i++)
            {
                top += gelendizi[i];
            }
            double ao = top / gelendizi.Length;
            return ao;
        }
        static void AritmetikOrt()
        {
            int adet ;
            int a = 1;
            int top = 0;
            while(true)
            {
                Console.WriteLine("Lütfen Kac Adet Sayı Girceğinizi Yazınız");
                 adet=int.Parse(Console.ReadLine());
                if(adet<= 0 )
                {
                    Console.WriteLine("0 dan büyük sayı giriniz");
                }
                else
                {
                    break;
                }
            }
            //int[] dizi = new int[adet];
            for (int i = 0;i<adet;i++)
            {
                Console.WriteLine(a+".sayıyı giriniz");
                top += int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Aritmetik Ortalama="+(top/adet));
        }
        static double medyan(double[] dizi,int adet)
        {
            dizi = kabarcik_siralama(dizi);
            if (adet % 2 == 1)
            {
                int ortaIndeks = adet / 2;
                return dizi[ortaIndeks];
            }
            else if (adet % 2 == 0)
            {
                int orta1 = adet / 2;
                int orta2 = orta1 - 1;
                double medyan = (dizi[orta1] + dizi[orta2]) / 2.0;
                return medyan;
            }
            return 0.0;
        }
        static void medyan()
        {
            int adet;
            int a = 1;
            while (true)
            {
                Console.WriteLine("Lütfen Kac Adet Sayı Girceğinizi Yazınız");
                adet = int.Parse(Console.ReadLine());
                if (adet <= 0)
                {
                    Console.WriteLine("0 dan büyük sayı giriniz");
                }
                else
                {
                    break;
                }
            }
            double[] dizi = new double[adet];
            for (int i = 0; i < adet; i++)
            {
                Console.WriteLine(a + ".sayıyı giriniz");
                dizi[i] = int.Parse(Console.ReadLine());
            }
            dizi = kabarcik_siralama(dizi);
            if(adet%2==1)
            {
                int ortaIndeks = adet / 2;
                Console.WriteLine("Medyan = " + dizi[ortaIndeks]);
            }
            else if(adet%2==0)
            {
                int orta1 = adet / 2;
                int orta2 = orta1 - 1;
                double medyan = (dizi[orta1] + dizi[orta2]) / 2.0;
                Console.WriteLine("Medyan = " + medyan+"\n");
            }
        }
        static double mod(double[] dizi,int adet)
        {
            double krs = 0;
            double sayi = 0;
            double[,] dönen = frekans(dizi, adet);
            for (int i = 0; i < dizi.Length; i++)
            {

                if (dönen[i, 1] > krs)
                {
                    sayi = dönen[i, 0];
                    krs = dönen[i, 1];
                }
            }
            return sayi;
        }
        static void mod()
        {
            int adet;
            int a = 1;
            while (true)
            {
                Console.WriteLine("Lütfen Kac Adet Sayı Girceğinizi Yazınız");
                adet = int.Parse(Console.ReadLine());
                if (adet <= 0)
                {
                    Console.WriteLine("0 dan büyük sayı giriniz");
                }
                else
                {
                    break;
                }
            }
            double[] dizi = new double[adet];
            double krs = 0;
            double sayi=0;
            for (int i = 0; i < adet; i++)
            {
                Console.WriteLine(a + ".sayıyı giriniz");
                dizi[i] = int.Parse(Console.ReadLine());
            }
            double[,] dönen= frekans(dizi,adet);
            for(int i = 0; i< dizi.Length; i++)
            {

                if (dönen[i, 1] > krs)
                {
                    sayi = dönen[i, 0];
                    krs= dönen[i,1];
                }
            }
            Console.WriteLine("Mod="+sayi+"\n");
        }
        static double Sapma(double[] dizi,int adet)
        {
            double top = 0;
            for (int i = 0; i < adet; i++)
            {
                top += dizi[i];
            }
            double ao;
           // Math.Round((ao = top / adet), 2);
            ao = top / adet;
            top = 0;
            for (int i = 0; i < dizi.Length; i++)
            {
                top += Math.Pow((dizi[i] - ao), 2.0);
            }
            double sonuc;
            sonuc = top / (adet - 1);
             sonuc= Math.Sqrt(sonuc);
            return sonuc; 
        }
    }
}
