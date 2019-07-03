using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umas.DALC;

namespace Umas.Negocio
{
    public class Conn
    {
        private static db_vcentralEntities _connection;

        public static db_vcentralEntities Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new db_vcentralEntities();
                }
                return _connection;
            }
            set
            {
                _connection = value;
            }
        }
    }
}
