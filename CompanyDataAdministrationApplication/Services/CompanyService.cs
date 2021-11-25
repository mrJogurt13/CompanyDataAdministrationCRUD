using CompanyDataAdministrationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CompanyDataAdministrationApplication.Services
{
    class CompanyService
    {
        private readonly HttpClient _client = new HttpClient();

        public CompanyService(HttpClient client)
        {
            _client = client;
        }

        internal List<Company> GetOverview()
        {
            List<Company> list = null;
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = _client.GetAsync("https://localhost:44319/CompanyData").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<Company>>(result);
            }
            return list;
        }

        internal void Delete(int Id)
        {
            _client.PutAsync("https://localhost:44319/CompanyData/" + Id, null);
        }
    }
}
