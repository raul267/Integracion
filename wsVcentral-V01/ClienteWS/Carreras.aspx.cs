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
using System.Xml.Serialization;
using Umas.Negocio;
using Umas.DALC;
using System.Data.SqlClient;

public partial class index : System.Web.UI.Page
{
    SqlConnection conexion = new SqlConnection("server=DESKTOP-6L53SUV; database=db_vcentral; User ID=val;Password=val");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Limpiar();
            LlenarCarreras();

            //Cuando la página se cargue, colocar la dirección de cualquier api
            string url = "http://www.sieduc.cl/phpApi/mdl_course.php";
            string res = leerPaginaWeb(url);
            JavaScriptSerializer js = new JavaScriptSerializer();
            Cursos Lista = js.Deserialize<Cursos>(res);
            cboCursoo.Items.Clear();
            cboCursoo.Items.Add(new ListItem("Seleccione...", "666"));
            foreach (Ramos cursos in Lista.cursos)
            {
                string valor = cursos.IDCursoMoodle;
                string texto = cursos.Nombre;
                cboCursoo.Items.Add(new ListItem(texto, valor));
            }

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



    protected void Asignar_Click(object sender, EventArgs e)
    {
        string query = "INSERT INTO asignacionn (cod_cursoumas, cod_carrera, cod_cursomoodle) VALUES (@cu_umas, @ca_umas, @cu_moodle)";
        conexion.Open();
        SqlCommand comando = new SqlCommand(query, conexion);
        comando.Parameters.AddWithValue("@cu_umas", cboRamos.SelectedValue);
        comando.Parameters.AddWithValue("@ca_umas", cboCarrera.SelectedValue);
        comando.Parameters.Add("@cu_moodle",cboCursoo.SelectedValue);
        comando.ExecuteNonQuery();
        conexion.Close();
        Response.Write("<script>alert('Exito al registrar');</script>");
    }

    public void Limpiar()
    {
        cboCarrera.SelectedIndex = 0;
        cboCursoo.SelectedIndex = 0;
        cboRamos.SelectedIndex = 0;
        lblResultado.InnerText = "";
    }
}