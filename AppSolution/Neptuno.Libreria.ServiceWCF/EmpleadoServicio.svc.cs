using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Neptuno.Libreria.Bussines;
using Neptuno.Libreria.Entity;

namespace Neptuno.Libreria.ServiceWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "EmpleadoServicio" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione EmpleadoServicio.svc o EmpleadoServicio.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class EmpleadoServicio : IEmpleadoServicio
    {
        EmpleadoBll obj = new EmpleadoBll();

        public string  EmpleadoActualizar(Empleados emp)
        {
            Empleado xemp = new Empleado();
            xemp.Apellidos = emp.Apellidos;
            xemp.Nombre = emp.Nombre;
            xemp.Cargo = emp.Cargo;
            xemp.IdEmpleado = emp.IdEmpleado;
            string msj = obj.ProcesarEmpleado(2, xemp);
            return msj;
        }

        public string EmpleadoAdicionar(Empleados emp)
        {
            Empleado xemp = new Empleado();
            xemp.Apellidos = emp.Apellidos;
            xemp.Nombre = emp.Nombre;
            xemp.Cargo = emp.Cargo;
            string msj=obj.ProcesarEmpleado(1, xemp);
            return msj;
        }

        public Empleados EmpleadoBuscar(int id)
        {
            Empleado xemp = new Empleado();
            xemp.IdEmpleado = id;
            Empleados emp = ConvertEmpleadoToEmpleados(obj.Consultar(xemp));
            return emp; 
        }

        public string EmpleadoEliminar(Empleados emp)
        {
            Empleado xemp = new Empleado();           
            xemp.IdEmpleado = emp.IdEmpleado;
            string msj = obj.ProcesarEmpleado(2, xemp);
            return msj;
        }

        public List<Empleados> EmpleadoListar()
        {
            List<Empleados> lempleados = new List<Empleados>();
            Empleados miEmpleado;
            foreach (Empleado miRegistro in obj.Listar())
            {
                miEmpleado = ConvertEmpleadoToEmpleados(miRegistro);
                lempleados.Add(miEmpleado);
            }
            return lempleados;

        }

        private Empleados ConvertEmpleadoToEmpleados(Empleado miRegistro)
        {
            Empleados miEmpleado = new Empleados();
            miEmpleado.IdEmpleado = miRegistro.IdEmpleado;
            miEmpleado.Apellidos = miRegistro.Apellidos;
            miEmpleado.Nombre = miRegistro.Nombre;
            miEmpleado.Cargo = miRegistro.Cargo;
            return miEmpleado;
        }
    }
}
