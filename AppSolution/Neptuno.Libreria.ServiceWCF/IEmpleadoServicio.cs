using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Neptuno.Libreria.ServiceWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IEmpleadoServicio" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IEmpleadoServicio
    {
        [OperationContract]
        List<Empleados> EmpleadoListar();

        [OperationContract]
        Empleados EmpleadoBuscar(int id);

        [OperationContract]
        string EmpleadoAdicionar(Empleados emp);

        [OperationContract]
        string EmpleadoActualizar(Empleados emp);

        [OperationContract]
        string EmpleadoEliminar(Empleados emp);
    }

}
