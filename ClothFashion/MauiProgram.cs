using ClothFashion.Services;
using ClothFashion.ViewModels;
using ClothFashion.Views;
using Microsoft.Extensions.Logging;

namespace ClothFashion
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("BebasNeue-Regular.ttf", "BebasNeueRegular");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddTransient<ClothFashionService>();

            builder.Services.AddTransient<HomeViewModel>();
            builder.Services.AddTransient<DetailViewModel>();
            builder.Services.AddTransient<WelcomeViewModel>();

            builder.Services.AddTransient<HomeView>();
            builder.Services.AddTransient<DetailView>();
            builder.Services.AddTransient<WelcomeView>();

            return builder.Build();
        }
    }
}
