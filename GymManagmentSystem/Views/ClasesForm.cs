using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GymManagementSystem
{
    public partial class ClasesForm : Form
    {
        // Lista para almacenar las reservas
        public static List<string> reservas = new List<string>();

        public ClasesForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Configuración del formulario
            this.Text = "Gestión de Clases";
            this.ClientSize = new System.Drawing.Size(600, 400);

            // Controles
            Label lblTitulo = new Label { Text = "Clases Disponibles", Location = new System.Drawing.Point(20, 20), Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold) };
            ListBox lstClases = new ListBox { Location = new System.Drawing.Point(20, 60), Width = 540, Height = 200 };
            Button btnReservar = new Button { Text = "Reservar", Location = new System.Drawing.Point(20, 280), Width = 100 };
            Button btnVolverLogin = new Button { Text = "Volver al Login", Location = new System.Drawing.Point(150, 280), Width = 120 };

            // Lista de clases (puedes adaptarla a una fuente de datos más avanzada)
            List<string> clases = new List<string>
            {
                "Zumba - Lunes 10:00 AM - Entrenador: Ana (Cupo: 15)",
                "CardioDance - Martes 6:00 PM - Entrenador: Luis (Cupo: 10)",
                "Funcionales - Miércoles 8:00 AM - Entrenador: Carlos (Cupo: 20)"
            };

            // Agregar clases a la lista
            foreach (var clase in clases)
            {
                lstClases.Items.Add(clase);
            }

            // Agregar controles al formulario
            this.Controls.Add(lblTitulo);
            this.Controls.Add(lstClases);
            this.Controls.Add(btnReservar);
            this.Controls.Add(btnVolverLogin);

            // Evento para reservar clase
            btnReservar.Click += (sender, e) =>
            {
                if (lstClases.SelectedItem != null)
                {
                    // Guardar la reserva
                    string reserva = $"Cliente: {Environment.UserName} - Clase: {lstClases.SelectedItem.ToString()}";
                    reservas.Add(reserva); // Añadir la reserva a la lista estática
                    MessageBox.Show($"Reserva exitosa para la clase: {lstClases.SelectedItem.ToString()}", "Reserva Confirmada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona una clase para reservar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };

            // Evento para volver al login
            btnVolverLogin.Click += (sender, e) =>
            {
                this.Hide(); // Esconde este formulario
                Form1 loginForm = new Form1(); // Crea una nueva instancia de Form1 (login)
                loginForm.ShowDialog(); // Muestra Form1 como diálogo
                this.Close(); // Cierra este formulario después de volver al login
            };
        }
    }
}


