using BicycleCheckList.Views;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace BicycleCheckList.Models
{

    [JsonConverter(typeof(CheckItemGroupJsonConverter))]
    public partial class CheckItemGroup(string category, ObservableCollection<CheckItem> checkItems) : ObservableCollection<CheckItem>(checkItems)
    {
        private string group = category;

        [JsonPropertyName("Group")]
        public string Group { get => group; set => group = value; }
    }

}