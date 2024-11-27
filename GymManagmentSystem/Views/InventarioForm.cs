using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GymManagmentSystem.Views; 

namespace GymManagementSystem
{
    public partial class InventarioForm : Form
    {
        public InventarioForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Configuración del formulario
            this.Text = "Gestión de Inventario";
            this.ClientSize = new System.Drawing.Size(600, 500);

            // Título
            Label lblTitulo = new Label
            {
                Text = "Inventario de Máquinas",
                Location = new Point(20, 20),
                Font = new Font("Arial", 14, FontStyle.Bold)
            };

            // Lista para mostrar las máquinas
            ListBox lstInventario = new ListBox
            {
                Location = new Point(20, 60),
                Width = 540,
                Height = 350
            };

            
            List<(string maquina, DateTime fechaFinVida)> inventario = new List<(string, DateTime)>
            {
                ("Cinta de correr", DateTime.Now.AddMonths(2)),
                ("Bicicleta estática", DateTime.Now.AddMonths(6)),
                ("Máquina de remo", DateTime.Now.AddMonths(1)),
                ("Elíptica", DateTime.Now.AddMonths(4)),
                ("Pesas libres", DateTime.Now.AddMonths(12)),
                ("Máquina de abdominales", DateTime.Now.AddMonths(3)),
                ("Máquina de prensa", DateTime.Now.AddMonths(5)),
                ("Banco de pesas", DateTime.Now.AddMonths(8)),
                ("Máquina de estiramiento", DateTime.Now.AddMonths(10)),
                ("Cuerda para saltar", DateTime.Now.AddMonths(11)),
                ("Máquina de tracción dorsal", DateTime.Now.AddMonths(3)),
                ("Máquina de pectorales", DateTime.Now.AddMonths(7)),
                ("Máquina de piernas", DateTime.Now.AddMonths(2)),
                ("Máquina de glúteos", DateTime.Now.AddMonths(9)),
                ("Máquina Smith", DateTime.Now.AddMonths(1)),
                ("Máquina de polea alta", DateTime.Now.AddMonths(5)),
                ("Máquina de extensión de piernas", DateTime.Now.AddMonths(3)),
                ("Máquina de curl de piernas", DateTime.Now.AddMonths(4)),
                ("Máquina de aductores", DateTime.Now.AddMonths(6)),
                ("Máquina de abductores", DateTime.Now.AddMonths(2))
            };

            
            foreach (var item in inventario)
            {
                string status = item.fechaFinVida <= DateTime.Now.AddMonths(3)
                    ? "(¡Revisión Necesaria!)"
                    : "(En buen estado)";
                lstInventario.Items.Add($"{item.maquina} - Vida útil hasta: {item.fechaFinVida.ToShortDateString()} {status}");
            }

            // Botón para ver reportes
            Button btnReportes = new Button
            {
                Text = "Ver Reportes",
                Location = new Point(50, 430),
                Width = 120
            };
            btnReportes.Click += (sender, e) =>
            {
                ReportesForm reportesForm = new ReportesForm();
                reportesForm.ShowDialog();
            };

            // Botón "Clientes" para abrir ExcelController
            Button btnClientes = new Button
            {
                Text = "Clientes",
                Location = new Point(200, 430),
                Width = 120
            };
            btnClientes.Click += (sender, e) =>
            {
                ExcelController excelController = new ExcelController();
                excelController.ShowDialog();
            };

            // Botón "Ver Reservas" para abrir un formulario con las reservas de clases
            Button btnVerReservas = new Button
            {
                Text = "Ver Reservas",
                Location = new Point(350, 430),
                Width = 120
            };
            btnVerReservas.Click += (sender, e) =>
            {
                VerReservasForm verReservasForm = new VerReservasForm();
                verReservasForm.ShowDialog();
            };

            // Botón para cerrar sesión
            Button btnCerrarSesion = new Button
            {
                Text = "Cerrar Sesión",
                Location = new Point(500, 430),
                Width = 120
            };
            btnCerrarSesion.Click += (sender, e) =>
            {
                this.Close(); // Cierra el formulario actual
            };

            // Botón para volver al login
            Button btnVolverLogin = new Button
            {
                Text = "Volver al Login",
                Location = new Point(500, 430),
                Width = 120
            };
            btnVolverLogin.Click += (sender, e) =>
            {
                this.Hide(); // Esconde este formulario
                Form1 loginForm = new Form1(); // Crea una nueva instancia de Form1
                loginForm.ShowDialog(); // Muestra Form1 como diálogo
                this.Close(); // Cierra este formulario después de volver al login
            };

            // Agregar controles al formulario
            this.Controls.Add(lblTitulo);
            this.Controls.Add(lstInventario);
            this.Controls.Add(btnReportes);
            this.Controls.Add(btnClientes);
            this.Controls.Add(btnCerrarSesion);
            this.Controls.Add(btnVolverLogin);
            this.Controls.Add(btnVerReservas); // Agregar el botón para ver las reservas
        }
    }
}
