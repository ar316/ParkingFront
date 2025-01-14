using Microsoft.UI.Xaml.Controls;
using ParkingFront.Services.RegisterService;
using ParkingFront.Utilities;
using ParkingFront.Views.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Services.Maps;


namespace ParkingFront.ViewModels.Register
{
    internal class RegisterViewModel : INotifyPropertyChanged
    {

        private string _nombre;
        private string _identificacion;
        private string _contrasena;
        private string _correo;
        private string _phone;

        public string Nombre
        {
            get => _nombre;
            set
            {
                if (_nombre != value)
                {
                    _nombre = value;
                    OnPropertyChanged(nameof(Nombre)); 
                }
            }
        }

        public string Identificacion
        {
            get => _identificacion;
            set
            {
                if (_identificacion != value)
                {
                    _identificacion = value;
                    OnPropertyChanged(nameof(Identificacion)); 
                }
            }
        }

        public string Contrasena
        {
            get => _contrasena;
            set
            {
                if (_contrasena != value)
                {
                    _contrasena = value;
                    OnPropertyChanged(nameof(Contrasena)); 
                }
            }
        }

        public string Correo
        {
            get => _correo;
            set
            {
                if (_correo != value)
                {
                    _correo = value;
                    OnPropertyChanged(nameof(Correo)); // Notifica al binding
                }
            }
        }

        public string Phone
        {
            get => _phone;
            set
            {
                if (_phone != value)
                {
                    _phone = value;
                    OnPropertyChanged(nameof(Phone)); // Notifica al binding
                }
            }
        }


        // Comandos
        public ICommand RegisterCommand { get; }
        public ICommand BackCommand { get; }

        private readonly Action _navigateBack;

        private readonly RegisterService _apiService;
        private readonly InfoBar _infoBar;

        // Constructor
        public RegisterViewModel(Action navigateBack, InfoBar infoBar)
        {
            _navigateBack = navigateBack;
            RegisterCommand = new RelayCommand(OnRegister);
            BackCommand = new RelayCommand(OnBack);
            _apiService = _apiService = new RegisterService();
            _infoBar = infoBar;
        }

      

        // Método que se ejecuta al registrarse
        private async void OnRegister()
        {
            if (string.IsNullOrEmpty(this._nombre) || string.IsNullOrEmpty(this._identificacion) ||
                string.IsNullOrEmpty(this._contrasena) || string.IsNullOrEmpty(this._correo))
            {
                NotificationHelper.ShowNotification(_infoBar, "Error", "Debe completar todos los campos.", InfoBarSeverity.Error);
                return;
            }

            var result = await _apiService.RegisterUserAsync(_identificacion, _nombre, _phone,  _correo, _contrasena);
           
            if (result)
            {
                NotificationHelper.ShowNotification(_infoBar, "Éxito", "Registro exitoso.", InfoBarSeverity.Success);
                
            }
            else
            {
                NotificationHelper.ShowNotification(_infoBar, "Error", "Registro inválido.", InfoBarSeverity.Error);
            }
        }

       

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnBack()
        {
            _navigateBack?.Invoke();
        }
    }
}
