using CarsListApp.Maui.Services;
using CarsListApp.Maui.ViewModels;
using CarsListApp.Maui.Views;
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

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "cars.db3");
            builder.Services.AddTransient(s => ActivatorUtilities.CreateInstance<CarService>(s, dbPath));

            builder.Services.AddSingleton<CarListViewModel>();
            builder.Services.AddTransient<CarDetailsViewModel>();

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<CarDetailsPage>();

            //builder.Services.AddSingleton<LoadingPageViewModel>();
            //builder.Services.AddSingleton<LoginViewModel>();
            //builder.Services.AddSingleton<LogoutViewModel>();

            //builder.Services.AddSingleton<LoadingPage>();
            //builder.Services.AddSingleton<LoginPage>();
            //builder.Services.AddSingleton<LogoutPage>();

            // builder.Services.AddTransient<CarService>();
            return builder.Build();
        }
    }
}
