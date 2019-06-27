using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace nota3
{
    public partial class AsignarRamos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblRamo.InnerText = Request.QueryString["id"];
            CargarComboCarrera();
        }

        public void CargarComboCarrera()
        {
            WServiceSoapClient ws = new WServiceSoapClient();
            string str = ws.Carreras().ToString();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(str);
            XmlNodeList nodo = doc.GetElementsByTagName("carrera");
            ddlCarreras.Items.Clear();
            ddlCarreras.Items.Add(new ListItem("Seleccione...", ""));
            foreach (XmlNode item in nodo)
            {
                string valor = item.SelectSingleNode("codcarr").InnerText;
                string texto = item.SelectSingleNode("nombre").InnerText;
                ddlCarreras.Items.Add(new ListItem(texto, valor));
            }
        }

    }
}