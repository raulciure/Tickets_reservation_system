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
    internal class CompanyRepositoryTest
    {
        [Fact]
        void CompanyAddTest()
        {
            Company company = new Company
            {
                Name = "TestName",
                CountryOfRegistration = "TestCOR";
                
            };
            CompanyRepository companyRepository = new CompanyRepository();

        }
    }
}
