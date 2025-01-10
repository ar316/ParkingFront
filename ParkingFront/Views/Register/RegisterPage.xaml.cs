using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using ParkingFront.ViewModels.Register;
using ParkingFront.Views.Login;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;


namespace ParkingFront.Views.Register
{

    public sealed partial class RegisterPage : Page
    {

        private RegisterViewModel _registerViewModel;
        public RegisterPage()
        {
            this.InitializeComponent();
            _registerViewModel = new RegisterViewModel(OnNavigateBack, NotificationInfoBar);
            this.DataContext = _registerViewModel;
        }

        private void OnNavigateBack()
        {
            Frame.Navigate(typeof(LoginPage));
        }
    }
}
