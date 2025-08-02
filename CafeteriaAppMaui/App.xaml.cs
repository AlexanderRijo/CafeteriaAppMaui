using CafeteriaAppMaui.Model;
using CafeteriaAppMaui.Services;

namespace CafeteriaAppMaui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            AgregarDatosPruebaAsync();

        }

      private async void AgregarDatosPruebaAsync ()
        {
            await DatabaseServices.Init();
            var productos = await DatabaseServices.GetProductosAsync();
           if (productos.Any()) 
            {
                await DatabaseServices.AddProductosAsync(new Productos {Nombre = "Yuquita", Precio = 50, cantidad = 35 });
                await DatabaseServices.AddProductosAsync(new Productos { Nombre = "Arepa", Precio = 25, cantidad = 15 });
                await DatabaseServices.AddProductosAsync(new Productos { Nombre = "Empanada", Precio = 10, cantidad = 5 });
                await DatabaseServices.AddProductosAsync(new Productos { Nombre = "Bollito de Yuca", Precio = 30, cantidad = 35 });
                await DatabaseServices.AddProductosAsync(new Productos { Nombre = "Pan con Queso", Precio = 40, cantidad = 5 });
                await DatabaseServices.AddProductosAsync(new Productos { Nombre = "Jugos", Precio = 50, cantidad = 25 });
            }
        }
           
        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}