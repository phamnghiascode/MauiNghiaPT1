using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SurfingApp.Models;
using SurfingApp.Services;
using System.Collections.ObjectModel;

namespace SurfingApp.ViewModels
{
    public partial class HomeViewModel : ViewModelBase
    {
        [ObservableProperty]
        private ObservableCollection<Post> posts = new ObservableCollection<Post>();

        [ObservableProperty]
        private ObservableCollection<User> users = new ObservableCollection<User>();


        private readonly UserService userService;

        private readonly PostService postService;


        [RelayCommand]
        public void ToogleLike()
        {

        }

        [RelayCommand]
        public void PostPlay()
        {

        }

        public HomeViewModel()
        {
            userService = new UserService();
            postService = new PostService(userService);
            LoadData();
        }

        void LoadData()
        {
            Users = userService.GetUsers();
            Posts = postService.GetPosts();
        }
    }
}