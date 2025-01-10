using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingFront.Utilities
{
    public static class NotificationHelper
    {
        public static void ShowNotification(InfoBar infoBar, string title, string message, InfoBarSeverity severity = InfoBarSeverity.Informational)
        {
            infoBar.Title = title;
            infoBar.Message = message;
            infoBar.Severity = severity;
            infoBar.IsOpen = true;
        }
    }
}
