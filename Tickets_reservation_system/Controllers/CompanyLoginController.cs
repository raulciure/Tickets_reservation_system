﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets_reservation_system.Models.Repositories;

namespace Tickets_reservation_system.Controllers
{
    internal class CompanyLoginController
    {
        private CompanyLoginRepository companyLoginRepository = new CompanyLoginRepository();

        //List<CompanyUser> companyUsers = new List<CompanyUser>
        //{
        //    new CompanyUser { User = "user1", Password = "abcd"},
        //    new CompanyUser { User = "user2", Password = "efgh"}
        //};

        public bool LoginValidation(string username, string password)
        {
            if(companyLoginRepository.GetAll().Find(x => x.Username.Equals(username) && x.Password.Equals(password)) != null) return true;
            return false;
        }
    }
}
