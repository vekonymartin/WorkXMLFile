using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkXMLFile
{
    class Program
    {
        static void ToConsole<T>(IEnumerable<T> input, string str)
        {
            Console.WriteLine("***" + str);

            foreach (T item in input)
                Console.WriteLine(item.ToString());

            Console.WriteLine("***" + str + "end");
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            List<Person> people = Person.Load("http://users.nik.uni-obuda.hu/prog3/_data/people.xml");

            var names = people.Where(p => p.Dept == "Biomatika Intézet").Select(p => new { p.Name, p.Rank });
            ToConsole(names, " 0. task");

            // ======================================================================
            // 1. Task
            // Határozzuk meg az AII intézetben dolgozók darabszámát!

            string dept = "Alkalmazott Informatikai Intézet";
            var f1 = people.Where(p => p.Dept == dept).Count();
            var f1_alt = people.Count(p => p.Dept == dept);

            var f1_alt2 = from p in people
                          where p.Dept == dept
                          group p by p.Dept into g
                          select g.Count();
            
            ToConsole(f1_alt2, " 1. task");

            // ======================================================================
            // 2. Task
            // Jelenítsük meg azokat, akiknek a harmadik emeleten van irodája!
            var f2 = people.Where(p => p.Room.StartsWith("BA.3"))
                .Select(p => new { p.Name, p.Room });

            var f2_alt = from p in people
                         where p.Room.StartsWith("BA.3")
                         select new { p.Name, p.Room };

            ToConsole(f2_alt, " 2. task");

            // ======================================================================
            // 3. Task
            // Kiknek van a leghosszabb vagy legrövidebb nevük?

            var min1 = people.Min(p => p.Name.Length);
            var max1 = people.Max(p => p.Name.Length);
            var f3 = people
                .Where(p => p.Name.Length == min1 || p.Name.Length == max1)
                .Select(p => p.Name);

            var f3_alt = from p in people
                         let minLength = people.Min(x => x.Name.Length)
                         let maxLength = people.Max(x => x.Name.Length)
                         where p.Name.Length == minLength || p.Name.Length == maxLength
                         select p.Name;

            ToConsole(f3_alt, "3. task");

            // ======================================================================
            // 4. Task
            // Határozzuk meg intézetenként a dolgozók darabszámát!

            var f4 = people
                .GroupBy(p => p.Dept)
                .Select(g => new { Dept = g.Key, Cnt = g.Count() });

            var f4_alt = from p in people
                         group p by p.Dept into g
                         select new { Dept = g.Key, Cnt = g.Count() };

            ToConsole(f4_alt, "4. task");

            // ======================================================================
            // 5. Task
            // Határozzuk meg a legnagyobb intézetet!
            //
            // OrderByDescending is használható az OrderBy + Reverse helyett
            // Mivel csökkenő sorrendbe rendeztünk, ezért az első elem (FirstOrDefault) éppen a legnagyobb lesz.

            var f5 = f4.OrderBy(rec => rec.Cnt).Reverse().FirstOrDefault();
            Console.WriteLine("5. task : " + f5.Dept);
            Console.ReadLine();

            var f5_alt = from p in f4
                         let maxCount = f4.Max(r => r.Cnt)
                         where p.Cnt == maxCount
                         select p.Dept;

            ToConsole(f5_alt, "5. task");

            // ======================================================================
            // 6. Task
            // Listázzuk a legnagyobb intézet dolgozóit!

            var f6 = people.Where(p => p.Dept == f5.Dept).Select(p => p.Name);

            var f6_alt = from p in people
                     where p.Dept == f5.Dept
                     select p.Name;

            ToConsole(f6_alt, "6. task");

            // ======================================================================
            // 7. Task
            // Listázzuk a harmadik legnagyobb intézet dolgozóit szobaszám szerint csökkenő sorrendben!
            //
            // // ElementAtOrDefault: adott indexű elemét adja vissza a sorozatnak (azaz itt a 3.-at)

            var third = f4.OrderByDescending(p => p.Cnt).ElementAtOrDefault(2);
            Console.WriteLine("Harmadik legnagyobb részleg: " + third);

            var f7 = people
                .Where(p => p.Dept == third.Dept)
                .OrderByDescending(p => p.Room)
                .Select(p => new { p.Name, p.Room });

            var f7_alt = from p in people
                         where p.Dept == third.Dept
                         orderby p.Room descending
                         select new { p.Name, p.Room };

            ToConsole(f7_alt, "7. task");
        }
    } 
}
