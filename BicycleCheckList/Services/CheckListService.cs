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
        static readonly string[] predefinedCategories = ["Rain Clothes", "Bicycle Clothes", "Underwear", "Toilette Arctiles", "First Aid", "Medicine", "Bicycle Gears"];
        public List<string> Categories { get; private set; } = new List<string>(predefinedCategories);

        static readonly CheckItem[] predefinedCheckList = [
            new CheckItem { Category = "Rain Clothes", Name = "Rain trouser", IsChecked = true },
            new CheckItem(category: "Bicycle Gears", name: "Tube", isChecked: true)

            ];
        public List<CheckItem> CheckList { get; private set; } = new List<CheckItem>(predefinedCheckList);



    }
}
