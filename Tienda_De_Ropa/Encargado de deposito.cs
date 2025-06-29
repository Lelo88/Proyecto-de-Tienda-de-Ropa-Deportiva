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
    public partial class EncargadoDeDeposito: Form
    {
        int decision = 1;
        DeporteBLL deporteBLL = new DeporteBLL();

        public EncargadoDeDeposito()
        {
            InitializeComponent();
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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btn_SeleccionarProducto_Click(object sender, EventArgs e)
        {
            //SELECCIONA UN PRODUCTO, SOLO HACIENDO CLICK Y OBTIENE LOS DATOS DEL PRODUCTO
            //DEBE ESTAR LA TABLA PREVIAMENTE CARGADA CON PRODUCTOS
            btn_ModificarProducto.Enabled = true;
            btn_EliminarProducto.Enabled = true;
            DataGridViewRow row = dgv_Deposito.CurrentRow;
            int idProducto = Convert.ToInt32(row.Cells["ColIdProducto"].Value);
            string deporte = row.Cells["ColIdDeporte"].Value.ToString();
            string nombre = row.Cells["ColNombre"].Value.ToString();
            string cantidad = row.Cells["ColCantidad"].Value.ToString();
            string marca = row.Cells["ColMarca"].Value.ToString();
            string modelo = row.Cells["ColModelo"].Value.ToString();
            string precio = row.Cells["ColPrecio"].Value.ToString();
            txt_IdProducto.Text = idProducto.ToString();
            txt_Nombre.Text = nombre;
            nud_Cantidad.Text = cantidad;
            txt_Marca.Text = marca;
            txt_Modelo.Text = modelo;
            txt_Precio.Text = precio;
            cbo_Deporte.Text = deporte;
        }

        private void btn_agregarProducto_Click(object sender, EventArgs e)
        {
            ConfigurarDataGridViewColumnasPorCodigo();
            BLL.DeporteBLL deporte = new BLL.DeporteBLL();
            //AGREGA EL PRODUCTO A LA LISTA DE PRODUCTOS
            //DEBE ESTAR LA TABLA PREVIAMENTE CARGADA CON PRODUCTOS
            MessageBox.Show("Llene a continuacion los campos para agregar un nuevo producto");
            dgv_Deposito.Enabled = false;
            btn_CerrarSesion.Enabled = false;
            btn_SeleccionarProducto.Enabled = false;
            btn_AgregarProducto.Enabled = false;
            btn_ModificarProducto.Enabled = false;
            btn_EliminarProducto.Enabled = false;
            btn_ListarProductos.Enabled = false;
            btn_CancelarCambios.Enabled = true;
            btn_GuardarCambios.Enabled = true;
            txt_IdProducto.Enabled = false;
            txt_Nombre.Enabled = true;
            txt_Marca.Enabled = true;
            txt_Modelo.Enabled = true;
            nud_Cantidad.Enabled = true;
            txt_Precio.Enabled = true;
            cbo_Deporte.Enabled = true;
            //cbo_Deporte.Items.Clear();
            //cbo_Deporte.Items.Remove(cbo_Deporte.SelectedItem);
            cbo_Deporte.DataSource=deporte.ObtenerNombresDeDeportes();
            txt_IdProducto.Text = "";
            txt_Nombre.Text = "";
            txt_Marca.Text ="";
            txt_Modelo.Text = "";
            nud_Cantidad.Value = 0;
            txt_Precio.Text = "";
        }

        private void btn_modificarProducto_Click(object sender, EventArgs e)
        {
            BLL.DeporteBLL deportes = new BLL.DeporteBLL();
            if (decision == 1)
            {
                MessageBox.Show("Se habilito la modificacion de un producto");
                MessageBox.Show("Presione cancelar si quiere dejarlo como esta");
                MessageBox.Show("Presione modificar producto para aplicar los cambios");
                DataGridViewRow row = dgv_Deposito.CurrentRow;
                btn_ModificarProducto.Enabled = true;
                btn_EliminarProducto.Enabled = false;
                btn_AgregarProducto.Enabled = false;
                btn_CerrarSesion.Enabled = false;
                btn_SeleccionarProducto.Enabled = false;
                btn_CancelarCambios.Enabled = true;
                btn_ListarProductos.Enabled = false;
                dgv_Deposito.Enabled = false;
                cbo_Deporte.Enabled = true;
                cbo_Deporte.DataSource = deportes.ObtenerNombresDeDeportes();
                int idProducto = Convert.ToInt32(row.Cells["ColIdProducto"].Value);
                string deporte = row.Cells["ColIdDeporte"].Value.ToString();
                string nombre = row.Cells["ColNombre"].Value.ToString();
                int cantidad = Convert.ToInt32(row.Cells["ColCantidad"].Value);
                string marca = row.Cells["ColMarca"].Value.ToString();
                string modelo = row.Cells["ColModelo"].Value.ToString();
                float precio = Convert.ToSingle(row.Cells["ColPrecio"].Value);
                txt_IdProducto.Text = idProducto.ToString();
                cbo_Deporte.SelectedItem = deporte;
                txt_Nombre.Text = nombre;
                nud_Cantidad.Value = cantidad;
                txt_Marca.Text = marca;
                txt_Modelo.Text = modelo;
                txt_Precio.Text = precio.ToString();
                txt_IdProducto.Enabled = false;
                cbo_Deporte.Enabled = true;
                txt_Nombre.Enabled = true;
                txt_Marca.Enabled = true;
                txt_Modelo.Enabled = true;
                txt_Precio.Enabled = true;
                nud_Cantidad.Enabled = true;
                decision = 0;
            }
            else
            {
                BLL.EncargadoBLL encargado = new BLL.EncargadoBLL();
                int idProducto = Convert.ToInt32(txt_IdProducto.Text);
                string deporte = cbo_Deporte.SelectedItem.ToString();
                string nombre = txt_Nombre.Text;
                int cantidad = Convert.ToInt32(nud_Cantidad.Value);
                string marca = txt_Marca.Text;
                string modelo = txt_Modelo.Text;
                float precio = Convert.ToSingle(txt_Precio.Text);
                encargado.ModificarProducto(idProducto,deporte,nombre,cantidad,marca,modelo,precio);
                MessageBox.Show("Se ha modificado un nuevo empleado correctamente");
                MessageBox.Show("Por favor... liste nuevamente los empleados para visualizar los cambios");
                txt_IdProducto.Text = "";
                txt_Nombre.Text = "";
                nud_Cantidad.Value = 0;
                txt_Marca.Text = "";
                txt_Modelo.Text = "";
                txt_Precio.Text = "";
                cbo_Deporte.DataSource = null;
                btn_CerrarSesion.Enabled = true;
                btn_SeleccionarProducto.Enabled = false;
                btn_AgregarProducto.Enabled = false;
                btn_ModificarProducto.Enabled = false;
                btn_EliminarProducto.Enabled = false;
                btn_ListarProductos.Enabled = true;
                btn_GuardarCambios.Enabled = false;
                btn_CancelarCambios.Enabled = false;
                dgv_Deposito.Enabled = false;
                txt_IdProducto.Enabled = false;
                cbo_Deporte.Enabled = false;
                txt_Nombre.Enabled = false;
                txt_Marca.Enabled = false;
                txt_Modelo.Enabled = false;
                txt_Precio.Enabled = false;
                nud_Cantidad.Enabled = false;
                decision = 1;
            }
        }

        private void btn_eliminarProducto_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Esta eliminando el empleado seleccionado ¿esta seguro?", "Eliminar Empleado", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly, false);
            if (r == DialogResult.Yes)
            {
                DataGridViewRow row = dgv_Deposito.CurrentRow;
                int idProducto = Convert.ToInt32(row.Cells["ColIdProducto"].Value);
                BLL.EncargadoBLL encargado = new BLL.EncargadoBLL();
                encargado.EliminarProducto(idProducto);
                MessageBox.Show("Se elimino el empleado");
                txt_IdProducto.Text = "";
                txt_Nombre.Text = "";
                nud_Cantidad.Value = 0;
                txt_Marca.Text = "";
                txt_Modelo.Text = "";
                txt_Precio.Text = "";
                btn_CerrarSesion.Enabled = true;
                btn_SeleccionarProducto.Enabled = false;
                btn_AgregarProducto.Enabled = false;
                btn_ModificarProducto.Enabled = false;
                btn_EliminarProducto.Enabled = false;
                btn_ListarProductos.Enabled = true;
                btn_GuardarCambios.Enabled = false;
                btn_CancelarCambios.Enabled = false;
                dgv_Deposito.Enabled = false;
                txt_IdProducto.Enabled = false;
                cbo_Deporte.Enabled = false;
                txt_Nombre.Enabled = false;
                txt_Marca.Enabled = false;
                txt_Modelo.Enabled = false;
                txt_Precio.Enabled = false;
                cbo_Deporte.DataSource = null;
                cbo_Deporte.Enabled = false;
                dgv_Deposito.DataSource = null;
            }
            else
            {
                MessageBox.Show("Ok, siga con lo que estaba haciendo");
            }
        }

        private void btn_ListarProductos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SE HAN LISTADO LOS PRODUCTOS");
            dgv_Deposito.Enabled = true;
            btn_SeleccionarProducto.Enabled = true;
            btn_AgregarProducto.Enabled = true;
            BLL.EncargadoBLL encargado = new BLL.EncargadoBLL();
            ConfigurarDataGridViewColumnasPorCodigo();
            dgv_Deposito.DataSource = encargado.ListarProductos();
        }
        private void ConfigurarDataGridViewColumnasPorCodigo()
        {
            dgv_Deposito.AutoGenerateColumns = false; // Desactivar auto-generación
            dgv_Deposito.Columns.Clear(); // Limpiar columnas existentes
            dgv_Deposito.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColIdProducto", HeaderText = "ID", DataPropertyName = "Id_producto" });
            dgv_Deposito.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColIdDeporte", HeaderText = "Deporte", DataPropertyName = "Deporte" });
            dgv_Deposito.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColNombre", HeaderText = "Nombre", DataPropertyName = "Nombre" });
            dgv_Deposito.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColCantidad", HeaderText = "Cantidad", DataPropertyName = "Cantidad" });
            dgv_Deposito.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColMarca", HeaderText = "Marca", DataPropertyName = "Marca" });
            dgv_Deposito.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColModelo", HeaderText = "Modelo", DataPropertyName = "Modelo" });
            dgv_Deposito.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColPrecio", HeaderText = "Precio", DataPropertyName = "Precio" });
        }

        private void btn_GuardarCambios_Click(object sender, EventArgs e)
        {
            BLL.EncargadoBLL encargado = new BLL.EncargadoBLL();
            Producto producto = new Producto
            {
                Nombre = txt_Nombre.Text,
                Marca = txt_Marca.Text,
                Modelo = txt_Modelo.Text,
                Cantidad = Convert.ToInt32(nud_Cantidad.Value),
                Precio = Convert.ToSingle(txt_Precio.Text),
                Deporte = new Deporte
                {
                    Id_Deporte = ObtenerIdDeporteDesdeNombre(cbo_Deporte.SelectedItem.ToString()),
                    Nombre = cbo_Deporte.SelectedItem.ToString()
                }
            };

            encargado.AgregarProducto(producto);

            MessageBox.Show("Se ha agregado un nuevo producto correctamente");
            MessageBox.Show("Por favor... liste nuevamente los productos para visualizar los cambios");
            txt_IdProducto.Text = "";
            txt_Nombre.Text = "";
            txt_Marca.Text = "";
            txt_Modelo.Text = "";
            nud_Cantidad.Value = 0;
            txt_Precio.Text = "";
            dgv_Deposito.Enabled = false;
            btn_CerrarSesion.Enabled = true;
            btn_SeleccionarProducto.Enabled = false;
            btn_AgregarProducto.Enabled = false;
            btn_ModificarProducto.Enabled = false;
            btn_EliminarProducto.Enabled = false;
            btn_ListarProductos.Enabled = true;
            btn_CancelarCambios.Enabled = false;
            btn_GuardarCambios.Enabled = false;
            txt_IdProducto.Enabled = false;
            txt_Nombre.Enabled = false;
            txt_Marca.Enabled = false;
            txt_Modelo.Enabled = false;
            nud_Cantidad.Enabled = false;
            txt_Precio.Enabled = false;
            cbo_Deporte.Enabled = false;
            dgv_Deposito.DataSource = null;
            
        }

        private void btn_CancelarCambios_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Si cancela, se tendra que listar todo otra vez ¿esta seguro?", "Cancelar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly, false);
            if (r == DialogResult.Yes)
            {
                MessageBox.Show("Se cancela el proceso");
                txt_IdProducto.Text = "";
                txt_Nombre.Text = "";
                txt_Marca.Text = "";
                txt_Modelo.Text = "";
                nud_Cantidad.Value = 0;
                btn_CerrarSesion.Enabled = true;
                btn_SeleccionarProducto.Enabled = false;
                btn_AgregarProducto.Enabled = false;
                btn_ModificarProducto.Enabled = false;
                btn_EliminarProducto.Enabled = false;
                btn_ListarProductos.Enabled = true;
                btn_GuardarCambios.Enabled = false;
                btn_CancelarCambios.Enabled = false;
                dgv_Deposito.Enabled = false;
                txt_IdProducto.Enabled = false;
                txt_Nombre.Enabled = false;
                txt_Marca.Enabled = false;
                txt_Modelo.Enabled = false;
                nud_Cantidad.Enabled = false;
                txt_Precio.Enabled = false;
                cbo_Deporte.Enabled = false;
                dgv_Deposito.DataSource = null;
            }
            else
            {
                MessageBox.Show("Ok, siga con lo que estaba haciendo");
            }
        }
    }
}
