using CarsListApp.Maui.Models;
using SQLite;

namespace CarsListApp.Maui.Services;

public class CarService
{
    private SQLiteConnection conn;
    private readonly string _dbPath;

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
        Init();

        try
        {

        }
        catch (Exception ex)
        {

        }

        return new();
    }

}
