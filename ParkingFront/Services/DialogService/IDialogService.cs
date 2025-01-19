﻿using Microsoft.UI.Xaml.Controls;
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
        Task ShowMessageAsync(string title, string content);
    }
}
