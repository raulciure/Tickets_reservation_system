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
    internal class PassangerRepository : Interfaces.IPassangerRepository
    {
        private string jsonPath = ProjectPath.GetProjectPath() + "/Database/passangers_data.json";

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

        public Passanger GetPassanger(string id)
        {
            List<Passanger> jsonContent = DeserializeJson(jsonPath);
            return jsonContent.Find(x => x.Id.Equals(id));
        }
    }
}
