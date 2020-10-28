using Menu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Menu.Services.Interfaces
{
    interface IMenuService
    {
        /// <summary>
        /// Adds a subitem to an existing MenuItem
        /// or adds at top-level item (parentItem == null)
        /// </summary>
        /// <param name="parentItem"></param>
        /// <param name="childItem"></param>
        void AddItem(MenuItem parentItem, MenuItem childItem);
    }
}
