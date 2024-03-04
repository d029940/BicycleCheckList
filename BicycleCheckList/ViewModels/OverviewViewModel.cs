using BicycleCheckList.Models;
using BicycleCheckList.Services;
using BicycleCheckList.ViewModels;
using BicycleCheckList.Views;
using CommunityToolkit.Mvvm.Input;
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
        CheckListService checkListService;
        public List<CheckItemGroup> CheckItemsGroups { get; }

        public OverviewViewModel(CheckListService checkListService)
        {
            this.checkListService = checkListService;

            CheckItemsGroups = checkListService.CheckItemsGroups;

            foreach (var checkItemGroup in CheckItemsGroups)
            {
                Debug.WriteLine(checkItemGroup.Group);
            }

            Title = "Overview";


            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(CheckItemsGroups, options);
            Debug.WriteLine(json);
        }

        [RelayCommand]
        async Task GoToCheckItemsConfigPage()
        {
            await Shell.Current.GoToAsync(nameof(CheckItemsConfigPage), true);
        }
    }

}
