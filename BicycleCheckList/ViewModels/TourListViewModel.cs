using BicycleCheckList.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace BicycleCheckList.ViewModels
{
    public partial class TourListViewModel : BaseViewModel
    {
       
        public TourList Tours { get; }

        [ObservableProperty]
        Tour? selectedTour;

        partial void OnSelectedTourChanged(Tour? oldValue, Tour? newValue)
        {
            Debug.WriteLine($"Changed: Old = {oldValue?.Name}, New = {newValue?.Name}");
        }

        public TourListViewModel()
        {
            this.Tours = new TourList();
            Tours.Load();
            SelectedTour = Tours.AllTours?[Tours.CurrentTour];
            Title = "Tour list";
        }
    }
}
