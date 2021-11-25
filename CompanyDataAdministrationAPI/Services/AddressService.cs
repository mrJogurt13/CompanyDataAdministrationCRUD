using CompanyDataAdministrationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyDataAdministrationAPI.Services
{
    public class AddressService
    {
        private readonly CompanyDataAdministrationContext _companyContext;

        public AddressService(CompanyDataAdministrationContext _companyContext)
        {
            this._companyContext = _companyContext;
        }

        internal Address GetById(int Id)
        {
            return _companyContext.Addresses.FirstOrDefault(a => a.AddressId == Id);
        }

        internal void Add(Address address)
        {
            _companyContext.Addresses.Add(address);
        }

        internal bool Validate(Address address)
        {
            if(address.StrHnr.Length <= 255 &&
                address.ZipCode.Length <= 10 &&
                address.City.Length <= 100 &&
                address.Country.Length <= 150)
                return true;
            return false;
        }
    }
}
