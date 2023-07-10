using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Tickets_reservation_system.Models.Repositories
{
    internal class CompanyLoginRepository : ICompanyLoginRepository
    {
        private string jsonPath = "Database/companies_users_data.json";

        public void SerializeJson(List<CompanyUser> list, string path)
        {
            string jsonText = JsonConvert.SerializeObject(list);
            File.WriteAllText(path, jsonText);
        }

        public List<CompanyUser> DeserializeJson(string path)
        {
            string jsonText = File.ReadAllText(path);
            List<CompanyUser> list = JsonConvert.DeserializeObject<List<CompanyUser>>(jsonText);
            return list;
        }

        public void Add(CompanyUser obj)
        {
            List<CompanyUser> jsonContent = DeserializeJson(jsonPath);
            jsonContent.Add(obj);
            SerializeJson(jsonContent, jsonPath);
        }

        public void Update(CompanyUser currentObj, CompanyUser updateObj)
        {
            List<CompanyUser> jsonContent = DeserializeJson(jsonPath);
            var index = jsonContent.IndexOf(updateObj);
            jsonContent[index] = updateObj;
            SerializeJson(jsonContent, jsonPath);
        }

        public void Delete(CompanyUser obj)
        {
            List<CompanyUser> jsonContent = DeserializeJson(jsonPath);
            jsonContent.Remove(obj);
            SerializeJson(jsonContent, jsonPath);
        }

        public CompanyUser GetCompanyUser(string username)
        {
            List<CompanyUser> jsonContent = DeserializeJson(jsonPath);
            return jsonContent.Find(x => x.Username.Equals(username));
        }

        public List<CompanyUser> GetAll()
        {
            List<CompanyUser> jsonContent = DeserializeJson(jsonPath);
            return jsonContent;
        }
    }
}
