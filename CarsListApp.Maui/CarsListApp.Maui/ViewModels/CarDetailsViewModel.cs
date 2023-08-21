using CarsListApp.Maui.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CarsListApp.Maui.ViewModels;

[QueryProperty(nameof(Car), "Car")]
public partial class CarDetailsViewModel : BaseViewModel
{

    [ObservableProperty]
    Car car;
}
