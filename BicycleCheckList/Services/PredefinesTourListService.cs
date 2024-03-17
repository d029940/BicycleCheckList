using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BicycleCheckList.Core;
using BicycleCheckList.Models;

namespace BicycleCheckList.Services
{
    public class PredefinesTourListService
    {
        const string checkItemsFilename = "checklist.json";
        // Define a map of groups (string) with checkitems (List<string>)
        //static readonly string[] predefinedCategories = ["Rain Clothes", "Bicycle Clothes", "Underwear", "Toilette Arctiles", "First Aid", "Medicine", "Bicycle Gears"];

        public List<CheckItemGroup> CheckItemsGroups { get; } = BuildFactory();

        private static List<CheckItemGroup> BuildFactory() =>
            [
                new CheckItemGroup("Rain Clothes",
                [
                    new("Trouser", 1, "en-US"),
                    new("Shoes", 1, "en-US")
                ]),
                new CheckItemGroup("Bicycle Gears",
                [
                    new("Tube"),
                    new("Tools")
                ]),
                new CheckItemGroup("Kosmetik",
                [
                    new("Badeschuhe"),
                    new("Sonnencreme"),
                    new("Creme"),
                    new("Papiertaschentücher"),
                    new("Nagelschere / -feile"),
                    new("Nagelknipser"),
                    new("Shampoo"),
                    new("Mundwasser"),
                    new("Kamm / Bürste"),
                    new("Deo"),
                    new("Rasierschaum"),
                    new("Zahnsticks"),
                    new("Zahnpasta"),
                    new("Zahnseide"),
                    new("Zahnbürste"),
                    new("Rasierer + Klingen"),
                    new("Duschgel"),
                ])
            ];

        public static List<CheckItemGroup> ReadFromJson()
        {
            try
            {
                string appDir = FileSystem.Current.AppDataDirectory;
                string json = File.ReadAllText(Path.Combine(appDir, checkItemsFilename));
                List<CheckItemGroup>? checkItems = JsonSerializer.Deserialize<List<CheckItemGroup>>(json);
                if (checkItems != null ) { return checkItems; }
                return BuildFactory();
                
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return BuildFactory();
            }       
        }

        public static void WriteToJson(List<CheckItemGroup> items)
        {
            string appDir = FileSystem.Current.AppDataDirectory;
            string json = JsonSerializer.Serialize(items, ServiceOptions.jsonOptions);
            File.WriteAllText(Path.Combine(appDir, checkItemsFilename), json);
        }

    }
}