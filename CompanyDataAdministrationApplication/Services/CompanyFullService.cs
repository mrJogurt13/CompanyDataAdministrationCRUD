using CompanyDataAdministrationAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CompanyDataAdministrationApplication.Services
{
    class CompanyFullService
    {
        private readonly HttpClient _client = new HttpClient();

        public CompanyFullService(HttpClient client)
        {
            _client = client;
        }

        internal void Save(List<CompanyFull> companyFullList)
        {
            _client.PostAsync("https://localhost:44319/CompanyData", new StringContent(JsonConvert.SerializeObject(companyFullList)));
            //Fehlermeldung einfügen
        }

        internal void Update(List<CompanyFull> companyFullList)
        {
            _client.PutAsync("https://localhost:44319/CompanyData", new StringContent(JsonConvert.SerializeObject(companyFullList)));
            //Fehlermeldung
        }

        internal CompanyFull GetById(int Id)
        {
            CompanyFull cf = new CompanyFull();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = _client.GetAsync("https://localhost:44319/CompanyData/" + Id).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                cf = JsonConvert.DeserializeObject<CompanyFull>(result);
            }
            return cf;
        }
    }
}
