using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace ParkingFront.Converter
{
    public class EstadoToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string estado = value as string;
            switch (estado)
            {
                case "Disponible":
                    return new SolidColorBrush(Microsoft.UI.Colors.Green);
                case "Ocupado":
                    return new SolidColorBrush(Microsoft.UI.Colors.Red);
                default:
                    return new SolidColorBrush(Microsoft.UI.Colors.Gray);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
