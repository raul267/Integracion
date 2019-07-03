using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using dalc;
namespace Umas.Negocio
{
   public class Carrera
    {
        public bool Crear(Entidades.Carrera oCar)
        {
            dalc.carrera dCarr = new dalc.carrera();
            dCarr.codcarr = oCar.Codcarr;
            dCarr.nombre = oCar.nombre;

            Conn.Connection.carrera.Add(dCarr);
            Conn.Connection.SaveChanges();
            return true;

        }
    }
}
