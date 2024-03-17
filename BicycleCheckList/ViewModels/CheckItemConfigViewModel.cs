using BicycleCheckList.Models;
using BicycleCheckList.Services;
using BicycleCheckList.Views;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleCheckList.ViewModels
{
    public partial class CheckItemConfigViewModel: BaseViewModel
    {
        // TODO: Define obervabel prop SelectedTour
        PredefinesTourListService checkListService;
        public List<CheckItemGroup> CheckItemsGroups { get; }

        public CheckItemConfigViewModel(PredefinesTourListService checkListService)
        {
            this.checkListService = checkListService;

            CheckItemsGroups = checkListService.CheckItemsGroups;

            Title = "Check Item Configuration";
        }

        [RelayCommand]
        async Task GoToUpdateCheckItemPage()
        {
            await Shell.Current.GoToAsync(nameof(UpdateCheckItemPage), true);
        }

    }
}
