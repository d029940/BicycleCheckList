using BicycleCheckList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleCheckList.ViewModels
{
    public partial class TourListViewModel: BaseViewModel
    {
        public TourList Tours { get; }


        public TourListViewModel()
        {
            this.Tours = new TourList();
            Title = "Tour list";
        }
    }
}
