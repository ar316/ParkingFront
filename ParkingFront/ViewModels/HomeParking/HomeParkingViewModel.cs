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
using Windows.UI.Notifications;


namespace ParkingFront.ViewModels.HomeParking
{
    public class HomeParkingViewModel : INotifyPropertyChanged
    {

        private string _plate;
        private readonly InfoBar _infoBar;
        public ICommand ValidateRentCommand { get; }
        private readonly Action _notification;
        private readonly IDialogService _dialogService;

        public string Plate
        {
            get => _plate;
            set
            {
                _plate = value;
                OnPropertyChanged(nameof(Plate));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public HomeParkingViewModel(InfoBar infoBar, IDialogService dialogService )
        {
            _dialogService = dialogService;
            _infoBar = infoBar;
            ValidateRentCommand = new RelayCommand(ValidateRent);
        
    }

        private async void ValidateRent()
        {
            if(this._plate.Length >= 5 && this._plate.Length < 5)
            {
                NotificationHelper.ShowNotification(_infoBar, "Rent validated", this._plate, InfoBarSeverity.Success);
            }
            else
            {
                NotificationHelper.ShowNotification(_infoBar, "Rent invaluidaaaa", this._plate, InfoBarSeverity.Error);
            }



        }

       

    }

}
