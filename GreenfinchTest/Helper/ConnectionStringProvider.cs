using AbstractedORMLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreenfinchTest.Helper
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        public string GetConnectionString
        {
            get
            {
                return "Data Source=ERTANCALISKAN\\ERTANCALISKAN;Initial Catalog=GREENFINCHTUBE;User ID=sa;Password=sapass;Application Name=GREENFINCHTUBE";
            }
        }

        public string GetTenantId()
        {
            return "";
        }
    }
}