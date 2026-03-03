using System;
using System.Collections.Generic;
using System.Text;

namespace MauiIntroductie.Models
{
    public class Functie
    {
        public string Naam { get; set; }
        public override bool Equals(object? obj)
        {
            return obj is Functie functie && functie.Naam == this.Naam;
        }
        public override string ToString()
        {
            return this.Naam;
        }
    }
}
