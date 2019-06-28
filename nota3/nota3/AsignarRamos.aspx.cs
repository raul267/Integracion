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
            lblRamo.InnerText = "Vas a asignar el ramo: ";
            lblRamo.InnerText = lblRamo.InnerText + Request.QueryString["id"];
            CargarComboCarrera();
            
        }

        public void CargarComboCarrera()
        {
            ServiceReference1.WebService1SoapClient ws = new ServiceReference1.WebService1SoapClient();
            string str = ws.Carreras().ToString();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(str);
            XmlNodeList nodo = doc.GetElementsByTagName("carrera");
            ddlCarreras.Items.Clear();
            ddlCarreras.Items.Add(new ListItem("Seleccione una carrera...", ""));
            foreach (XmlNode item in nodo)
            {
                string valor = item.SelectSingleNode("codcarr").InnerText;
                string texto = item.SelectSingleNode("nombre").InnerText;
                ddlCarreras.Items.Add(new ListItem(texto, valor));
            }
        }

        protected void ddlCarreras_SelectedIndexChanged(object sender, EventArgs e)
        {
            string codcarr = ddlCarreras.SelectedValue.ToString();
            ServiceReference1.WebService1SoapClient ws = new ServiceReference1.WebService1SoapClient();
            string str = ws.MallaCarrera(codcarr).ToString();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(str);

            XmlNodeList nodo = doc.GetElementsByTagName("malla");
            ddlRamos.Items.Clear();
            ddlRamos.Items.Add(new ListItem("Selecciona un ramo", ""));
            foreach (XmlNode item in nodo)
            {
                string valor = item.SelectSingleNode("codramo").InnerText;
                string texto = item.SelectSingleNode("nomramo").InnerText;
                ddlRamos.Items.Add(new ListItem(texto, valor));
            }
        }
    }
}