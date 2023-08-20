using CarsListApp.Maui.ViewModels;

namespace CarsListApp.Maui.Views;

public partial class CarDetailsPage : ContentPage
{
    // private readonly CarDetailsViewModel _carDetailsViewModel;

    public CarDetailsPage(CarDetailsViewModel carDetailsViewModel)
    {
        InitializeComponent();

        BindingContext = carDetailsViewModel;

        // _carDetailsViewModel = carDetailsViewModel;
    }


}