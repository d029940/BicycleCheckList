using BicycleCheckList.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            SelectedTour = Tours.AllTours[Tours.CurrentTour];
            Title = "Tour list";
        }
    }
}
