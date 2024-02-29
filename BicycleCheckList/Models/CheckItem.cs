using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleCheckList.Models
{
    public class CheckItem
    {
        public required string Category {get; set;}
        public required string Name { get; set; }

        public string? Language { get; set;}

        public CheckItem() { }
        public CheckItem(string category, string name, string language="en-US")
        {
            Category = category;
            Name = name;
            Language = language;
        }
    }
}
