using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClasesApi
{
    public class NotasF
    {
        string iDCursoMoodle;
        string rutEstudiante;
        string notaFinal;
        string ano;
        string periodo;

        public NotasF()
        {

        }

        public NotasF(string iDCursoMoodle, string rutEstudiante, string notaFinal, string ano, string periodo)
        {
            this.iDCursoMoodle = iDCursoMoodle;
            this.rutEstudiante = rutEstudiante;
            this.notaFinal = notaFinal;
            this.ano = ano;
            this.periodo = periodo;
        }

        public string IDCursoMoodle { get => iDCursoMoodle; set => iDCursoMoodle = value; }
        public string RutEstudiante { get => rutEstudiante; set => rutEstudiante = value; }
        public string NotaFinal { get => notaFinal; set => notaFinal = value; }
        public string Ano { get => ano; set => ano = value; }
        public string Periodo { get => periodo; set => periodo = value; }
    }
}