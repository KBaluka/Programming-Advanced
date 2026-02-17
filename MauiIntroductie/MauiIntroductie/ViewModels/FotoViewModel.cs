using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiIntroductie.ViewModels
{
    public partial class FotoViewModel: BaseViewModel
    {
        [ObservableProperty]
        int hoogte, breedte;
    }
}
