using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using ParkingFront.DTO;
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

namespace ParkingFront.Views
{

    public sealed partial class IncioPage : Page
    {

        public ObservableCollection<Espacio> Espacios { get; set; }

        public IncioPage()
        {
            this.InitializeComponent();
            Espacios = new ObservableCollection<Espacio>();
            this.DataContext = this;
            // Llamar a un método para cargar los datos de ejemplo
            CargarDatosDeEjemplo();
        }

        private void CargarDatosDeEjemplo()
        {
            // Aquí agregarías los datos que llegan desde el backend
            Espacios.Add(new Espacio { ID = 1, Piso = 1, Zona = "A", NumeroEspacio = "1", Estado = "Disponible" });
            Espacios.Add(new Espacio { ID = 2, Piso = 1, Zona = "A", NumeroEspacio = "2", Estado = "Ocupado" });
            Espacios.Add(new Espacio { ID = 3, Piso = 2, Zona = "B", NumeroEspacio = "3", Estado = "Disponible" });
            // Agrega más datos según sea necesario
        }
    }
}
