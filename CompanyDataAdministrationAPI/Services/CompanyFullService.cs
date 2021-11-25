using CompanyDataAdministrationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyDataAdministrationAPI.Services
{
    public class CompanyFullService
    {
        private readonly CompanyDataAdministrationContext _companyContext;
        private readonly CompanyService _companyService;
        private readonly AddressLinkService _addressLinkService;
        private readonly AddressService _addressService;

        public CompanyFullService(CompanyDataAdministrationContext companyContext, CompanyService companyService, AddressService addressService, AddressLinkService addressLinkService)
        {
            _companyContext = companyContext;
            _companyService = companyService;
            _addressService = addressService;
            _addressLinkService = addressLinkService;
        }

        internal CompanyFull Get(int Id)
        {
            AddressLink al = _addressLinkService.GetByCompanyId(Id);
            Address a = _addressService.GetById(al.AddressId);
            Company c = _companyService.GetById(Id);
            CompanyFull company = new CompanyFull()
            {
                AdressLink = al,
                Address = a,
                Company = c
            };

            return company;
        }

        internal void CreateCompanyEntry(CompanyFull company)
        {
            var comp = company.Company;
            var addr = company.Address;
            var addL = company.AdressLink;

            if (_companyService.Validate(comp) && _addressService.Validate(addr) && _addressLinkService.Validate(addL))
            {
                comp.CompanyNr = _companyService.GenerateCompanyNr();
                _companyService.Add(comp);
                _addressService.Add(addr);

                _companyContext.SaveChanges();

                addL.CompanyId = comp.CompanyId;
                addL.AddressId = addr.AddressId;
                _addressLinkService.Add(company.AdressLink);

                _companyContext.SaveChanges();
            }
        }

        internal void UpdateCompany(CompanyFull company)
        {
            var comp = _companyService.GetById(company.Company.CompanyId);
            if (comp != null) comp = company.Company;

            var addr = _addressService.GetById(company.Address.AddressId);
            if (addr != null) addr = company.Address;

            var addL = _addressLinkService.GetById(company.AdressLink.AddressLinkId);
            if (addL != null) addL = company.AdressLink;

            _companyContext.SaveChanges();
        }
    }
}
