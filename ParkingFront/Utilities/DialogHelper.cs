using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingFront.Utilities
{
    public static class DialogHelper
    {
        public static async Task<ContentDialogResult> ShowDialogAsync(XamlRoot xamlRoot, string title, string content, string primaryButtonText = "Aceptar", string closeButtonText = "Cancelar")
        {
            var dialog = new ContentDialog
            {
                XamlRoot = xamlRoot,
                Title = title,
                Content = content,
                PrimaryButtonText = primaryButtonText,
                CloseButtonText = closeButtonText
            };

            return await dialog.ShowAsync();
        }
    }
}
