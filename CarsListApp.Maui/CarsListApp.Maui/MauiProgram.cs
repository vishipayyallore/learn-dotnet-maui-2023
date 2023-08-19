using CarsListApp.Maui.Services;
using CarsListApp.Maui.ViewModels;
using Microsoft.Extensions.Logging;

namespace CarsListApp.Maui
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
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            builder.Services.AddTransient<CarService>();

            builder.Services.AddSingleton<CarListViewModel>();

            builder.Services.AddSingleton<MainPage>();

            //builder.Services.AddSingleton<LoadingPageViewModel>();
            //builder.Services.AddSingleton<LoginViewModel>();
            //builder.Services.AddSingleton<LogoutViewModel>();
            //builder.Services.AddTransient<CarDetailsViewModel>();

            //builder.Services.AddSingleton<LoadingPage>();
            //builder.Services.AddSingleton<LoginPage>();
            //builder.Services.AddSingleton<LogoutPage>();
            //builder.Services.AddTransient<CarDetailsPage>();

            return builder.Build();
        }
    }
}
