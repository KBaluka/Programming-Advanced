using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiIntroductie.ViewModels
{
    public partial class FotoViewModel: ObservableObject
    {
        [ObservableProperty]
        int hoogte, breedte;
    }
}
