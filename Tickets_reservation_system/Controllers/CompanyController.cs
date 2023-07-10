using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets_reservation_system.Models;
using Tickets_reservation_system.Models.Repositories;

namespace Tickets_reservation_system.Controllers
{
    internal class CompanyController
    {
        private readonly CompanyRepository companyRepository = new CompanyRepository();

        public List<Company> GetCompanies()
        {
            return companyRepository.GetAll();
        }

        public Company GetCompanyByName(string name)
        {
            return companyRepository.GetCompany(name);
        }
    }
}
