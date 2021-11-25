using System;
using System.Collections.Generic;

namespace CompanyDataAdministrationAPI.Models
{
    public partial class AddressLink
    {
        public int AddressLinkId { get; set; }
        public int CompanyId { get; set; }
        public int AddressId { get; set; }
        public string AddressTyp { get; set; }
    }
}
