using System;

namespace SayisalLotoTahminApp
{
    class Program
    {
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            // Menü
            // [1] - Yeni Tahmin Üret
            // [2] - Çıkış
            // 
            // Seçiminiz : 1

            // 1 - 14 - 23 - 45 - 24 - 9
            // 1 - 14 - 23 - 45 - 24 - 9
            // 1 - 14 - 23 - 45 - 24 - 9
            // 1 - 14 - 23 - 45 - 24 - 9
            // 1 - 14 - 23 - 45 - 24 - 9
            // 1 - 14 - 23 - 45 - 24 - 9
            // 1 - 14 - 23 - 45 - 24 - 9
            // 1 - 14 - 23 - 45 - 24 - 9

            string secim = "";

            do
            {
                WriteMenu();

                secim = Console.ReadLine();
                Console.ResetColor();

                // Menü
                // [1] - Yeni Tahmin Üret
                // [2] - Yeni Tahmin Üret(limitli)
                // [3] - Kendin Üret
                // [0] - Çıkış
                // 
                // Seçiminiz : 
                

                switch (secim)
                {
                    case "0":
                        return;

                    case "1":
                        // Yeni Tahmin Üret
                        Console.WriteLine();

                        //for (int i = 0; i < 8; i++) // satırlar için dönüyoruz.
                        //{
                        //    // object initializers
                        //    //int[] tahminler = new int[] {
                        //    //    rnd.Next(1, 50),
                        //    //    rnd.Next(1, 50),
                        //    //    rnd.Next(1, 50), 
                        //    //    rnd.Next(1, 50), 
                        //    //    rnd.Next(1, 50), 
                        //    //    rnd.Next(1, 50) };

                        //    //tahminler[0] = rnd.Next(1, 50);
                        //    //tahminler[1] = rnd.Next(1, 50);
                        //    //tahminler[2] = rnd.Next(1, 50);
                        //    //tahminler[3] = rnd.Next(1, 50);
                        //    //tahminler[4] = rnd.Next(1, 50);
                        //    //tahminler[5] = rnd.Next(1, 50);

                        //    int[] tahminler = new int[6];

                        //    for (int j = 0; j < tahminler.Length; j++)
                        //    {
                        //        bool hasSame;
                        //        int sayi;
                        //        do
                        //        {
                        //            sayi = rnd.Next(1, 50);
                        //            hasSame = false;

                        //            for (int m = 0; m < tahminler.Length; m++)
                        //            {
                        //                if (sayi == tahminler[m])
                        //                {
                        //                    hasSame = true;
                        //                }
                        //            }

                        //        } while (hasSame);

                        //        tahminler[j] = sayi;
                        //    }

                        //    Array.Sort(tahminler);

                        //    for (int k = 0; k < tahminler.Length; k++)
                        //    {
                        //        Console.Write(tahminler[k] + " - ");
                        //    }

                        //    Console.WriteLine();
                        //}

                        Generate(8);

                        WriteInfo("Tahminleriniz yukarıdadır, menü ye dönmek için bir tuşa basınız.");
                        break;

                    case "2":
                        // Yeni Tahmin Üret(limitli)

                        int tahminAdet = 0;

                        do
                        {
                            Console.WriteLine();
                            Console.Write("Lütfen tahmin adedi giriniz : ");
                            string tahminAdetStr = Console.ReadLine();
                            tahminAdet = int.Parse(tahminAdetStr);  // try-catch

                            if (tahminAdet > 8 || tahminAdet < 1)
                            {
                                WriteError(2);
                                //WriteError("1 ve 8 arasında bir değer girebilirsiniz.", "Yanlış giriş!", false);
                            }

                        } while (tahminAdet > 8 || tahminAdet < 1);

                        Generate(tahminAdet);

                        WriteInfo("Tahminleriniz yukarıdadır, menü ye dönmek için bir tuşa basınız.");
                        break;

                    case "3":
                        // Kendin Üret
                        // ??
                        // Kullanıcıdan satır adedi alınır.(1-8 arası olmalı)
                        // Her satır için 6 adet sayı alınır.(aynı sayıyı girememeli)
                        // tüm satır verileri alındıktan sonra tüm satırlar yazdırılır ama sıralı(WriteBySort kullanılabilir)
                        break;

                    default:
                        WriteError(1);
                        //WriteError("Lütfen menüye dönmek için bir tuşa basınız..");
                        break;
                }


            } while (secim != "0");

        }

        private static void Generate(int tahminAdet)
        {
            for (int i = 0; i < tahminAdet; i++)
            {
                int[] tahminler = new int[6];

                for (int j = 0; j < tahminler.Length; j++)
                {
                    bool hasSame;
                    int sayi;
                    do
                    {
                        sayi = rnd.Next(1, 50);
                        hasSame = false;

                        for (int m = 0; m < tahminler.Length; m++)
                        {
                            if (sayi == tahminler[m])
                            {
                                hasSame = true;
                            }
                        }

                    } while (hasSame);

                    tahminler[j] = sayi;
                }

                WriteBySort(tahminler);

                Console.WriteLine();
            }
        }

        private static void WriteBySort(int[] tahminler)
        {
            Array.Sort(tahminler);

            for (int k = 0; k < tahminler.Length; k++)
            {
                Console.Write(tahminler[k]);

                if (k < tahminler.Length - 1)
                {
                    Console.Write(" - ");
                }
            }
        }

        private static void WriteMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();

            Console.WriteLine("Sayısal Loto Tahmin Uygulaması");
            Console.WriteLine("==============================");
            Console.WriteLine();

            Console.WriteLine("Menü");
            Console.WriteLine("[1] - Yeni Tahmin Üret");
            Console.WriteLine("[2] - Yeni Tahmin Üret(limitli)");
            Console.WriteLine("[3] - Kendin Üret");
            Console.WriteLine("[0] - Çıkış");
            Console.WriteLine();
            Console.Write("Seçiminiz : ");
        }

        private static void WriteError(int komut)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;

            if (komut == 1)
            {
                Console.WriteLine("Yanlış giriş yaptınız.");
                Console.Write("Lütfen menüye dönmek için bir tuşa basınız..");
                Console.ReadKey();
            }
            else if (komut == 2)
            {
                Console.WriteLine("Yanlış giriş!");
                Console.WriteLine("1 ve 8 arasında bir değer girebilirsiniz.");
            }

            Console.ResetColor();
        }

        private static void WriteError(string errorMessage, string errorTitle = "Yanlış giriş yaptınız!", bool hasReadKey = true)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(errorTitle);
            Console.Write(errorMessage);

            if (hasReadKey)
            {
                Console.ReadKey();
            }

            Console.ResetColor();
        }

        private static void WriteInfo(string message, string title = "", bool hasReadKey = true)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(title);
            Console.Write(message);

            if (hasReadKey)
            {
                Console.ReadKey();
            }

            Console.ResetColor();
        }
    }
}
