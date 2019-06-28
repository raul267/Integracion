using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Xml.Serialization;
using wsVcentralV01;
using Umas.DALC;
using Umas.Negocio;

/// <summary>
/// Descripción breve de WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    public WebService()
    {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

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

    public bool Crear(string xmlAsignacion)
    {
        XmlSerializer xmlSerial = new XmlSerializer(typeof(Entidades.Asignacion));
        StringReader xmlRead = new StringReader(xmlAsignacion);
        Entidades.Asignacion oAs = (Entidades.Asignacion)xmlSerial.Deserialize(xmlRead);
        Umas.Negocio.Asignacion nAs = new Umas.Negocio.Asignacion();

        if (nAs.Crear(oAs))
        {
            return true;
        }
        else
        {
            return false;
        }

    }

}
