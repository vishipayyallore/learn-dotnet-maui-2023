using CarsListApp.Maui.Models;
using CarsListApp.Maui.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Web;

namespace CarsListApp.Maui.ViewModels;

[QueryProperty(nameof(Id), nameof(Id))]
public partial class CarDetailsViewModel : BaseViewModel, IQueryAttributable
{
    private readonly CarService carApiService;

    public CarDetailsViewModel(CarService carApiService)
    {
        this.carApiService = carApiService;
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
