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
        private class CompanyUser
        {
            public string User { get; set; }
            public string Password { get; set; }
        }

        List<CompanyUser> companyUsers = new List<CompanyUser>
        {
            new CompanyUser { User = "user1", Password = "abcd"},
            new CompanyUser { User = "user2", Password = "efgh"}
        };

        public bool LoginValidation(string username, string password)
        {
            if(companyUsers.Any(x => x.User.Equals(username) && x.Password.Equals(password)))
                return true;
            return false;
        }
    }
}
