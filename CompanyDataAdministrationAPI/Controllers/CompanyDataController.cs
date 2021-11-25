using CompanyDataAdministrationAPI.Models;
using CompanyDataAdministrationAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyDataAdministrationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyDataController : ControllerBase
    {
        private readonly CompanyService _companyService;
        private readonly CompanyFullService _companyFullService;

        private readonly ILogger<CompanyDataController> _logger;

        public CompanyDataController(ILogger<CompanyDataController> logger, CompanyService companyService, CompanyFullService companyFullService)
        {
            _logger = logger;
            _companyService = companyService;
            _companyFullService = companyFullService;
        }

        [HttpGet]
        public IActionResult GetOverview()
        {
            return Ok(_companyService.GetAllExistingCompanies());
        }

        [HttpGet("{Id}")]
        public IActionResult GetCompanyData(int Id)
        {
            return Ok(_companyFullService.Get(Id));
        }

        [HttpPost]
        public IActionResult CreateNewCompany(List<CompanyFull> companyList)
        {
            foreach(CompanyFull company in companyList) /* If it's stupid and it works it ain't stupid. Problem is it ain't workin so it's just stupid*/
            {
                _companyFullService.CreateCompanyEntry(company);
            }
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateCompany(List<CompanyFull> companyList)
        {
            foreach (CompanyFull company in companyList)
            {
                _companyFullService.UpdateCompany(company);
            }
            return Ok();
        }

        [HttpPut("{Id}")]
        public IActionResult DeleteCompany(int Id)
        {
            _companyService.Delete(Id);
            return Ok();
        }
    }
}
