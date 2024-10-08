﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets_reservation_system.Models
{
    [Serializable]
    internal class Company
    {
        private string name;
        private List<string> fleet;
        private string countryOfRegistration;

        public Company(string name, List<string> fleet, string countryOfRegistration)
        {
            this.name = name;
            this.fleet = fleet;
            this.countryOfRegistration = countryOfRegistration;
        }

        public Company() { }

        public string Name { get => this.name; set => this.name = value; }
        public List<string> Fleet { get => this.fleet; set => this.fleet = value; }
        public string CountryOfRegistration { get => this.countryOfRegistration; set => this.countryOfRegistration = value; }
    }
}
