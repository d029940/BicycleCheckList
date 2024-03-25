using BicycleCheckList.Models;
using BicycleCheckList.Resources.Strings;
using BicycleCheckList.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace BicycleCheckList.ViewModels
{
    public partial class TourListViewModel : BaseViewModel
    {
       
        public TourList Tours { get; set;  }

        [ObservableProperty]
        Tour? selectedTour;

        OverviewViewModel overviewViewModel;

        partial void OnSelectedTourChanged(Tour? oldValue, Tour? newValue)
        {
            Debug.WriteLine($"Changed: Old = {oldValue?.Name}, New = {newValue?.Name}");
        }

        public TourListViewModel(OverviewViewModel overviewViewModel)
        {
            this.overviewViewModel = overviewViewModel;
            this.Tours = new TourList();
            Tours.Load();
            // TODO: Currently hard-coded
            SelectedTour = Tours.AllTours?[0];
            Title = AppResources.TourList;
        }


        [RelayCommand]
        void Save()
        {
            // TODO: Currently hard-coded
            //Tours!.AllTours![0].ItemGroupList =  SelectedTour!.ItemGroupList.ToList();
            TourListService.WriteToJson(Tours);
        }

        [RelayCommand]
        void Reset()
        {
            TourList res = TourListService.Reset();
            if (res != null)
            {
                // TODO: Currently hard-coded
                SelectedTour = res.AllTours?[0];
                
                overviewViewModel.CheckItemsGroups = new ObservableCollection<CheckItemGroup>(SelectedTour!.ItemGroupList);


            }
        }

    }
}
