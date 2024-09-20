using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tickets_reservation_system.Models.Repositories;
using Xunit;

namespace Tickets_reservation_system.Testing
{
    public class CompanyLoginRepositoryTest
    {
        [Fact]
        public void CompanyUserReadTest()
        {
            CompanyRepository companyRepository = new CompanyRepository();

            var companyUsers = companyRepository.GetAll();

            //foreach(var user in companyUsers)
            //{
            //    MessageBox.Show(user.Name + " " + user.CountryOfRegistration);
            //}

            Assert.True(companyUsers.Any());
        }
    }
}
