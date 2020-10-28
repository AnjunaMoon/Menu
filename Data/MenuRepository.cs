using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Menu.Models;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.IO;
using Menu.Extensions;

namespace Menu.Data
{
    public interface IMenuRepository
    {
        Task<MenuItem> GetMenu();
        Task<string> AddItem(MenuItem newItem);
        void DeleteAll();
    }

    public class MenuRepository : IMenuRepository
    {
        private string dataPath =
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "menu.json");
        private static object locker = new object();


        public async Task<string> AddItem(MenuItem newItem)
        {
            var menu = await GetMenu();

            var parent = menu.GetItemAndSubitems().Where(item => item.Id == newItem.ParentId).FirstOrDefault();
            if (parent == null)
                throw new Exception($"Parent menuitem does not exists. Id={newItem.ParentId}");

            newItem.Id = Guid.NewGuid().ToString();
            newItem.Items = new List<MenuItem>();
            parent.Items.Add(newItem);

            lock (locker)
            {
                File.WriteAllTextAsync(dataPath, JsonConvert.SerializeObject(menu));
            }

            return newItem.Id;
        }

        public async Task<MenuItem> GetMenu()
        {
            MenuItem menu;

            if (!File.Exists(dataPath))
                lock (locker)
                {
                    menu = new MenuItem { Label = "root", Url = string.Empty };
                    File.WriteAllText(dataPath, JsonConvert.SerializeObject(menu));
                }

            using (StreamReader file = new StreamReader(dataPath))
            {
                var data = await file.ReadToEndAsync();
                menu = JsonConvert.DeserializeObject<MenuItem>(data);
            }

            return menu;
        }

        public void DeleteAll()
        {
            lock (locker)
            {
                File.Delete(dataPath);
                var menu = new MenuItem { Label = "root", Url = string.Empty };
                File.WriteAllText(dataPath, JsonConvert.SerializeObject(menu));
            }

        }
    }
}
