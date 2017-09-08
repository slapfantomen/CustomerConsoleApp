using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerConsoleApp
{
    class Address
    {
        public string Street { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public Address()
        {

        }

        public Address(string street, string zipcode, string city, string country)
        {
            Street = street;
            Zipcode = zipcode;
            City = city;
            Country = country;
        }
    }
}
