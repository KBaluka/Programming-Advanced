using System;
using System.Collections.Generic;
using System.Text;

namespace MauiOefeningen.Models;
public class Product
{
    public string Naam { get; set; } = "";
    public decimal Prijs { get; set; }
    public int Aantal { get; set; }
    public decimal Totaal => Prijs * Aantal;
}
