using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Database
{
    internal class Connection
    {
        public static String getConnectionString()
        {
            return "server=ivan.database.windows.net;database=PersonasDB;uid=Pruebas;pwd=@abcd1234;trustServerCertificate = true;";
        }
    }
}
