
using labo04;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class Program
    {
        static void Main(string[] args)
        {
            //zad1
            using (var sw = new StreamWriter("nrAlbumu.txt"))
            {
                Console.WriteLine("Podaj swój album: ");
                string album = Console.ReadLine();
                sw.WriteLine(album);

            }

            //zad2
            using (var sr = new StreamReader("readme.txt"))
            {
                var line = sr.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);

                    line = sr.ReadLine();
                }
            }

            //zad3
            using (var pr = new StreamReader("pesels.txt"))
            {
                int licznikM = 0;
                int licznikKob = 0;
                string pesel = pr.ReadLine();
                while (pesel != null)
                {
                    int number = pesel[9] - 48;

                    if (number % 2 == 0)
                    {
                        licznikKob++;
                    }
                    else
                        licznikM++;

                    pesel = pr.ReadLine();

                }

                Console.WriteLine("Kobiety :" + licznikKob + " Mezczyzni : " + licznikM);
            }

            zad4();

        }

        public class Indicator
        {
            public string id { get; set; }
            public string value { get; set; }
        }

        public class Country
        {
            public string id { get; set; }
            public string value { get; set; }
        }

        public class Root
        {
            public Indicator indicator { get; set; }
            public Country country { get; set; }
            public string value { get; set; }
            public string @decimal { get; set; }
            public string date { get; set; }
        }



        public static void zad4()
        {
            List<Root> list;
            using (var sr = new StreamReader("db.json"))
            {
                var json = sr.ReadToEnd();
                list = JsonConvert.DeserializeObject<List<Root>>(json);
            }

            zad4v1(list);
            zad4v2(list);
            zad4v3(list);

            Console.WriteLine("Zad4 podpunkt 4");
            Console.WriteLine("Wybierz kraj:(US,CN,IN):");
            string kraj = Console.ReadLine();
            Console.WriteLine("Wybierz date:(1960-2019):");
            string data = Console.ReadLine();
            zad4v4(list, kraj, data);

            Console.WriteLine("zad 4 kropka 5 : Roznica miedzy wybranymi krajami i datami :");
            Console.WriteLine("Wybierz kraj 1:(US,CN,IN):");
            string kraj1 = Console.ReadLine();
            Console.WriteLine("Wybierz date 1:(1960-2019):");
            string data1 = Console.ReadLine();
            Console.WriteLine("Wybierz kraj 2:(US,CN,IN):");
            string kraj2 = Console.ReadLine();
            Console.WriteLine("Wybierz date 2:(1960-2019):");
            string data2 = Console.ReadLine();

            zad4v5(list, kraj1, data1, kraj2, data2);

            Console.WriteLine("zad 4 podpunkt 6 : Procentowy wzrost populacji względem roku poprzedniego do wskazanego :");
            Console.WriteLine("Wybierz kraj 1:(US,CN,IN):");
            string kraj3 = Console.ReadLine();
            Console.WriteLine("Wybierz date 1:(1960-2019):");
            string data3 = Console.ReadLine();

            zad4v6(list, kraj3, data3);
        }

        public static void zad4v1(List<Root> list)
        {
            String in1970 = "";
            String in2000 = "";
            foreach (var root in list)
            {
                if (root.country.id.Equals("IN") && root.date.Equals("1970"))
                {
                    in1970 = root.value;
                }

                if (root.country.id.Equals("IN") && root.date.Equals("2000"))
                {
                    in2000 = root.value;
                }
            }

            long a = Int64.Parse(in1970);
            long b = Int64.Parse(in2000);
            long c = b - a;
            Console.WriteLine("Zad4 kropka 1");
            Console.WriteLine("w 1970: " + a + " w 2000: " + b + " roznica: " + c);
        }

        public static void zad4v2(List<Root> list)
        {
            String in1970 = "0";
            String in2000 = "0";
            foreach (var root in list)
            {
                if (root.country.id.Equals("US") && root.date.Equals("1965"))
                {
                    in1970 = root.value;
                }

                if (root.country.id.Equals("US") && root.date.Equals("2010"))
                {
                    in2000 = root.value;
                }
            }

            long a = Int64.Parse(in1970);
            long b = Int64.Parse(in2000);
            long c = b - a;
            Console.WriteLine("Zad4 kropka 2");
            Console.WriteLine("w 1965: " + a + " w 2010: " + b + " roznica: " + c);
        }

        public static void zad4v3(List<Root> list)
        {
            String in1970 = "";
            String in2000 = "";
            foreach (var root in list)
            {
                if (root.country.id.Equals("CN") && root.date.Equals("1980"))
                {
                    in1970 = root.value;
                }

                if (root.country.id.Equals("CN") && root.date.Equals("2018"))
                {
                    in2000 = root.value;
                }
            }

            long a = Int64.Parse(in1970);
            long b = Int64.Parse(in2000);
            long c = b - a;
            Console.WriteLine("Zad 4 kropka 3");
            Console.WriteLine("w 1980: " + a + " w 2018: " + b + " roznica: " + c);
        }

        public static void zad4v4(List<Root> list, String countryID, String year)
        {
            String pop = "";
            foreach (var root in list)
            {
                if (root.country.id.Equals(countryID) && root.date.Equals(year))
                {
                    pop = root.value;
                }
            }

            Console.WriteLine(countryID + " " + year + " :" + pop);
        }

        public static void zad4v5(List<Root> list, String countryID1, String year1, String countryID2, String year2)
        {
            String in1 = "";
            String in2 = "";
            foreach (var root in list)
            {
                if (root.country.id.Equals(countryID1) && root.date.Equals(year1))
                {
                    in1 = root.value;
                }

                if (root.country.id.Equals(countryID2) && root.date.Equals(year2))
                {
                    in2 = root.value;
                }
            }

            long a = Int64.Parse(in1);
            long b = Int64.Parse(in2);
            long c = b - a;
            Console.WriteLine("w " + countryID1 + " " + year1 + ": " + a + " \nw " + countryID2 + " " + year2 + ": " +
                              b + " \nroznica: " + c);
        }

        public static void zad4v6(List<Root> list, String countryID, String year)
        {
            int yearInt = Int16.Parse(year);
            int prevYear = yearInt - 1;
            if (yearInt > 1960 && yearInt < 2020)
            {
                String year1 = "";
                String year2 = "";
                foreach (var root in list)
                {
                    if (root.country.id.Equals(countryID) && root.date.Equals(year))
                    {
                        year1 = root.value;
                    }
                    if (root.country.id.Equals(countryID) && root.date.Equals(prevYear.ToString()))
                    {
                        year2 = root.value;
                    }
                }
                Console.WriteLine(countryID + " " + year1 + " :" + year2);
                long a = Int64.Parse(year1);
                long b = Int64.Parse(year2);
                double c = (double)(a - b) / b;
                Console.WriteLine(c*100 + "%");
            }
        }
        //public static void Zad5()
        //{
        //    FilePersonRepository repository = new FilePersonRepository();
        //    Person p1 = new Person(1, "Rafał", "Gawlak", "007");
        //    repository.Add(p1);
        //    repository.GetById(1);
        //    repository.GetAll();
        //    repository.Remove(1);
        //    repository.GetAll();
        // Zadanie niedokończone, brakuję pliku FilePersonRepository, z przyczyny takiej, iż nie do końca wiem jak ma wyglądądać.
        //}
    }
}
