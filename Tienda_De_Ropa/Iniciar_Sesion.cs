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
            string user = txt_Usuario.Text.Trim();
            string pass = txt_Contrasenia.Text.Trim();

            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            try
            {
                // Instanciás cada tipo de empleado
                var administrador = new BLL.Administrador();
                var gerente = new BLL.GerenteBLL();
                var vendedor = new BLL.VendedorBLL();
                var encargado = new BLL.EncargadoBLL();

                if (administrador.IniciarSesion(user, pass))
                {
                    MessageBox.Show($"Bienvenido ADMINISTRADOR: {user}");
                    this.Hide();
                    new Administrador().Show();
                    return;
                }

                if (gerente.IniciarSesion(user, pass))
                {
                    MessageBox.Show($"Bienvenido GERENTE: {user}");
                    this.Hide();
                    new Gerente().Show();
                    return;
                }

                if (encargado.IniciarSesion(user, pass))
                {
                    MessageBox.Show($"Bienvenido ENCARGADO: {user}");
                    this.Hide();
                    new EncargadoDeDeposito().Show();
                    return;
                }

                if (vendedor.IniciarSesion(user, pass))
                {
                    MessageBox.Show($"Bienvenido VENDEDOR: {user}");
                    this.Hide();
                    new Vendedor(user, pass).Show();
                    return;
                }

                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar sesión: " + ex.Message);
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
