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
using System.Data.SqlClient;
using System.Collections;
namespace Tienda_De_Ropa
{
    public partial class Iniciar_Sesion : Form
    {

        public Iniciar_Sesion()
        {

            InitializeComponent();

        }

        private void btn_salir_Click(object sender, EventArgs e)
        {

            DialogResult r = MessageBox.Show("¿Seguro que desea salir de la aplicación?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly, false);
            if (r == DialogResult.Yes)
            {

                MessageBox.Show("Cerrando...");
                Application.Exit();
            }
            else {

                MessageBox.Show("El sistema seguira en funcionamiento");
            }

        }

        private void btn_iniciar_Click(object sender, EventArgs e)
        {
            string user = txt_Usuario.Text;
            string pass = txt_Contrasenia.Text;
            
            BLL.Administrador administrador = new BLL.Administrador();// Instancia de la clase Administrador
            BLL.Encargado_De_Deposito encargado = new BLL.Encargado_De_Deposito();// Instancia de la clase Administrador
            BLL.Gerente gerente = new BLL.Gerente();// Instancia de la clase Administrador
            BLL.Vendedor vendedor = new BLL.Vendedor();// Instancia de la clase Administrador
            BLL.Tipo_empleado tipo_empleado = new BLL.Tipo_empleado();// Instancia de la clase Tipo_empleado

            try
            {
                if (administrador.Iniciar_Sesion(user, pass))
                {
                    MessageBox.Show("Bienvenido ADMINISTRADOR: " + user);
                    this.Hide();
                    Administrador frmadministrador = new Administrador();
                    frmadministrador.Show();
                    
                }


                if (encargado.Iniciar_Sesion(user, pass))
                {

                    MessageBox.Show("Bienvenido ENCARGADO: " + user);
                    this.Hide();
                    EncargadoDeDeposito frmencargado = new EncargadoDeDeposito();
                    frmencargado.Show();
                }

                if (gerente.Iniciar_Sesion(user, pass))
                {

                    MessageBox.Show("Bienvenido GERENTE: " + user);
                    this.Hide();
                    Gerente frmgerente = new Gerente();
                    frmgerente.Show();
                }

                if (vendedor.Iniciar_Sesion(user, pass))
                {

                    MessageBox.Show("Bienvenido VENDEDOR " + user);
                    this.Hide();
                    Vendedor frmvendedor = new Vendedor(user,pass);
                    frmvendedor.Show();

                }

                if (string.IsNullOrEmpty(txt_Usuario.Text) || string.IsNullOrEmpty(txt_Contrasenia.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar sesión. Por favor, intente nuevamente.");
                return;
            }

            
            
            
            
        }

        private void txt_usuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_contraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Iniciar_Sesion_Load(object sender, EventArgs e)
        {

        }
        private void Enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Iniciar.PerformClick();
                e.Handled = true;
            }
        }
        
        

}
}
