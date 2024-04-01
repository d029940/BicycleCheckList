using BicycleCheckList.Models;
using BicycleCheckList.Services;
using BicycleCheckList.ViewModels;
using BicycleCheckList.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BicycleCheckList.Resources.Strings;

namespace BicycleCheckList.ViewModels
{
    public partial class OverviewViewModel : BaseViewModel
    {
        #region Properties, Constructor
        [ObservableProperty]
        public ObservableCollection<CheckItemGroup> checkItemsGroups;

        public TourList TourList;

        public OverviewViewModel()
        {
            this.TourList = new TourList();
            TourList.Load();
            int selectedTour = TourList.CurrentTour;
            CheckItemsGroups = new ObservableCollection<CheckItemGroup>(TourList!.AllTours![selectedTour].ItemGroupList);
            string name = TourList.AllTours[selectedTour].Name;
            Title = $"{AppResources.OverviewTitle} - Name: {name}";
        }
        #endregion

        #region Actions
        /// <summary>
        /// Save the current tour
        /// </summary>
        [RelayCommand]
        void Save()
        {
            int selectedTour = TourList.CurrentTour;
            TourList!.AllTours![selectedTour].ItemGroupList = [.. CheckItemsGroups];
            TourListService.WriteToJson(TourList);
        }

        /// <summary>
        /// Reset all items to unchecked state
        /// </summary>
        [RelayCommand]
        void Reset()
        {
            var res = TourListService.Reset();
            if (res != null)
            {
                TourList = res;
                int selectedTour = TourList.CurrentTour;
                CheckItemsGroups = new ObservableCollection<CheckItemGroup>(TourList!.AllTours![selectedTour].ItemGroupList);
            }
        }

        [RelayCommand]
        void AddGroup()
        {
            CheckItemGroup group = new CheckItemGroup("New Category", []);
            CheckItemsGroups.Add(group);
            Save();
        }
        [RelayCommand]
        void RenameGroup()
        {
            Save();
        }

        [RelayCommand]
        async Task GoToCheckItemsConfigPage()
        {
            await Shell.Current.GoToAsync(nameof(CheckItemsConfigPage), true);
        }

        /// <summary>
        /// Navigate to the tour list page
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        async Task GoToTourListPage()
        {
            // Set Selected Tour
            int selectedTour = TourList.CurrentTour;
            Dictionary<string, object> param = new Dictionary<string, object>()
            {
                { "SelectedTour", selectedTour }
            };
            await Shell.Current.GoToAsync($"{nameof(TourListPage)}", true, (IDictionary<string, object>)param);
        }

        /// <summary>
        /// When an item is checked or unchecked save the tour.
        /// </summary>
        /// <param name="value"></param>
        public void CheckedItemChanged(Boolean value) {
            Save();
        }
        #endregion

    }

}
