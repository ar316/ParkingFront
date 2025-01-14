using Microsoft.UI.Xaml.Controls;
using ParkingFront.ViewModels.HomeParking;
using ParkingFront.ViewModels.Login;
using ParkingFront.ViewModels.Register;
using ParkingFront.Views.Home;
using ParkingFront.Views.Login;
using ParkingFront.Views.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingFront.Services.Navigation
{
    public class NavigationService: INavigationService
    {
        private readonly Frame _frame;

        public NavigationService(Frame frame)
        {
            _frame = frame;
        }

        public void NavigateTo<TViewModel>()
        {
            if (typeof(TViewModel) == typeof(LoginViewModel))
            {
                _frame.Navigate(typeof(LoginPage));
            }
            else if (typeof(TViewModel) == typeof(HomeParkingViewModel))
            {
                _frame.Navigate(typeof(HomePage));
            }
            else if (typeof(TViewModel) == typeof(RegisterViewModel))
            {
                _frame.Navigate(typeof(RegisterPage));
            }
        }
    }
}
