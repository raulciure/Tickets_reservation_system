using Microsoft.Data.Sqlite;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tickets_reservation_system.Models.Repositories.Utilitaries;


namespace Tickets_reservation_system.Models.Repositories
{
    internal class PlaneRepository : Interfaces.IPlaneRepository
    {
        private string jsonPath = ProjectPath.GetProjectPath() + "/Database/planes_data.json";

        public void SerializeJson(List<Plane> list, string path)
        {
            string jsonText = JsonConvert.SerializeObject(list);
            File.WriteAllText(path, jsonText);
        }

        public List<Plane> DeserializeJson(string path)
        {
            string jsonText = File.ReadAllText(path);

            try
            {
                List<Plane> list = JsonConvert.DeserializeObject<List<Plane>>(jsonText);
                return list;
            }
            catch
            {
                MessageBox.Show("Json deserialization problem!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
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
