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
        public List<Tour> AllTours { get; set; }

        public TourList()
        {
            // 1. read from json
            var tours = TourListService.ReadFromJson();
            if (tours !=  null)
            {
                AllTours = tours.AllTours;
                CurrentTour = tours.CurrentTour;
                return;
            }
            // 2. if tour list is empty, create standard tour list
            CurrentTour = 0;
            AllTours = [];
            var checkGroups = PredefinesTourListService.ReadFromJson();
            var tour = new Tour{ Name = "Standard Tour", ItemGroupList = checkGroups };
            AllTours.Add(tour);
        }


        public void Save()
        {
            TourListService.WriteToJson(this);
        }
    }
}
