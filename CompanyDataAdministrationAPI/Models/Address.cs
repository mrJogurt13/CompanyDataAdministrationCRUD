using System;
using System.Collections.Generic;

namespace CompanyDataAdministrationAPI.Models
{
    public partial class Address
    {
        public int AddressId { get; set; }
        public string StrHnr { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
