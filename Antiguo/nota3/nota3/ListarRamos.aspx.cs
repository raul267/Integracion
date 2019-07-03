using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nota3
{
    public partial class ListarRamos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarRamos();
        }

        static string leerPaginaWeb(string url)
        {
            //Crear la solicitud a la url
            WebRequest request = WebRequest.Create(url);
            //Obtener la respuesta
            WebResponse response = request.GetResponse();
            //abrir el stream de la respuesta obtenida
            StreamReader reader = new StreamReader(response.GetResponseStream());
            //Leer el contenido
            string res = reader.ReadToEnd();
            //cerramos los stream abiertos
            reader.Close();
            response.Close();
            return res;
        }

        public void CargarRamos()
        {
            string url = "http://www.sieduc.cl/phpApi/mdl_course.php";
            string res = leerPaginaWeb(url);
            JavaScriptSerializer js = new JavaScriptSerializer();
            ramos lista = js.Deserialize<ramos>(res);
            

            if (lista.Cursos == null)
            {
                lblm.Text = "fue null la wea";
            }
            else
            {
                foreach (ramo ramo in lista.Cursos)
                {
                    lblm.Text = lblm.Text + "<label>"+ramo.Nombre+"</label><a href='AsignarRamos.aspx?id="+ramo.IDCursoMoodle+"'>Asignar</a> <br>";
                    
                }
            }

        }

        public void Asginar(int id)
        {
            Response.Redirect("AsignarRamos.asp?id="+id);
        }
    }
}