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
        private readonly GerenteBLL gerenteBLL = new GerenteBLL();
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
            try
            {
                dgv_Ventas.DataSource = gerenteBLL.ListarVentas();

                // Activar controles
                btn_Aplicar.Enabled = true;
                btn_Buscar.Enabled = true;
                txt_DetalleBusqueda.Enabled = true;
                cbo_OrdenarPor.Enabled = true;
                dgv_Ventas.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar ventas: " + ex.Message);
            }
        }

        private void btn_Aplicar_Click(object sender, EventArgs e)
        {
            {
                if (cbo_OrdenarPor.SelectedItem != null)
                {
                    string criterio = cbo_OrdenarPor.SelectedItem.ToString();
                    try
                    {
                        dgv_Ventas.DataSource = gerenteBLL.OrdenarVentasPor(criterio);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al ordenar: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccioná un criterio para ordenar.");
                }
            }
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txt_DetalleBusqueda.Text, out int idVenta))
            {
                try
                {
                    Venta venta = gerenteBLL.BuscarVenta(idVenta);
                    if (venta != null)
                        dgv_Ventas.DataSource = new List<Venta> { venta };
                    else
                        MessageBox.Show("No se encontró la venta con ese ID.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar la venta: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un ID válido (solo números).");
            }
        }
        private void Gerente_Load(object sender, EventArgs e)
        {
            cbo_OrdenarPor.Items.Add("FECHA");
            cbo_OrdenarPor.Items.Add("TOTAL");
            cbo_OrdenarPor.Items.Add("NOMBRE_CLIENTE");
            cbo_OrdenarPor.Items.Add("NOMBRE_EMPLEADO");
        }

    }
}
