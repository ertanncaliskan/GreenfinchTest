using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractedORMLibrary
{
    public interface IConnectionStringProvider
    {
        string GetConnectionString { get; }
        string GetTenantId();
    }
}
