using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleCheckList.Models
{
    public class CheckItem
    {
        public bool IsChecked { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string? Language { get; set; }

        public CheckItem() { }
        public CheckItem(string category, string name, bool isChecked = false, string language = "en-US")
        {
            IsChecked = isChecked;
            Category = category;
            Name = name;
            Language = language;
        }
    }
}
