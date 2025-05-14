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
        public List<CheckItemGroup> CheckItemsGroups { get; }

        public CheckItemConfigViewModel()
        {
            CheckItemsGroups = PredefinesTourListService.StdTour();

            Title = "Check Item Configuration";
        }

        [RelayCommand]
        async Task GoToUpdateCheckItemPage()
        {
            await Shell.Current.GoToAsync(nameof(UpdateCheckItemPage), true);
        }

    }
}
