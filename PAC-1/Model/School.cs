using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PAC_1.Model
{
    class School
    {
        public string Name { get; set; } //pelna nazwa placowki
        public string ShortName { get; set; } //skrotowa nazwa
        public string ZipCode { get; set; }
        public string City { get; set; } //mozesz zrefaktorowac. Nie wiedzialam, jak zrobic ogolna nazwe
        public string Street { get; set; }
        public string Number { get; set; }
        public int? SecondNumber { get; set; }


        public School() { }
        public School(string name, string shortName, string zipCode, string city, string street, string number, int? secondNumber = null)
        {
            Name = name;
            ShortName = shortName;
            ZipCode = zipCode;
            City = city;
            Street = street;
            Number = number;
            SecondNumber = secondNumber;
        }
        public School(School s)
        {
            Name = s.Name;
            ShortName = s.ShortName;
            ZipCode = s.ZipCode;
            City = s.City;
            Street = s.Street;
            Number = s.Number;
            SecondNumber = s.SecondNumber;
        }

        public override string ToString()
        {
            return ShortName;
        }

    }

    
}