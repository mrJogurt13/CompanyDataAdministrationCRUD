using CompanyDataAdministrationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyDataAdministrationAPI.Services
{
    public class CompanyService
    {
        private readonly CompanyDataAdministrationContext _companyContext;

        public CompanyService(CompanyDataAdministrationContext _companyContext)
        {
            this._companyContext = _companyContext;
        }

        internal Company GetById(int Id)
        {
            return _companyContext.Companies.FirstOrDefault(c => c.CompanyId == Id);
        }

        internal List<Company> GetAllExistingCompanies()
        {
            return _companyContext.Companies
                .Where(c => c.IsDeleted == false || c.IsDeleted == null)
                .ToList<Company>();//*/
        }

        internal void Delete(int Id)
        {
            var entity = _companyContext.Companies.Where(c => c.CompanyId == Id).FirstOrDefault();
            if (entity != null)
            {
                entity.IsDeleted = true;

                _companyContext.SaveChanges();
            }
        }

        internal void Add(Company company)
        {
            _companyContext.Companies.Add(company);
        }

        internal bool Validate(Company company)
        {
            if (company.Firstname.Length <= 60 &&
                company.Lastname.Length <= 255 &&
                company.CompanyName.Length <= 255 &&
                !company.Phone.Equals(null) &&
                company.EmailAddress.Length <= 255)
                return true;
            return false;
        }

        internal string GenerateCompanyNr()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] stringChars = new char[8];
            
            for(int i=0; i<stringChars.Length; i++)
            {
                stringChars[i] = chars[new Random().Next(chars.Length)];
            }

            return new string(stringChars);
        }
    }
}
