using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Mvvm.Input;

namespace MauiIntroductie.ViewModels
{
    public partial class BaseViewModel: ObservableObject
    {
        [ObservableProperty]
        string title;

        [RelayCommand]
        public static async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
