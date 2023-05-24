using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets_reservation_system.Models;
using Tickets_reservation_system.Models.Repositories;

namespace Tickets_reservation_system.Controllers
{
    internal class PlaneController
    {
        private readonly PlaneRepository planeRepository;

        public List<Plane> GetPlanesByCompany(Company company)
        {
            return planeRepository.GetPlanesByCompany(company.Name);
        }

        public Plane GetPlaneByTailNumber(string tailNumber)
        {
            return planeRepository.GetPlane(tailNumber);
        }
    }
}
