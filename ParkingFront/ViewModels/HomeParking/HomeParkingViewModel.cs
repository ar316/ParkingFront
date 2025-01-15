using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using ParkingFront.Services.DialogService;
using ParkingFront.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ParkingFront.ViewModels.HomeParking
{
    public class HomeParkingViewModel : INotifyPropertyChanged
    {

        private string _plate;
        private readonly InfoBar _infoBar;
        public ICommand ValidateRentCommand { get; }
        private readonly IDialogService _dialogService;

        public string Plate
        {
            get => _plate;
            set
            {
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public HomeParkingViewModel(InfoBar infoBar, IDialogService dialogService)
        {
            _infoBar = infoBar;
            ValidateRentCommand = new RelayCommand<XamlRoot>(async (xamlRoot) => await ValidateRent(xamlRoot));
            _dialogService = dialogService;
    }

        private async void ValidateRent()
        {
           NotificationHelper.ShowNotification(_infoBar, "Rent validated", this.Plate ,  InfoBarSeverity.Success);
           ToastNotificationHelper.ShowToastNotification("Validacion", "Puede continuar .");
            await ShowDialog();
        }

        private async Task ShowDialog()
        {
            // Aquí necesitas pasar el XamlRoot desde la vista
            var result = await _dialogService.ShowDialogAsync(null, "Título del diálogo", "Este es el contenido del diálogo.");

            if (result == ContentDialogResult.Primary)
            {
                await _dialogService.ShowDialogAsync(null, "Resultado", "Has aceptado el diálogo.", "Ok");
            }
            else
            {
                await _dialogService.ShowDialogAsync(null, "Resultado", "Has cancelado el diálogo.", "Ok");
            }
        }
    }

}
