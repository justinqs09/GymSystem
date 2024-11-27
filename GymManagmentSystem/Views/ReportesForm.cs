using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GymManagementSystem
{
    public partial class ReportesForm : Form
    {
        public ReportesForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Configuración del formulario
            this.Text = "Generar Reportes";
            this.ClientSize = new System.Drawing.Size(800, 600);

            // Controles
            Label lblTitulo = new Label
            {
                Text = "Reportes de Gestión",
                Location = new System.Drawing.Point(20, 20),
                Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold)
            };

            // Botones para los reportes
            Button btnMatricula = new Button
            {
                Text = "Reporte de Matrícula",
                Location = new System.Drawing.Point(50, 80),
                Width = 200
            };

            Button btnFinanzas = new Button
            {
                Text = "Reporte Contable",
                Location = new System.Drawing.Point(50, 140),
                Width = 200
            };

            Button btnClases = new Button
            {
                Text = "Reporte de Clases",
                Location = new System.Drawing.Point(50, 200),
                Width = 200
            };

            ListBox lstReportes = new ListBox
            {
                Location = new System.Drawing.Point(300, 80),
                Width = 450,
                Height = 400
            };

            // Agregar controles al formulario
            this.Controls.Add(lblTitulo);
            this.Controls.Add(btnMatricula);
            this.Controls.Add(btnFinanzas);
            this.Controls.Add(btnClases);
            this.Controls.Add(lstReportes);

            // Eventos de los botones
            btnMatricula.Click += (sender, e) =>
            {
                lstReportes.Items.Clear();
                GenerarReporteMatricula(lstReportes);
            };

            btnFinanzas.Click += (sender, e) =>
            {
                lstReportes.Items.Clear();
                GenerarReporteFinanzas(lstReportes);
            };

            btnClases.Click += (sender, e) =>
            {
                lstReportes.Items.Clear();
                GenerarReporteClases(lstReportes);
            };

            // Botón para cerrar sesión
            Button btnCerrarSesion = new Button
            {
                Text = "Cerrar Sesión",
                Location = new System.Drawing.Point(50, 500),
                Width = 120
            };

            this.Controls.Add(btnCerrarSesion);

            btnCerrarSesion.Click += (sender, e) =>
            {
                this.Close(); // Regresa al login
            };
        }

        // Generar Reporte de Matrícula
        private void GenerarReporteMatricula(ListBox lstReportes)
        {
            // Ejemplo de datos simulados de matrícula
            List<(string mes, int inscritos, int bajas)> matriculaData = new List<(string, int, int)>
            {
                ("Enero", 50, 5),
                ("Febrero", 60, 4),
                ("Marzo", 70, 8),
                ("Abril", 80, 3)
            };

            lstReportes.Items.Add("Reporte de Matrícula");
            lstReportes.Items.Add("----------------------------");
            foreach (var data in matriculaData)
            {
                lstReportes.Items.Add($"Mes: {data.mes} | Nuevos Inscritos: {data.inscritos} | Bajas: {data.bajas}");
            }
        }

        // Generar Reporte Contable
        private void GenerarReporteFinanzas(ListBox lstReportes)
        {
            // Ejemplo de datos simulados de finanzas
            List<(string mes, double ingresos, double egresos)> finanzasData = new List<(string, double, double)>
            {
                ("Enero", 5000.00, 1000.00),
                ("Febrero", 6000.00, 1200.00),
                ("Marzo", 7000.00, 1500.00),
                ("Abril", 8000.00, 1800.00)
            };

            lstReportes.Items.Add("Reporte Contable");
            lstReportes.Items.Add("----------------------------");
            foreach (var data in finanzasData)
            {
                double balance = data.ingresos - data.egresos;
                lstReportes.Items.Add($"Mes: {data.mes} | Ingresos: ${data.ingresos} | Egresos: ${data.egresos} | Balance: ${balance}");
            }
        }

        // Generar Reporte de Clases
        private void GenerarReporteClases(ListBox lstReportes)
        {
            // Ejemplo de datos simulados de clases
            List<(string clase, string horario, int inscritos)> clasesData = new List<(string, string, int)>
            {
                ("Zumba", "Lunes 8:00 AM", 20),
                ("CardioDance", "Martes 6:00 PM", 15),
                ("Funcionales", "Miércoles 7:00 AM", 18),
                ("Zumba", "Jueves 8:00 AM", 25),
                ("CardioDance", "Viernes 6:00 PM", 10),
                ("Funcionales", "Sábado 7:00 AM", 22),
                ("Zumba", "Domingo 9:00 AM", 30),
                ("Funcionales", "Lunes 6:00 PM", 16)
            };

            lstReportes.Items.Add("Reporte de Clases");
            lstReportes.Items.Add("----------------------------");
            foreach (var data in clasesData)
            {
                lstReportes.Items.Add($"Clase: {data.clase} | Horario: {data.horario} | Inscritos: {data.inscritos}");
            }

            var clasesPopulares = clasesData
                .OrderByDescending(c => c.inscritos)
                .Take(3)
                .Select(c => $"{c.clase} ({c.horario} - {c.inscritos} inscritos)");

            lstReportes.Items.Add("");
            lstReportes.Items.Add("Clases Más Populares:");
            foreach (var popular in clasesPopulares)
            {
                lstReportes.Items.Add(popular);
            }
        }
    }
}
