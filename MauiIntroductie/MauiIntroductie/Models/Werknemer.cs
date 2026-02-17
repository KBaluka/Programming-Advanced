using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MauiIntroductie.Models
{
    public class Werknemer
    {
        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Functie { get; set; }
        public DateTime Geboortedatum { get; set; } = new DateTime(1990, 01, 01);
        public DateTime InDienst { get; set; } = DateTime.Now;
        public string VolledigeNaam => $"{Voornaam} {Achternaam}";
    }
}
