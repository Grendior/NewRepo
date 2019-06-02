using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Projekt6
{

    class Ciag
    {
        public int[] tab;
        public List<int> listaFib = new List<int>();
        public List<int> listaArm = new List<int>();
        public List<int> listaMer = new List<int>();
        public Ciag()
        {
            Console.WriteLine("Podaj liczbę wartości które mają się znaleźć w ciągu: ");
            tab = new int[int.Parse(Console.ReadLine())];
            for (int i = 0; i < tab.Length; i++)
            {
                Console.Write($"Wyraz[{i + 1}] = ");
                tab[i] = int.Parse(Console.ReadLine());
            }
        }
        int Fibon(int liczba)
        {
            int a, b;
            a = 1;
            b = 1;
            for (int i = 0; i < 19; i++)
            {
                if (liczba == 1)
                {
                    return liczba;
                }
                b += a;
                a = b - a;
                if (b == liczba)
                {
                    return liczba;
                }
            }
            return 0;
        }
        int Armstrong(int liczba)
        {
            string dl = liczba.ToString();
            int[] tab1 = new int[dl.Length];
            double suma = 0;
            int i = 0;
            while (liczba != 0)
            {
                int sklad;
                sklad = liczba % 10;
                liczba = (liczba - sklad) / 10;
                tab1[i] = sklad;
                i++;
            }
            int lcyfr = int.Parse(dl)+1;
            for (int j = 0; j < dl.Length; j++)
            {
                suma += Math.Pow(tab1[j], lcyfr);
            }
            if (suma == liczba)
            {
                return liczba;
            }
            else
            {
                return 0;
            }
        }
        //public int Armstrong(int liczba)
        //{
        //    string dl = liczba.ToString();
        //    int[] tablica = new int[dl.Length];
        //    double suma = 0;
        //    for (int i = 0; i < tablica.Length; i++)
        //    {
        //        suma += Math.Pow(tablica[i], dl.Length);
        //    }
        //    if (suma == liczba)
        //    {
        //        return liczba;
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}
        int Mersenne(int liczba)
        {
            int i = 0;
            double suma = 0;
            while (liczba > suma)
            {

                suma = Math.Pow(2, i) - 1;
                i++;
            }
            if (liczba == suma)
            {
                return liczba;
            }
            else
            {
                return 0;
            }
        }
        public void Wynik()
        {
            for (int i = 0; i < tab.Length; i++)
            {
                if ((Fibon(tab[i]) != 0))
                {
                    listaFib.Add(Fibon(tab[i]));
                }
                if (Armstrong(tab[i]) != 0)
                {
                    listaArm.Add(Armstrong(tab[i]));
                }
                if (Mersenne(tab[i]) != 0)
                {
                    listaMer.Add(Mersenne(tab[i]));
                }
            }
            listaFib.Sort();
            listaMer.Sort();
            listaArm.Sort();
            Console.WriteLine();
            Console.Write("Ciąg Fibonacciego:");
            foreach (int item in listaFib)
            {
                Console.Write($" {item}");
            }
            Console.WriteLine();
            Console.Write("Ciąg Mersenne'a:");
            foreach (int item in listaMer)
            {
                Console.Write($" {item}");
            }
            Console.WriteLine();
            Console.Write("Ciąg Armstronga:");
            foreach (int item in listaArm)
            {
                Console.Write($" {item}");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Ciag arra = new Ciag();
            arra.Wynik();
            Console.ReadKey();
        }
    }
}
