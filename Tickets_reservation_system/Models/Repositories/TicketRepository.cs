using Microsoft.Data.Sqlite;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets_reservation_system.Models.Repositories
{
    internal class TicketRepository : ITicketRepository
    {
        private string jsonPath = "Database/tickets_data.json";

        public void SerializeJson(List<Ticket> list, string path)
        {
            string jsonText = JsonConvert.SerializeObject(list);
            File.WriteAllText(path, jsonText);
        }

        public List<Ticket> DeserializeJson(string path)
        {
            string jsonText = File.ReadAllText(path);
            List<Ticket> list = JsonConvert.DeserializeObject<List<Ticket>>(jsonText);
            return list;
        }

        public void Add(Ticket obj)
        {
            List<Ticket> jsonContent = DeserializeJson(jsonPath);
            jsonContent.Add(obj);
            SerializeJson(jsonContent, jsonPath);
        }

        public void Update(Ticket currentObj, Ticket updateObj)
        {
            List<Ticket> jsonContent = DeserializeJson(jsonPath);
            var index = jsonContent.IndexOf(currentObj);
            jsonContent[index] = updateObj;
            SerializeJson(jsonContent, jsonPath);
        }

        public void Delete(Ticket obj)
        {
            List<Ticket> jsonContent = DeserializeJson(jsonPath);
            jsonContent.Remove(obj);
            SerializeJson(jsonContent, jsonPath);
        }

        public Ticket GetTicket(int ticketId)
        {
            List<Ticket> jsonContent = DeserializeJson(jsonPath);
            return jsonContent.Find(x =>  x.TicketId.Equals(ticketId));
        }

        public void DeleteTicketByPassangerIdSerialNumber(string idSerialNumber)
        {
            List<Ticket> jsonContent = DeserializeJson(jsonPath);
            jsonContent.RemoveAll(x => x.Passanger.IdSerialNumber.Equals(idSerialNumber));
            SerializeJson(jsonContent, jsonPath);
        }
    }
}
