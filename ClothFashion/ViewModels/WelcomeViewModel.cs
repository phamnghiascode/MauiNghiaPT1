using ClothFashion.Models;
using ClothFashion.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace ClothFashion.ViewModels
{
    public partial class WelcomeViewModel : ObservableObject
    {
        private readonly ClothFashionService clothFashionService;

        private ObservableCollection<Item> _items;

        public WelcomeViewModel(ClothFashionService clothFashionService)
        {
            this.clothFashionService = clothFashionService;

            LoadData();
        }

        [ObservableProperty]
        private ObservableCollection<Item> items;

        void LoadData()
        {
            Items = new ObservableCollection<Item>(clothFashionService.GetPromoItems());
        }
    }
}
