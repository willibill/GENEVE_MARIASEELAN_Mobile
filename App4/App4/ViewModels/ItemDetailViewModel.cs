using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App4
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public INavigation Navigation { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
        }
        public async Task DeleteItem_Clicked()
        {
            await DataStore.DeleteItemAsync(Item.Id);
        }
    }
}
