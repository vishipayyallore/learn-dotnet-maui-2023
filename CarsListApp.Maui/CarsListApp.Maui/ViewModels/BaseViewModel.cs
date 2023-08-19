using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CarsListApp.Maui.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    private string title;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotLoading))]
    private bool isLoading;

    public bool IsNotLoading => !IsLoading;
}


//public partial class BaseViewModel : INotifyPropertyChanged
//{
//    private string _title;
//    private bool _isBusy;

//    public string Title
//    {
//        get => _title;

//        set
//        {
//            if (_title != value)
//            {
//                _title = value;
//                OnPropertyChanged();
//            }
//        }
//    }

//    public bool IsBusy
//    {
//        get => _isBusy;

//        set
//        {
//            if (_isBusy != value)
//            {
//                _isBusy = value;
//                OnPropertyChanged();
//            }
//        }
//    }

//    public event PropertyChangedEventHandler PropertyChanged;

//    public void OnPropertyChanged([CallerMemberName] string propertyName = null)
//    {
//        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//    }
//}
