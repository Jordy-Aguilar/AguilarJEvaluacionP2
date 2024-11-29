using System;
using System.IO;
using Microsoft.Maui.Controls;
namespace AguilarJEvaluacionP2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            string nombre = "Jordy Enrique";
            string apellido = "Aguilar Yaure";
            string folderName = nombre + apellido;
            string folderPath = Path.Combine(FileSystem.AppDataDirectory, folderName);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string fileName = folderName + ".txt";
            string filePath = Path.Combine(folderPath, fileName);
            string recargaInfo = "Información de la recarga: $100.00\nFecha: " + DateTime.Now;

            await File.WriteAllTextAsync(filePath, recargaInfo);
            await DisplayAlert("Éxito", "La información se ha guardado " + filePath, "OK");
        }
    }
}