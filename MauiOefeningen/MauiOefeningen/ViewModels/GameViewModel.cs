using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using CommunityToolkit.Mvvm.Input;

namespace MauiOefeningen.ViewModels;

public partial class GameViewModel : BaseViewModel
{
    readonly IGameRepository repo;
    public ObservableCollection<Game> Games { get; } = new();

    [ObservableProperty] 
    Game? selectedGame;
    [ObservableProperty] 
    int id;
    [ObservableProperty]
    string naam, uitgever;
    [ObservableProperty] 
    double moeilijkheidsgraad;

    public GameViewModel(IGameRepository repo)
    {
        this.repo = repo;
        Title = "GamePage";
        foreach (var g in repo.GetGames())
            Games.Add(g);
        NieuwGame();
    }

    partial void OnSelectedGameChanged(Game? value)
    {
        if (value == null) return;
        Id = value.Id;
        Naam = value.Naam;
        Moeilijkheidsgraad = value.Moeilijkheidsgraad;
        Uitgever = value.Uitgever;
    }

    [RelayCommand]
    void NieuwGame()
    {
        SelectedGame = null;
        Id = 0;
        Naam = "";
        Moeilijkheidsgraad = 1;
        Uitgever = "";
    }

    [RelayCommand]
    void Toevoegen()
    {
        var g = new Game
        {
            Id = Id,
            Naam = Naam ?? "",
            Moeilijkheidsgraad = (int)Moeilijkheidsgraad,
            Uitgever = Uitgever ?? ""
        };
        repo.AddGame(g);
        Games.Add(g);
        NieuwGame();
    }
}