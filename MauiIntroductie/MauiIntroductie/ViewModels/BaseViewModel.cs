using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
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

        [RelayCommand]
        //In cursus zit void in plaats van Task -> het moet Task zijn en niet void
        public static async Task GoHome()
        {
            //4 backslashes maakt dat het werkt in plaats wat er in de cursus staat -> moet deze gebruiken
            // await Shell.Current.GoToAsync("\\\\HomePage");
            await Shell.Current.GoToAsync(nameof(HomePage));
        }
    }
}
