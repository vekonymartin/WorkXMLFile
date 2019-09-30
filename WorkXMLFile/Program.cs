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
            ToConsole(names, "0. feladat");

            // ======================================================================
            // 1. Task
            // Határozzuk meg az AII intézetben dolgozók darabszámát!

            string dept = "Alkalmazott Informatikai Intézet";
            var f1 = people.Where(p => p.Dept == dept).Count();

            // ======================================================================
            // 2. Task
            // Jelenítsük meg azokat, akiknek a harmadik emeleten van irodája!




            // ======================================================================
            // 3. Task
            // Kiknek van a leghosszabb vagy legrövidebb nevük?



            // ======================================================================
            // 4. Task
            // Határozzuk meg intézetenként a dolgozók darabszámát!





            // ======================================================================
            // 5. Task
            // Határozzuk meg a legnagyobb intézetet!




            // ======================================================================
            // 6. Task
            // Listázzuk a legnagyobb intézet dolgozóit!




            // ======================================================================
            // 7. Task
            // Listázzuk a harmadik legnagyobb intézet dolgozóit szobaszám szerint csökkenő sorrendben!

        }
    } 
}
