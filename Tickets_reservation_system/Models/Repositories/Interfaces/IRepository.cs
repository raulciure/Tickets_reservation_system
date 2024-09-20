using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets_reservation_system.Models.Repositories.Interfaces
{
    internal interface IRepository<T>
    {
        void SerializeJson(List<T> list, string path);
        List<T> DeserializeJson(string path);
        void Add(T obj);
        bool Update(T currentObj, T updateObj);
        bool Delete(T obj);
    }
}
