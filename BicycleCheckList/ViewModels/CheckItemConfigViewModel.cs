using BicycleCheckList.Models;
using BicycleCheckList.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleCheckList.ViewModels
{
    public class CheckItemConfigViewModel: BaseViewModel
    {

        CheckListService checkListService;
        public List<CheckItemGroup> CheckItemsGroups { get; }

        public CheckItemConfigViewModel(CheckListService checkListService)
        {
            this.checkListService = checkListService;

            CheckItemsGroups = checkListService.CheckItemsGroups;

            Title = "Check Item Configuration";
        }


    }
}
