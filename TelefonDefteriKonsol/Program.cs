using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonDefteriKonsol
{
    class Program
    {
        static int sayac = 0;
        static string[] kayitlar = new string[10];



        static void Main(string[] args)
        {
            //SplitKullanimi();
            // C: klasörüne telfed adında bir klasör oluşturmanız gerekmektedir.
            Oku();

            string menuSecim = "";

            do
            {
                menuSecim = MenuGoster();

                switch (menuSecim)
                {
                    case "1":
                        // Listeleme
                        Listele();
                        break;

                    case "2":
                        // Yeni Kayıt
                        YeniKayitEkle();
                        break;

                    case "3":
                        // Düzenle
                        KayitDuzenle();
                        break;

                    case "4":
                        // Sil
                        KayitSil();
                        break;

                    case "5":
                        Kaydet();
                        break;
                    default:
                        break;
                }


            } while (menuSecim != "5");



            Console.ReadKey();
        }

        private static void Oku()
        {
            if(System.IO.File.Exists(@"C:\telfed\teldef.txt") == true)
            {
                kayitlar = System.IO.File.ReadAllLines(@"C:\telfed\teldef.txt");
                sayac = kayitlar.Length;

                Array.Resize(ref kayitlar, 10);
            }
        }

        private static void Kaydet()
        {
            string[] kayitlar2 = new string[sayac];

            for (int i = 0; i < sayac; i++)
            {
                kayitlar2[i] = kayitlar[i];
            }

            System.IO.File.WriteAllLines(@"C:\telfed\teldef.txt", kayitlar2);
        }

        private static void KayitSil()
        {
            Console.Clear();
            Console.WriteLine("===== KAYIT SİLME =====");
            Console.WriteLine();

            if (sayac == 0)
            {
                Console.WriteLine("Kayıt yoktur.");
                Console.ReadKey();
                return;
            }

            int index = 0;

            do
            {
                Console.Write("Kayıt ID : ");
                index = int.Parse(Console.ReadLine());
            } while (index < 0 || index >= sayac);


            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            string kayit = kayitlar[index]; // Diziden duzenlenecek kayıt okunur.
            string[] kayitDetay = kayit.Split(';'); // ad, soyad, tel parçalanır.

            Console.WriteLine(" Ad\t : " + kayitDetay[0]);
            Console.WriteLine(" Soyad\t : " + kayitDetay[1]);
            Console.WriteLine(" Tel\t : " + kayitDetay[2]);

            Console.WriteLine();
            Console.WriteLine("Silmek istediğinize emin misiniz? (E/H)");
            string evetHayir = Console.ReadLine();

            if (evetHayir == "E")
            {
                string[] kayitlar2 = new string[10];
                int diziSayac = 0;

                for (int i = 0; i < sayac; i++)
                {
                    if (i != index)
                    {
                        // Silmek istediği index'li kayıt değil ise..
                        kayitlar2[diziSayac] = kayitlar[i];
                        diziSayac++;
                    }
                }

                kayitlar = kayitlar2;
                sayac--;

            }

        }

        private static void KayitDuzenle()
        {
            Console.Clear();
            Console.WriteLine("===== KAYIT DÜZENLEME =====");
            Console.WriteLine();

            if (sayac == 0)
            {
                Console.WriteLine("Kayıt yoktur.");
                Console.ReadKey();
                return;
            }

            int index = 0;

            do
            {
                Console.Write("Kayıt ID : ");
                index = int.Parse(Console.ReadLine());
            } while (index < 0 || index >= sayac);


            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            string kayit = kayitlar[index]; // Diziden duzenlenecek kayıt okunur.
            string[] kayitDetay = kayit.Split(';'); // ad, soyad, tel parçalanır.

            Console.WriteLine(" Ad\t : " + kayitDetay[0]);
            Console.WriteLine(" Soyad\t : " + kayitDetay[1]);
            Console.WriteLine(" Tel\t : " + kayitDetay[2]);

            Console.WriteLine();
            Console.WriteLine("Düzenlemek istediğinize emin misiniz? (E/H)");
            string evetHayir = Console.ReadLine();

            if (evetHayir == "E")
            {
                Console.WriteLine("===== YENİ BİLGİLER =====");
                Console.WriteLine();

                Console.Write(" Ad\t : ");
                string ad = Console.ReadLine();

                Console.Write(" Soyad\t : ");
                string soyad = Console.ReadLine();

                Console.Write(" Tel\t : ");
                string tel = Console.ReadLine();

                string kayitOzet = string.Join(";", ad, soyad, tel);
                kayitlar[index] = kayitOzet;
            }

        }

        private static void Listele()
        {
            Console.Clear();

            Console.WriteLine("===== KAYITLAR =====");
            Console.WriteLine();

            for (int i = 0; i < sayac; i++)
            {
                string[] kayit = kayitlar[i].Split(';');
                Console.WriteLine(i + "\t{0}\t{1}\t{2}", kayit[0], kayit[1], kayit[2]);
            }

            Console.WriteLine();

            if (sayac == 0)
            {
                Console.WriteLine("Kayıt bulunamadı.");
            }
            else
            {
                Console.WriteLine("Kayıtlar listelenmiştir.");
            }

            Console.ReadKey();
        }

        private static void YeniKayitEkle()
        {
            Console.Clear();

            Console.WriteLine("===== YENİ KAYIT =====");
            Console.WriteLine();

            Console.Write("Ad\t : ");
            string ad = Console.ReadLine();

            Console.Write("Soyad\t : ");
            string soyad = Console.ReadLine();

            Console.Write("Tel\t : ");
            string tel = Console.ReadLine();

            kayitlar[sayac] = string.Join(";", ad, soyad, tel);
            sayac++;

            Console.WriteLine();
            Console.WriteLine("Kayıt eklenmiştir.");
            Console.ReadKey();

        }

        private static string MenuGoster()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("===== MENÜ =====");
            Console.WriteLine(" 1 - Listeleme");
            Console.WriteLine(" 2 - Yeni Kayıt");
            Console.WriteLine(" 3 - Düzenle");
            Console.WriteLine(" 4 - Sil");
            Console.WriteLine(" 5 - Çıkış");
            Console.WriteLine("================");

            string secim = string.Empty;

            do
            {

                Console.WriteLine();
                Console.Write("Lütfen yapmak istediğiniz işlemi belirtiniz : ");
                secim = Console.ReadLine();

            } while (secim != "1" && secim != "2" &&
                        secim != "3" && secim != "4" && secim != "5");

            Console.ResetColor();
            Console.WriteLine();

            return secim;
        }

        private static void SplitKullanimi()
        {
            string metin = "hasan;kahraman;5556669996";

            string[] degerler = new string[3];
            degerler = metin.Split(';');

            for (int i = 0; i < degerler.Length; i++)
            {
                Console.WriteLine(degerler[i]);
            }
        }
    }
}
