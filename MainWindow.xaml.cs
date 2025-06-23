using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GeneradorDeClavesSeguras
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenerarContrasena_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtLongitud.Text, out int longitud) || longitud <= 0)
            {
                MessageBox.Show("Ingrese una longitud válida.");
                return;
            }

            string caracteres = "";

            if (chkMinusculas.IsChecked == true) caracteres += "abcdefghijklmnopqrstuvwxyz";
            if (chkMayusculas.IsChecked == true) caracteres += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if (chkNumeros.IsChecked == true) caracteres += "0123456789";
            if (chkSimbolos.IsChecked == true) caracteres += "!@#$%^&*()-_=+[]{}|;:,.<>?";

            if (string.IsNullOrEmpty(caracteres))
            {
                MessageBox.Show("Seleccione al menos una opción.");
                return;
            }

            StringBuilder contraseña = new StringBuilder();
            Random rnd = new Random();

            for (int i = 0; i < longitud; i++)
            {
                int index = rnd.Next(caracteres.Length);
                contraseña.Append(caracteres[index]);
            }

            txtResultado.Text = contraseña.ToString();
        }

        private void CopiarContrasena_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtResultado.Text))
            {
                Clipboard.SetText(txtResultado.Text);
                MessageBox.Show("¡Contraseña copiada al portapapeles!", "Copiado", MessageBoxButton.OK, MessageBoxImage.Information);
                limpiarCampos();
            }
            else
            {
                MessageBox.Show("No hay contraseña para copiar.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public void limpiarCampos()
        {
            txtResultado.Text = "";
            txtLongitud.Text = "";
        }
    }
}