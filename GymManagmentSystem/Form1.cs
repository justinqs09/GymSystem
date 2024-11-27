using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using OfficeOpenXml;

namespace GymManagementSystem
{
    public partial class Form1 : Form
    {
        private string clientFilePath = @"C:\Users\Justin´s PC\OneDrive\Documentos\ProjectTecnicas\GymManagmentSystem-master\usuarios.xlsx";
        private string trainerFilePath = @"C:\Users\Justin´s PC\OneDrive\Documentos\ProjectTecnicas\GymManagmentSystem-master\entrenadores.xlsx";

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Configuración del formulario
            this.Text = "Login";
            this.ClientSize = new System.Drawing.Size(400, 300);

            // Controles del formulario
            Label lblUsername = new Label { Text = "Username:", Location = new Point(50, 50) };
            TextBox txtUsername = new TextBox { Location = new Point(150, 50), Width = 200 };

            Label lblPassword = new Label { Text = "Password:", Location = new Point(50, 100) };
            TextBox txtPassword = new TextBox { Location = new Point(150, 100), Width = 200, UseSystemPasswordChar = true };

            Label lblRole = new Label { Text = "Role:", Location = new Point(50, 150) };
            ComboBox cbRole = new ComboBox
            {
                Location = new Point(150, 150),
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cbRole.Items.AddRange(new string[] { "Cliente", "Entrenador" });

            Button btnLogin = new Button { Text = "Login", Location = new Point(150, 200), Width = 80 };
            Label lblMessage = new Label { Location = new Point(50, 250), Width = 300, ForeColor = Color.Red };

            // Agregar controles al formulario
            this.Controls.Add(lblUsername);
            this.Controls.Add(txtUsername);
            this.Controls.Add(lblPassword);
            this.Controls.Add(txtPassword);
            this.Controls.Add(lblRole);
            this.Controls.Add(cbRole);
            this.Controls.Add(btnLogin);
            this.Controls.Add(lblMessage);

            // Evento del botón de login
            btnLogin.Click += (sender, e) =>
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();
                string role = cbRole.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(role))
                {
                    lblMessage.ForeColor = Color.Red;
                    lblMessage.Text = "Please select a role!";
                    return;
                }

                // Validar login según el rol
                bool isValidLogin = false;

                if (role == "Cliente")
                {
                    isValidLogin = ValidateLoginFromExcelUser(clientFilePath, username, password);
                }
                else if (role == "Entrenador")
                {
                    isValidLogin = ValidateLoginFromExcelTrainers(trainerFilePath, username, password);
                }


                if (isValidLogin)
                {
                    lblMessage.ForeColor = Color.Green;
                    lblMessage.Text = "Login successful!";

                    if (role == "Cliente")
                    {
                        ClasesForm clasesForm = new ClasesForm();
                        this.Hide();
                        clasesForm.ShowDialog();
                        this.Close();
                    }
                    else if (role == "Entrenador")
                    {
                        InventarioForm inventarioForm = new InventarioForm();
                        this.Hide();
                        inventarioForm.ShowDialog();
                        this.Close();
                    }
                }
                else
                {
                    lblMessage.ForeColor = Color.Red;
                    lblMessage.Text = "Invalid username or password!";
                }
            };
        }

        private bool ValidateLoginFromExcelUser(string filePath, string username, string password)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    MessageBox.Show($"El archivo {Path.GetFileName(filePath)} no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    var worksheet = package.Workbook.Worksheets.FirstOrDefault();
                    if (worksheet == null) return false;

                    // Leer todas las filas del archivo Excel
                    var rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++) // Comenzar desde la fila 2 para omitir encabezados
                    {
                        string firstName = worksheet.Cells[row, 1]?.Text.Trim();
                        string lastName = worksheet.Cells[row, 2]?.Text.Trim();
                        string userPassword = worksheet.Cells[row, 3]?.Text.Trim(); // Country

                        // Concatenar First Name y Last Name
                        string fullUsername = $"{firstName} {lastName}";

                        if (username.Equals(fullUsername, StringComparison.OrdinalIgnoreCase) &&
                            password.Equals(userPassword, StringComparison.OrdinalIgnoreCase))
                        {
                            return true; // Login válido
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al leer el archivo Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false; // Login inválido
        }

        private bool ValidateLoginFromExcelTrainers(string filePath, string username, string password)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    MessageBox.Show($"El archivo {Path.GetFileName(filePath)} no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    var worksheet = package.Workbook.Worksheets.FirstOrDefault();
                    if (worksheet == null) return false;

                    // Leer todas las filas del archivo Excel
                    var rowCount = worksheet.Dimension.Rows;

                    for (int row = 1; row <= rowCount; row++) // No hay encabezados
                    {
                        string trainerUsername = worksheet.Cells[row, 1]?.Text.Trim(); // Columna 1
                        string trainerPassword = worksheet.Cells[row, 2]?.Text.Trim(); // Columna 2

                        if (username.Equals(trainerUsername, StringComparison.OrdinalIgnoreCase) &&
                            password.Equals(trainerPassword, StringComparison.OrdinalIgnoreCase))
                        {
                            return true; // Login válido
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al leer el archivo Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false; // Login inválido
        }






        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}