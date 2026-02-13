using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiIntroductie.ViewModels
{
    public partial class PersoonViewModel: ObservableObject
    {
        [ObservableProperty]
        public string naam;

        partial void OnNaamChanging(string value)
        {
            Shell.Current.DisplayAlert("Changing", naam, "ok");
        }
        partial void OnNaamChanged(string value)
        {
            Shell.Current.DisplayAlert("Changed", Naam, "ok");
        }
    }
}
