using BicycleCheckList.Models;
using BicycleCheckList.Services;
using BicycleCheckList.ViewModels;
using BicycleCheckList.Views;
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

namespace BicycleCheckList.ViewModels
{
    public partial class OverviewViewModel : BaseViewModel
    {
        public List<CheckItemGroup> CheckItemsGroups { get; }

        readonly TourList tourList;

        readonly int selectedTour = 0;
        public OverviewViewModel()
        {
            tourList = new TourList();
            tourList.Load();
            selectedTour = tourList.CurrentTour;
            CheckItemsGroups = tourList!.AllTours![selectedTour].ItemGroupList;
            Title = "Overview";
        }

        [RelayCommand]
        void Save()
        {
            tourList!.AllTours![selectedTour].ItemGroupList = CheckItemsGroups;
            TourListService.WriteToJson(tourList);
        }

        [RelayCommand]
        async Task GoToCheckItemsConfigPage()
        {
            await Shell.Current.GoToAsync(nameof(CheckItemsConfigPage), true);
        }

        [RelayCommand]
        async Task GoToTourListPage()
        {
            // Set Selected Tour
            Dictionary<string, object> param = new Dictionary<string, object>()
            {
                { "SelectedTour", selectedTour }
            };
            await Shell.Current.GoToAsync($"{nameof(TourListPage)}", true, (IDictionary<string, object>)param);
        }

    }

}
