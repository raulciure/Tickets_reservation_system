using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets_reservation_system.Models;
using Tickets_reservation_system.Models.Repositories;
using Xunit;
using Xunit.Sdk;

namespace Tickets_reservation_system.Testing
{
    public class CompanyRepositoryTest
    {
        [Fact]
        public void CompanyAddTest()
        {
            CompanyRepository companyRepository = new CompanyRepository();

            Company insertCompany = new Company
            {
                Name = "TestName",
                CountryOfRegistration = "TestCOR",
                Fleet = new List<string>() { "N7862S", "N2113R" }
            };

            companyRepository.Add(insertCompany);
            Company readCompany = companyRepository.GetCompany("TestName");

            Assert.Equal(insertCompany, readCompany);
        }
    }
}
