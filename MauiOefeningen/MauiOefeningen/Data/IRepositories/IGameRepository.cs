using System;
using System.Collections.Generic;
using System.Text;
using MauiOefeningen.Models;

namespace MauiOefeningen.Data.IRepositories;
public interface IGameRepository
{
    List<Game> GetGames();
    void AddGame(Game game);
}