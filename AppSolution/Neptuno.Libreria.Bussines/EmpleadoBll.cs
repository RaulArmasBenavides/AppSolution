using System;
using System.Collections.Generic;
using Neptuno.Libreria.DataAccess;
using Neptuno.Libreria.Entity;
using System.Data.SqlClient;
using Neptuno.Libreria.Connection;

namespace Neptuno.Libreria.Bussines
{
    public class EmpleadoBll : AccesoDB
    {
        #region Metodos de Negocio

        public List<Empleado> Listar()
        {
            List<Empleado> lista = new List<Empleado>();
            using (SqlConnection cn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    cn.Open();
                    EmpleadoDao dao = new EmpleadoDao();
                    lista = dao.readAll(cn);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return lista;
        }//end

        public Empleado Consultar(Empleado e)
        {
            Empleado emp = null;

            using (SqlConnection cn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    cn.Open();
                    EmpleadoDao dao = new EmpleadoDao();
                    emp = dao.findForId(cn, e);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return emp;
        }//end

        public string ProcesarEmpleado(int opcion,Empleado e)
        {
            string msj = "";
            using (SqlConnection cn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    cn.Open();
                    EmpleadoDao dao = new EmpleadoDao();
                    switch (opcion)
                    {
                        case 1:
                            dao.create(cn, e);
                            msj = "Empleado registrado con exito";
                            break;
                        case 2:
                            dao.update(cn, e);
                            msj = "Empleado actualizado con exito";
                            break;
                        case 3:
                            dao.delete(cn, e);
                            msj = "Empleado eliminado con exito";
                            break;
                    }
                    return msj;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            
        }

        #endregion
    }
}
