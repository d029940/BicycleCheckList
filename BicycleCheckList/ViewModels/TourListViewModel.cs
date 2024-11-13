using BicycleCheckList.Models;
using BicycleCheckList.Resources.Strings;
using BicycleCheckList.Services;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Xml.Linq;

namespace BicycleCheckList.ViewModels
{
    public partial class TourListViewModel : BaseViewModel
    {
        #region Properties to be used by the page
        //[ObservableProperty]
        //public TourList tours;
        public ObservableCollection<Tour> AllTours { get; }

        [ObservableProperty]
        Tour? selectedTour;
        #endregion

        #region class vars
        readonly OverviewViewModel overviewViewModel;
        private readonly TourList tours;
        private readonly int currentTour = 0;
        #endregion

        public TourListViewModel()
        {
            tours = overviewViewModel.TourList;

            currentTour = tours.CurrentTour;
            if (tours.AllTours != null)
            {
                AllTours = new ObservableCollection<Tour>(tours.AllTours);
                SelectedTour = tours.AllTours[currentTour];
            }
            else
            {
                AllTours = [];
            }

            Title = AppResources.TourList;
        }


        [RelayCommand]
        void Save()
        {
            TourListService.WriteToJson(tours);
        }

        [RelayCommand]
        void Add()
        {
            Tour tour = new()
            {
                Name = "New Tour",
                ItemGroupList = PredefinesTourListService.StdTour()
            };
            AllTours.Add(tour);
            //SelectedTour = tour;
            //overviewViewModel.CheckItemsGroups = new ObservableCollection<CheckItemGroup>(SelectedTour!.ItemGroupList);
        }

        [RelayCommand]
        void Rename() {
            Debug.WriteLine("Rename");
        }

        [RelayCommand]
        void Reset()
        {
            TourList res = TourListService.Reset();
            if (res != null)
            {
                //tours = res;
                // TODO: Currently hard-coded
                SelectedTour = res.AllTours?[currentTour];

                overviewViewModel.CheckItemsGroups = new ObservableCollection<CheckItemGroup>(SelectedTour!.ItemGroupList);


            }
        }

    }
}
