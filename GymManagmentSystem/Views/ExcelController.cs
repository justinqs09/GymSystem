using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using OfficeOpenXml;

namespace GymManagmentSystem.Views
{
    public partial class ExcelController : Form
    {
        private string filePath = @"C:\Users\Justin´s PC\OneDrive\Documentos\ProjectTecnicas\GymManagmentSystem-master\usuarios.xlsx";
        private Panel infoExcel;
        private Button btnVer;

        public ExcelController()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Control de Usuarios";
            this.ClientSize = new System.Drawing.Size(600, 600);

            // Panel para mostrar información
            infoExcel = new Panel { Location = new Point(10, 10), Size = new Size(580, 500), AutoScroll = true };

            // Botón "Ver"
            btnVer = new Button
            {
                Text = "Ver",
                Location = new Point(250, 520),
                Width = 100
            };
            btnVer.Click += (sender, e) => DisplayUsers();

            // Agregar controles al formulario
            this.Controls.Add(infoExcel);
            this.Controls.Add(btnVer);

            // Mostrar usuarios al cargar el formulario
            DisplayUsers();
        }

        private void DisplayUsers()
        {
            // Limpiar el panel
            infoExcel.Controls.Clear();
            int yPosition = 10;

            try
            {
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("El archivo de usuarios no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    var worksheet = package.Workbook.Worksheets.FirstOrDefault();
                    if (worksheet == null) return;

                    var rowCount = worksheet.Dimension.Rows;

                    // Mostrar datos en el panel
                    for (int row = 2; row <= rowCount; row++) // Asumiendo que la fila 1 es encabezado
                    {
                        string nombre = worksheet.Cells[row, 1].Text;
                        string apellido = worksheet.Cells[row, 2].Text;
                        string pais = worksheet.Cells[row, 3].Text;

                        var label = new Label
                        {
                            Text = $"{nombre} {apellido} - {pais}",
                            Location = new Point(10, yPosition),
                            AutoSize = true
                        };
                        infoExcel.Controls.Add(label);
                        yPosition += 30; // Espaciado
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al leer el archivo Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


