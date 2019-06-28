﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml;

namespace wsVcentralV01
{
    public class XmlUmas
    {
        public XmlUmas()
        {
        }

        public XmlDocument xmlCarreras()
        {
            XmlDocument doc = new XmlDocument();
            string str = "<vcentral>";
            ModeloUmas obj = new ModeloUmas();
            DataTable dt = obj.Carreras();
            foreach (DataRow fila in dt.Rows)
            {
                str += "<carrera>";
                str += "<codcarr>" + fila["codcarr"].ToString() + "</codcarr>";
                str += "<nombre>" + fila["nombre"].ToString() + "</nombre>";
                str += "</carrera>";
            }
            str += "</vcentral>";
            doc.LoadXml(str);
            return doc;
        }

        public XmlDocument xmlMallaCarrera(string codcarr)
        {
            XmlDocument doc = new XmlDocument();
            string str = "<vcentral>";
            ModeloUmas obj = new ModeloUmas();
            DataTable dt = obj.MallaCarrera(codcarr);
            foreach (DataRow fila in dt.Rows)
            {
                str += "<malla>";
                str += "<codcarr>" + fila["codcarr"].ToString() + "</codcarr>";
                str += "<nomcarrera>" + fila["nomcarrera"].ToString() + "</nomcarrera>";
                str += "<codramo>" + fila["codramo"].ToString() + "</codramo>";
                str += "<nomramo>" + fila["nomramo"].ToString() + "</nomramo>";
                str += "<nivel>" + fila["nivel"].ToString() + "</nivel>";
                str += "</malla>";
            }
            str += "</vcentral>";
            doc.LoadXml(str);
            return doc;
        }
    }
}