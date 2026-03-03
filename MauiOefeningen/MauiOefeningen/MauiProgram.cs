using MauiOefeningen.ViewModels;
using MauiOefeningen.Views;
using Microsoft.Extensions.Logging;

namespace MauiOefeningen
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<NaamTonenViewModel>();
            builder.Services.AddSingleton<NaamTonenPage>();

            builder.Services.AddSingleton<VakViewModel>();
            builder.Services.AddSingleton<VakPage>();

            builder.Services.AddSingleton<AfbeeldingenViewModel>();
            builder.Services.AddSingleton<AfbeeldingenPage>();

            builder.Services.AddSingleton<VragenLijstViewModel>();
            builder.Services.AddSingleton<VragenLijstPage>();

            builder.Services.AddSingleton<AlleNegenViewModel>();
            builder.Services.AddSingleton<AlleNegenPage>();

            builder.Services.AddSingleton<GetallenRijViewModel>();
            builder.Services.AddSingleton<GetallenRijPage>();

            builder.Services.AddSingleton<FactuurViewModel>();
            builder.Services.AddSingleton<FactuurPage>();

            builder.Services.AddSingleton<GameViewModel>();
            builder.Services.AddSingleton<GamePage>();

            builder.Services.AddSingleton<PersonenIngevenViewModel>();
            builder.Services.AddSingleton<PersonenIngevenPage>();
            builder.Services.AddSingleton<PersonenTonenPage>();

            builder.Services.AddSingleton<IGameRepository, GameRepository>();

            return builder.Build();
        }
    }
}