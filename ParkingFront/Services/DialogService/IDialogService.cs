using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingFront.Services.DialogService
{
    public interface IDialogService
    {
        Task<ContentDialogResult> ShowDialogAsync(XamlRoot xamlRoot, string title, string content, string primaryButtonText = "Aceptar", string closeButtonText = "Cancelar");
    }
}
