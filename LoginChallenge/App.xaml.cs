using LoginChallenge.Views;

namespace LoginChallenge
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LoginView();
        }
    }
}
