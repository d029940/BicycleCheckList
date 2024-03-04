using System.Text.Json.Serialization;

namespace BicycleCheckList.Models
{

    public class CheckItemGroup(string category, List<CheckItem> checkItems) : List<CheckItem>(checkItems)
    {
        private string group = category;

        [JsonPropertyName("Category")]
        public string Group { get => group; set => group = value; }
    }

}