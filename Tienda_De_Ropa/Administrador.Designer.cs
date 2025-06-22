namespace Tienda_De_Ropa
{
    partial class Administrador
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_CerrarSesion = new System.Windows.Forms.Button();
            this.btn_AgregarEmpleado = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_EliminarEmpleado = new System.Windows.Forms.Button();
            this.btn_ModificarEmpleado = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_idEmpleado = new System.Windows.Forms.TextBox();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.txt_apellido = new System.Windows.Forms.TextBox();
            this.txt_dni = new System.Windows.Forms.TextBox();
            this.txt_usuario = new System.Windows.Forms.TextBox();
            this.txt_contrasenia = new System.Windows.Forms.TextBox();
            this.cbo_tipoDeEmpleado = new System.Windows.Forms.ComboBox();
            this.dgv_Empleados = new System.Windows.Forms.DataGridView();
            this.btn_SeleccionarEmpleado = new System.Windows.Forms.Button();
            this.btn_ListarEmpleados = new System.Windows.Forms.Button();
            this.btn_GuardarCambios = new System.Windows.Forms.Button();
            this.btn_CancelarCambios = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Empleados)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Yellow;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 30.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(204, 14);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(383, 72);
            this.label4.TabIndex = 11;
            this.label4.Text = "Administrador";
            // 
            // btn_CerrarSesion
            // 
            this.btn_CerrarSesion.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CerrarSesion.Location = new System.Drawing.Point(16, 11);
            this.btn_CerrarSesion.Margin = new System.Windows.Forms.Padding(4);
            this.btn_CerrarSesion.Name = "btn_CerrarSesion";
            this.btn_CerrarSesion.Size = new System.Drawing.Size(108, 74);
            this.btn_CerrarSesion.TabIndex = 12;
            this.btn_CerrarSesion.Text = "Cerrar Sesion";
            this.btn_CerrarSesion.UseVisualStyleBackColor = true;
            this.btn_CerrarSesion.Click += new System.EventHandler(this.btn_CerrarSesion_Click);
            // 
            // btn_AgregarEmpleado
            // 
            this.btn_AgregarEmpleado.Enabled = false;
            this.btn_AgregarEmpleado.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AgregarEmpleado.Location = new System.Drawing.Point(175, 125);
            this.btn_AgregarEmpleado.Margin = new System.Windows.Forms.Padding(4);
            this.btn_AgregarEmpleado.Name = "btn_AgregarEmpleado";
            this.btn_AgregarEmpleado.Size = new System.Drawing.Size(130, 74);
            this.btn_AgregarEmpleado.TabIndex = 13;
            this.btn_AgregarEmpleado.Text = "Agregar Empleado";
            this.btn_AgregarEmpleado.UseVisualStyleBackColor = true;
            this.btn_AgregarEmpleado.Click += new System.EventHandler(this.btn_AgregarEmpleado_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Yellow;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 218);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 29);
            this.label1.TabIndex = 14;
            this.label1.Text = "Empleado N°:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Menu;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(16, 105);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(752, 12);
            this.panel1.TabIndex = 15;
            // 
            // btn_EliminarEmpleado
            // 
            this.btn_EliminarEmpleado.Enabled = false;
            this.btn_EliminarEmpleado.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_EliminarEmpleado.Location = new System.Drawing.Point(483, 125);
            this.btn_EliminarEmpleado.Margin = new System.Windows.Forms.Padding(4);
            this.btn_EliminarEmpleado.Name = "btn_EliminarEmpleado";
            this.btn_EliminarEmpleado.Size = new System.Drawing.Size(130, 74);
            this.btn_EliminarEmpleado.TabIndex = 17;
            this.btn_EliminarEmpleado.Text = "Eliminar Empleado";
            this.btn_EliminarEmpleado.UseVisualStyleBackColor = true;
            this.btn_EliminarEmpleado.Click += new System.EventHandler(this.btn_EliminarEmpleado_Click);
            // 
            // btn_ModificarEmpleado
            // 
            this.btn_ModificarEmpleado.Enabled = false;
            this.btn_ModificarEmpleado.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ModificarEmpleado.Location = new System.Drawing.Point(329, 125);
            this.btn_ModificarEmpleado.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ModificarEmpleado.Name = "btn_ModificarEmpleado";
            this.btn_ModificarEmpleado.Size = new System.Drawing.Size(130, 74);
            this.btn_ModificarEmpleado.TabIndex = 18;
            this.btn_ModificarEmpleado.Text = "Modificar Empleado";
            this.btn_ModificarEmpleado.UseVisualStyleBackColor = true;
            this.btn_ModificarEmpleado.Click += new System.EventHandler(this.btn_ModificarEmpleado_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Yellow;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 258);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 29);
            this.label3.TabIndex = 27;
            this.label3.Text = "Nombres:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Yellow;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 301);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 29);
            this.label5.TabIndex = 28;
            this.label5.Text = "Apellidos:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Yellow;
            this.label6.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 339);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 29);
            this.label6.TabIndex = 29;
            this.label6.Text = "D.N.I:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Yellow;
            this.label7.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(381, 215);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(193, 29);
            this.label7.TabIndex = 30;
            this.label7.Text = "Tipo de empleado:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Yellow;
            this.label8.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(381, 258);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 29);
            this.label8.TabIndex = 31;
            this.label8.Text = "Usuario:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Yellow;
            this.label9.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(381, 301);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(127, 29);
            this.label9.TabIndex = 32;
            this.label9.Text = "Contraseña:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txt_idEmpleado
            // 
            this.txt_idEmpleado.Enabled = false;
            this.txt_idEmpleado.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.txt_idEmpleado.Location = new System.Drawing.Point(176, 215);
            this.txt_idEmpleado.Margin = new System.Windows.Forms.Padding(4);
            this.txt_idEmpleado.Name = "txt_idEmpleado";
            this.txt_idEmpleado.Size = new System.Drawing.Size(72, 35);
            this.txt_idEmpleado.TabIndex = 34;
            this.txt_idEmpleado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_nombre
            // 
            this.txt_nombre.Enabled = false;
            this.txt_nombre.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.txt_nombre.Location = new System.Drawing.Point(176, 255);
            this.txt_nombre.Margin = new System.Windows.Forms.Padding(4);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(191, 35);
            this.txt_nombre.TabIndex = 35;
            this.txt_nombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_apellido
            // 
            this.txt_apellido.Enabled = false;
            this.txt_apellido.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.txt_apellido.Location = new System.Drawing.Point(175, 298);
            this.txt_apellido.Margin = new System.Windows.Forms.Padding(4);
            this.txt_apellido.Name = "txt_apellido";
            this.txt_apellido.Size = new System.Drawing.Size(191, 35);
            this.txt_apellido.TabIndex = 36;
            this.txt_apellido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_dni
            // 
            this.txt_dni.Enabled = false;
            this.txt_dni.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.txt_dni.Location = new System.Drawing.Point(175, 341);
            this.txt_dni.Margin = new System.Windows.Forms.Padding(4);
            this.txt_dni.Name = "txt_dni";
            this.txt_dni.Size = new System.Drawing.Size(191, 35);
            this.txt_dni.TabIndex = 37;
            this.txt_dni.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_usuario
            // 
            this.txt_usuario.Enabled = false;
            this.txt_usuario.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.txt_usuario.Location = new System.Drawing.Point(582, 255);
            this.txt_usuario.Margin = new System.Windows.Forms.Padding(4);
            this.txt_usuario.Name = "txt_usuario";
            this.txt_usuario.Size = new System.Drawing.Size(178, 35);
            this.txt_usuario.TabIndex = 38;
            this.txt_usuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_contrasenia
            // 
            this.txt_contrasenia.Enabled = false;
            this.txt_contrasenia.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.txt_contrasenia.Location = new System.Drawing.Point(582, 295);
            this.txt_contrasenia.Margin = new System.Windows.Forms.Padding(4);
            this.txt_contrasenia.Name = "txt_contrasenia";
            this.txt_contrasenia.Size = new System.Drawing.Size(178, 35);
            this.txt_contrasenia.TabIndex = 39;
            this.txt_contrasenia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbo_tipoDeEmpleado
            // 
            this.cbo_tipoDeEmpleado.Enabled = false;
            this.cbo_tipoDeEmpleado.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_tipoDeEmpleado.FormattingEnabled = true;
            this.cbo_tipoDeEmpleado.Items.AddRange(new object[] {
            "Administrador",
            "Encargado",
            "Gerente",
            "Vendedor"});
            this.cbo_tipoDeEmpleado.Location = new System.Drawing.Point(582, 216);
            this.cbo_tipoDeEmpleado.Margin = new System.Windows.Forms.Padding(4);
            this.cbo_tipoDeEmpleado.Name = "cbo_tipoDeEmpleado";
            this.cbo_tipoDeEmpleado.Size = new System.Drawing.Size(178, 31);
            this.cbo_tipoDeEmpleado.TabIndex = 40;
            // 
            // dgv_Empleados
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Empleados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Empleados.BackgroundColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Empleados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Empleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Empleados.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_Empleados.Enabled = false;
            this.dgv_Empleados.Location = new System.Drawing.Point(16, 383);
            this.dgv_Empleados.Name = "dgv_Empleados";
            this.dgv_Empleados.ReadOnly = true;
            this.dgv_Empleados.RowHeadersWidth = 51;
            this.dgv_Empleados.RowTemplate.Height = 24;
            this.dgv_Empleados.Size = new System.Drawing.Size(748, 160);
            this.dgv_Empleados.TabIndex = 41;
            // 
            // btn_SeleccionarEmpleado
            // 
            this.btn_SeleccionarEmpleado.Enabled = false;
            this.btn_SeleccionarEmpleado.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SeleccionarEmpleado.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_SeleccionarEmpleado.Location = new System.Drawing.Point(16, 125);
            this.btn_SeleccionarEmpleado.Margin = new System.Windows.Forms.Padding(4);
            this.btn_SeleccionarEmpleado.Name = "btn_SeleccionarEmpleado";
            this.btn_SeleccionarEmpleado.Size = new System.Drawing.Size(130, 74);
            this.btn_SeleccionarEmpleado.TabIndex = 42;
            this.btn_SeleccionarEmpleado.Text = "Seleccionar Empleado";
            this.btn_SeleccionarEmpleado.UseVisualStyleBackColor = true;
            this.btn_SeleccionarEmpleado.Click += new System.EventHandler(this.btn_SeleccionarEmpleado_Click);
            // 
            // btn_ListarEmpleados
            // 
            this.btn_ListarEmpleados.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ListarEmpleados.Location = new System.Drawing.Point(638, 125);
            this.btn_ListarEmpleados.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ListarEmpleados.Name = "btn_ListarEmpleados";
            this.btn_ListarEmpleados.Size = new System.Drawing.Size(130, 74);
            this.btn_ListarEmpleados.TabIndex = 43;
            this.btn_ListarEmpleados.Text = "Listar Empleado";
            this.btn_ListarEmpleados.UseVisualStyleBackColor = true;
            this.btn_ListarEmpleados.Click += new System.EventHandler(this.btn_ListarEmpleados_Click);
            // 
            // btn_GuardarCambios
            // 
            this.btn_GuardarCambios.Enabled = false;
            this.btn_GuardarCambios.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GuardarCambios.Location = new System.Drawing.Point(582, 341);
            this.btn_GuardarCambios.Margin = new System.Windows.Forms.Padding(4);
            this.btn_GuardarCambios.Name = "btn_GuardarCambios";
            this.btn_GuardarCambios.Size = new System.Drawing.Size(178, 35);
            this.btn_GuardarCambios.TabIndex = 44;
            this.btn_GuardarCambios.Text = "Guardar ";
            this.btn_GuardarCambios.UseVisualStyleBackColor = true;
            this.btn_GuardarCambios.Click += new System.EventHandler(this.btn_GuardarCambios_Click);
            // 
            // btn_CancelarCambios
            // 
            this.btn_CancelarCambios.Enabled = false;
            this.btn_CancelarCambios.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CancelarCambios.Location = new System.Drawing.Point(386, 341);
            this.btn_CancelarCambios.Margin = new System.Windows.Forms.Padding(4);
            this.btn_CancelarCambios.Name = "btn_CancelarCambios";
            this.btn_CancelarCambios.Size = new System.Drawing.Size(178, 35);
            this.btn_CancelarCambios.TabIndex = 45;
            this.btn_CancelarCambios.Text = "Cancelar ";
            this.btn_CancelarCambios.UseVisualStyleBackColor = true;
            this.btn_CancelarCambios.Click += new System.EventHandler(this.btn_CancelarCambios_Click);
            // 
            // Administrador
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(777, 555);
            this.Controls.Add(this.btn_CancelarCambios);
            this.Controls.Add(this.btn_GuardarCambios);
            this.Controls.Add(this.btn_ListarEmpleados);
            this.Controls.Add(this.btn_SeleccionarEmpleado);
            this.Controls.Add(this.dgv_Empleados);
            this.Controls.Add(this.cbo_tipoDeEmpleado);
            this.Controls.Add(this.txt_contrasenia);
            this.Controls.Add(this.txt_usuario);
            this.Controls.Add(this.txt_dni);
            this.Controls.Add(this.txt_apellido);
            this.Controls.Add(this.txt_nombre);
            this.Controls.Add(this.txt_idEmpleado);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_ModificarEmpleado);
            this.Controls.Add(this.btn_EliminarEmpleado);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_AgregarEmpleado);
            this.Controls.Add(this.btn_CerrarSesion);
            this.Controls.Add(this.label4);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Administrador";
            this.Text = "Administrador";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Empleados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_CerrarSesion;
        private System.Windows.Forms.Button btn_AgregarEmpleado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_EliminarEmpleado;
        private System.Windows.Forms.Button btn_ModificarEmpleado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_idEmpleado;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.TextBox txt_apellido;
        private System.Windows.Forms.TextBox txt_dni;
        private System.Windows.Forms.TextBox txt_usuario;
        private System.Windows.Forms.TextBox txt_contrasenia;
        private System.Windows.Forms.ComboBox cbo_tipoDeEmpleado;
        private System.Windows.Forms.DataGridView dgv_Empleados;
        private System.Windows.Forms.Button btn_SeleccionarEmpleado;
        private System.Windows.Forms.Button btn_ListarEmpleados;
        private System.Windows.Forms.Button btn_GuardarCambios;
        private System.Windows.Forms.Button btn_CancelarCambios;
    }
}