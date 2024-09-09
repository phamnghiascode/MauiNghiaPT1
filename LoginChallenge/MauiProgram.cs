using Microsoft.Extensions.Logging;

namespace LoginChallenge
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
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Font Awesome 6 Free-Regular-400.otf", "awesome");
                    fonts.AddFont("Font Awesome 6 Brands-Regular-400.otf", "awesomebrand");
                    fonts.AddFont("Font Awesome 6 Free-Solid-900.otf", "awesomeboold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
