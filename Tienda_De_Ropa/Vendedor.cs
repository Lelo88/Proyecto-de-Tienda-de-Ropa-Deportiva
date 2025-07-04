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
        private readonly VendedorBLL vendedor = new VendedorBLL();
        private readonly VentaBLL ventaBLL = new VentaBLL();
        private readonly ClienteBLL clienteBLL = new ClienteBLL();

        public Vendedor(string user, string pass)
        {
            InitializeComponent();
            label1.Text = "Vendedor: " + vendedor.ObtenerNombreCompletoPorUsuario(user);
        }

        private void Vendedor_Load(object sender, EventArgs e) {
            txt_IdVenta.Text = ventaBLL.ObtenerProximoIdVenta().ToString();
        }

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
            string nombreSeleccionado = cbo_Producto.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(nombreSeleccionado)) return;

            var producto = listaProductos.FirstOrDefault(p => p.Nombre == nombreSeleccionado);
            if (producto != null)
            {
                nud_Cantidad.Maximum = producto.Cantidad; // asigna cantidad máxima
                nud_Cantidad.Value = producto.Cantidad > 0 ? 1 : 0;
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
                    MessageBox.Show("La cantidad ingresada supera el stock disponible.", "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nud_Cantidad.Value = producto.Cantidad;
                }

                txt_Precio.Text = ((decimal)producto.Precio * nud_Cantidad.Value).ToString("0.00");
            }
        }

        private void btn_AgregarProductoALista_Click(object sender, EventArgs e)
        {
            string nombreP = cbo_Producto.Text;
            int cantidadNueva = (int)nud_Cantidad.Value;

            if (string.IsNullOrWhiteSpace(nombreP) || cantidadNueva == 0)
            {
                MessageBox.Show("Seleccione un producto y una cantidad válida.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Buscar stock disponible
            var producto = listaProductos.FirstOrDefault(p => p.Nombre == nombreP);
            if (producto == null) return;

            // Verificar cuánto ya se agregó de ese producto
            int cantidadYaAgregada = 0;
            foreach (DataGridViewRow fila in dgv_ProductosCargados.Rows)
            {
                if (fila.Cells["ColProducto"].Value?.ToString() == nombreP)
                {
                    cantidadYaAgregada += Convert.ToInt32(fila.Cells["ColCantidad"].Value);
                }
            }

            // Verificar si se supera el stock
            if (cantidadYaAgregada + cantidadNueva > producto.Cantidad)
            {
                MessageBox.Show("Ya se agregó todo el stock disponible de este producto.", "Stock agotado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            float precioUnitario = producto.Precio;
            float subtotal = precioUnitario * cantidadNueva;

            dgv_ProductosCargados.Rows.Add(nombreP, cantidadNueva, precioUnitario.ToString("0.00"), subtotal.ToString("0.00"));

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
            txt_IdVenta.Text = ventaBLL.ObtenerProximoIdVenta().ToString(); // volver a generar número de venta
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

        private void txt_DniCliente_Leave(object sender, EventArgs e)
        {
            string dni = txt_DniCliente.Text.Trim();
            if (string.IsNullOrWhiteSpace(dni))
                return;

            try
            {
                var cliente = clienteBLL.BuscarClientePorDni(dni);

                if (cliente != null)
                {
                    // Cliente encontrado → mostrar sus datos y bloquear campos
                    txt_NombreCliente.Text = cliente.Nombre;
                    txt_ApellidoCliente.Text = cliente.Apellido;
                    txt_ClienteNro.Text = cliente.Id_Cliente.ToString();
                    txt_NombreCliente.Enabled = false;
                    txt_ApellidoCliente.Enabled = false;
                }
                else
                {
                    // Cliente no encontrado → permitir ingresar datos
                    var r = MessageBox.Show("Cliente no encontrado. ¿Desea registrarlo?", "Nuevo cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        txt_NombreCliente.Clear();
                        txt_ApellidoCliente.Clear();
                        txt_ClienteNro.Text = "Nuevo";
                        txt_NombreCliente.Enabled = true;
                        txt_ApellidoCliente.Enabled = true;
                        txt_NombreCliente.Focus();
                    }
                    else
                    {
                        txt_DniCliente.Clear();
                        txt_NombreCliente.Clear();
                        txt_ApellidoCliente.Clear();
                        txt_ClienteNro.Clear();
                        txt_DniCliente.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar cliente: " + ex.Message);
            }
        }

    }
}
