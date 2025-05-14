using BicycleCheckList.Models;
using BicycleCheckList.Views;

namespace BicycleCheckList
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(CheckItemsConfigPage), typeof(CheckItemsConfigPage));
            Routing.RegisterRoute(nameof(UpdateCheckItemPage), typeof(UpdateCheckItemPage));
            Routing.RegisterRoute(nameof(TourListPage), typeof(TourListPage));
        }
    }
}
