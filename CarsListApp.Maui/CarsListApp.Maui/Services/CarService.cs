using CarsListApp.Maui.Models;

namespace CarsListApp.Maui.Services;

public class CarService
{

    public List<Car> GetCars() => new()
        {
            new Car() { Id = 1, Make = "Honda", Model = "Fit", Vin="123" },
            new Car() { Id = 2, Make = "Toyota", Model = "Fit", Vin="234" },
            new Car() { Id = 3, Make = "Audi", Model = "Fit", Vin="345" },
            new Car() { Id = 4, Make = "BMW", Model = "Fit", Vin="456" },
            new Car() { Id = 5, Make = "Nissan", Model = "Fit", Vin="567" },
            new Car() { Id = 6, Make = "Ferrari", Model = "Fit", Vin="678" },
        };

}
