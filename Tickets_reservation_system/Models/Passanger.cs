using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets_reservation_system.Models
{
    [Serializable]
    internal class Passanger
    {
        private string firstName;
        private string lastName;
        private string email;
        private string phoneNumber;
        private int age;
        private string idSerialNumber;

        public Passanger(string firstName, string lastName, string email,
            string phoneNumber, int age, string idSerialNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.age = age;
            this.idSerialNumber = idSerialNumber;
        }

        public Passanger() { }

        public string FirstName { get => this.firstName; set => this.firstName = value; }
        public string LastName { get => this.lastName; set => this.lastName = value; }
        public string Email { get => this.email; set => this.email = value; }
        public string PhoneNumber { get => this.phoneNumber; set => this.phoneNumber = value; }
        public int Age { get => this.age; set => this.age = value; }
        public string IdSerialNumber { get => this.idSerialNumber; set => this.idSerialNumber = value; }
    }
}
