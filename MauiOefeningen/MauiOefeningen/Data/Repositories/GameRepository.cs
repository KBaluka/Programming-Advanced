using System;
using System.Collections.Generic;
using System.Text;
using MauiOefeningen.Data.IRepositories;
using MauiOefeningen.Models;

namespace MauiOefeningen.Data.Repositories;
public class GameRepository : IGameRepository
{
    private readonly List<Game> games = new()
    {
        new Game { Id = 1, Naam = "Cluedo",        Moeilijkheidsgraad = 2, Uitgever = "Hasbro Gaming" },
        new Game { Id = 2, Naam = "Monopoly",      Moeilijkheidsgraad = 3, Uitgever = "Parker" },
        new Game { Id = 3, Naam = "Machiavelli",   Moeilijkheidsgraad = 3, Uitgever = "999 Games" },
        new Game { Id = 4, Naam = "Catan",         Moeilijkheidsgraad = 4, Uitgever = "999 Games" },
        new Game { Id = 5, Naam = "Carcassonne",   Moeilijkheidsgraad = 4, Uitgever = "999 Games" },
        new Game { Id = 6, Naam = "SpeakOut",      Moeilijkheidsgraad = 5, Uitgever = "Hasbro Gaming" },
        new Game { Id = 7, Naam = "Skyjo",         Moeilijkheidsgraad = 1, Uitgever = "Magilano" }
    };
    public List<Game> GetGames() => games;
    public void AddGame(Game game) => games.Add(game);
}
