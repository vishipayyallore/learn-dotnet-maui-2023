using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CarsListApp.Maui.ViewModels;

public partial class BaseViewModel : INotifyPropertyChanged
{
    private string _title;
    private bool _isBusy;

    public string Title
    {
        get => _title;

        set
        {
            if (_title != value)
            {
                _title = value;
                OnPropertyChanged();
            }
        }
    }

    public bool IsBusy
    {
        get => _isBusy;

        set
        {
            if (_isBusy != value)
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
