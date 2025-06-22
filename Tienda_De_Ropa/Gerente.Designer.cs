namespace Tienda_De_Ropa
{
    partial class Gerente
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
            this.label4 = new System.Windows.Forms.Label();
            this.btn_CerrarSesion = new System.Windows.Forms.Button();
            this.btn_ListarVentas = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbo_OrdenarPor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_DetalleBusqueda = new System.Windows.Forms.TextBox();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.btn_Aplicar = new System.Windows.Forms.Button();
            this.dgv_Ventas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Ventas)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Yellow;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 30.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(295, 17);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(229, 72);
            this.label4.TabIndex = 12;
            this.label4.Text = "Gerente";
            // 
            // btn_CerrarSesion
            // 
            this.btn_CerrarSesion.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CerrarSesion.Location = new System.Drawing.Point(16, 15);
            this.btn_CerrarSesion.Margin = new System.Windows.Forms.Padding(4);
            this.btn_CerrarSesion.Name = "btn_CerrarSesion";
            this.btn_CerrarSesion.Size = new System.Drawing.Size(108, 74);
            this.btn_CerrarSesion.TabIndex = 13;
            this.btn_CerrarSesion.Text = "Cerrar Sesion";
            this.btn_CerrarSesion.UseVisualStyleBackColor = true;
            this.btn_CerrarSesion.Click += new System.EventHandler(this.btn_CerrarSesion_Click);
            // 
            // btn_ListarVentas
            // 
            this.btn_ListarVentas.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ListarVentas.Location = new System.Drawing.Point(671, 17);
            this.btn_ListarVentas.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ListarVentas.Name = "btn_ListarVentas";
            this.btn_ListarVentas.Size = new System.Drawing.Size(97, 71);
            this.btn_ListarVentas.TabIndex = 14;
            this.btn_ListarVentas.Text = "Listar Ventas";
            this.btn_ListarVentas.UseVisualStyleBackColor = true;
            this.btn_ListarVentas.Click += new System.EventHandler(this.btn_ListarVentas_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Menu;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(16, 96);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(752, 12);
            this.panel1.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Yellow;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 121);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 38);
            this.label1.TabIndex = 56;
            this.label1.Text = "Ordenar por:";
            // 
            // cbo_OrdenarPor
            // 
            this.cbo_OrdenarPor.Enabled = false;
            this.cbo_OrdenarPor.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_OrdenarPor.FormattingEnabled = true;
            this.cbo_OrdenarPor.Items.AddRange(new object[] {
            "Mas Vendido",
            "Menos Vendido",
            "Ventas por Vendedor"});
            this.cbo_OrdenarPor.Location = new System.Drawing.Point(316, 123);
            this.cbo_OrdenarPor.Margin = new System.Windows.Forms.Padding(4);
            this.cbo_OrdenarPor.Name = "cbo_OrdenarPor";
            this.cbo_OrdenarPor.Size = new System.Drawing.Size(343, 37);
            this.cbo_OrdenarPor.TabIndex = 57;
            this.cbo_OrdenarPor.SelectedIndexChanged += new System.EventHandler(this.cbo_OrdenarPor_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Yellow;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 166);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(238, 38);
            this.label2.TabIndex = 58;
            this.label2.Text = "Buscar en venta:";
            // 
            // txt_DetalleBusqueda
            // 
            this.txt_DetalleBusqueda.Enabled = false;
            this.txt_DetalleBusqueda.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.txt_DetalleBusqueda.Location = new System.Drawing.Point(316, 168);
            this.txt_DetalleBusqueda.Margin = new System.Windows.Forms.Padding(4);
            this.txt_DetalleBusqueda.Name = "txt_DetalleBusqueda";
            this.txt_DetalleBusqueda.Size = new System.Drawing.Size(343, 35);
            this.txt_DetalleBusqueda.TabIndex = 59;
            this.txt_DetalleBusqueda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Enabled = false;
            this.btn_Buscar.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Buscar.Location = new System.Drawing.Point(672, 169);
            this.btn_Buscar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(96, 38);
            this.btn_Buscar.TabIndex = 60;
            this.btn_Buscar.Text = "Buscar";
            this.btn_Buscar.UseVisualStyleBackColor = true;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // btn_Aplicar
            // 
            this.btn_Aplicar.Enabled = false;
            this.btn_Aplicar.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Aplicar.Location = new System.Drawing.Point(672, 123);
            this.btn_Aplicar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Aplicar.Name = "btn_Aplicar";
            this.btn_Aplicar.Size = new System.Drawing.Size(96, 38);
            this.btn_Aplicar.TabIndex = 61;
            this.btn_Aplicar.Text = "Aplicar";
            this.btn_Aplicar.UseVisualStyleBackColor = true;
            this.btn_Aplicar.Click += new System.EventHandler(this.btn_Aplicar_Click);
            // 
            // dgv_Ventas
            // 
            this.dgv_Ventas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Ventas.Enabled = false;
            this.dgv_Ventas.Location = new System.Drawing.Point(16, 212);
            this.dgv_Ventas.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_Ventas.Name = "dgv_Ventas";
            this.dgv_Ventas.RowHeadersWidth = 51;
            this.dgv_Ventas.Size = new System.Drawing.Size(752, 267);
            this.dgv_Ventas.TabIndex = 62;
            // 
            // Gerente
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(777, 494);
            this.Controls.Add(this.dgv_Ventas);
            this.Controls.Add(this.btn_Aplicar);
            this.Controls.Add(this.btn_Buscar);
            this.Controls.Add(this.txt_DetalleBusqueda);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbo_OrdenarPor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_ListarVentas);
            this.Controls.Add(this.btn_CerrarSesion);
            this.Controls.Add(this.label4);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Gerente";
            this.Text = "Gerente";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Ventas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_CerrarSesion;
        private System.Windows.Forms.Button btn_ListarVentas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbo_OrdenarPor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_DetalleBusqueda;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.Button btn_Aplicar;
        private System.Windows.Forms.DataGridView dgv_Ventas;
    }
}