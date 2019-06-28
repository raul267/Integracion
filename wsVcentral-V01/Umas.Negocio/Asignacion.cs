using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Umas.DALC;
namespace Umas.Negocio
{
    public class Asignacion
    {
        public bool Crear(Entidades.Asignacion oAs)
        {
            DALC.asignacion dAs = new DALC.asignacion();
            dAs.id_carrera = oAs.Id_carrera;
            dAs.id_ramo = oAs.Id_ramo;
            dAs.id_curso_moodle = oAs.Id_curso_modle;

            Conn.Connection.asignacion.Add(dAs);
            Conn.Connection.SaveChanges();

            return true;
        }

    }
}
