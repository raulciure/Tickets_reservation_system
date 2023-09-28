using Microsoft.Data.Sqlite;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tickets_reservation_system.Models.Repositories.Utilitaries;


namespace Tickets_reservation_system.Models.Repositories
{
    internal class FlightRepository : Interfaces.IFlightRepository
    {
        private string jsonPath = ProjectPath.GetProjectPath() + "/Database/flights_data.json";

        public void SerializeJson(List<Flight> list, string path)
        {
            string jsonText = JsonConvert.SerializeObject(list);
            File.WriteAllText(path, jsonText);
        }

        public List<Flight> DeserializeJson(string path)
        {
            string jsonText = File.ReadAllText(path);
            List<Flight> list = JsonConvert.DeserializeObject<List<Flight>>(jsonText);
            return list;
        }

        public void Add(Flight obj)
        {
            List<Flight> jsonContent = DeserializeJson(jsonPath);
            jsonContent.Add(obj);
            SerializeJson(jsonContent, jsonPath);
        }

        public void Update(Flight currentObj, Flight updateObj)
        {
            List<Flight> jsonContent = DeserializeJson(jsonPath);
            var index = jsonContent.IndexOf(currentObj);
            jsonContent[index] = updateObj;
            SerializeJson(jsonContent, jsonPath);
        }

        public void Delete(Flight obj)
        {
            List<Flight> jsonContent = DeserializeJson(jsonPath);
            jsonContent.Remove(obj);
            SerializeJson(jsonContent, jsonPath);
        }

        public Flight GetFlight(string flightNumber)
        {
            List<Flight> jsonContent = DeserializeJson(jsonPath);
            return jsonContent.Find(x => x.FlightNumber.Equals(flightNumber));
        }

        public List<Flight> GetFlightsOfCompany(string companyName)
        {
            List<Flight> jsonContent = DeserializeJson(jsonPath);
            return jsonContent.FindAll(x => x.Company.Name.Equals(companyName));
        }

        public List<Flight> GetAll()
        {
            List<Flight> jsonContent = DeserializeJson(jsonPath);
            return jsonContent;
        }
    }
}
