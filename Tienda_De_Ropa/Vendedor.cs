using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tienda_De_Ropa
{
    
    public partial class Vendedor: Form
    {
        BLL.Metodo_de_pago metodo = new BLL.Metodo_de_pago();
        BLL.Vendedor vendedor = new BLL.Vendedor();
        List <string> productos = new List<string>();
        List <int> cantidadProducto = new List<int>();
        List <float> precios = new List<float>();
        

        public Vendedor(string user, string pass)
        {
            InitializeComponent();
            //OBTIENE EL ID_EMPLEADO DE UN VENDEDOR
            txt_IdVendedor.Text=vendedor.ObtenerIdVendedor(user,pass).ToString();
            //OBTIENE EL ID_EMPLEADO DE UN VENDEDOR

        }
        private void Vendedor_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void btn_GenerarVenta_Click(object sender, EventArgs e)
        {
            //cargarDatos();// CARGA LOS NOMBRES, CANTIDADES Y PRECIOS DE LOS PRODUCTOS EN LISTAS
            mostrarDatosDeProductos();//MUESTRA POR CONSOLA
            mostrarDatosDeCantidadesDeProductos();//MUESTRA POR CONSOLA
            mostrarDatosDePreciosUnitariosDeProductos();//MUESTRA POR CONSOLA
            ConfigurarDataGridViewColumnasPorCodigo();//LIMPIA LA TABLA DEL DGV
            txt_ApellidoCliente.Enabled = true;
            txt_NombreCliente.Enabled = true;
            txt_DniCliente.Enabled = true;
            cbo_MetodoDePago.Enabled = true;
            cbo_Producto.Enabled = true;
            nud_Cantidad.Enabled = false;
            txt_Precio.Enabled = false;
            txt_Total.Enabled = false;
            btn_AgregarProductoALista.Enabled = true;
            btn_ConfirmarVenta.Enabled = true;
            btn_CancelarVenta.Enabled = true;
            btn_EliminarProductoDeLista.Enabled = true;
            btn_GenerarVenta.Enabled = false;
            btn_CerrarSesion.Enabled = false;
            txt_Fecha.Text = DateTime.Now.ToString("dd MM yyyy");
            cbo_MetodoDePago.DataSource = metodo.ObtenerMetodoDePago();//OBTIENE METODOS DE PAGO
            nud_Cantidad.Value = 0;
            txt_Precio.Text = "";
            dgv_ProductosCargados.Enabled = true;
            dgv_ProductosCargados.DataSource = null;
            txt_Total.Text = "0";
        }
        private void btn_AgregarProductoALista_Click(object sender, EventArgs e)
        {
            string nombreP = cbo_Producto.Text;
            int cantidadP= (int)nud_Cantidad.Value;
            ModificarDatos();
            float precioP = Convert.ToSingle(txt_Precio.Text);
            dgv_ProductosCargados.Rows.Add(nombreP, cantidadP, vendedor.ObtenerPrecioUnitario(nombreP), precioP);
            txt_Total.Text = (Convert.ToInt32(txt_Total.Text) + Convert.ToInt32(txt_Precio.Text)).ToString();
            cbo_Producto.Items.Clear();
            cbo_Producto.SelectedItem = null;
            nud_Cantidad.Value = 0;

        }
        private void btn_CancelarVenta_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Si le da que si, se cancelara toda la venta para el cliente ¿ESTA SEGURO?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly, false);
            if (r == DialogResult.Yes)
            {
                //dgv_ProductosCargados.DataSource = null;
                //cbo_Producto.DataSource = null;
                MessageBox.Show("SE HA CANCELADO LA VENTA");
                //LIMPIA LOS DATOS DE LOS TXT Y LOS CBO
                txt_IdVendedor.Clear();
                txt_IdVenta.Clear();
                txt_ApellidoCliente.Clear();
                txt_NombreCliente.Clear();
                txt_ClienteNro.Clear();
                txt_DniCliente.Clear();
                txt_Fecha.Clear();
                txt_Total.Clear();
                nud_Cantidad.Value = 0;
                txt_Precio.Clear();

                //ARMAR CONSULTA SQL PARA LIMPIAR LA TABLA DE VENTAS DEL CLIENTE
                //LIMPIA LOS DATOS DE LOS TXT Y LOS CBO

                //DESHABILITA EL USO DE LA INTERAZ
                txt_IdVendedor.Enabled = false;
                txt_IdVenta.Enabled = false;
                txt_ApellidoCliente.Enabled = false;
                txt_NombreCliente.Enabled = false;
                txt_ClienteNro.Enabled = false;
                txt_DniCliente.Enabled = false;
                txt_Fecha.Enabled = false;
                cbo_MetodoDePago.Enabled = false;
                txt_Total.Enabled = false;
                cbo_Producto.Enabled = false;
                nud_Cantidad.Enabled = false;
                txt_Precio.Enabled = false;
                btn_AgregarProductoALista.Enabled = false;
                btn_ConfirmarVenta.Enabled = false;
                btn_CancelarVenta.Enabled = false;
                btn_EliminarProductoDeLista.Enabled = false;
                btn_CerrarSesion.Enabled = true;
                btn_GenerarVenta.Enabled = true;
                dgv_ProductosCargados.Enabled = false;
                dgv_ProductosCargados.DataSource = null;
                txt_Total.Text = "0";
                //ARMAR CONSULTA SQL PARA LIMPIAR LA TABLA DE VENTAS DEL CLIENTE
                //DESHABILITA EL USO DE LA INTERAZ
            }
            else
            {
                MessageBox.Show("El sistema seguira en funcionamiento");
            }
        }
        private void btn_CerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Seguro que desea cerrar sesion?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly, false);
            if (r == DialogResult.Yes)
            {
                MessageBox.Show("Cerrando sesion...");
                this.Hide();
                Iniciar_Sesion iniciar_sesion = new Iniciar_Sesion();
                iniciar_sesion.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("El sistema seguira en funcionamiento");
            }
        }


        private void label10_Click(object sender, EventArgs e)
        {
            
        }

        private void txt_Fecha_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_ConfirmarVenta_Click(object sender, EventArgs e)
        {
            //EN SQL CARGAR TODAS LAS VENTAS DE UN CLIENTE
        }
        private void btn_EliminarProductoDeLista_Click(object sender, EventArgs e)
        {
            //HACER CCONSULTA SQL PARA ELIMINAR PRODUCTO CARGADO EN LA LISTA
        }

        private void ConfigurarDataGridViewColumnasPorCodigo()
        {
            dgv_ProductosCargados.AutoGenerateColumns = false; // Desactivar auto-generación
            dgv_ProductosCargados.Columns.Clear(); // Limpiar columnas existentes
            dgv_ProductosCargados.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColProducto", HeaderText = "Producto", DataPropertyName = "Producto" });
            dgv_ProductosCargados.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColCantidad", HeaderText = "Cantidad", DataPropertyName = "Cantidad" });
            dgv_ProductosCargados.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColPrecioUnitario", HeaderText = "Precio Unitario", DataPropertyName = "PrecioUnitario" });
            dgv_ProductosCargados.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColTotal", HeaderText = "Total", DataPropertyName = "Total" });
        }

        private void cbo_Producto_SelectedIndexChanged(object sender, EventArgs e)
        {
            string producto= cbo_Producto.Text;
            int cantidad = 0;
            foreach (string fila in productos)
            {
                if (fila.Equals(cbo_Producto.SelectedItem.ToString()))//SI EL PRODUCTO SE LLAMA IGUAL ENTONCES...
                {
                    for (int i = 0; i < productos.Count; i++) {
                        cantidad = cantidadProducto[i];
                        nud_Cantidad.Value = cantidad;
                        nud_Cantidad.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("El producto seleccionado no tiene cantidad disponible");
                }
            }

        }
        private void nud_Cantidad_ValueChanged(object sender, EventArgs e)
        {
            string producto = cbo_Producto.Text;
            decimal precio= vendedor.ObtenerPrecioUnitario(producto) * nud_Cantidad.Value;
            int cantMax= Convert.ToInt32(vendedor.ObtenerCantidad(producto));
            if (nud_Cantidad.Value>cantMax) {
                MessageBox.Show("OJO QUE LA CANTIDAD QUE ELIGIO SUPERA LA EXISTENCIA DEL PRODUCTO");
                nud_Cantidad.Value = cantMax; 
                precio = vendedor.ObtenerPrecioUnitario(producto) * nud_Cantidad.Value;
            }
            else { 
                
            }
            txt_Precio.Text = precio.ToString();
        }
        private void txt_Precio_TextChanged(object sender, EventArgs e)
        {
            //EL PRECIO SERA MODIFICADO DE ACUERDO A LA CANTIDAD QUE ELIGA EL USUARIO
        }
        private void cargarDatos()
        {//  CARGA LOS NOMBRES, CANTIDADES Y PRECIOS DE LOS PRODUCTOS EN LISTAS DESDE EL SQL
            int alternador = 1;
            if (alternador == 1)
            {
                productos.AddRange(vendedor.ObtenerProducto());
                cantidadProducto.AddRange(vendedor.ObtenerCantidadDeTodosLosProductos());
                precios.AddRange(vendedor.ObtenerTodosLosPreciosUnitarios());
                foreach (string fila in productos)
                {
                    cbo_Producto.Items.Add(fila);
                }
                alternador--;
            }
            else {
                cbo_Producto.Items.Clear();
                cbo_Producto.SelectedItem = null;
                nud_Cantidad.Value = 0;
                alternador++;
            }
            
        }//  CARGA LOS NOMBRES, CANTIDADES Y PRECIOS DE LOS PRODUCTOS EN LISTAS DESDE EL SQL
        private void ModificarDatos()
        {//MODIFICA LAS LISTAS DE PRODUCTOS, CANTIDADES Y PRECIOS
            string producto = cbo_Producto.Text;
            int cantidadPorUsuario = (int)nud_Cantidad.Value;
            for (int i = 0; i < cantidadProducto.Count; i++)
            {
                if (cbo_Producto.SelectedItem.Equals(productos[i]))
                {
                    cantidadProducto[i] = cantidadProducto[i]-cantidadPorUsuario;
                    if (cantidadProducto[i] == 0)
                    {
                        MessageBox.Show("SE ELIMINARA EL PRODUCTO == " + productos[i]);
                        productos[i].Remove(i);
                        cantidadProducto.RemoveAt(i);
                        precios.RemoveAt(i);
                        
                    }
                    else {
                         
                        Console.WriteLine("AUN HAY DISPONIBILIDAD DEL PRODUCTO " + cantidadProducto[i]);
                    }
                    
                }
            }
        }
        // Muestra los datos de los productos, cantidades y precios por consola
        private void mostrarDatosDeProductos() {
            for (int i=0;i<productos.Count;i++)
            Console.WriteLine("ACA SE IMPRIME EL NOMBRE QUE CONTIENE PRODUCTOS I  " + productos[i]);
        }
        private void mostrarDatosDeCantidadesDeProductos()
        {
            for (int i = 0; i < cantidadProducto.Count; i++)
                Console.WriteLine("ACA SE IMPRIME LA CANTIDAD DE CADA PRODUCTO  " + cantidadProducto[i]);
        }
        private void mostrarDatosDePreciosUnitariosDeProductos()
        {
            for (int i = 0; i < precios.Count; i++)
                Console.WriteLine("ACA SE IMPRIME LA CANTIDAD DE CADA PRODUCTO  " + precios[i]);
        }

        private void btn_ListarProductos_Click(object sender, EventArgs e)
        {
            cbo_Producto.Items.Clear();
            cbo_Producto.SelectedItem = null;
            nud_Cantidad.Value = 0;
            cargarDatos();
        }
        // Muestra los datos de los productos, cantidades y precios por consola

    }
}
