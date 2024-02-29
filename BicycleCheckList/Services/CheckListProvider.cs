using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BicycleCheckList.Models;

namespace BicycleCheckList.Providers

{
    public class CheckListProvider
    {
        static readonly string[] PredefinedCategories = ["Rain Clothes", "Bicycle Clothes", "Underwear", "Toilette Arctiles", "First Aid", "Medicine", "Bicycle Gears"];
        public List<string> Categories { get; private set; } = new List<string>(PredefinedCategories);

        static readonly CheckItem[] PredefinedCheckList = [
            new CheckItem { Category = "Rain Clothes", Name = "Rain trouser" },
            new CheckItem { Category = "Bicycle Gears", Name = "Tube" }

            ];
        public List<CheckItem> CheckList { get; private set; } = new List<CheckItem>(PredefinedCheckList);



    }
}
