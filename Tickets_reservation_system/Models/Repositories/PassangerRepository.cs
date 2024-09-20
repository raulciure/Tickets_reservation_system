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
    internal class PassengerRepository : Interfaces.IPassengerRepository
    {
        private string jsonPath = ProjectPath.GetProjectPath() + "/Database/passengers_data.json";

        public void SerializeJson(List<Passanger> list, string path)
        {
            string jsonText = JsonConvert.SerializeObject(list);
            File.WriteAllText(path, jsonText);
        }

        public List<Passanger> DeserializeJson(string path)
        {
            string jsonText = File.ReadAllText(path);

            try
            {
                List<Passanger> list = JsonConvert.DeserializeObject<List<Passanger>>(jsonText);
                return list;
            }
            catch
            {
                MessageBox.Show("Json deserialization problem!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        public void Add(Passanger obj)
        {
            List<Passanger> jsonContent = DeserializeJson(jsonPath);
            jsonContent.Add(obj);
            SerializeJson(jsonContent, jsonPath);
        }

        public bool Update(Passanger currentObj, Passanger updateObj)
        {
            List<Passanger> jsonContent = DeserializeJson(jsonPath);
            int index = jsonContent.IndexOf(updateObj);
            if (index >= 0)
            {
                jsonContent[index] = updateObj;
                SerializeJson(jsonContent, jsonPath);
                return true;
            }
            return false;
        }

        public bool Delete(Passanger obj)
        {
            List<Passanger> jsonContent = DeserializeJson(jsonPath);
            bool status = jsonContent.Remove(obj);
            if (status == true)
            {
                SerializeJson(jsonContent, jsonPath);
                return true;
            }
            return false;
        }

        public Passanger GetPassenger(string id)
        {
            List<Passanger> jsonContent = DeserializeJson(jsonPath);
            return jsonContent.Find(x => x.Id.Equals(id));
        }
    }
}
