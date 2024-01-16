using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*ADAM ASMACA*/

            // Kelimelerin bulunduğu dizi
            string[,] kelimeler = { { "anahtar", "Eşya" }, { "kulaklık", "Eşya" }, { "klavye", "Eşya" }, { "elma", "Meyve"}, { "armut", "Meyve" }, { "inek", "Hayvan" }, {"koyun", "Hayvan" }, { "tavşan", "Hayvan" }, { "kedi", "Hayvan" }, { "köpek", "Hayvan" } };

            // Diziden rastgele bir eleman seçiyor
            Random rastgele = new Random();            
            int no = rastgele.Next(0, kelimeler.GetLength(0));

            // Seçilen elemandaki kelimenin harflerini küçük yapıyor
            string cevap = kelimeler[no,0].ToLower();

            // Her yanlış yaptığında arttırabileceğimiz puan tanımlıyoruz
            int puan = 0;

            // Konsolda görünecek olan başlıklar için ilk başta null tanımlıyoruz.
            string GYazi = null;            

            // Tahminlerin doğruluğunu kontrol etmek için bool veri tipi oluşturup false veriyoruz
            bool tahmin = false;

            // cevap taki harflerimiz görünmesin diye 
            // cevap taki kelimenin harf sayısı kadar _ elemanı bulunan for döngüsü ile yeni bir char dizisi oluşturuyoruz.
            char[] G = new char[cevap.Length];
            for (int i = 0; i < cevap.Length; i++)
            {
                G[i] = '_';
            }

            // Yanlış ve Doğru harfleri tutmak için ArrayList oluşturuyoruz.
            ArrayList yanlis = new ArrayList();
            ArrayList dogru = new ArrayList();

            // Oyun için while döngüsü oluşturuyoruz.
            // Cevaptaki harf sayısı ile doğru listesindeki harf sayısına eşit değilse ve
            // puanı 6 dan küçük ise döngü devam edicek.
            while (cevap.Length != dogru.Count && puan < 6)
            {
                Console.WriteLine("\n---------------------------------------------------------\n");
                
                // Başlık için GYazi yı kontrol ediyoruz.
                if (GYazi == "D")
                    Console.WriteLine("** ÇOK İYİSİN! **\n");
                else if (GYazi == "Y")
                    Console.WriteLine("** YANLIŞ HARF! **\n");
                else if (GYazi == "T")
                    Console.WriteLine("** ZATEN BU HARFİ DENEDİN! **\n");
                else if (GYazi == "YT")
                    Console.WriteLine("** YANLIŞ TAHMİN! **\n");
                else
                    Console.WriteLine("** ADAM ASMACA **\n");

                // Diziden seçtiğimiz kelimenin kategorisini gösteriyoruz.
                Console.WriteLine("Kategori: "+ kelimeler[no, 1]);

                // Kelimeyi göstermek için oluşturduğumuz G dizisinden elemanları for döngüsü ile çekiyoruz.
                Console.Write("Kelime: ");
                    for (int i = 0; i < cevap.Length; i++)
                    {
                        Console.Write(G[i] + " ");
                    }

                // yanlis ArrayList teki harfleri göstermek için for döngüsü yapıyoruz.
                // Eğer harf yok ise Yok yazısını gösteriyoruz.
                Console.Write("\nYanlış Harfler: ");
                    for (int i = 0; i < yanlis.Count; i++)
                    {                       
                        if(yanlis.Count != 0)
                            Console.Write(yanlis[i] + ", ");
                        else
                            Console.Write("Yok");
                    }
                
                 // Puana göre adamın neresinin gösterileceğini ayarlıyoruz.
                 // Puanı 0 dan büyük ise kafası görünmeye başlasın değilse boşluk gösterilsin.
                 string Kafa = (puan > 0) ? "Q" : "";
                 string Govde = (puan > 1) ? "()" : "";
                 string SolKol = (puan > 2) ? "┌" : "";
                 string SagKol = (puan > 3) ? "┐" : "";
                 string SolBacak = (puan > 4) ? "/" : "";
                 string SagBacak = (puan > 5) ? "\\" : "";
                
                 // Adam Asmacanın görüntüsünü ayarlıyoruz.
                 Console.WriteLine(
                       "\n"
                     + "\n  _________"
                     + "\n  |    |"
                    + $"\n  |    {Kafa}"
                    + $"\n  |   {SolKol}{Govde}{SagKol}"
                    + $"\n  |    {SolBacak}{SagBacak}"
                    + "\n"
                    );

                // Oyuncudan bir harf veya tahminde bulunmasını istiyoruz yazdığını string e çevirip harflerini küçük yapıyoruz.
                 Console.Write("Bir harf yazın veya tahminde bulunun:");
                var secim = Console.ReadLine().ToString().ToLower();
                
                // cevap taki harfleri char dizisine çeviriyoruz. 
                char[] c = cevap.ToCharArray();

                // secim deki harfleri char dizisine çeviriyoruz.
                char[] s = secim.ToCharArray();

                // secim eğer null ise diğer kodları çalıştırmadan döngü başına dönsün.
                if (String.IsNullOrEmpty(secim))
                {
                    continue;
                }

                // secim deki karakter sayısı 1 den fazla ve secim ile cevap aynı ise tahmin true olsun.
                // Ve döngü dursun.
                if (secim.Length > 1 && secim == cevap)
                {
                    tahmin = true;
                    break;
                }
                // cevap içerisinde secim de girilen harfi arıyoruz.                
                else if(cevap.Contains(secim))
                {                    
                    // dogru ArrayList de secim de girilen harf var mı kontrol ediyoruz.
                    // Var ise GYazi T olsun ve diğer kodları çalıştırmadan döngü başına dönsün.
                    if (dogru.Contains(s[0]))
                    {
                        GYazi = "T";
                        continue;
                    }

                    for (int i = 0; i<cevap.Length; i++)
                    {
                        // c dizisindeki harf s dizindeki harf ile aynı değilse diğer kodları çalıştırmadan döngü başına dönsün.
                        if (c[i] != s[0]) continue;

                        // c dizisindeki harf s dizindeki harf ile aynı ise
                        // s dizisindeki harf dogru ArrayList e eklensin,
                        // G dizisinde _ elemanını s teki harf ile değiştiriyoruz.
                        dogru.Add(s[0]);
                        G.SetValue(c[i], i);

                        // Ve GYazi D olsun.
                        GYazi = "D";
                    }
                }
                else
                {
                    // secim in karakter uzunluğu 1 e eşit mi kontrol ediyoruz.
                    // eşit ise
                    if (secim.Length == 1)
                    {
                        // yanlis ArrayList de secim de girilen harf var mı kontrol ediyoruz.
                        // Var ise GYazi T olsun ve diğer kodları çalıştırmadan döngü başına dönsün.
                        if (yanlis.Contains(s[0]))
                        {
                            GYazi = "T";
                            continue;
                        }

                        // s dizisindeki harf yanlis ArrayList e eklensin,
                        // puan +1 arttırılsın
                        yanlis.Add(s[0]);
                        puan++;

                        // Ve GYazi Y olsun.
                        GYazi = "Y";
                    }
                    // secim in karakter uzunluğu 1 e eşit değilse
                    else
                    {
                        // puan +1 arttırılsın
                        // Ve GYazi YT olsun.
                        puan++;
                        GYazi = "YT";
                    }

                }

            }

            // cevap karakter uzunluğu ile dogru ArrayList teki eleman sayısı aynı ise
            // Veya tahmin true ise
            if (cevap.Length == dogru.Count || tahmin)
            {
                Console.WriteLine("\n---------------------------------------------------------\n");
                Console.WriteLine($"Tebrikler kelimeyi buldun!\nKelime: {cevap}");
            }
            // eğer değilse 
            else
            {
                Console.WriteLine("\n---------------------------------------------------------\n");
                Console.WriteLine("** MAALESEF BİLEMEDİN! **\n");
                Console.WriteLine("Kategori: " + kelimeler[no, 1]);
                Console.Write("Kelime: " + cevap);
                Console.Write("\nYanlış Harfler: ");
                for (int i = 0; i < yanlis.Count; i++)
                {
                    if (yanlis.Count != 0)
                        Console.Write(yanlis[i] + ", ");
                    else
                        Console.Write("Yok");
                }
                Console.WriteLine(
                       "\n"
                     + "\n  _________"
                     + "\n  |    |"
                    + $"\n  |    Q"
                    + $"\n  |   ┌()┐"
                    + $"\n  |    /\\"
                    + "\n"
                    );
            }
            

           Console.ReadLine();
        }
    }
}
