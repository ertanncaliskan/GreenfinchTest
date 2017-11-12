using AbstractedORMLibrary.ORMCatalog;
using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractedORMLibrary
{
    public static class DataBase
    {
        public static IConnectionStringProvider ConnectionStringProvider;
        public static DataAccessProvider DataProvider(EDataAccessType dataAccessType)
        {
            switch (dataAccessType)
            {
                case EDataAccessType.NPoco:
                    return new NPocoDataAccessProvider(new Database(ConnectionStringProvider.GetConnectionString, DatabaseType.SqlServer2012));
            }
            return null;
        }
    }
}
