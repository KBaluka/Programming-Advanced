using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
namespace MauiOefeningen.ViewModels;
public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    string title;

    [ObservableProperty]
    int getal;
}