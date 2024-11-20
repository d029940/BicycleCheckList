using BicycleCheckList.Views;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace BicycleCheckList.Models
{

    [JsonConverter(typeof(CheckItemGroupJsonConverter))]
    public partial class CheckItemGroup(string category, List<CheckItem> checkItems) : List<CheckItem>(checkItems)
    {
        private string group = category;

        [JsonPropertyName("Group")]
        public string Group { get => group; set => group = value; }
    }

}