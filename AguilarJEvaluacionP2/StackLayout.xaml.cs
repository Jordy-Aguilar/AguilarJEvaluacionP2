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
                await DisplayAlert("Error", "El n�mero de tel�fono debe tener 10 d�gitos v�lidos", "OK");
                return;
            }

            string fileName = $"{nombre.Replace(" ", "")}.txt";
            string filePath = Path.Combine(FileSystem.AppDataDirectory, fileName);
            File.WriteAllText(filePath, $"Nombre: {nombre}\nN�mero: {numero}");
            await DisplayAlert("Recarga Exitosa", "La recarga se realiz�", "OK");
            Resumen_JAguilar.Text = $"Datos de ultima recarga:\nNombre: {nombre}\nN�mero: {numero}";
            Numero_JAguilar.Text = string.Empty;
            Nombre_JAguilar.Text = string.Empty;
        }
    }
}
