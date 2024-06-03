namespace Progreso_2_HernanJurado
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnHJBoton1Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Paginas.Recaga_Telefonica());
        }
        private void OnHJBoton2Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Paginas.Recargas_Realizadas());
        }

    }

}
