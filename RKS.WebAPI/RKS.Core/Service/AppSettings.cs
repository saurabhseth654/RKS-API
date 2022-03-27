using Microsoft.Extensions.Configuration;
using RKS.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RKS.Core.Service
{
   public class AppSettings: IAppSettings
    {
        private readonly IConfiguration _configuration;

        public AppSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetValue(string name)
        {
            return _configuration[name];

        }
    }
}
