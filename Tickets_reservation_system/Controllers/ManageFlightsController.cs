using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tickets_reservation_system.Models;
using Tickets_reservation_system.Models.Repositories;

namespace Tickets_reservation_system.Controllers
{
    internal class ManageFlightsController
    {
        private readonly FlightRepository flightRepository = new FlightRepository();

        public void Add(Flight flight)
        {
            flightRepository.Add(flight);
        }

        public bool Update(Flight currentFlight, Flight updateFlight)
        {
            return flightRepository.Update(currentFlight, updateFlight);
        }

        public bool Remove(Flight flight)
        {
            return flightRepository.Delete(flight);
        }

        public List<Flight> GetFlights()
        {
            return flightRepository.GetAll();
        }

        public List<Flight> GetFlights(string companyName)
        {
            return flightRepository.GetFlightsOfCompany(companyName);
        }

        public Flight GetFlight(string flightNumber)
        {
            return flightRepository.GetFlight(flightNumber);
        }

        public TimeSpan GetFlightTime(DateTime departureTime, DateTime arrivalTime)
        {
            return (arrivalTime - departureTime);
        }

        public List<Flight.Days> GetOperatingDays(ListBox.SelectedObjectCollection selectedItems)
        {
            List<Flight.Days> operatingDays = new List<Flight.Days>();

            foreach(object item in selectedItems)
            {
                if (Enum.TryParse(item.ToString(), out Flight.Days parsedDay))
                {
                    operatingDays.Add(parsedDay);
                }
            }

            return operatingDays;
        }
    }
}
