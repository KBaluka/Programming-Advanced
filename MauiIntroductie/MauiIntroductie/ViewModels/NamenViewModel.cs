using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using CommunityToolkit.Mvvm.Input;

namespace MauiIntroductie.ViewModels
{
    public partial class NamenViewModel: BaseViewModel
    {
        [ObservableProperty]
        string naam;

        [ObservableProperty]
        ObservableCollection<string> namen;

        public NamenViewModel()
        {
            this.Title = "Namen toevoegen";
            this.Namen = [];
        }

        [RelayCommand]
        private void NaamToevoegen()
        {
            this.Namen.Add(this.naam);
            this.Naam = "";
        }
    }
}


// <DataTemplate x:DataType="x:String"> dit moet bij NamenPage.xaml inzitten om te werken