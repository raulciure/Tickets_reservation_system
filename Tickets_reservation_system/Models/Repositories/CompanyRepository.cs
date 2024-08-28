using Microsoft.Data.Sqlite;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Tickets_reservation_system.Models.Repositories.Utilities;


namespace Tickets_reservation_system.Models.Repositories
{
    internal class CompanyRepository : Interfaces.ICompanyRepository
    {
        private string jsonPath = ProjectPath.GetProjectPath() + "/Database/companies_data.json";

        public void SerializeJson(List<Company> list, string path)
        {
            string jsonText = JsonConvert.SerializeObject(list);
            File.WriteAllText(path, jsonText);
        }

        public List<Company> DeserializeJson(string path)
        {
            string jsonText = File.ReadAllText(path);

            try
            {
                List<Company> list = JsonConvert.DeserializeObject<List<Company>>(jsonText);
                return list;
            }
            catch
            {
                MessageBox.Show("Json deserialization problem!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
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
