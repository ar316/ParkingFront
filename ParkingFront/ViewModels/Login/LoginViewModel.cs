using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using ParkingFront.DTO.Login;
using ParkingFront.Services.LoginService;
using ParkingFront.Services.Navigation;
using ParkingFront.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Runtime.InteropServices.JavaScript.JSType;

using ParkingFront.Views.Home;
using ParkingFront.ViewModels.HomeParking;

namespace ParkingFront.ViewModels.Login
{
    public class LoginViewModel : INotifyPropertyChanged
    {

        private string _identification;
        private string _password;
        private readonly INavigationService _navigationService;
        public ICommand LoginCommand { get; }
        public ICommand LoginGuessCommand { get; }
        private readonly InfoBar _infoBar;
        private readonly LoginService _loginService;
        private readonly Action _navigateToHome;
        public string Identification
        {
            get => _identification;
            set
            {
                if (_identification != value)
                {
                    _identification = value;
                    OnPropertyChanged(nameof(Identification));
                }
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

    

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public LoginViewModel(InfoBar notificationInfoBar, INavigationService navigationService)
        {
            LoginCommand = new RelayCommand(OnLogin);
            _infoBar = notificationInfoBar;
            _loginService = new LoginService();
            _navigationService = navigationService;
            LoginGuessCommand = new RelayCommand(OnLoginGuess);
        }
        public event PropertyChangedEventHandler? PropertyChanged;


        public async void OnLoginGuess()
        {
            _navigationService.NavigateTo<HomeParkingViewModel>();
        }



        public async void OnLogin()
        {
            if (string.IsNullOrEmpty(this._identification) || string.IsNullOrEmpty(this._password))
            {
                NotificationHelper.ShowNotification(_infoBar, "Error", "Por favor ingrese identificacion y contraseña", InfoBarSeverity.Error);
                return;
            }

            LoginResponse response = await _loginService.Login(_identification, _password);

            if (response == null)
            {
                NotificationHelper.ShowNotification(_infoBar, "Error", "Inicio de sesión fallido. Verifique sus credenciales.", InfoBarSeverity.Error);
                return;
            }
            else
            {
                NotificationHelper.ShowNotification(_infoBar, "Success", "Inicio de sesión exitoso.", InfoBarSeverity.Success);

                _navigationService.NavigateTo<HomeParkingViewModel>();

            }
        }

     
   


    }
}
