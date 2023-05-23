using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets_reservation_system.Models.Repositories
{
    internal interface IRepository<T>
    {
        void Add(T obj);
        void Update(T currentObj, T updateObj);
        void Delete(T obj);
    }
}
