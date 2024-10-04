using ClothFashion.Models;
using ClothFashion.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace ClothFashion.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        private readonly ClothFashionService clothFashionService;

        [ObservableProperty]
        private Promotion promotion;

        [ObservableProperty]
        private ObservableCollection<string> categories;

        [ObservableProperty]
        private ObservableCollection<Product> products;

        [ObservableProperty]
        private string selectedCategory;

        public HomeViewModel(ClothFashionService clothFashionService)
        {
            this.clothFashionService = clothFashionService;
            LoadData();
        }

        private void LoadData()
        {
            Promotion = clothFashionService.GetPromotion();
            Categories = new ObservableCollection<string>(clothFashionService.GetCategories());
            SelectedCategory = Categories.FirstOrDefault();
            Products = new ObservableCollection<Product>(clothFashionService.GetPopularProducts());
        }
    }
}
