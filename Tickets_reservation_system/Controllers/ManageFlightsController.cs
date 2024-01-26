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

        public List<Days> GetOperatingDays(ListBox.SelectedObjectCollection selectedItems)
        {
            List<Days> operatingDays = new List<Days>();

            foreach(object item in selectedItems)
            {
                if (Enum.TryParse(item.ToString(), out Days parsedDay))
                {
                    operatingDays.Add(parsedDay);
                }
            }

            return operatingDays;
        }
    }
}
