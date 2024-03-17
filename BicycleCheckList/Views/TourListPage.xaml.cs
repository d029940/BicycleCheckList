using BicycleCheckList.Models;
using BicycleCheckList.ViewModels;
using System.Diagnostics;

namespace BicycleCheckList.Views;

public partial class TourListPage : ContentPage
{
    public TourListPage(TourListViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        var vm = BindingContext as TourListViewModel;
        vm.SelectedTour = vm.Tours.AllTours[vm.Tours.CurrentTour];
        Debug.WriteLine($"SelectedTour = {vm.SelectedTour}");
        base.OnNavigatedTo(args);
    }

}