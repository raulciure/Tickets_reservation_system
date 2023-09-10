using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets_reservation_system.Models
{
    [Serializable]
    internal class CompanyUser
    {
        private string companyName;
        private string username;
        private string password;

        public CompanyUser(string companyName, string username, string password)
        {
            this.companyName = companyName;
            this.username = username;
            this.password = password;
        }

        public CompanyUser() { }

        public string CompanyName { get => this.companyName; set => this.companyName = value; }
        public string Username { get => this.username; set => this.username = value; }
        public string Password { get => this.password; set => this.password = value; }
    }
}
