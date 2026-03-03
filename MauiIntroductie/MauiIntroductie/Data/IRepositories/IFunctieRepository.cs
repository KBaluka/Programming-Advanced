using System;
using System.Collections.Generic;
using System.Text;

namespace MauiIntroductie.Data.IRepositories
{
    public interface IFunctieRepository
    {
        public List<Functie> GetFuncties();
    }
}
