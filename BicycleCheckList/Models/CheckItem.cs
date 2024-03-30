using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BicycleCheckList.Models
{
    [JsonConverter(typeof(CheckItemGroupJsonConverter))]
    public class CheckItem(string name, int amount = 1, string language = "de-DE", bool isChecked = false)
    {
        public bool IsChecked { get; set; } = isChecked;
        public string Name { get; set; } = name;
        public int Amount { get; set; } = amount;
        public string? Language { get; set; } = language;

    }
}
