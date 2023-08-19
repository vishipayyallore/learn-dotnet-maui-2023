using CarsListApp.Maui.ViewModels;

namespace CarsListApp.Maui
{
    public partial class MainPage : ContentPage
    {
        private readonly CarListViewModel _carListViewModel;

        int count = 0;

        public MainPage(CarListViewModel carListViewModel)
        {
            InitializeComponent();

            BindingContext = carListViewModel;

            _carListViewModel = carListViewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // await _carListViewModel.GetCarList();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
