using System;
using System.IO;
using System.Threading.Tasks;

namespace Progreso_2_HernanJurado.Paginas;

public partial class Recaga_Telefonica : ContentPage
{
	public Recaga_Telefonica()
	{
		InitializeComponent();
	}

    private int Cantidad = 0;

    private void OnCantidadChanged(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            var radioButton = sender as RadioButton;
            Cantidad = int.Parse(radioButton.Content.ToString().Trim('$'));
            DisplayAlert("Cantidad seleccionada", $"Se seleccionó una recarga de ${Cantidad}", "OK");
        }
    }

    private async void OnConfirmarClicked(object sender, EventArgs e)
    {
        string NumeroTelefonico = HJNumero.Text;
        string Operadora = HJOperador.SelectedItem?.ToString();

        if (string.IsNullOrEmpty(NumeroTelefonico) || Operadora == null || Cantidad == 0)
        {
            await DisplayAlert("Error!!", "Coplete todo antes de continuar", "OK");
            return;
        }

        bool confirm = await DisplayAlert("Confirmación", $"¿Desea recargar ${Cantidad} en el número {NumeroTelefonico}?", "Sí", "No");
        if (confirm)
        {
            await RealizarRecargaAsync(NumeroTelefonico, Operadora, Cantidad);
        }
    }

    private async Task RealizarRecargaAsync(string NumeroTelefonico,string Operadora, int cantidad)
    {
        string date = DateTime.Now.ToString("dd/MM/yyyy");
        string fileName = $"{NumeroTelefonico}.txt";
        string content = $"Se realizo una recarga de$ {cantidad} en {Operadora} al numero {NumeroTelefonico} el {date}";

        // Guardar archivo en el dispositivo
        string folderPath = @"C:\Users\ASUS GAMING\source\repos\Progreso-2-HernanJurado\Recargas-Historial";
        string filePath = Path.Combine(folderPath, fileName);
        File.WriteAllText(filePath, content);

        // Mostrar mensaje de confirmación
        await DisplayAlert("Recarga Exitosa!!", $"Se ha recargado ${cantidad} a {NumeroTelefonico}.", "OK");
    }
}

