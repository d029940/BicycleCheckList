using BicycleCheckList.Models;
using BicycleCheckList.Services;
using BicycleCheckList.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleCheckList.ViewModels
{
    public class OverviewViewModel : BaseViewModel
    {
        CheckListService checkListService;
        public ObservableCollection<CheckItem> CheckItems { get; } // = new();

        public OverviewViewModel(CheckListService checkListService)
        {
            this.checkListService = checkListService;
           
            CheckItems = new ObservableCollection<CheckItem>(checkListService.CheckList);
            Title = "Overview";
        }
            
            
    
    }
}
