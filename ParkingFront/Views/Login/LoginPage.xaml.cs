using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using ParkingFront.DTO.Login;
using ParkingFront.Services.Navigation;
using ParkingFront.ViewModels.Login;
using ParkingFront.Views.Home;
using ParkingFront.Views.Register;


namespace ParkingFront.Views.Login
{
    public sealed partial class LoginPage : Page
    {
        private readonly LoginViewModel _viewModel;
        private readonly INavigationService _navigationService;

        // Utilizando el contenedor de dependencias
        public LoginPage()
        {
            this.InitializeComponent();

            _viewModel = new LoginViewModel(NotificationInfoBar,
                (INavigationService)App.Services.GetService(typeof(INavigationService)));


            this.DataContext = _viewModel;
        }

        private void OnRegisterClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RegisterPage));
        }

        private void OnInciok(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(IncioPage));
        }


    }
}
