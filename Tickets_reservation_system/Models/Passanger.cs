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
        private string id;

        public Passanger(string firstName, string lastName, string email,
            string phoneNumber, int age, string id)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.age = age;
            this.id = id;
        }

        public Passanger() { }

        public string FirstName { get => this.firstName; set => this.firstName = value; }
        public string LastName { get => this.lastName; set => this.lastName = value; }
        public string Email { get => this.email; set => this.email = value; }
        public string PhoneNumber { get => this.phoneNumber; set => this.phoneNumber = value; }
        public int Age { get => this.age; set => this.age = value; }
        public string Id { get => this.id; set => this.id = value; }
    }
}
