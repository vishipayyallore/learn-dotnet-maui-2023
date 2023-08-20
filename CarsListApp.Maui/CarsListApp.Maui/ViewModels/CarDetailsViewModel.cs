using CarsListApp.Maui.Models;
using CarsListApp.Maui.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Web;

namespace CarsListApp.Maui.ViewModels;

[QueryProperty(nameof(Car), "Car")]
public partial class CarDetailsViewModel : BaseViewModel, IQueryAttributable
{
    private readonly CarService _carApiService;

    public CarDetailsViewModel(CarService carApiService)
    {
        Title = $"Car Details - {car.Make} {car.Model}";

        _carApiService = carApiService ?? throw new ArgumentNullException(nameof(carApiService));
    }

    NetworkAccess accessType = Connectivity.Current.NetworkAccess;

    [ObservableProperty]
    Car car;

    [ObservableProperty]
    int id;

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Id = Convert.ToInt32(HttpUtility.UrlDecode(query["Id"].ToString()));
    }

    public async Task GetCarData()
    {
        //if (accessType == NetworkAccess.Internet)
        //{
        //    Car = await carApiService.GetCar(Id);
        //}
        //else
        //{
        //    Car = App.CarDatabaseService.GetCar(Id);
        //}
    }
}
