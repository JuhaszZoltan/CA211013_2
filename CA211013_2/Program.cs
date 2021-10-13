using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA211013_2
{
    class Program
    {
        static List<Kategoria> kategoriak = new List<Kategoria>();
        static void Main(string[] args)
        {
            Beolvas();
            Console.WriteLine($"2. feladat: {kategoriak.Count} db");
            Console.WriteLine($"3. feladat: {kategoriak.Sum(x => x.Utas)} fő");
            Console.Write("4. fekladat: kulcsszó: ");
            string ksz = Console.ReadLine();
            bool van = kategoriak.Any(x => x.Nev.Contains(ksz));
            Console.WriteLine($"\t{(van ? "Van találat!" : "Nincs találat")}");
            if (van)
            {
                Console.WriteLine("5. feladat:");
                //kategoriak
                //    .Where(x => x.Nev.Contains(ksz))
                //    .ToList()
                //    .ForEach(x => Console.WriteLine($"\t{x.Nev} {x.Utas} fő"));

                kategoriak
                    .Where(x => x.Nev.Contains(ksz))
                    .Select(x => $"\t{x.Nev} {x.Utas} fő")
                    .ToList()
                    .ForEach(x => Console.WriteLine(x));

                //var r = from k in kategoriak
                //        where k.Nev.Contains(ksz)
                //        select $"\t{k.Nev} {k.Utas} fő";

                // r.ToList().ForEach(x => Console.WriteLine(x));
            }

            Console.WriteLine("6.feladat:");
            kategoriak.Where(x => x.Eltuntek > x.Utas * .6)
                .Select(x => $"\t{x.Nev}")
                .ToList()
                .ForEach(x => Console.WriteLine(x));

            //string r = kategoriak
            //    .Where(x => x.Tulelok == kategoriak.Max(y => y.Tulelok))
            //    .First().Nev;

            string r = kategoriak.OrderByDescending(x => x.Tulelok).First().Nev;

            Console.WriteLine($"7. feladat: {r}");

            Console.ReadKey();
        }

        private static void Beolvas()
        {
            using (var sr = new StreamReader(@"..\..\res\titanic.txt", Encoding.UTF8))
            {
                while (!sr.EndOfStream)
                {
                    kategoriak.Add(new Kategoria(sr.ReadLine().Split(';')));
                }
            }
        }

        private static void HulyesegekAPeldaKedveert()
        {
            var t = new int[] { 20, 30, 40 };
            Console.WriteLine(t.Sum());
            int sum = 0;
            foreach (var x in t)
            {
                sum += x;
            }
            Console.WriteLine($"op: {sum}");
        }
    }
}
