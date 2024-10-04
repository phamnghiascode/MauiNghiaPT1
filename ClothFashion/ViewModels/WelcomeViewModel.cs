using ClothFashion.Models;
using ClothFashion.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using ClothFashion.Views;

namespace ClothFashion.ViewModels
{
    public partial class WelcomeViewModel : ObservableObject
    {
        private readonly ClothFashionService clothFashionService;

        private ObservableCollection<Item> _items;

        [ObservableProperty]
        private ObservableCollection<Item> items;

        [RelayCommand]
        private async Task GoToHomePage()
        {
            await Shell.Current.GoToAsync(nameof(HomeView), true);
        }
        public WelcomeViewModel(ClothFashionService clothFashionService)
        {
            this.clothFashionService = clothFashionService;

            LoadData();
        }
        void LoadData()
        {
            Items = new ObservableCollection<Item>(clothFashionService.GetPromoItems());
        }
    }
}
