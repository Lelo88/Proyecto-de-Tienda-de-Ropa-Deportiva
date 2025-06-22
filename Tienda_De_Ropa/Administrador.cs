using BLL;
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
    public partial class Administrador: Form
    {
        public int decision = 1;
        public Administrador()
        {
            InitializeComponent();
            
            
            
        }

        private void button3_Click(object sender, EventArgs e)
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
        private void btn_ListarEmpleados_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SE HAN LISTADO LOS EMPLEADOS");
            dgv_Empleados.Enabled = true;
            btn_SeleccionarEmpleado.Enabled = true;
            btn_AgregarEmpleado.Enabled = true;
            BLL.Administrador administrador = new BLL.Administrador();
            ConfigurarDataGridViewColumnasPorCodigo();
            dgv_Empleados.DataSource = administrador.Listar_empleados();

        }
        private void ConfigurarDataGridViewColumnasPorCodigo()
        {
            dgv_Empleados.AutoGenerateColumns = false; // Desactivar auto-generación
            dgv_Empleados.Columns.Clear(); // Limpiar columnas existentes
            dgv_Empleados.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColIdEmpleado", HeaderText = "ID", DataPropertyName = "Id_empleado" });
            dgv_Empleados.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColTipoEmpleado", HeaderText = "Tipo de Empleado", DataPropertyName = "ID_TIPO_EMPLEADO" });
            dgv_Empleados.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColDescripcion", HeaderText = "Descripcion", DataPropertyName = "Descripcion" });
            dgv_Empleados.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColNombre", HeaderText = "Nombre", DataPropertyName = "Nombre" });
            dgv_Empleados.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColApelido", HeaderText = "Apellido", DataPropertyName = "Apelido" });
            dgv_Empleados.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColDni", HeaderText = "DNI", DataPropertyName = "Dni" });
            dgv_Empleados.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColUsuario", HeaderText = "Usuario", DataPropertyName = "Usuario" });
            dgv_Empleados.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColContraseña", HeaderText = "Contraseña", DataPropertyName = "Contraseña" });
        }
        private void btn_SeleccionarEmpleado_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgv_Empleados.CurrentRow;
            btn_ModificarEmpleado.Enabled = true;
            btn_EliminarEmpleado.Enabled = true;
            cbo_tipoDeEmpleado.Enabled = false;
            int idEmpleado = Convert.ToInt32(row.Cells["ColIdEmpleado"].Value);
            string descripcion = row.Cells["ColDescripcion"].Value.ToString();
            string nombre = row.Cells["ColNombre"].Value.ToString();
            string apellido = row.Cells["ColApelido"].Value.ToString();
            string dni = row.Cells["ColDni"].Value.ToString();
            string usuario = row.Cells["ColUsuario"].Value.ToString();
            string contrasena = row.Cells["ColContraseña"].Value.ToString();
            txt_idEmpleado.Text = idEmpleado.ToString();
            cbo_tipoDeEmpleado.SelectedItem = descripcion;
            txt_nombre.Text = nombre;
            txt_apellido.Text = apellido;
            txt_dni.Text = dni;
            txt_usuario.Text = usuario;
            txt_contrasenia.Text = contrasena;
        }

        private void btn_AgregarEmpleado_Click(object sender, EventArgs e)
        {
            BLL.Tipo_empleado tipo_Empleado = new BLL.Tipo_empleado();
            MessageBox.Show("Llene a continuacion los campos para agregar un nuevo empleado");
            dgv_Empleados.Enabled = false;
            btn_GuardarCambios.Enabled = true;
            btn_CancelarCambios.Enabled = true;
            btn_ListarEmpleados.Enabled = false;
            btn_AgregarEmpleado.Enabled = false;
            btn_CerrarSesion.Enabled = false; 
            btn_SeleccionarEmpleado.Enabled = false;
            btn_ModificarEmpleado.Enabled = false;  
            txt_nombre.Enabled = true;
            txt_apellido.Enabled = true;
            txt_dni.Enabled = true;
            txt_usuario.Enabled = true;
            txt_contrasenia.Enabled = true;
            txt_idEmpleado.Enabled = false;
            txt_idEmpleado.Text = "";
            txt_nombre.Text = "";
            txt_apellido.Text = "";
            txt_dni.Text = "";
            txt_usuario.Text = "";
            txt_contrasenia.Text = "";
            cbo_tipoDeEmpleado.Enabled = true;
            cbo_tipoDeEmpleado.DataSource = tipo_Empleado.obtenerTiposDeEmpleado();

        }
        private void btn_GuardarCambios_Click(object sender, EventArgs e)
        {
            BLL.Administrador administrador = new BLL.Administrador();
            string descripcion = cbo_tipoDeEmpleado.SelectedItem.ToString();
            string nombre = txt_nombre.Text;
            string apellido = txt_apellido.Text;
            string dni = txt_dni.Text;
            string usuario = txt_usuario.Text;
            string contraseña = txt_contrasenia.Text;
            administrador.Alta_de_empleado(descripcion, nombre, apellido, dni, usuario, contraseña);
            txt_idEmpleado.Text = "";
            txt_nombre.Text = "";
            txt_apellido.Text = "";
            txt_dni.Text = "";
            txt_usuario.Text = "";
            txt_contrasenia.Text = "";
            btn_CerrarSesion.Enabled = true;
            btn_SeleccionarEmpleado.Enabled = false;
            btn_AgregarEmpleado.Enabled = false;
            btn_ModificarEmpleado.Enabled = false;
            btn_EliminarEmpleado.Enabled = false;
            btn_ListarEmpleados.Enabled = true;
            btn_GuardarCambios.Enabled = false;
            btn_CancelarCambios.Enabled = false;
            dgv_Empleados.Enabled = true;
            txt_nombre.Enabled = false;
            txt_apellido.Enabled = false;
            txt_dni.Enabled = false;
            txt_usuario.Enabled = false;
            txt_contrasenia.Enabled = false;
            txt_idEmpleado.Enabled = false;
            cbo_tipoDeEmpleado.Enabled = false;
            dgv_Empleados.DataSource = null;
            MessageBox.Show("Se ha agregado un nuevo empleado");
        }

        private void btn_ModificarEmpleado_Click(object sender, EventArgs e)
        {
            BLL.Tipo_empleado tipo_Empleado = new BLL.Tipo_empleado();
            if (decision==1)
            {
                MessageBox.Show("Se habilito la modificacion de un empleado");
                MessageBox.Show("Presione cancelar si quiere dejarlo como esta");
                MessageBox.Show("Presione modificar empleado para aplicar los cambios");
                DataGridViewRow row = dgv_Empleados.CurrentRow;
                btn_ModificarEmpleado.Enabled = true;
                btn_EliminarEmpleado.Enabled = false;
                btn_AgregarEmpleado.Enabled = false;
                btn_CerrarSesion.Enabled = false;
                btn_SeleccionarEmpleado.Enabled = false;
                btn_CancelarCambios.Enabled = true;
                cbo_tipoDeEmpleado.Enabled = true;
                //cbo_tipoDeEmpleado.Items.Clear();
                //cbo_tipoDeEmpleado.SelectedItem = "";
                //cbo_tipoDeEmpleado.Items.Remove(cbo_tipoDeEmpleado.SelectedItem);
                cbo_tipoDeEmpleado.DataSource = tipo_Empleado.obtenerTiposDeEmpleado();
                int idEmpleado = Convert.ToInt32(row.Cells["ColIdEmpleado"].Value);
                string descripcion = row.Cells["ColDescripcion"].Value.ToString();
                string nombre = row.Cells["ColNombre"].Value.ToString();
                string apellido = row.Cells["ColApelido"].Value.ToString();
                string dni = row.Cells["ColDni"].Value.ToString();
                string usuario = row.Cells["ColUsuario"].Value.ToString();
                string contrasena = row.Cells["ColContraseña"].Value.ToString();
                txt_idEmpleado.Text = idEmpleado.ToString();
                //cbo_tipoDeEmpleado.Items.Add(descripcion);
                cbo_tipoDeEmpleado.SelectedItem = descripcion;
                txt_nombre.Text = nombre;
                txt_apellido.Text = apellido;
                txt_dni.Text = dni;
                txt_usuario.Text = usuario;
                txt_contrasenia.Text = contrasena;
                txt_idEmpleado.Enabled = false;
                txt_nombre.Enabled = true;
                txt_apellido.Enabled = true;
                txt_dni.Enabled = true;
                txt_usuario.Enabled = true;
                txt_contrasenia.Enabled = true;
                decision = 0;
            }
            else
            {
                BLL.Administrador administrador = new BLL.Administrador();
                string idEmpleado = txt_idEmpleado.Text;
                string descripcion = cbo_tipoDeEmpleado.SelectedItem.ToString();
                string nombre = txt_nombre.Text;
                string apellido = txt_apellido.Text;
                string dni = txt_dni.Text;
                string usuario = txt_usuario.Text;
                string contraseña = txt_contrasenia.Text;
                administrador.Modificar_empleado(idEmpleado,descripcion, nombre, apellido, dni, usuario, contraseña);
                MessageBox.Show("Se ha modificado un nuevo empleado correctamente");
                MessageBox.Show("Por favor... liste nuevamente los empleados para visualizar los cambios");
                txt_idEmpleado.Text = "";
                txt_nombre.Text = "";
                txt_apellido.Text = "";
                txt_dni.Text = "";
                txt_usuario.Text = "";
                txt_contrasenia.Text = "";
                //cbo_tipoDeEmpleado.Items.Clear();
                //cbo_tipoDeEmpleado.Items.Remove(cbo_tipoDeEmpleado.SelectedItem);
                btn_CerrarSesion.Enabled = true;
                btn_SeleccionarEmpleado.Enabled = false;
                btn_AgregarEmpleado.Enabled = false;
                btn_ModificarEmpleado.Enabled = false;
                btn_EliminarEmpleado.Enabled = false;
                btn_ListarEmpleados.Enabled = true;
                btn_GuardarCambios.Enabled = false;
                btn_CancelarCambios.Enabled = false;
                dgv_Empleados.Enabled = true;
                txt_nombre.Enabled = false;
                txt_apellido.Enabled = false;
                txt_dni.Enabled = false;
                txt_usuario.Enabled = false;
                txt_contrasenia.Enabled = false;
                txt_idEmpleado.Enabled = false;
                //cbo_tipoDeEmpleado.Items.Clear();
                //cbo_tipoDeEmpleado.Items.Remove(cbo_tipoDeEmpleado.SelectedItem);
                cbo_tipoDeEmpleado.Enabled = false;
                dgv_Empleados.DataSource = null;
                decision = 1;
            }
            
        }

        private void btn_EliminarEmpleado_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Esta eliminando el empleado seleccionado ¿esta seguro?", "Eliminar Empleado", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly, false);
            if (r == DialogResult.Yes)
            {
                DataGridViewRow row = dgv_Empleados.CurrentRow;
                int idEmpleado = Convert.ToInt32(row.Cells["ColIdEmpleado"].Value);
                BLL.Administrador administrador = new BLL.Administrador();
                administrador.Baja_de_empleado(idEmpleado);
                MessageBox.Show("Se elimino el empleado");
                txt_idEmpleado.Text = "";
                txt_nombre.Text = "";
                txt_apellido.Text = "";
                txt_dni.Text = "";
                txt_usuario.Text = "";
                txt_contrasenia.Text = "";
                //cbo_tipoDeEmpleado.Items.Clear();
                //cbo_tipoDeEmpleado.Items.Remove(cbo_tipoDeEmpleado.SelectedItem);
                btn_CerrarSesion.Enabled = true;
                btn_SeleccionarEmpleado.Enabled = false;
                btn_AgregarEmpleado.Enabled = false;
                btn_ModificarEmpleado.Enabled = false;
                btn_EliminarEmpleado.Enabled = false;
                btn_ListarEmpleados.Enabled = true;
                btn_GuardarCambios.Enabled = false;
                btn_CancelarCambios.Enabled = false;
                dgv_Empleados.Enabled = false;
                txt_nombre.Enabled = false;
                txt_apellido.Enabled = false;
                txt_dni.Enabled = false;
                txt_usuario.Enabled = false;
                txt_contrasenia.Enabled = false;
                txt_idEmpleado.Enabled = false;
                //cbo_tipoDeEmpleado.Items.Clear();
                //cbo_tipoDeEmpleado.Items.Remove(cbo_tipoDeEmpleado.SelectedItem);
                cbo_tipoDeEmpleado.Enabled = false;
                dgv_Empleados.DataSource = null;
            }
            else
            {
                MessageBox.Show("Ok, siga con lo que estaba haciendo");
            }

        }

        private void btn_CancelarCambios_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Si cancela, se tendra que listar todo otra vez ¿esta seguro?", "Cancelar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly, false);
            if (r == DialogResult.Yes)
            {
                MessageBox.Show("Se cancela el proceso");
                txt_idEmpleado.Text = "";
                txt_nombre.Text = "";
                txt_apellido.Text = "";
                txt_dni.Text = "";
                txt_usuario.Text = "";
                txt_contrasenia.Text = "";
                //cbo_tipoDeEmpleado.Items.Remove(cbo_tipoDeEmpleado.SelectedItem);
                btn_CerrarSesion.Enabled = true;
                btn_SeleccionarEmpleado.Enabled = false;
                btn_AgregarEmpleado.Enabled = false;
                btn_ModificarEmpleado.Enabled = false;
                btn_EliminarEmpleado.Enabled = false;
                btn_ListarEmpleados.Enabled = true;
                btn_GuardarCambios.Enabled = false;
                btn_CancelarCambios.Enabled = false;
                dgv_Empleados.Enabled = false;
                txt_nombre.Enabled = false;
                txt_apellido.Enabled = false;
                txt_dni.Enabled = false;
                txt_usuario.Enabled = false;
                txt_contrasenia.Enabled = false;
                txt_idEmpleado.Enabled = false;
                //cbo_tipoDeEmpleado.Items.Clear();
                //cbo_tipoDeEmpleado.Items.Remove(cbo_tipoDeEmpleado.SelectedItem);
                cbo_tipoDeEmpleado.Enabled = false;
                dgv_Empleados.DataSource = null;
            }
            else
            {
                MessageBox.Show("Ok, siga con lo que estaba haciendo");
            }
        }
    }
}
