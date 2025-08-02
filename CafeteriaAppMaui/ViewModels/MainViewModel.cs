using CafeteriaAppMaui.Model;
using CafeteriaAppMaui.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CafeteriaAppMaui.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        public ObservableCollection<Productos> Productos { get; } = new();

        [ObservableProperty]
        private ObservableCollection<Productos> filteredProducts;

        [ObservableProperty]
        private string searchText;

        public ICommand DeleteProductCommand { get; }

        public MainViewModel()
        {
            DeleteProductCommand = new Command<Productos>(async (product) => await DeleteProductAsync(product));
            LoadProducts();
        }

        private async Task DeleteProductAsync(Productos product)
        {
            await DatabaseServices.DeleteProductoAsync(product.ID);
            FilteredProducts.Remove(product);
            Productos.Remove(product);
        }

        partial void OnSearchTextChanged(string value)
        {
            FilterProducts();
        }

        private async void LoadProducts()
        {
            var list = await DatabaseServices.GetProductosAsync();
            Productos.Clear();
            foreach (var item in list)
                Productos.Add(item);
            FilterProducts();
        }

        private void FilterProducts()
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                FilteredProducts = new ObservableCollection<Productos>(Productos);
            }
            else
            {
                var lower = searchText.ToLower();
                FilteredProducts = new ObservableCollection<Productos>(
                    Productos.Where(p => p.Nombre.ToLower().Contains(lower)));
            }
        }

        [RelayCommand]
        private async Task AbrirWhatsapp()
        {
            var url = "https://wa.me/182955550123?text=Hola%20Steven%2C%20quiero%20hacer%20un%20pedido";
            try
            {
                await Launcher.Default.OpenAsync(url);
            }
            catch
            {
                await Shell.Current.DisplayAlert("ERROR", "ete whatsapp no quiere abrir", "OK");
            }
        }
    }
}
