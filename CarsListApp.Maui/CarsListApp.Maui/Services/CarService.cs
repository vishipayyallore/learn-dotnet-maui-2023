using CarsListApp.Maui.Models;
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

}
