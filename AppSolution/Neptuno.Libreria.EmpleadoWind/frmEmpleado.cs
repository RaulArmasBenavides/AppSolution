using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Neptuno.Libreria.EmpleadoWind.ProxyWCF;

namespace Neptuno.Libreria.EmpleadoWind
{
    public partial class frmEmpleado : Form
    {
        public frmEmpleado()
        {
            InitializeComponent();
        }
       
        EmpleadoServicioClient obj = new EmpleadoServicioClient();

        private void frmEmpleado_Load(object sender, EventArgs e)
        {
            try
            {
                dgvEmpleado.DataSource = obj.EmpleadoListar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        Empleados emp;

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            emp = new Empleados()
            {
                Apellidos=txtApellido.Text,
                Nombre=txtNombre.Text,
                Cargo=txtCargo.Text
            };
            try
            {
                string msj = obj.EmpleadoAdicionar(emp);
                MessageBox.Show(msj);
                frmEmpleado_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }
    }
}
