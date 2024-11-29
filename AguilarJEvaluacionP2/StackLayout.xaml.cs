using System.IO;
using Microsoft.Maui.Controls;

namespace AguilarJEvaluacionP2
{

    public partial class StackLayout : ContentPage
    {
        public StackLayout()
        {
            InitializeComponent();
        }

        private async void JBtn_Recargar_Click(object sender, EventArgs e)
        {
            string numero = Numero_JAguilar.Text;
            string nombre = Nombre_JAguilar.Text;

            if (string.IsNullOrEmpty(numero) || string.IsNullOrEmpty(nombre))
            {
                await DisplayAlert("Error", "Se produjo un error al ingreso de datos", "OK");
                return;
            }

            if (numero.Length != 10 || !long.TryParse(numero, out _))
            {
                await DisplayAlert("Error", "El número de teléfono debe tener 10 dígitos válidos", "OK");
                return;
            }

            string fileName = $"{nombre.Replace(" ", "")}.txt";
            string filePath = Path.Combine(FileSystem.AppDataDirectory, fileName);
            File.WriteAllText(filePath, $"Nombre: {nombre}\nNúmero: {numero}");
            await DisplayAlert("Recarga Exitosa", "La recarga se realizó", "OK");
            Resumen_JAguilar.Text = $"Datos de ultima recarga:\nNombre: {nombre}\nNúmero: {numero}";
            Numero_JAguilar.Text = string.Empty;
            Nombre_JAguilar.Text = string.Empty;
        }
    }
}
