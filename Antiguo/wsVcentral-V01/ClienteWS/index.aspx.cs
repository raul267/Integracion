using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Notas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }


    protected void btnAdmCursos_Click(object sender, EventArgs e)
    {
        Response.Redirect("Carreras.aspx");
    }

    protected void btnCargarNotas_Click(object sender, EventArgs e)
    {
        Response.Redirect("Notas.aspx");
    }
}