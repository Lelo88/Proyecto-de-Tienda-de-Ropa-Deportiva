using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tienda_De_Ropa
{
    public partial class Gerente: Form
    {
        public Gerente()
        {
            InitializeComponent();
        }

        private void cbo_OrdenarPor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_CerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Seguro que desea cerrar sesion?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly, false);
            if (r == DialogResult.Yes)
            {
                MessageBox.Show("Cerrando sesion...");
                this.Hide();
                Iniciar_Sesion iniciar_sesion = new Iniciar_Sesion();
                MessageBox.Show("HASTA LUEGO!!");
                iniciar_sesion.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("El sistema seguira en funcionamiento");
            }
        }

        private void btn_ListarVentas_Click(object sender, EventArgs e)
        {
            //ARMAR CON CONSULTA SQL LISTANDO LAS VENTAS REALIZADAS POR LOS EMPLEADOS

            btn_Aplicar.Enabled = true;
            btn_Buscar.Enabled = true;
            txt_DetalleBusqueda.Enabled = true;
            cbo_OrdenarPor.Enabled = true;
            dgv_Ventas.Enabled = true;
        }

        private void btn_Aplicar_Click(object sender, EventArgs e)
        {
            //ORDENA LOS ELEMENTOS DE ACUERDO SI ELIGIO MAYOR, MENOR VENDIDO (PENSAR EN LA IDEA...)
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            //BUSCA DE ACUERDO A LO QUE EL USUARIO ESCRIBA EN EL TXT
        }
    }
}
