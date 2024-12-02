using BicycleCheckList.Models;
using BicycleCheckList.Resources.Strings;
using BicycleCheckList.Services;
using BicycleCheckList.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BicycleCheckList.ViewModels
{
    public partial class OverviewViewModel : BaseViewModel
    {
        #region Properties, Constructor
        [ObservableProperty]
        public ObservableCollection<CheckItemGroup> checkItemsGroups;

        public TourList TourList;

        public OverviewViewModel()
        {
            this.TourList = new TourList();
            TourList.Load();
            int selectedTour = TourList.CurrentTour;
            CheckItemsGroups = new ObservableCollection<CheckItemGroup>(TourList!.AllTours![selectedTour].ItemGroupList);
            string name = TourList.AllTours[selectedTour].Name;
            Title = $"{AppResources.OverviewTitle} - Name: {name}";
        }
        #endregion

        #region Actions
        /// <summary>
        /// Save the current tour
        /// </summary>
        [RelayCommand]
        void Save()
        {
            int selectedTour = TourList.CurrentTour;
            TourList!.AllTours![selectedTour].ItemGroupList = [.. CheckItemsGroups];
            TourListService.WriteToJson(TourList);
        }

        /// <summary>
        /// Reset all items to unchecked state
        /// </summary>
        [RelayCommand]
        void Reset()
        {
            var res = TourListService.Reset();
            if (res != null)
            {
                TourList = res;
                int selectedTour = TourList.CurrentTour;
                // TODO: Optimize: notify instead of creating a new collection list
                CheckItemsGroups = new ObservableCollection<CheckItemGroup>(TourList!.AllTours![selectedTour].ItemGroupList);
            }
        }

        #region Group commands

        [RelayCommand]
        async Task AddGroupAsync()
        {
            string result = await Application.Current!.Windows[0].Page!.DisplayPromptAsync(
                $"{AppResources.NewGroup}",
                $"{AppResources.NewGroupDescription}");

            CheckItemGroup group = new(result, []);
            CheckItemsGroups.Add(group);
            Save();
        }

        [RelayCommand]
        async Task RenameGroupAsync(CheckItemGroup group)
        {
            string result = await Application.Current!.Windows[0].Page!.DisplayPromptAsync(
                $"{AppResources.RenameGroup}",
                $"{AppResources.NewGroupName}",
                initialValue: group.Group);
            group.Group = result;
            UpdateCheckList();
        }

        [RelayCommand]
        void DeleteGroup(CheckItemGroup group)
        {
            CheckItemsGroups.Remove(group);
            Save();
        }
        #endregion

        #region Item commands
        [RelayCommand]
        async Task AddItemAsync(CheckItemGroup group)
        {
            string result = await Application.Current!.Windows[0].Page!.DisplayPromptAsync(
                $"{AppResources.NewItem}",
                $"{AppResources.NewItemDescription}"
            );

            CheckItem checkItem = new(result);
            group.Add(checkItem);
            Save();
        }

        [RelayCommand]
        async Task ChangeItemAsync(CheckItem item)
        {
            string result = await Application.Current!.Windows[0].Page!.DisplayPromptAsync(
                $"{AppResources.ChangeItem}",
                $"{AppResources.NewItemDescription}"
            );
            item.Name = result;
            // TODO: if a item property is changed, no notification is sent. (only for adding, deleting)
            // TODO: Need to know the Checkgroup in order to remove the old item and insert the new one
            UpdateCheckList();
            //Save();

        }
        [RelayCommand]
        void DeleteItem(CheckItem item)
        {
            foreach (CheckItemGroup group in CheckItemsGroups)
            {
                
                if (group.Remove(item))
                {
                    Save();
                    break;
                }
            }
        }

        /// <summary>
        /// When an item is checked or unchecked save the tour.
        /// </summary>
        /// <param name="value"></param>
        public void CheckedItemChanged(Boolean value)
        {
            Save();
        }

        [RelayCommand]
        void ClearAllItems()
        {
            foreach (CheckItemGroup group in CheckItemsGroups)
            {
                foreach (CheckItem item in group)
                {
                    item.IsChecked = false;
                }
            }
            UpdateCheckList();
        }

        #endregion

        #region Navigation Commands
        [RelayCommand]
        async Task GoToCheckItemsConfigPage()
        {
            await Shell.Current.GoToAsync(nameof(CheckItemsConfigPage), true);
        }

        /// <summary>
        /// Navigate to the tour list page
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        async Task GoToTourListPage()
        {
            // Set Selected Tour
            int selectedTour = TourList.CurrentTour;
            Dictionary<string, object> param = new Dictionary<string, object>()
            {
                { "SelectedTour", selectedTour }
            };
            await Shell.Current.GoToAsync($"{nameof(TourListPage)}", true, (IDictionary<string, object>)param);
        }
        #endregion
        #endregion

        #region Helper functions

        void UpdateCheckList()
        {
            // TODO: Optimize: notify instead of creating a new collection list
            CheckItemsGroups = new ObservableCollection<CheckItemGroup>(CheckItemsGroups);
            Save();
        }

        #endregion

    }

}
