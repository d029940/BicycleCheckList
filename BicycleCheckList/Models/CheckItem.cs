using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleCheckList.Models
{
    public class CheckItem(string name, bool isChecked = false, string language = "en-US")
    {
        public bool IsChecked { get; set; } = isChecked;
        public string Name { get; set; } = name;
        public string? Language { get; set; } = language;
    }
}
