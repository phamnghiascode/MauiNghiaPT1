using SurfingApp.Models;
using System.Collections.ObjectModel;

namespace SurfingApp.Services
{
    public class PostService
    {
        private readonly UserService _userService;
        public PostService(UserService userService)
        {
            _userService = userService;
        }


        public ObservableCollection<Post> GetPosts()
        {
            return new ObservableCollection<Post>
            {
                new Post { Title = "Probably considered the forefather of pro surfing", Image = "post01.jpg", Likes = "1.2k", User = _userService.User1 },
                new Post { Title = "One of the most inspirational people in the public eye", Image = "post02.jpg", Likes = "225", User = _userService.User2 },
                new Post { Title = "Lorem ipsum dolor sit amet, consectetur adipiscing elit", Image = "post03.jpg", Likes = "111", User = _userService.User3 },
                new Post { Title = "Lorem ipsum dolor sit amet, consectetur adipiscing elit", Image = "post04.jpg", Likes = "988", User = _userService.User4 },
                new Post { Title = "Lorem ipsum dolor sit amet, consectetur adipiscing elit", Image = "post05.jpg", Likes = "210", User = _userService.User5 },
                new Post { Title = "Lorem ipsum dolor sit amet, consectetur adipiscing elit", Image = "post06.jpg", Likes = "334", User = _userService.User6 },
                new Post { Title = "Lorem ipsum dolor sit amet, consectetur adipiscing elit", Image = "post07.jpg", Likes = "122", User = _userService.User1 },
                new Post { Title = "Lorem ipsum dolor sit amet, consectetur adipiscing elit", Image = "post08.jpg", Likes = "1.4k", User = _userService.User2 }
            };
        }
    }
}