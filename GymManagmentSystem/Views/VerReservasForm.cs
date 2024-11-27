using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GymManagementSystem
{
    public partial class VerReservasForm : Form
    {
        public VerReservasForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Reservas de Clases";
            this.ClientSize = new System.Drawing.Size(600, 400);

            // Panel para mostrar las reservas
            Panel panelReservas = new Panel
            {
                Location = new Point(10, 10),
                Size = new Size(560, 300),
                AutoScroll = true
            };

            Button btnCerrar = new Button
            {
                Text = "Cerrar",
                Location = new Point(250, 320),
                Width = 100
            };
            btnCerrar.Click += (sender, e) =>
            {
                this.Close();
            };

            // Agregar las reservas al panel
            int yPosition = 10;
            foreach (var reserva in ClasesForm.reservas)
            {
                Label lblReserva = new Label
                {
                    Text = reserva,
                    Location = new Point(10, yPosition),
                    AutoSize = true
                };
                panelReservas.Controls.Add(lblReserva);
                yPosition += 30;
            }

            // Agregar controles al formulario
            this.Controls.Add(panelReservas);
            this.Controls.Add(btnCerrar);
        }
    }
}
