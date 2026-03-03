using System;
using System.Collections.Generic;
using System.Text;

namespace MauiOefeningen.Models;
public class Persoon
{
    public string Voornaam { get; set; } = "";
    public DateTime Geboortedatum { get; set; } = DateTime.Today;
}
