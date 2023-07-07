using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Tickets_reservation_system.Models.Repositories
{
    internal class CompanyRepository : ICompanyRepository
    {
        private string jsonPath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "Database/companies_data.json");

        public void SerializeJson(List<Company> list, string path)
        {
            string jsonText = JsonSerializer.Serialize(list);
            File.WriteAllText(path, jsonText);
        }

        public List<Company> DeserializeJson(string path)
        {
            string jsonText = File.ReadAllText(path);
            Type type = typeof(Company);
            
            List<Company> list = (List<Company>)JsonSerializer.Deserialize(jsonText, type);
            return list;
        }

        public void Add(Company obj)
        {
            List<Company> jsonContent = DeserializeJson(jsonPath);
            jsonContent.Add(obj);
            SerializeJson(jsonContent, jsonPath);
        }

        public void Update(Company currentObj, Company updateObj)
        {
            List<Company> jsonContent = DeserializeJson(jsonPath);
            var index = jsonContent.IndexOf(updateObj);
            jsonContent[index] = updateObj;
            SerializeJson(jsonContent, jsonPath);
        }

        public void Delete(Company obj)
        {
            List<Company> jsonContent = DeserializeJson(jsonPath);
            jsonContent.Remove(obj);
            SerializeJson(jsonContent, jsonPath);
        }

        public Company GetCompany(string name)
        {
            List<Company> jsonContent = DeserializeJson(jsonPath);
            return jsonContent.Find(x => x.Name.Equals(name));
        }

        public List<Company> GetAll()
        {
            List<Company> jsonContent = DeserializeJson(jsonPath);
            return jsonContent;
        }
    }
}
