using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets_reservation_system.Models
{
    internal class Plane
    {
        internal class Seating
        {
            public int EconomySeats { get; set; }
            public int BussinessSeats { get; set; }
            public int FirstSeats { get; set; }
        }

        private string name;
        private string tailNumber;
        private int seatsNr;
        private Seating seatingConfiguration;
        private int range;

        public Plane(string name, string tailNumber, int seatsNr, Seating seatingConfiguration, int range)
        {
            this.name = name;
            this.tailNumber = tailNumber;
            this.seatsNr = seatsNr;
            this.seatingConfiguration = seatingConfiguration;
            this.range = range;
        }

        public Plane() { }

        public string Name { get => this.name; set => this.name = value; }
        public string TailNumber { get => this.tailNumber; set => this.tailNumber = value; }
        public int SeatsNr { get => this.seatsNr; set => this.seatsNr = value; }
        public Seating SeatingConfiguration { get => this.seatingConfiguration; set => this.seatingConfiguration = value; }
        public int Range { get => this.range; set => this.range = value; }
    }
}
