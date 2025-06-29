using BLL;
using Entidad;
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
    public partial class EncargadoDeDeposito : Form
    {
        int decision = 1;
        private readonly DeporteBLL deporteBLL = new DeporteBLL();
        private readonly EncargadoBLL encargado = new EncargadoBLL();

        public EncargadoDeDeposito()
        {
            InitializeComponent();
        }

        private void btn_CerrarSesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea cerrar sesión?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show("Cerrando sesión...");
                Hide();
                new Iniciar_Sesion().Show();
                Close();
            }
        }

        private void btn_SeleccionarProducto_Click(object sender, EventArgs e)
        {
            if (dgv_Deposito.CurrentRow != null)
            {
                DataGridViewRow row = dgv_Deposito.CurrentRow;
                txt_IdProducto.Text = row.Cells["ColIdProducto"].Value.ToString();
                cbo_Deporte.Text = row.Cells["ColIdDeporte"].Value.ToString();
                txt_Nombre.Text = row.Cells["ColNombre"].Value.ToString();
                nud_Cantidad.Value = Convert.ToInt32(row.Cells["ColCantidad"].Value);
                txt_Marca.Text = row.Cells["ColMarca"].Value.ToString();
                txt_Modelo.Text = row.Cells["ColModelo"].Value.ToString();
                txt_Precio.Text = row.Cells["ColPrecio"].Value.ToString();

                btn_ModificarProducto.Enabled = true;
                btn_EliminarProducto.Enabled = true;
            }
        }

        private void btn_agregarProducto_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Llene a continuación los campos para agregar un nuevo producto");
            cbo_Deporte.DataSource = deporteBLL.ObtenerNombresDeDeportes();
            HabilitarCampos(true);
            LimpiarCampos();
        }

        private void btn_modificarProducto_Click(object sender, EventArgs e)
        {
            if (decision == 1)
            {
                MessageBox.Show("Se habilitó la modificación de un producto");
                cbo_Deporte.DataSource = deporteBLL.ObtenerNombresDeDeportes();
                HabilitarCampos(true);
                decision = 0;
            }
            else
            {
                Producto producto = new Producto
                {
                    Id_Producto = Convert.ToInt32(txt_IdProducto.Text),
                    Nombre = txt_Nombre.Text,
                    Marca = txt_Marca.Text,
                    Modelo = txt_Modelo.Text,
                    Cantidad = Convert.ToInt32(nud_Cantidad.Value),
                    Precio = Convert.ToSingle(txt_Precio.Text),
                    Deporte = new Deporte
                    {
                        Id_Deporte = deporteBLL.ObtenerIdDeporteDesdeNombre(cbo_Deporte.SelectedItem.ToString()),
                        Nombre = cbo_Deporte.SelectedItem.ToString()
                    }
                };

                encargado.ModificarProducto(producto);
                MessageBox.Show("Producto modificado correctamente");
                LimpiarCampos();
                HabilitarCampos(false);
                decision = 1;
            }
        }

        private void btn_eliminarProducto_Click(object sender, EventArgs e)
        {
            if (dgv_Deposito.CurrentRow != null)
            {
                int idProducto = Convert.ToInt32(dgv_Deposito.CurrentRow.Cells["ColIdProducto"].Value);
                encargado.EliminarProducto(idProducto);
                MessageBox.Show("Producto eliminado correctamente");
                LimpiarCampos();
                dgv_Deposito.DataSource = null;
            }
        }

        private void btn_ListarProductos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Productos listados correctamente");
            ConfigurarDataGridViewColumnasPorCodigo();
            dgv_Deposito.DataSource = encargado.ListarProductos();
        }

        private void btn_GuardarCambios_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto
            {
                Nombre = txt_Nombre.Text,
                Marca = txt_Marca.Text,
                Modelo = txt_Modelo.Text,
                Cantidad = Convert.ToInt32(nud_Cantidad.Value),
                Precio = Convert.ToSingle(txt_Precio.Text),
                Deporte = new Deporte
                {
                    Id_Deporte = deporteBLL.ObtenerIdDeporteDesdeNombre(cbo_Deporte.SelectedItem.ToString()),
                    Nombre = cbo_Deporte.SelectedItem.ToString()
                }
            };

            encargado.AgregarProducto(producto);
            MessageBox.Show("Producto agregado correctamente");
            LimpiarCampos();
            HabilitarCampos(false);
            dgv_Deposito.DataSource = null;
        }

        private void btn_CancelarCambios_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de cancelar los cambios?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LimpiarCampos();
                HabilitarCampos(false);
                dgv_Deposito.DataSource = null;
            }
        }

        private void ConfigurarDataGridViewColumnasPorCodigo()
        {
            dgv_Deposito.AutoGenerateColumns = false;
            dgv_Deposito.Columns.Clear();
            dgv_Deposito.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColIdProducto", HeaderText = "ID", DataPropertyName = "Id_Producto" });
            dgv_Deposito.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColIdDeporte", HeaderText = "Deporte", DataPropertyName = "Deporte" });
            dgv_Deposito.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColNombre", HeaderText = "Nombre", DataPropertyName = "Nombre" });
            dgv_Deposito.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColCantidad", HeaderText = "Cantidad", DataPropertyName = "Cantidad" });
            dgv_Deposito.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColMarca", HeaderText = "Marca", DataPropertyName = "Marca" });
            dgv_Deposito.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColModelo", HeaderText = "Modelo", DataPropertyName = "Modelo" });
            dgv_Deposito.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColPrecio", HeaderText = "Precio", DataPropertyName = "Precio" });
        }

        private void LimpiarCampos()
        {
            txt_IdProducto.Clear();
            txt_Nombre.Clear();
            txt_Marca.Clear();
            txt_Modelo.Clear();
            nud_Cantidad.Value = 0;
            txt_Precio.Clear();
            cbo_Deporte.DataSource = null;
        }

        private void HabilitarCampos(bool habilitar)
        {
            dgv_Deposito.Enabled = !habilitar;
            txt_IdProducto.Enabled = false;
            txt_Nombre.Enabled = habilitar;
            txt_Marca.Enabled = habilitar;
            txt_Modelo.Enabled = habilitar;
            nud_Cantidad.Enabled = habilitar;
            txt_Precio.Enabled = habilitar;
            cbo_Deporte.Enabled = habilitar;

            btn_AgregarProducto.Enabled = !habilitar;
            btn_EliminarProducto.Enabled = !habilitar;
            btn_ModificarProducto.Enabled = !habilitar;
            btn_ListarProductos.Enabled = !habilitar;
            btn_SeleccionarProducto.Enabled = !habilitar;
            btn_CerrarSesion.Enabled = !habilitar;
            btn_GuardarCambios.Enabled = habilitar;
            btn_CancelarCambios.Enabled = habilitar;
        }
    }
}
