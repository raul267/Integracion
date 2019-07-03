using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace nota3
{
    public class BaseDatos
    {

        String strConn = "Data Source=localhost;Initial Catalog=db_vcentral;Integrated Security=True";

        public DataTable EjecutarConsulta(SqlCommand Cmd)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter Sda = new SqlDataAdapter(Cmd);
            try
            {
                Cmd.Connection = new SqlConnection(strConn);
                Sda.Fill(dt);
                Cmd.Connection.Close();
            }
            catch (SqlException exp)
            {
                dt = null;
            }
            return dt;
        }

        public bool EjecutarAccion(SqlCommand Cmd)
        {
            bool std = false;
            DataTable dt = new DataTable();
            SqlDataAdapter Sda = new SqlDataAdapter(Cmd);
            try
            {
                Cmd.Connection = new SqlConnection(strConn);
                Sda.Fill(dt);
                Cmd.Connection.Close();
                std = true;
            }
            catch (SqlException exp)
            {
                std = false;
            }
            return std;
        }
    }
}