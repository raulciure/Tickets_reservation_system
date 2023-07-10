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
    internal class PassangerRepository : IPassangerRepository
    {
        private string jsonPath = "Database/passangers_data.json";

        public void SerializeJson(List<Passanger> list, string path)
        {
            string jsonText = JsonConvert.SerializeObject(list);
            File.WriteAllText(path, jsonText);
        }

        public List<Passanger> DeserializeJson(string path)
        {
            string jsonText = File.ReadAllText(path);
            List<Passanger> list = JsonConvert.DeserializeObject<List<Passanger>>(jsonText);
            return list;
        }

        public void Add(Passanger obj)
        {
            List<Passanger> jsonContent = DeserializeJson(jsonPath);
            jsonContent.Add(obj);
            SerializeJson(jsonContent, jsonPath);
        }

        public void Update(Passanger currentObj, Passanger updateObj)
        {
            List<Passanger> jsonContent = DeserializeJson(jsonPath);
            var index = jsonContent.IndexOf(updateObj);
            jsonContent[index] = updateObj;
            SerializeJson(jsonContent, jsonPath);
        }

        public void Delete(Passanger obj)
        {
            List<Passanger> jsonContent = DeserializeJson(jsonPath);
            jsonContent.Remove(obj);
            SerializeJson(jsonContent, jsonPath);
        }

        public Passanger GetPassanger(string idSerialNumber)
        {
            List<Passanger> jsonContent = DeserializeJson(jsonPath);
            return jsonContent.Find(x => x.IdSerialNumber.Equals(idSerialNumber));
        }
    }
}
