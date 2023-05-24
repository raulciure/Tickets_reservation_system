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
        private readonly FlightRepository flightRepository;

        public void Add(Flight flight)
        {
            flightRepository.Add(flight);
        }

        public void Update(Flight currentFlight, Flight updateFlight)
        {
            flightRepository.Update(currentFlight, updateFlight);
        }

        public void Remove(Flight flight)
        {
            flightRepository.Delete(flight);
        }

        public List<Flight> GetFlights()
        {
            return flightRepository.GetAll();
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
                Flight.Days parsedDay;
                if (Enum.TryParse(item.ToString(), out parsedDay))
                {
                    operatingDays.Add(parsedDay);
                }
            }

            return operatingDays;
        }
    }
}
