using System;
using System.Collections.Generic;
using System.Text;

namespace TRS_DAL
{
    static class ConnectionStringBuilder
    {
        static private string _dataBase = "dbi361369";
        static private string _password = "Wachtwoord1";
        static private string _server = "studmysql01.fhict.local";
        static private string _uid = "dbi361369";

        public static string CreateConString()
        {
            return $"SERVER= {_server}; DATABASE= {_dataBase}; UID= {_uid}; PASSWORD= {_password}; SslMode=none";
        }
    }
}
