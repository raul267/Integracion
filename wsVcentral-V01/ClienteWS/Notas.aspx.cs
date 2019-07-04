using ClasesApi;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Notas : System.Web.UI.Page
{
    SqlConnection conexion = new SqlConnection("server=DESKTOP-6L53SUV; database=db_vcentral; User ID=val;Password=val");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string url = "http://www.sieduc.cl/phpApi/mdl_enrole_course.php";
            string res = LeerPaginaWeb(url);
            JavaScriptSerializer js = new JavaScriptSerializer();
            AlumnoNotas Lista = js.Deserialize<AlumnoNotas>(res);

            cboAno.Items.Clear();
            cboAno.Items.Add(new ListItem("Seleccione...", ""));
            cboAno.Items.Add(new ListItem("2018", "2018"));
            cboAno.Items.Add(new ListItem("2019", "2019"));
            cboAno.Items.Add(new ListItem("2020", "2020"));

            cboPeriodo.Items.Clear();
            cboPeriodo.Items.Add(new ListItem("Seleccione...", ""));
            cboPeriodo.Items.Add(new ListItem("1", "1"));
            cboPeriodo.Items.Add(new ListItem("2", "2"));

            lblNotas.InnerHtml += "<table border=1 bgcolor='white'>";
            lblNotas.InnerHtml += "<thead>";
            lblNotas.InnerHtml += "<tr>";
            lblNotas.InnerHtml += "<th>Id curso</th>";
            lblNotas.InnerHtml += "<th>Rut estudiante</th>";
            lblNotas.InnerHtml += "<th>Nota final</th>";
            lblNotas.InnerHtml += "</tr>";
            lblNotas.InnerHtml += "</thead>";
            lblNotas.InnerHtml += "<tbody>";
            foreach (NotasF alucursos in Lista.alucursos)
            {
                lblNotas.InnerHtml += "<tr>";
                lblNotas.InnerHtml += "<td>" + alucursos.IDCursoMoodle + "</td>";
                lblNotas.InnerHtml += "<td>" + alucursos.RutEstudiante + "</td>";
                lblNotas.InnerHtml += "<td>" + alucursos.NotaFinal + "</td>";
                lblNotas.InnerHtml += "</tr>";
                // Response.Write("ID Curso : " + alucursos.IDCursoMoodle + " - Rut Estudiante : " + alucursos.RutEstudiante +
                // " - Nota Final: " + alucursos.NotaFinal + "<br>");
            }
            lblNotas.InnerHtml += "</tbody>";
            lblNotas.InnerHtml += "</table>";

        }
    }

    static string LeerPaginaWeb(string url)
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

    protected void btnTraspasar_Click(object sender, EventArgs e)
    {
        //Una vez seleccionado el combo año y el combo periodo se debe cargar a una web service
        //los siguientes datos: IdCursoMoodle, RutEstudiante, NotaFinal, Año, Periodo.
        //Antes de cargar a la web service se debe hacer la validación de datos segun el modelo
        //de negocio visto en clases (si el alumno reprueba.. blabla.. recordar los if)

        //HACER ALGO ASI

        //Sacar datos de la vita
        int ano = 0;
        int per = 0;
        Int32.TryParse(cboAno.SelectedValue,out ano);
        Int32.TryParse(cboPeriodo.SelectedValue, out per);
        //Sacar datos de la api 

        string url = "http://www.sieduc.cl/phpApi/mdl_enrole_course.php";
        string res = LeerPaginaWeb(url);
        JavaScriptSerializer js = new JavaScriptSerializer();
        AlumnoNotas Lista = js.Deserialize<AlumnoNotas>(res);
        wsUmas.WebServiceSoapClient ws = new wsUmas.WebServiceSoapClient();
        string query = "exec SPIngresarNota @ano,@per,@codramo,@codalu,@nf";
        foreach (NotasF alucursos in Lista.alucursos)
        {


            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@ano",ano);
            comando.Parameters.AddWithValue("@per", per);
            comando.Parameters.AddWithValue("@codramo", alucursos.IDCursoMoodle);
            comando.Parameters.AddWithValue("@codalu", alucursos.RutEstudiante);
            comando.Parameters.Add("@nf", alucursos.NotaFinal);
            comando.ExecuteNonQuery();
            conexion.Close();
        }
        
        Response.Write("<script>alert('Exito al traspasar las notas');</script>");

        /*
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
       */
    }

    protected void btnMostrar_Click(object sender, EventArgs e)
    {
        divNotas.Style.Add("display","block");
    }
}