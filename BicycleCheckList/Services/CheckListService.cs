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
        public List<string> Categories { get; private set; } = new List<string>(predefinedCategories);

        static readonly CheckItem[] predefinedCheckList = [
            new CheckItem("Rain trouser"),
            new CheckItem("Tube")

            ];
        public List<CheckItem> CheckList { get; private set; } = new List<CheckItem>(predefinedCheckList);
        // public List<CheckItemGroup> CheckItemGroups { get; private set; } = new List<CheckItemGroup>(new CheckItemGroup(predefinedCategories[0], CheckList));



    }
}
