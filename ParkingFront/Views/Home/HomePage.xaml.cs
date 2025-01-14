using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using ParkingFront.DTO.Login;
using ParkingFront.Services.DialogService;
using ParkingFront.Services.Navigation;
using ParkingFront.ViewModels.HomeParking;
using ParkingFront.ViewModels.Login;
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
        private HomeParkingViewModel _viewModel;

        public HomePage()
        {
            this.InitializeComponent();
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



    }
}
