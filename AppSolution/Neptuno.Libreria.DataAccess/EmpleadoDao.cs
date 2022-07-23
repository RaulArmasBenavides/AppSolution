using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Neptuno.Libreria.Entity;
using Neptuno.Libreria.Service;
using System.Data;


namespace Neptuno.Libreria.DataAccess
{
    public class EmpleadoDao : ICrudService<Empleado>
    {
        #region Metodos de Persistencia
               
        public void create(SqlConnection cn, Empleado t)
        {
            using (var cmd=new SqlCommand("usp_Empleado_Adicionar",cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Apellidos", t.Apellidos);
                cmd.Parameters.AddWithValue("@Nombre", t.Nombre);
                cmd.Parameters.AddWithValue("@Cargo", t.Cargo);
                cmd.Parameters.Add("@IdEmpleado",SqlDbType.Int).Direction=ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                t.IdEmpleado = (Int32)cmd.Parameters["@IdEmpleado"].Value;
            }
        }
        

        public void delete(SqlConnection cn, Empleado t)
        {
            using (var cmd = new SqlCommand("usp_Empleado_Eliminar", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;                
                cmd.Parameters.AddWithValue("@IdEmpleado", t.IdEmpleado);
                cmd.ExecuteNonQuery();
            }
        }
        

        public Empleado findForId(SqlConnection cn, Empleado t)
        {
            Empleado emp = null;

            using (var cmd = new SqlCommand("usp_Empleado_Buscar", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdEmpleado", t.IdEmpleado);

                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult);
                if (dr != null)
                {
                    int posId = dr.GetOrdinal("IdEmpleado");
                    int posApe = dr.GetOrdinal("Apellidos");
                    int posNom = dr.GetOrdinal("Nombre");
                    int posCar = dr.GetOrdinal("Cargo");                
                    if (dr.Read())
                    {
                        emp = new Empleado();
                        emp.IdEmpleado = dr.GetInt32(posId);
                        emp.Apellidos = dr.GetString(posApe);
                        emp.Nombre = dr.GetString(posNom);
                        emp.Cargo = dr.GetString(posCar);                        
                    }
                    dr.Close();
                }
            }
            return emp;
        }
        

        public List<Empleado> readAll(SqlConnection cn)
        {
            List<Empleado> lista = null;
            using (var cmd = new SqlCommand("usp_Empleados_Listar", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult);
                if (dr != null)
                {
                    int posId = dr.GetOrdinal("IdEmpleado");
                    int posApe = dr.GetOrdinal("Apellidos");
                    int posNom = dr.GetOrdinal("Nombre");
                    int posCar = dr.GetOrdinal("Cargo");                   
                    Empleado emp;
                    lista = new List<Empleado>();
                    while (dr.Read())
                    {
                        emp = new Empleado();
                        emp.IdEmpleado = dr.GetInt32(posId);
                        emp.Apellidos = dr.GetString(posApe);
                        emp.Nombre = dr.GetString(posNom);
                        emp.Cargo = dr.GetString(posCar);                       
                        lista.Add(emp);
                    }
                    dr.Close();
                }
            }
            return lista;
        }

        
        public void update(SqlConnection cn, Empleado t)
        {
            using (var cmd = new SqlCommand("usp_Empleado_Actualizar", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Apellidos", t.Apellidos);
                cmd.Parameters.AddWithValue("@Nombre", t.Nombre);
                cmd.Parameters.AddWithValue("@Cargo", t.Cargo);
                cmd.Parameters.AddWithValue("@IdEmpleado",t.IdEmpleado);
                cmd.ExecuteNonQuery();                
            }
        }

        #endregion
    }
}
