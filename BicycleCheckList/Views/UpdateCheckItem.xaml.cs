using BicycleCheckList.ViewModels;

namespace BicycleCheckList.Views;

public partial class UpdateCheckItemPage : ContentPage
{
	public UpdateCheckItemPage(UpdateCheckItemViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}