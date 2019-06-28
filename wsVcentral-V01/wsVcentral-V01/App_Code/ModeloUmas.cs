﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace wsVcentralV01
{
    public class ModeloUmas
    {
        public ModeloUmas()
        {
        }

        public DataTable Carreras()
        {
            DataTable dt;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_carreras";
                BaseDatos db = new BaseDatos();
                dt = db.EjecutarConsulta(cmd);
            }
            catch (SqlException ex)
            {
                dt = null;
            }
            return dt;
        }

        public DataTable MallaCarrera(string codcarr)
        {
            DataTable dt;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_mallacarrera";
                cmd.Parameters.Add("@codcarr", SqlDbType.VarChar, 50).Value = codcarr;
                BaseDatos db = new BaseDatos();
                dt = db.EjecutarConsulta(cmd);
            }catch(SqlException ex)
            {
                dt = null;
            }
            return dt;
        }
    }
}