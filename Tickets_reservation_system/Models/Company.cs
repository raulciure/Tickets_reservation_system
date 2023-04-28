using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets_reservation_system.Models
{
    internal class Company
    {
        private string name;
        private List<Plane> fleet;
        private string countryOfRegistration;

        public Company(string name, List<Plane> fleet, string countryOfRegistration)
        {
            this.name = name;
            this.fleet = fleet;
            this.countryOfRegistration = countryOfRegistration;
        }

        public string Name { get; set; }
        public List<Plane> Fleet { get; set; }
        public string CountryOfRegistration { get; set; }
    }
}
