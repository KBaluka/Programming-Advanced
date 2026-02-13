using MauiIntroductie.ViewModels;
using MauiIntroductie.Views;
using Microsoft.Extensions.Logging;

namespace MauiIntroductie
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
            builder.Services.AddSingleton<VoorbeeldPage>();
            builder.Services.AddSingleton<PersoonViewModel>();

            builder.Services.AddSingleton<LabelsPage>();
            builder.Services.AddSingleton<LabelsViewModel>();

            builder.Services.AddSingleton<StackLayoutPage>();
            builder.Services.AddSingleton<StackLayoutViewModel>();

            builder.Services.AddSingleton<FotoPage>();
            builder.Services.AddSingleton<FotoViewModel>();

            return builder.Build();
        }
    }
}
