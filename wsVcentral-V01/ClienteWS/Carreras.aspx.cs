using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using wsUmas;
using ClasesApi;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LlenarCarreras();
        }

        //Cuando la página se cargue, colocar la dirección de cualquier api
        string url = "http://www.sieduc.cl/phpApi/mdl_course.php";
        string res = leerPaginaWeb(url);
        JavaScriptSerializer js = new JavaScriptSerializer();
        Cursos Lista = js.Deserialize<Cursos>(res);

        foreach (Ramos cursos in Lista.cursos)
        {
            Response.Write("Código de curso : " + cursos.IDCursoMoodle + " - Nombre : " + cursos.Nombre + "<br>");
        }
    }

    static string leerPaginaWeb(string url)
    {
        //Crear la solicitud de la URL.
        WebRequest request = WebRequest.Create(url);

        //Obtener la respuesta.
        WebResponse response = request.GetResponse();

        //Abrir el stream de la respuesta recibida.
        StreamReader reader = new StreamReader(response.GetResponseStream());

        //Leer el contenido.
        string res = reader.ReadToEnd();

        //Cerrar los streams abiertos.
        reader.Close();
        response.Close();
        return res;
    }

    public void LlenarCarreras()
    {
        wsUmas.WebServiceSoapClient ws = new wsUmas.WebServiceSoapClient();
        string str = ws.Carreras().ToString();
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(str);

        XmlNodeList nodo = doc.GetElementsByTagName("carrera");
        cboCarrera.Items.Clear();
        cboCarrera.Items.Add(new ListItem("Seleccione...", ""));
        foreach (XmlNode item in nodo)
        {
            string valor = item.SelectSingleNode("codcarr").InnerText;
            string texto = item.SelectSingleNode("nombre").InnerText;
            cboCarrera.Items.Add(new ListItem(texto, valor));
        }
    }

    protected void cboCarrera_SelectedIndexChanged(object sender, EventArgs e)
    {
        string codcarr = cboCarrera.SelectedValue.ToString();
        wsUmas.WebServiceSoapClient ws = new wsUmas.WebServiceSoapClient();
        string str = ws.MallaCarrera(codcarr).ToString();
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(str);

        XmlNodeList nodo = doc.GetElementsByTagName("malla");
        cboRamos.Items.Clear();
        cboRamos.Items.Add(new ListItem("Seleccione...", ""));
        foreach (XmlNode item in nodo)
        {
            string valor = item.SelectSingleNode("codramo").InnerText;
            string texto = item.SelectSingleNode("nomramo").InnerText;
            cboRamos.Items.Add(new ListItem(texto, valor));
        }
    }
}