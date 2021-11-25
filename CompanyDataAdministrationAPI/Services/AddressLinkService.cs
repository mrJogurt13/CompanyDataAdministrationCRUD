using CompanyDataAdministrationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyDataAdministrationAPI.Services
{
    public class AddressLinkService
    {
        private readonly CompanyDataAdministrationContext _companyContext;

        public AddressLinkService(CompanyDataAdministrationContext _companyContext)
        {
            this._companyContext = _companyContext;
        }

        internal AddressLink GetByCompanyId(int Id)
        {
            return _companyContext.AddressLinks.FirstOrDefault(a => a.CompanyId == Id);
        }

        internal void Add(AddressLink adressLink)
        {
            _companyContext.AddressLinks.Add(adressLink);
        }

        internal AddressLink GetById(int Id)
        {
            return _companyContext.AddressLinks.FirstOrDefault(a => a.AddressLinkId == Id);
        }

        internal bool Validate(AddressLink addressLink)
        {
            if (!addressLink.CompanyId.Equals(null) &&
                !addressLink.AddressId.Equals(null) &&
                addressLink.AddressTyp.Length <= 4)
                return true;
            return false;
        }
    }
}
