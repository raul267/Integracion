using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClasesApi
{
    public class Ramos
    {
        string iDCursoMoodle;
        string nombre;

        public Ramos()
        {

        }

        public Ramos(string iDCursoMoodle, string nombre)
        {
            this.iDCursoMoodle = iDCursoMoodle;
            this.nombre = nombre;
        }

        public string IDCursoMoodle { get => iDCursoMoodle; set => iDCursoMoodle = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }


}