using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e1_Validator
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public Address Address { get; set; }
    }

    public class Address
    {
        public string Street { get; set; }
        public string ZIP { get; set; }
    }
}
