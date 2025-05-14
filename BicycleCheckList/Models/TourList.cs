using BicycleCheckList.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleCheckList.Models
{
    public class TourList
    {
        public int CurrentTour { get; set; }
        public List<Tour>? AllTours { get; set; }

        public void Load()
        {
            TourList tours = TourListService.ReadFromJson();
                AllTours = tours.AllTours;
                CurrentTour = tours.CurrentTour;
        }


        public void Save()
        {
            TourListService.WriteToJson(this);
        }
    }
}
