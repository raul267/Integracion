using System;
using System.Configuration;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace wsVcentralV01
{
    public class BaseDatos
    {
        String strConn = ConfigurationManager.AppSettings["val"];

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

