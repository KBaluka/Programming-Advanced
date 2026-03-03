using System;
using System.Collections.Generic;
using System.Text;

namespace MauiIntroductie.Data.IRepositories
{
    public interface IWerknemerRepository
    {
        public List<Werknemer> GetWerknemers();
        public Werknemer GetWerknemerById(int werknemerId);
    }
}
