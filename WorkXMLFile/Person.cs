using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq; // it's need to work xml file

namespace WorkXMLFile
{
    class Person
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Dept { get; set; }
        public string Rank { get; set; }
        public string Phone { get; set; }
        public string Room { get; set; }

        public static List<Person> Load(string url)
        {
            XDocument xdoc = XDocument.Load(url);
            return xdoc.Descendants("person").Select(
                node => new Person()
                {
                    Name = node.Element("name")?.Value,
                    Email = node.Element("email")?.Value,
                    Dept = node.Element("dept")?.Value,
                    Rank = node.Element("rank")?.Value,
                    Phone = node.Element("phone")?.Value,
                    Room = node.Element("room")?.Value
                }).ToList();
        }
    }
}
