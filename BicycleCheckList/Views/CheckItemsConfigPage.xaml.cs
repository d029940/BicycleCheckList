using BicycleCheckList.ViewModels;

namespace BicycleCheckList.Views;

public partial class CheckItemsConfigPage : ContentPage
{
	public CheckItemsConfigPage(CheckItemConfigViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}