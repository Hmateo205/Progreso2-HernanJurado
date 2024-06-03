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

    private int selectedAmount = 0;

    private void OnCantidadChanged(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            var radioButton = sender as RadioButton;
            selectedAmount = int.Parse(radioButton.Content.ToString().Trim('$'));
            DisplayAlert("Monto Seleccionado", $"Se seleccion� una recarga de ${selectedAmount}", "OK");
        }
    }

    private async void OnConfirmarClicked(object sender, EventArgs e)
    {
        string NumeroTelefonico = HJNumero.Text;
        string Operadora = HJOperador.SelectedItem?.ToString();

        if (string.IsNullOrEmpty(NumeroTelefonico) || Operadora == null || selectedAmount == 0)
        {
            await DisplayAlert("Error", "Por favor complete todos los campos antes de continuar.", "OK");
            return;
        }

        bool confirm = await DisplayAlert("Confirmaci�n", $"�Desea recargar ${selectedAmount} en el n�mero {NumeroTelefonico}?", "S�", "No");
        if (confirm)
        {
            await RealizarRecargaAsync(NumeroTelefonico, selectedAmount);
        }
    }

    private async Task RealizarRecargaAsync(string NumeroTelefonico, int amount)
    {
        string date = DateTime.Now.ToString("dd/MM/yyyy");
        string fileName = $"{NumeroTelefonico}.txt";
        string content = $"Se hizo una recarga de ${amount} d�lares en la siguiente fecha; {date}";

        // Guardar archivo en el dispositivo
        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), fileName);
        File.WriteAllText(filePath, content);

        // Mostrar mensaje de confirmaci�n
        await DisplayAlert("Recarga Exitosa", $"Se ha recargado ${amount} a {NumeroTelefonico}.", "OK");
    }
}

