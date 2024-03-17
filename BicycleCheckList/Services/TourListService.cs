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

        public static TourList? ReadFromJson()
        {
            string appDir = FileSystem.Current.AppDataDirectory;
            try
            {
                string json = File.ReadAllText(Path.Combine(appDir, tourListFilename));
                TourList? tourList = JsonSerializer.Deserialize<TourList?>(json);
                return tourList;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return null;
            }
        }

        public static TourList ReadFromJsonOrPredefinedTour()
        {
            var tourlist = ReadFromJson();
            if (tourlist == null)
            {
                tourlist = new TourList();
                
            }
            return tourlist;
        }


        public static void WriteToJson(TourList tourList)
        {
            string appDir = FileSystem.Current.AppDataDirectory;
            string json = JsonSerializer.Serialize(tourList, ServiceOptions.jsonOptions);
            File.WriteAllText(Path.Combine(appDir, tourListFilename), json);
        }
    }
}
