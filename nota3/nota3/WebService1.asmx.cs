using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;

namespace nota3
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public XmlDocument Carreras()
        {
            XmlUmas objxml = new XmlUmas();
            return objxml.xmlCarreras();
        }

        [WebMethod]
        public XmlDocument MallaCarrera(string codcarr)
        {
            XmlUmas objxml = new XmlUmas();
            return objxml.xmlMallaCarrera(codcarr);
        }
    }
}
