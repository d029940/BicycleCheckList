using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BicycleCheckList.Models;

namespace BicycleCheckList.Services

{
    public class CheckListService
    {
        // Define a map of groups (string) with checkitems (List<string>)
        static readonly string[] predefinedCategories = ["Rain Clothes", "Bicycle Clothes", "Underwear", "Toilette Arctiles", "First Aid", "Medicine", "Bicycle Gears"];

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

    }
}