using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Tickets_reservation_system.Models.Repositories
{
    internal class PlaneRepository : IPlaneRepository
    {
        private string jsonPath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "Database/planes_data.json");

        public void SerializeJson(List<Plane> list, string path)
        {
            string jsonText = JsonSerializer.Serialize(list);
            File.WriteAllText(path, jsonText);
        }

        public List<Plane> DeserializeJson(string path)
        {
            string jsonText = File.ReadAllText(path);
            Type type = typeof(Plane);

            List<Plane> list = (List<Plane>)JsonSerializer.Deserialize(jsonText, type);
            return list;
        }

        public void Add(Plane obj)
        {
            List<Plane> jsonContent = DeserializeJson(jsonPath);
            jsonContent.Add(obj);
            SerializeJson(jsonContent, jsonPath);
        }

        public void Update(Plane currentObj, Plane updateObj)
        {
            List<Plane> jsonContent = DeserializeJson(jsonPath);
            var index = jsonContent.IndexOf(updateObj);
            jsonContent[index] = updateObj;
            SerializeJson(jsonContent, jsonPath);
        }

        public void Delete(Plane obj)
        {
            List<Plane> jsonContent = DeserializeJson(jsonPath);
            jsonContent.Remove(obj);
            SerializeJson(jsonContent, jsonPath);
        }

        public List<Plane> GetAll()
        {
            List<Plane> jsonContent = DeserializeJson(jsonPath);
            return jsonContent;
        }

        public Plane GetPlane(string tailNumber)
        {
            List<Plane> jsonContent = DeserializeJson(jsonPath);
            return jsonContent.Find(x => x.TailNumber.Equals(tailNumber));
        }

        public List<Plane> GetPlanesByCompany(string companyName)
        {
            List<Plane> jsonContent = DeserializeJson(jsonPath);
            return jsonContent.FindAll(x => x.CompanyName.Equals(companyName));
        }

        public void DeletePlanesOfCompany(string companyName)
        {
            List<Plane> jsonContent = DeserializeJson(jsonPath);
            jsonContent.RemoveAll(x => x.CompanyName.Equals(companyName));
            SerializeJson(jsonContent, jsonPath);
        }
    }
}
