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
        private static db_vcentralEntities2 _connection;

        public static db_vcentralEntities2 Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new db_vcentralEntities2();
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
