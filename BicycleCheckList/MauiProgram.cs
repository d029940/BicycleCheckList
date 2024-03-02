using BicycleCheckList.ViewModels;
using BicycleCheckList.Services;
using Microsoft.Extensions.Logging;

namespace BicycleCheckList
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
            builder.Services.AddSingleton<CheckListService>();
            builder.Services.AddSingleton<OverviewViewModel>();
            builder.Services.AddSingleton<OverviewPage>();

            return builder.Build();
        }
    }
}
