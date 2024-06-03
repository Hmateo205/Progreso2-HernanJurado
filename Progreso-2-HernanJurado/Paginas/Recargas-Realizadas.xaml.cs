namespace Progreso_2_HernanJurado.Paginas;

public partial class Recargas_Realizadas : ContentPage
{
	public Recargas_Realizadas()
	{
		InitializeComponent();
        Historialrecargas();
    }
    private void Historialrecargas()
    {
        string folderPath = @"C:\Users\ASUS GAMING\source\repos\Progreso-2-HernanJurado\Recargas-Historial";
        var recargas = Directory.EnumerateFiles(folderPath, "*.txt")
                                .Select(file => File.ReadAllText(file))
                                .ToList();

        HJRecargasList.ItemsSource = recargas;
    }
 
}
