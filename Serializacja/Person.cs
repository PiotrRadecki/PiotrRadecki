using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serializacja
{
    [XmlRoot(ElementName = "Osoby")]
    public class Person
    {
        [XmlAttribute("FirstName")]
        public string Imie { get; set; }
        [XmlAttribute("LastName")]
        public string Nazwisko { get; set; }

        public Person()
        {

        }
        public Person(string Imie, string Nazwisko)
        {
            this.Imie = Imie;
            this.Nazwisko = Nazwisko;
        }

        public Person(Person osoba)
        {
            this.Imie = osoba.Imie;
            this.Nazwisko = osoba.Nazwisko;
        }
    }
}
