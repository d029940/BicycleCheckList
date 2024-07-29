using BicycleCheckList.Models;
using BicycleCheckList.Resources.Strings;
using BicycleCheckList.Services;
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
        Tour? _selectedTour;
        #endregion

        #region class vars
        readonly OverviewViewModel _overviewViewModel;
        private readonly TourList _tours;
        private readonly int _currentTour = 0;
        #endregion

        public TourListViewModel(OverviewViewModel overviewViewModel)
        {
            this._overviewViewModel = overviewViewModel;
            _tours = _overviewViewModel.TourList;

            _currentTour = _tours.CurrentTour;
            if (_tours.AllTours != null)
            {
                AllTours = new ObservableCollection<Tour>(_tours.AllTours);
                SelectedTour = _tours.AllTours[_currentTour];
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
            TourListService.WriteToJson(_tours);
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
        private static void Rename() {
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
                SelectedTour = res.AllTours?[_currentTour];

                _overviewViewModel.CheckItemsGroups = new ObservableCollection<CheckItemGroup>(SelectedTour!.ItemGroupList);


            }
        }

    }
}
