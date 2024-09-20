using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets_reservation_system.Models.Repositories.Interfaces
{
    internal interface IPlaneRepository : IRepository<Plane>
    {
        Plane GetPlane(string tailNumber);
        void DeletePlanesOfCompany(string companyName);
        List<Plane> GetPlanesByCompany(string companyName);
        List<Plane> GetAll();
    }
}
