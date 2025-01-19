using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingFront.Services.DialogService
{
    public class DialogService: IDialogService
    {
        public async Task ShowMessageAsync(string title, string content)
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = title,
                Content = content,
                CloseButtonText = "Aceptar"
            };

            var windowContent = Window.Current?.Content as FrameworkElement;
            if (windowContent != null)
            {
                dialog.XamlRoot = windowContent.XamlRoot;
            }
            else
            {
                // Handle the case where Window.Current.Content is null
                throw new InvalidOperationException("The application's window content is not set.");
            }

            await dialog.ShowAsync();
        }
    }
}
