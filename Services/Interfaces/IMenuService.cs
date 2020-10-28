using Menu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Menu.Services.Interfaces
{
    public interface IMenuService
    {
        /// <summary>
        /// Add menuItem to existing item
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="childLabel"></param>
        /// <param name="childUrl"></param>
        /// <returns>Id of new child item</returns>
        Task<string> AddItem(MenuItem newItem);

        /// <summary>
        /// Get full menu, where first menu item is the root
        /// </summary>
        /// <returns>The tree of menu-items</returns>
        Task<MenuItem> GetMenu();

        void DeleteAll();
    }
}
