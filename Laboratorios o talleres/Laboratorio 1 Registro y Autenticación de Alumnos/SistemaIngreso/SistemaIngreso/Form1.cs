using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace SistemaIngreso
{
    public partial class Form1 : Form
    {
        // Código de administrador para el inicio de sesión
        private const string CODIGO_ADMIN = "1234";

        public Form1()
        {
            // La llamada a InitializeComponent() debe ser la primera línea del constructor
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 1. Inicio de sesión rápido
            string codigoIngresado = InputBox.Show(
                "Ingrese el código de administrador o profesor:",
                "Inicio de Sesión",
                ""
            );

            if (codigoIngresado != CODIGO_ADMIN)
            {
                MessageBox.Show("Código incorrecto. El programa se cerrará.", "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); // Cierra el programa
                return;
            }

            // Inicializar campos de la interfaz
            LimpiarCampos();
        }

        // --- LÓGICA DE VALIDACIÓN ---

        // Valida que la Cédula solo contenga números (KeyPress)
        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo dígitos y la tecla de control (como Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Genera el Usuario automáticamente y lo actualiza cada vez que cambian Nombre o Cédula
        private void datos_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length > 0 && txtCedula.Text.Length > 0)
            {
                // Ejemplo: Primera letra del nombre + Cédula
                string primeraLetra = txtNombre.Text.Substring(0, 1).ToLower();
                string cedulaLimpia = txtCedula.Text.Trim();
                txtUsuario.Text = $"{primeraLetra}{cedulaLimpia}";
            }
            else
            {
                txtUsuario.Text = string.Empty;
            }
        }

        // Valida que los términos sean aceptados antes de intentar guardar (Validating)
        private void chkTerminos_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!chkTerminos.Checked)
            {
                MessageBox.Show("Debe aceptar los términos y condiciones para guardar.", "Términos no Aceptados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true; // Impide que el foco se mueva
            }
        }

        // Verifica si todos los campos obligatorios están llenos
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtCedula.Text))
            {
                MessageBox.Show("Los campos 'Nombre' y 'Cédula' son obligatorios.", "Advertencia de Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbCarrera.SelectedIndex == -1 || cmbSemestre.SelectedIndex == -1 || cmbJornada.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar 'Carrera', 'Semestre' y 'Jornada'.", "Advertencia de Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtContraseña.Text) || string.IsNullOrWhiteSpace(txtConfirmacion.Text))
            {
                MessageBox.Show("La 'Contraseña' y su 'Confirmación' son obligatorias.", "Advertencia de Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtContraseña.Text != txtConfirmacion.Text)
            {
                MessageBox.Show("La contraseña y la confirmación no coinciden.", "Error de Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!chkTerminos.Checked)
            {
                MessageBox.Show("Debe aceptar los términos y condiciones.", "Advertencia de Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // --- LÓGICA DE MENÚ Y BOTONES ---

        // Método para limpiar todos los campos del formulario
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtCedula.Clear();
            cmbCarrera.SelectedIndex = -1;
            cmbSemestre.SelectedIndex = -1;
            cmbJornada.SelectedIndex = -1;
            txtUsuario.Clear(); // Usuario es ReadOnly, pero se limpia al limpiar Nombre/Cédula
            txtContraseña.Clear();
            txtConfirmacion.Clear();
            chkTerminos.Checked = false;
            txtNombre.Focus();
        }

        // Archivo -> Nuevo (y tecla Esc)
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        // Archivo -> Guardar (y botón Guardar, y Ctrl+S)
        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuardarAlumno();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarAlumno();
        }

        // Lógica de Guardar Alumno
        private void GuardarAlumno()
        {
            // Ejecuta el evento Validating del chkTerminos antes de guardar
            if (!this.ValidateChildren(ValidationConstraints.Enabled))
            {
                // La validación del control (chkTerminos) falló
                return;
            }

            if (ValidarCampos())
            {
                // Crear objeto Alumno
                Alumno nuevoAlumno = new Alumno
                {
                    Nombre = txtNombre.Text.Trim(),
                    Cedula = txtCedula.Text.Trim(),
                    Carrera = cmbCarrera.SelectedItem.ToString(),
                    Semestre = cmbSemestre.SelectedItem.ToString(),
                    Jornada = cmbJornada.SelectedItem.ToString(),
                    Usuario = txtUsuario.Text.Trim(),
                    Contraseña = txtContraseña.Text // En una app real, la contraseña debe ser hasheada
                };

                // Agregar a la ListBox
                listBoxAlumnos.Items.Add(nuevoAlumno);

                MessageBox.Show("Alumno registrado exitosamente.", "Registro Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar campos para el siguiente ingreso
                LimpiarCampos();
            }
        }

        // Archivo -> Salir (con confirmación)
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de que desea salir de la aplicación?", "Confirmar Salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // Ayuda -> Acerca de
        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Sistema de Ingreso de Alumnos\n\n" +
                "Versión: 1.0\n" +
                "Autor: 61516 (Implementación de requerimientos)",
                "Acerca de",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        // Manejo de atajos de teclado (Esc para Nuevo, Ctrl+S para Guardar)
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                LimpiarCampos();
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.S)
            {
                GuardarAlumno();
                e.Handled = true;
            }
        }
    }
}
