using BicycleCheckList.Core;
using BicycleCheckList.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BicycleCheckList.Services
{
    class TourListService
    {
        const string tourListFilename = "tourlist.json";

        public static TourList ReadFromJson()
        {
            string appDir = FileSystem.Current.AppDataDirectory;

            try
            {
                TourList? tourList = null;
                string json = File.ReadAllText(Path.Combine(appDir, tourListFilename));
                tourList = JsonSerializer.Deserialize<TourList?>(json);

                if (tourList != null)
                {
                    return tourList;
                }
                else
                {
                    // Create predefined tour list
                    return TourListFromStd();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                // Create predefined tour list
                return TourListFromStd();
            }
        }

        private static TourList TourListFromStd()
        {
            List<CheckItemGroup> checkItems = PredefinesTourListService.StdTour();
            Tour tour = new() { Name = "Standard Tour", ItemGroupList = checkItems };

            TourList tourList = new();
            List<Tour> tours = [tour];

            tourList.AllTours = tours;
            tourList.CurrentTour = 0;

            return tourList;
        }


        public static void WriteToJson(TourList tourList)
        {
            string appDir = FileSystem.Current.AppDataDirectory;
            string json = JsonSerializer.Serialize(tourList, ServiceOptions.jsonOptions);
            File.WriteAllText(Path.Combine(appDir, tourListFilename), json);
        }
    }
}
