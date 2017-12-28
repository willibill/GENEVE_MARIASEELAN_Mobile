using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(App4.MockDataStore))]
namespace App4
{
    public class MockDataStore : IDataStore<Item>
    {
        Realm realm = Realm.GetInstance();

        public MockDataStore()
        {

            if (realm.All<Item>().Count() > 0)
            {
                return;
            }

            var mockItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." },
            };

            foreach (var item in mockItems)
            {
                realm.Write(() =>
                {
                    realm.Add(item);
                });
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            realm.Write(() =>
            {
                item.Id = Guid.NewGuid().ToString();
            });

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var _item = realm.All<Item>().Where((Item arg) => arg.Id == item.Id).FirstOrDefault();

            realm.Write(() =>
            {
                realm.Remove(item);
                realm.Add(item);
            });

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var _item = realm.All<Item>().Where((Item arg) => arg.Id == id).FirstOrDefault();
            if (_item == null)
                return await Task.FromResult(true);
            realm.Write(() =>
            {
                realm.Remove(_item);
            });
            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(realm.All<Item>().FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(realm.All<Item>());
        }
    }
}
