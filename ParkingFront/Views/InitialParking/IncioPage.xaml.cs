using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using ParkingFront.DTO;
using ParkingFront.ViewModels.Spaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ParkingFront.Views.InitialParking
{

    public sealed partial class IncioPage : Page
    {

        private readonly SpacesViewModel _viewModel;

        public IncioPage()
        {
            this.InitializeComponent();
            _viewModel = (SpacesViewModel)App.Services.GetService(typeof(SpacesViewModel));
            this.DataContext = _viewModel;

        }

    }
}
