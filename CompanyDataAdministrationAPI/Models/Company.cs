using System;
using System.Collections.Generic;

namespace CompanyDataAdministrationAPI.Models
{
    public partial class Company
    {
        public int CompanyId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string CompanyName { get; set; }
        public string CompanyNr { get; set; }
        public int Phone { get; set; }
        public int? Fax { get; set; }
        public string EmailAddress { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
