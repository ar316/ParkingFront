using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using ParkingFront.Services.DialogService;
using ParkingFront.Services.Navigation;
using ParkingFront.Utilities;

using ParkingFront.ViewModels.HomeParking;
using ParkingFront.ViewModels.Login;
using ParkingFront.ViewModels.Register;
using ParkingFront.Views.Login;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using LaunchActivatedEventArgs = Microsoft.UI.Xaml.LaunchActivatedEventArgs;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ParkingFront
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider Services { get; private set; }
        private Window _window;
        public App()
        {
            this.InitializeComponent();
            ConfigureServices();
        }

        private void ConfigureServices()
        {
            var services = new ServiceCollection();

            // Registrar los ViewModels
            services.AddTransient<LoginViewModel>();
            services.AddTransient<RegisterViewModel>();
            services.AddTransient<HomeParkingViewModel>();
            services.AddTransient<MainWindow>();
            services.AddSingleton<InfoBar>();
            services.AddSingleton<IDialogService, DialogService>();


            // Registrar el servicio de navegación
            services.AddSingleton<INavigationService>(provider =>
            {
                var frame = new Frame();
                _window.Content = frame;
                return new NavigationService(frame);
            });

            Services = services.BuildServiceProvider();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            _window = new MainWindow();
            _window.Activate();

            var navigationService = Services.GetService<INavigationService>();
            navigationService.NavigateTo<LoginViewModel>();
        }
    }
}
