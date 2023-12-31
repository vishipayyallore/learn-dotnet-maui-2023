﻿using CarsListApp.Maui.Models;
using SQLite;

namespace CarsListApp.Maui.Services;

public class CarService
{
    private SQLiteConnection conn;
    private readonly string _dbPath;
    private int result = 0;

    public string StatusMessage;

    public CarService(string dbPath)
    {
        _dbPath = dbPath;
    }

    private void Init()
    {
        if (conn is not null)
            return;

        conn = new SQLiteConnection(_dbPath);
        conn.CreateTable<Car>();
    }

    public List<Car> GetCars()
    {
        try
        {
            Init();

            return conn.Table<Car>().ToList();
        }
        catch (Exception)
        {
            StatusMessage = "Failed to retrieve data.";
        }

        return new();
    }

    public Car GetCar(int id)
    {
        try
        {
            Init();
            return conn.Table<Car>().FirstOrDefault(q => q.Id == id);
        }
        catch (Exception)
        {
            StatusMessage = "Failed to retrieve data.";
        }

        return null;
    }

    public void AddCar(Car car)
    {
        try
        {
            Init();

            if (car is null)
                throw new Exception("Invalid Car Record");

            result = conn.Insert(car);
            StatusMessage = result == 0 ? "Insert Failed" : "Insert Successful";
        }
        catch (Exception)
        {
            StatusMessage = "Failed to Insert data.";
        }
    }

    public void UpdateCar(Car car)
    {
        try
        {
            Init();

            if (car is null)
                throw new Exception("Invalid Car Record");

            result = conn.Update(car);
            StatusMessage = result == 0 ? "Update Failed" : "Update Successful";
        }
        catch (Exception)
        {
            StatusMessage = "Failed to Update data.";
        }
    }

    public int DeleteCar(int id)
    {
        int result = 0;

        try
        {
            Init();

            result = conn.Table<Car>().Delete(q => q.Id == id);
        }
        catch (Exception)
        {
            StatusMessage = "Failed to Delete data.";
        }

        return result;
    }

}
