using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace MauiIntroductie.ViewModels
{
    public partial class StackLayoutViewModel : BaseViewModel
    {
        [ObservableProperty]
        public string naam, email, telefoon, uitvoer, geslacht;

        [RelayCommand]
        public void UitvoerTonen()
        {
            this.Uitvoer = $"Dag {this.Naam}, je email {this.Email}, {this.Geslacht}";
        }
    }
}
