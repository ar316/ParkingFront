using CommunityToolkit.WinUI.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;

namespace ParkingFront.Utilities
{
    public class ToastNotificationHelper
    {
        public static void ShowToastNotification(string title, string content)
        {
      
            var toastContent = new ToastContentBuilder()
                .AddText(title)
                .AddText(content)
                .GetToastContent();

     
            var toast = new ToastNotification(toastContent.GetXml());

            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }
    }
}
