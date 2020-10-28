using Menu.Models;
using Menu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Menu.Services
{
    public class MenuService : IMenuService
    {
        private string dataPath = 
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "menu.json");
        
        public void AddItem(MenuItem parentItem, MenuItem childItem)
        {
            using (StreamReader file = File.OpenText(dataPath))
            {
                var menu = JsonConvert.DeserializeObject<List<MenuItem>>(file.ReadToEnd());
                menu.Where(m=>m.)
            }

        }
    }
}
