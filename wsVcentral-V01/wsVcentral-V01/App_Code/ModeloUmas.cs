using System;
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

        //Aqui se llamara al procedimiento almacenado del notas
        public DataTable Notas()
        {
            DataTable dt;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPIngresarNota";
                BaseDatos db = new BaseDatos();
                dt = db.EjecutarConsulta(cmd);
            }
            catch (SqlException ex)
            {
                dt = null;
            }
            return dt;
        }

        public DataTable InsertaNotas(int ano, int per, string codramo, string codsecc, string codalu, double nf)
        {
            DataTable dt;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPIngresarNota";
                cmd.Parameters.Add("@ano", SqlDbType.VarChar, 50).Value = ano;
                cmd.Parameters.Add("@per", SqlDbType.VarChar, 50).Value = per;
                cmd.Parameters.Add("@codramo", SqlDbType.VarChar, 50).Value = codramo;
                cmd.Parameters.Add("@codsecc", SqlDbType.VarChar, 50).Value = codsecc;
                cmd.Parameters.Add("@codalu", SqlDbType.VarChar, 50).Value = codalu;
                cmd.Parameters.Add("@nf", SqlDbType.VarChar, 50).Value = nf;
                BaseDatos db = new BaseDatos();
                dt = db.EjecutarConsulta(cmd);
            }
            catch (SqlException ex)
            {
                dt = null;
            }
            return dt;
        }
    }
}