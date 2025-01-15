using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using ParkingFront.DTO.Login;
<<<<<<< HEAD
using ParkingFront.Services.DialogService;
using ParkingFront.Services.Navigation;
using ParkingFront.ViewModels.HomeParking;
using ParkingFront.ViewModels.Login;
=======
using ParkingFront.ViewModels.HomeParking;
>>>>>>> de16f389f219835cd8662c665b819e1cde6bde72
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ParkingFront.Views.Home
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
<<<<<<< HEAD
        private HomeParkingViewModel _viewModel;
=======
        private LoginResponse _loginResponse;
        private HomeParkingViewModel ViewModel;
>>>>>>> de16f389f219835cd8662c665b819e1cde6bde72

        public HomePage()
        {
            this.InitializeComponent();
<<<<<<< HEAD
            _viewModel = (HomeParkingViewModel)App.Services.GetService(typeof(HomeParkingViewModel));
            _viewModel = new HomeParkingViewModel(NotificationInfoBar, (IDialogService)App.Services.GetService(typeof(IDialogService)));
            _viewModel.XamlRoot = this.Content.XamlRoot;
            this.DataContext = _viewModel;

        }

        private void ValidateRent()
        {
            // Pasar el XamlRoot al ViewModel
            _viewModel.ValidateRentCommand.Execute(this.Content.XamlRoot);
        }



=======
            ViewModel = new HomeParkingViewModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is LoginResponse loginResponse)
            {
                _loginResponse = loginResponse;
                ViewModel.ClientName = _loginResponse.user.name;
            }
        }

>>>>>>> de16f389f219835cd8662c665b819e1cde6bde72
    }
}
