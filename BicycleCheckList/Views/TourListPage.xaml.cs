using BicycleCheckList.Models;
using BicycleCheckList.ViewModels;

namespace BicycleCheckList.Views;

public partial class TourListPage : ContentPage
{
    public TourListPage(TourListViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}