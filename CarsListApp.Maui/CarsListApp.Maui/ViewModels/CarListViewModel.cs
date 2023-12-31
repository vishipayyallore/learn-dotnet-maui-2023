﻿using CarsListApp.Maui.Models;
using CarsListApp.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace CarsListApp.Maui.ViewModels;

public partial class CarListViewModel : BaseViewModel
{
    public ObservableCollection<Car> Cars { get; private set; } = new();

    [ObservableProperty]
    bool isRefreshing;

    [ObservableProperty]
    string make;

    [ObservableProperty]
    string model;

    [ObservableProperty]
    string vin;

    [ObservableProperty]
    string addEditButtonText;

    [ObservableProperty]
    int carId;

    const string editButtonText = "Update Car";
    const string createButtonText = "Add Car";
    NetworkAccess accessType = Connectivity.Current.NetworkAccess;
    string message = string.Empty;

    public CarListViewModel()
    {
        Title = "Car List";

        AddEditButtonText = createButtonText;

        GetCarList().Wait();
    }

    [RelayCommand]
    public async Task GetCarList()
    {
        if (IsLoading) return;

        try
        {
            IsLoading = true;

            if (Cars.Any()) Cars.Clear();

            var cars = new List<Car>();

            cars = App.CarServiceInstance.GetCars();

            foreach (var car in cars) Cars.Add(car);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get cars: {ex.Message}");

            await ShowAlert("Failed to retrieve list of cars.");
        }
        finally
        {
            IsLoading = false;

            IsRefreshing = false;
        }
    }

    [RelayCommand]
    async Task GetCarDetails(int id)
    {
        //if (car is null)
        //{
        //    return;
        //}

        //await Shell.Current.GoToAsync(nameof(CarDetailsPage), true, new Dictionary<string, object>
        //{
        //    {nameof(Car), car}
        //});

        if (id == 0) return;

        await Shell.Current.GoToAsync($"{nameof(CarDetailsPage)}?Id={id}", true);
    }

    [RelayCommand]
    async Task SaveCar()
    {
        if (string.IsNullOrEmpty(Make) || string.IsNullOrEmpty(Model) || string.IsNullOrEmpty(Vin))
        {
            await ShowAlert("Please insert valid data");
            return;
        }

        var car = new Car
        {
            Make = Make,
            Model = Model,
            Vin = Vin
        };

        if (CarId != 0)
        {
            car.Id = CarId;
            App.CarServiceInstance.UpdateCar(car);
            await Shell.Current.DisplayAlert("Info", App.CarServiceInstance.StatusMessage, "Ok");
        }
        else
        {
            App.CarServiceInstance.AddCar(car);
            await Shell.Current.DisplayAlert("Info", App.CarServiceInstance.StatusMessage, "Ok");
        }

        await GetCarList();
        await ClearForm();
    }

    [RelayCommand]
    async Task DeleteCar(int id)
    {
        if (id == 0)
        {
            await ShowAlert("Please try again");
            return;
        }

        var result = App.CarServiceInstance.DeleteCar(id);

        if (result == 0)
        {
            await Shell.Current.DisplayAlert("Failed", App.CarServiceInstance.StatusMessage, "Ok");
        }
        else
        {
            await Shell.Current.DisplayAlert("Info", "Deletion Success", "Ok");
            await GetCarList();
        }
    }

    [RelayCommand]
    async Task UpdateCar(int id)
    {
        // AddEditButtonText = editButtonText;

        await Task.CompletedTask;
        return;
    }

    [RelayCommand]
    async Task SetEditMode(int id)
    {
        AddEditButtonText = editButtonText;
        CarId = id;
        Car car;

        car = App.CarServiceInstance.GetCar(CarId);

        Make = car.Make;
        Model = car.Model;
        Vin = car.Vin;
    }

    [RelayCommand]
    async Task ClearForm()
    {
        AddEditButtonText = createButtonText;
        CarId = 0;

        Make = string.Empty;
        Model = string.Empty;
        Vin = string.Empty;

        await Task.CompletedTask;
    }

    private static async Task ShowAlert(string message)
    {
        await Shell.Current.DisplayAlert("Info", message, "Ok");
    }
}
