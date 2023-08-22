using CarsListApp.Maui.Services;

namespace CarsListApp.Maui
{
    public partial class App : Application
    {
        public static CarService CarServiceInstance { get; private set; }

        public App(CarService carService)
        {
            InitializeComponent();

            MainPage = new AppShell();

            CarServiceInstance = carService;
        }
    }
}
