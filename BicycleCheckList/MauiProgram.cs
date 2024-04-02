using BicycleCheckList.ViewModels;
using BicycleCheckList.Services;
using BicycleCheckList.Views;
using Microsoft.Extensions.Logging;
using BicycleCheckList.Models;

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
                    fonts.AddFont("MaterialIcons-Regular.ttf", "GoogleMaterialFont");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddTransient<UpdateCheckItemViewModel>();
            builder.Services.AddTransient<UpdateCheckItemPage>();


            builder.Services.AddTransient<CheckItemConfigViewModel>();
            builder.Services.AddTransient<CheckItemsConfigPage>();

            builder.Services.AddSingleton<TourListViewModel>();
            builder.Services.AddSingleton<TourListPage>();

            builder.Services.AddSingleton<OverviewViewModel>();
            builder.Services.AddSingleton<OverviewPage>();

            return builder.Build();
        }
    }
}
