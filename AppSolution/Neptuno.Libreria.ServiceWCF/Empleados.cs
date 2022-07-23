using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Neptuno.Libreria.ServiceWCF
{
    [DataContract]
    public class Empleados
    {
        //atributos
        private int idempleado;
        private string apellidos;
        private string nombre;
        private string cargo;

        //propiedades


        [DataMember]
        public int IdEmpleado
        {
            get { return idempleado; }
            set { idempleado = value; }
        }

        [DataMember]
        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

        [DataMember]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        [DataMember]
        public string Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }


    }
}