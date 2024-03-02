using BicycleCheckList.ViewModels;

namespace BicycleCheckList
{
    public partial class OverviewPage : ContentPage
    {
        public OverviewPage(OverviewViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }

}
