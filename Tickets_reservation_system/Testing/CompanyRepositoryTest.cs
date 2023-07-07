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
                Fleet = new List<Plane>()
                {
                    new Plane()
                    {
                        CompanyName = "TestName",
                        Name = "Boieng 737-800NG",
                        TailNumber = "N7862S",
                        SeatsNr = 136,
                        SeatingConfiguration = {FirstSeats = 10, BussinessSeats = 10, EconomySeats = 116},
                        Range = 6000
                    },
                    new Plane()
                    {
                        CompanyName = "TestName",
                        Name = "Airbus a320",
                        TailNumber = "N2113R",
                        SeatsNr = 128,
                        SeatingConfiguration = {FirstSeats = 0, BussinessSeats = 0, EconomySeats = 128},
                        Range = 6200
                    }
                }
            };

            companyRepository.Add(insertCompany);
            Company readCompany = companyRepository.GetCompany("TestName");

            Assert.Equal(insertCompany, readCompany);
        }
    }
}
