using BicycleCheckList.ViewModels;

namespace BicycleCheckList
{
    public partial class OverviewPage : ContentPage
    {
        readonly OverviewViewModel viewModel;
        public OverviewPage(OverviewViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            BindingContext = viewModel;
        }

        // There is no command for CheckBox. But on checking code should be executed
        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            viewModel.CheckedItemChanged(e.Value);
        }
    }

}
