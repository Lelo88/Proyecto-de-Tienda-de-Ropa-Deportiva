using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Entidad;

namespace Tienda_De_Ropa
{
    public partial class Vendedor : Form
    {
        private readonly MetodoDePagoBLL metodo = new MetodoDePagoBLL();
        private readonly ProductoBLL productoBLL = new ProductoBLL(); // CORREGIDO
        private List<Producto> listaProductos = new List<Producto>();

        public Vendedor(string user, string pass)
        {
            InitializeComponent();
            txt_IdVendedor.Text = "Vendedor123"; // Acá se debería asignar el ID, si se implementa correctamente
        }

        private void Vendedor_Load(object sender, EventArgs e) { }

        private void btn_GenerarVenta_Click(object sender, EventArgs e)
        {
            txt_ApellidoCliente.Enabled = txt_NombreCliente.Enabled = txt_DniCliente.Enabled = true;
            cbo_MetodoDePago.Enabled = cbo_Producto.Enabled = true;
            nud_Cantidad.Enabled = btn_AgregarProductoALista.Enabled = btn_ConfirmarVenta.Enabled =
                btn_CancelarVenta.Enabled = btn_EliminarProductoDeLista.Enabled = true;

            btn_GenerarVenta.Enabled = false;
            btn_CerrarSesion.Enabled = false;
            txt_Fecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            cbo_MetodoDePago.DataSource = metodo.ObtenerNombresDeMetodos();
            nud_Cantidad.Value = 0;
            txt_Precio.Clear();
            dgv_ProductosCargados.DataSource = null;
            txt_Total.Text = "0";

            ConfigurarDataGridViewColumnas();
            CargarDatosProductos();
        }

        private void CargarDatosProductos()
        {
            listaProductos = productoBLL.ListarProductos(); // CORREGIDO
            cbo_Producto.Items.Clear();
            foreach (var prod in listaProductos)
                cbo_Producto.Items.Add(prod.Nombre);
        }

        private void cbo_Producto_SelectedIndexChanged(object sender, EventArgs e)
        {
            var nombreSeleccionado = cbo_Producto.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(nombreSeleccionado)) return;

            var producto = listaProductos.FirstOrDefault(p => p.Nombre == nombreSeleccionado);
            if (producto != null)
            {
                nud_Cantidad.Maximum = producto.Cantidad;
                txt_Precio.Text = ((decimal)producto.Precio * nud_Cantidad.Value).ToString("0.00");
            }
        }

        private void nud_Cantidad_ValueChanged(object sender, EventArgs e)
        {
            if (cbo_Producto.SelectedItem == null) return;

            string nombre = cbo_Producto.Text;
            var producto = listaProductos.FirstOrDefault(p => p.Nombre == nombre);
            if (producto != null)
            {
                if (nud_Cantidad.Value > producto.Cantidad)
                {
                    nud_Cantidad.Value = producto.Cantidad;
                    MessageBox.Show("La cantidad supera el stock disponible.");
                }

                txt_Precio.Text = ((decimal)producto.Precio * nud_Cantidad.Value).ToString("0.00");
            }
        }

        private void btn_AgregarProductoALista_Click(object sender, EventArgs e)
        {
            string nombreP = cbo_Producto.Text;
            int cantidad = (int)nud_Cantidad.Value;
            float precioUnitario = productoBLL.ObtenerPrecioUnitario(nombreP); // CORREGIDO
            float subtotal = precioUnitario * cantidad;

            dgv_ProductosCargados.Rows.Add(nombreP, cantidad, precioUnitario, subtotal);
            txt_Total.Text = (float.Parse(txt_Total.Text) + subtotal).ToString("0.00");

            cbo_Producto.SelectedItem = null;
            nud_Cantidad.Value = 0;
        }

        private void btn_CancelarVenta_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea cancelar la venta?", "Confirmación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LimpiarFormulario();
            }
        }

        private void btn_CerrarSesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea cerrar sesión?", "Salir",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Hide();
                new Iniciar_Sesion().Show();
                Close();
            }
        }

        private void LimpiarFormulario()
        {
            txt_IdVendedor.Clear();
            txt_IdVenta.Clear();
            txt_ApellidoCliente.Clear();
            txt_NombreCliente.Clear();
            txt_ClienteNro.Clear();
            txt_DniCliente.Clear();
            txt_Fecha.Clear();
            txt_Total.Clear();
            txt_Precio.Clear();
            nud_Cantidad.Value = 0;

            dgv_ProductosCargados.Rows.Clear();
            cbo_Producto.SelectedIndex = -1;

            txt_ApellidoCliente.Enabled = txt_NombreCliente.Enabled =
            txt_DniCliente.Enabled = cbo_MetodoDePago.Enabled = cbo_Producto.Enabled =
            nud_Cantidad.Enabled = btn_AgregarProductoALista.Enabled = btn_ConfirmarVenta.Enabled =
            btn_CancelarVenta.Enabled = btn_EliminarProductoDeLista.Enabled = false;

            btn_CerrarSesion.Enabled = true;
            btn_GenerarVenta.Enabled = true;
        }

        private void ConfigurarDataGridViewColumnas()
        {
            dgv_ProductosCargados.AutoGenerateColumns = false;
            dgv_ProductosCargados.Columns.Clear();
            dgv_ProductosCargados.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColProducto", HeaderText = "Producto" });
            dgv_ProductosCargados.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColCantidad", HeaderText = "Cantidad" });
            dgv_ProductosCargados.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColPrecioUnitario", HeaderText = "Precio Unitario" });
            dgv_ProductosCargados.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColTotal", HeaderText = "Total" });
        }
    }
}
