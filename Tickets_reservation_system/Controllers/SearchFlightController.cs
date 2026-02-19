using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tickets_reservation_system.Models;
using Tickets_reservation_system.Models.Repositories;

namespace Tickets_reservation_system.Controllers
{
	internal class SearchFlightController
	{
		private readonly FlightRepository flightRepository = new FlightRepository();

		public List<Flight> GetFlights(string departureAirport, string arrivalAirport, DateTime departureDate, int seats)
		{
			TicketController ticketController = new TicketController();
			PlaneController planeController = new PlaneController();

			List<Flight> allFlights = flightRepository.GetAll();

			List<Flight> matchedFlights = allFlights.FindAll(x => (x.DepartureAirport.Equals(departureAirport)) 
															 && (x.ArrivalAirport.Equals(arrivalAirport))
															 && (x.DepartureTime.Date.Equals(departureDate))
															 );

			// Remove flights without required seats
			for (int i = 0; i < matchedFlights.Count; i++)
			{
				int reservedTickets = ticketController.GetTicketCountByFlight(matchedFlights[i].FlightNumber);
				int totalSeats = planeController.GetPlaneSeatNumbers(matchedFlights[i].PlaneTailNumber);
				if (totalSeats - reservedTickets < seats)
					matchedFlights.RemoveAt(i);
			}

			return matchedFlights;
		}
	}
}
