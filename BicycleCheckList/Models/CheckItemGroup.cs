namespace BicycleCheckList.Models
{

    public class CheckItemGroup(string name, List<CheckItem> checkItems) : List<CheckItem>(checkItems)
    {
        public string Name { get; private set; } = name;
    }
}