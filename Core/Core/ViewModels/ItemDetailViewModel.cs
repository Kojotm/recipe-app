using Core.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Core.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string name;
        private string description;
        private string info;

        public Command DeleteItemCommand { get; }
        public string Id { get; set; }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Info
        {
            get => info;
            set => SetProperty(ref info, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public ItemDetailViewModel()
        {
            DeleteItemCommand = new Command(OnDeleteItem);
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetRecipe(itemId);
                Id = item.Id;
                Name = item.Name;
                Description = item.Description;
                Info = $"{item.Calories}\n{item.Difficulty}\n{item.Time}";
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        private async void OnDeleteItem(object rec)
        {
            //await DataStore.DeleteRecipe("");
        }
    }
}
