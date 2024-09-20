using Microsoft.Data.Sqlite;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tickets_reservation_system.Models.Repositories.Utilities;


namespace Tickets_reservation_system.Models.Repositories
{
    internal class TicketRepository : Interfaces.ITicketRepository
    {
        private string jsonPath = ProjectPath.GetProjectPath() + "/Database/tickets_data.json";

        public void SerializeJson(List<Ticket> list, string path)
        {
            string jsonText = JsonConvert.SerializeObject(list);
            File.WriteAllText(path, jsonText);
        }

        public List<Ticket> DeserializeJson(string path)
        {
            string jsonText = File.ReadAllText(path);

            try
            {
                List<Ticket> list = JsonConvert.DeserializeObject<List<Ticket>>(jsonText);
                return list;
            }
            catch
            {
                MessageBox.Show("Json deserialization problem!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        public void Add(Ticket obj)
        {
            List<Ticket> jsonContent = DeserializeJson(jsonPath);
            jsonContent.Add(obj);
            SerializeJson(jsonContent, jsonPath);
        }

        public bool Update(Ticket currentObj, Ticket updateObj)
        {
            List<Ticket> jsonContent = DeserializeJson(jsonPath);
            int index = jsonContent.IndexOf(currentObj);
            if (index >= 0)
            {
                jsonContent[index] = updateObj;
                SerializeJson(jsonContent, jsonPath);
                return true;
            }
            return false;
        }

        public bool Delete(Ticket obj)
        {
            List<Ticket> jsonContent = DeserializeJson(jsonPath);
            bool status = jsonContent.Remove(obj);
            if (status == true)
            {
                SerializeJson(jsonContent, jsonPath);
                return true;
            }
            return false;
        }

        public Ticket GetTicket(int ticketId)
        {
            List<Ticket> jsonContent = DeserializeJson(jsonPath);
            return jsonContent.Find(x =>  x.TicketId.Equals(ticketId));
        }

        public void DeleteTicketByPassengerId(string id)
        {
            List<Ticket> jsonContent = DeserializeJson(jsonPath);
            jsonContent.RemoveAll(x => x.Passenger.Id.Equals(id));
            SerializeJson(jsonContent, jsonPath);
        }

        public List<Ticket> GetAll()
        {
            List<Ticket> jsonContent = DeserializeJson(jsonPath);
            return jsonContent;
        }
    }
}
