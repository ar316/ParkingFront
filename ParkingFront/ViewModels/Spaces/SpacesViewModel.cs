using ParkingFront.DTO;
using ParkingFront.Services.SpacesService;
using ParkingFront.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ParkingFront.ViewModels.Spaces
{
    public class SpacesViewModel : INotifyPropertyChanged
    {
        private readonly SpaceService _spaceService;
        private int _selectedFloor;
        private string _selectedSpace;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Espacio> Espacios { get; set; }
        public ICommand SelectFloorCommand { get; }
        public ICommand SelectSpaceCommand { get; }

        public int SelectedFloor
        {
            get => _selectedFloor;
            set
            {
                if (_selectedFloor != value)
                {
                    _selectedFloor = value;
                    OnPropertyChanged(nameof(SelectedFloor));
                    LoadSpacesForFloorAsync(_selectedFloor);
                }
            }
        }

        public string SelectedSpace
        {
            get => _selectedSpace;
            set
            {
                if (_selectedSpace != value)
                {
                    _selectedSpace = value;
                    OnPropertyChanged(nameof(SelectedSpace));
                }
            }
        }

        public SpacesViewModel(SpaceService spaceService)
        {
            _spaceService = spaceService;
            Espacios = new ObservableCollection<Espacio>();
            SelectFloorCommand = new RelayCommand<int>(OnSelectFloor);
            SelectSpaceCommand = new RelayCommand<string>(OnSelectSpace);
            LoadSpacesForFloorAsync(1); // Default to floor 1
        }

        private void OnSelectFloor(int floor)
        {
            Debug.WriteLine($"Piso seleccionado: {floor}");
            SelectedFloor = floor;
        }

        private void OnSelectSpace(string space)
        {
            Debug.WriteLine($"Espacio seleccionado: {space}");
            SelectedSpace = space;
        }

        private async void LoadSpacesForFloorAsync(int floor)
        {
            Espacios.Clear();
            var spaces = await _spaceService.GetSpacesApi(floor);
            foreach (var espacio in spaces)
            {
                Espacios.Add(espacio);
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}