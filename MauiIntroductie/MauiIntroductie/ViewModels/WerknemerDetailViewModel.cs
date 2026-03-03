using System;
using System.Collections.Generic;
using System.Text;

namespace MauiIntroductie.ViewModels
{
    [QueryProperty(nameof(WerknemerId), "WerknemerId")]
    public partial class WerknemerDetailViewModel: BaseViewModel
    {
        [ObservableProperty]
        Werknemer werknemer;

        [ObservableProperty]
        int werknemerId;

        private readonly IWerknemerRepository _werknemerRepository;
        public WerknemerDetailViewModel(IWerknemerRepository werknemerRepository)
        {
            this._werknemerRepository = werknemerRepository;
        }
        //identifier doorsturen in plaats van object, als je iets in de lijst aanpast blijft het ook aangepast
        partial void OnWerknemerIdChanged(int value)
        {
            this.Werknemer = this._werknemerRepository.GetWerknemerById(value);
        }
    }
}
