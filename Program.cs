using System;
using System.Collections;

namespace ConsoleApp18
{
    class Program
    {
        static void Main(string[] args)  // Mainin oluşturulması
        {
            Console.WriteLine("N değerini giriniz:");
            int n = Convert.ToInt32(Console.ReadLine());   // n değerinin alınması
            Console.WriteLine("Width değerini giriniz:");
            int weight = Convert.ToInt32(Console.ReadLine());  // width değerinin alınması
            Console.WriteLine("height değerini giriniz:");
            int height = Convert.ToInt32(Console.ReadLine());  // height değerinin alınması
            Console.WriteLine();
            ArrayList noktalar = new ArrayList();   // noktaların tutulduğu arraylistin oluşturulması
            Random r = new Random();   // random değişkenin oluşturulması
            Console.WriteLine("****----ÜRETİLEN NOKTALAR----****");
            Console.WriteLine();
            noktaUret(n, weight, height, r, noktalar);  // nokraların rastgele üretilmesi
            Console.WriteLine();
            Console.WriteLine("                                                  ****----UZAKLIK MATRİSİ----****");
            Console.WriteLine();
            ArrayList uzaklıklar = uzaklıkBul(noktalar);  // noktalar arasındaki uzaklığı bulup arrayliste atan fonksiyonun çağırılması
            foreach (double[] o in uzaklıklar)  // her bir noktanın diğer noktalara olan uzaklığını tutan listelerin tek tek arraylistten çekilmesi
            {
                foreach (double x in o)  // herbir listenin ilk elemanının çekilmesi
                {
                    Console.Write(String.Format("{0:0.##}-", x));  // herbir uzaklığın yazdırılması
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            enYakinKomsu(r, uzaklıklar);  // noktalar arasındaki en yakın yolu bulan fonksiyonun çalışması
        }

        public static ArrayList noktaUret(int n, int weight, int height, Random r, ArrayList noktalar)  // rastgele nokta üreten fonksiyon 
        {
            for (int i = 0; i < n; i++)  // üretilcek nokta kadar dönen for döngüsü
            {
                double[] nokta = new double[2];  // üretilen 2 noktanın tutulacağı listenin oluşturulması
                nokta[0] = r.NextDouble() * (weight);  // ilk noktanın oluşturulması
                nokta[1] = r.NextDouble() * (height);   // ikinci noktanın oluşturulması

                noktalar.Add(nokta);  // oluşturulan listenin arrayliste aktarılması

            }
            foreach (double[] o in noktalar)  // oluşturulan noktaların yazdırılması
            {
                Console.WriteLine("{0}-{1}", o[0], o[1]);
            }
            return noktalar;  // arraylistin geri döndürülmesi
        }

        public static ArrayList uzaklıkBul(ArrayList noktalar)  //herbir noktanın diğer noktalara olan uzaklığını bulan fonksiyon
        {
            ArrayList uzaklıklar = new ArrayList();  // uzaklık matrisinin oluşturulduğu arraylist
            for (int i = 0; i < noktalar.Count; i++)  // nokta sayısı kadar dönen for döngüsü
            {
                double[] uzaklık = new double[noktalar.Count];  // herbir noktanın diğer noktalara olan uzaklığını tutacak olan liste

                for (int j = 0; j < noktalar.Count; j++)  // nokta sayısı kadar dönen for döngüsü
                {
                    double[] nokta1 = (double[])noktalar[i];  // diğer noktalara uzaklıkları bulunacak olan nokta çiftinin çekilmesi
                    double[] nokta2 = (double[])noktalar[j];   // diğer nokta çiftlerinin çekilmesi
                    uzaklık[j] = Math.Sqrt(Math.Pow(nokta2[0] - nokta1[0], 2) + Math.Pow(nokta2[1] - nokta1[1], 2));  // ilgili iki noktanın uzaklığının bulunup uzaklık listesine atılması

                }
                uzaklıklar.Add(uzaklık);  // uzaklık listesinin arrayliste atılması

            }
            return uzaklıklar;  // arraylistin döndürülmesi

        }

        public static void enYakinKomsu(Random r, ArrayList uzaklıklar)  // en yakın yolu bulan fonksiyon
        {
            for (int i = 0; i < 10; i++)  // tur sayısı
            {
                Console.WriteLine("{0}.tur", i+1);
                double toplamYol = 0;  // en yakın yolun toplam uzunluğunun tutulduğu değişken
                int rastgele = r.Next(0, uzaklıklar.Count-1);  // hangi noktada başlanacağının rastgele atanması
                ArrayList dolasilanIndex = new ArrayList(); // dolaşılan noktaların tutulduğu arraylist
                for (int a = 0; a < uzaklıklar.Count; a++)  // nokta sayısı kadar dönen for döngüsü
                {
                    dolasilanIndex.Add(-1);  // arraylistin ilk elemanlarının -1 atanması
                }
                dolasilanIndex[0] = rastgele;  // başlanacak ilk elemanın arrayliste atılması

                for (int j = 1; j < uzaklıklar.Count; j++)  // nokta sayısı kadar dönen for döngüsü
                {

                    int index1 = (int)dolasilanIndex[j - 1];  // diğer noktalara uzaklığı bulunacak noktanın indexinin bulunması
                    double[] list2 = (double[])uzaklıklar[index1];  // noktanın diğer noktalara uzaklığını tutan listenin çekilmesi

                    double minYol = 999999999999999;  // bir noktanın diğer noktaya olan uzaklığının tutulduğu değişken(default olarak yüksek sayı atanmıştır)

                    for (int k = 0; k < list2.Length; k++)  // nokta sayısı kadar dönen for döngüsü
                    {
                        if (list2[k] == 0)  // uzaklık matrisindeki elemanın noktanın kendisi olup olmadadığının kontrolü
                        {
                            continue;
                        }
                        else
                        {
                            if (!(dolasilanIndex.Contains(k)) && list2[k] < minYol)  // nokta kendisi değilse ve daha önce dolaşılmadıysa ve şu ana kadarki en yakın noktaysa çalışan blok
                            {
                                minYol = list2[k];  // uzaklığın minyola atanması
                                dolasilanIndex[j] = k;  // dolasilan noktanın işaretlenmesi

                            }

                        }
                    }
                    toplamYol += minYol;  // minyolun toplam yola eklenmesi

                }

                foreach (int o in dolasilanIndex)  // dolasılan yolun yazdırılması
                {
                    Console.Write("{0}-", o);
                }
                Console.WriteLine();
                Console.WriteLine(toplamYol);  // dolasılan toplam yol uzunluğunun yazdırılması
                Console.WriteLine();

            }
        }
    }
}
