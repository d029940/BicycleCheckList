using BicycleCheckList.Models;
using BicycleCheckList.ModelViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleCheckList.ViewModels
{
    public partial class OverviewViewModel: BaseViewModel
    {

        ObservableCollection<CheckItem> CheckItems { get; } = new();
    }
}
