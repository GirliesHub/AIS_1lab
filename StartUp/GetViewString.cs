using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start
{
    public class GetViewString
    {
        public static string ViewString()
        {
            var projectRootPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;

            var jsonFilePath = Path.Combine(projectRootPath, "DataAccessLayer");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(jsonFilePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            return configuration["View"];
        }
    }
}