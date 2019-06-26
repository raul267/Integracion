using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nota3
{
    public class ramo
    {
        int idCursoMoodle;
        string nombre;

        public ramo() { }

        public ramo(int idCursoMoodle, string nombre)
        {
            this.idCursoMoodle = idCursoMoodle;
            this.nombre = nombre;
        }

        public int IDCursoMoodle { get => idCursoMoodle; set =>idCursoMoodle = value; }
        public string Nombre { get => nombre; set => nombre = value; }


    }


}