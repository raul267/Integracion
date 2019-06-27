using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace nota3
{
    public class JsonUmas
    {
        public string jsoncarreras()
        {
            ModeloUmas obj = new ModeloUmas();
            DataTable dt = obj.Carreras();
            Carreras c;
            List<Carreras> Carr = new List<Carreras>();
            foreach (DataRow fila in dt.Rows)
            {
                c = new Carreras();
                c.Codcarr = fila["codcarr"].ToString();
                c.Nombre = fila["nombre"].ToString();
                Carr.Add(c);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            string str = js.Serialize(Carr);
            return str;
        }

        public string jsonramos(string codcarr)
        {
            ModeloUmas obj = new ModeloUmas();
            DataTable dt = obj.Ramo(codcarr);
            Ramos r;
            List<Ramos> ramos = new List<Ramos>();
            foreach (DataRow fila in dt.Rows)
            {

                r = new Ramos();
                r.Codcarr = fila["codcarr"].ToString();
                r.Nomcarrera = fila["nomcarrera"].ToString();
                r.Codramo = fila["codramo"].ToString();
                r.Nomramo = fila["nomramo"].ToString();
                r.Nivel = int.Parse(fila["nivel"].ToString());
                ramos.Add(r);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            string str = js.Serialize(ramos);
            return str;
        }
    }

    public class Carreras
    {
        string codcarr;
        string nombre;
        public Carreras() { }
        public Carreras(string codcarr, string nombre)
        {
            this.codcarr = codcarr;
            this.nombre = nombre;
        }
        public string Codcarr { get => codcarr; set => codcarr = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    } //fin de la clase carreras

    public class Ramos
    {
        string codcarr;
        string nomcarrera;
        string codramo;
        string nomramo;
        int nivel;
        public Ramos() { }
        public Ramos(string codcarr, string nomcarrera, string codramo, string nomramo, int nivel)
        {
            this.codcarr = codcarr;
            this.nomcarrera = nomcarrera;
            this.codramo = codramo;
            this.nomramo = nomramo;
            this.nivel = nivel;
        }

        public string Codcarr { get => codcarr; set => codcarr = value; }
        public string Nomcarrera { get => nomcarrera; set => nomcarrera = value; }
        public string Codramo { get => codramo; set => codramo = value; }
        public string Nomramo { get => nomramo; set => nomramo = value; }
        public int Nivel { get => nivel; set => nivel = value; }
    }
}