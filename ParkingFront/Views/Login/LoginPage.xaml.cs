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

<<<<<<< HEAD
            _viewModel = new LoginViewModel(NotificationInfoBar,
                (INavigationService)App.Services.GetService(typeof(INavigationService)));
=======
            _viewModel = (LoginViewModel)App.Services.GetService(typeof(LoginViewModel));
            _navigationService = (INavigationService)App.Services.GetService(typeof(INavigationService));
>>>>>>> de16f389f219835cd8662c665b819e1cde6bde72

            this.DataContext = _viewModel;
        }

        private void OnRegisterClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RegisterPage));
        }



    }
}
