using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SistemaIngreso
{
    // Clase auxiliar para simular un InputBox simple.
    // En un proyecto real de WinForms, se usaría un Form dedicado o la referencia a Microsoft.VisualBasic.
    public static class InputBox
    {
        public static string Show(string prompt, string title, string defaultValue = "")
        {
            Form form = new Form()
            {
                Width = 350,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = title,
                StartPosition = FormStartPosition.CenterScreen
            };

            Label label = new Label() { Left = 20, Top = 15, Text = prompt, AutoSize = true };
            TextBox textBox = new TextBox() { Left = 20, Top = 40, Width = 300, Text = defaultValue };
            Button buttonOk = new Button() { Text = "Aceptar", Left = 160, Width = 80, Top = 75, DialogResult = DialogResult.OK };
            Button buttonCancel = new Button() { Text = "Cancelar", Left = 245, Width = 80, Top = 75, DialogResult = DialogResult.Cancel };

            buttonOk.Click += (sender, e) => { form.Close(); };
            buttonCancel.Click += (sender, e) => { form.Close(); };

            form.Controls.Add(textBox);
            form.Controls.Add(buttonOk);
            form.Controls.Add(buttonCancel);
            form.Controls.Add(label);
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            return form.ShowDialog() == DialogResult.OK ? textBox.Text : string.Empty;
        }
    }
}
