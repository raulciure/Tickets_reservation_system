using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets_reservation_system.Models.Repositories.Utilitaries
{
    public static class ProjectPath
    {
        public static string GetProjectPath()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            return projectDirectory;
        }
    }
}
