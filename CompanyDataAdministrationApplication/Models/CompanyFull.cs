using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyDataAdministrationAPI.Models
{
    public class CompanyFull
    {
        public AddressLink AdressLink { get; set; }
        public Address Address { get; set; }
        public Company Company { get; set; }
    }
}
