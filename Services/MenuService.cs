using Menu.Data;
using Menu.Models;
using Menu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Menu.Services
{
    public class MenuService : IMenuService
    {
        IMenuRepository _repository;

        #region CTOR
        public MenuService(IMenuRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        #endregion

        #region Service methods
    /// <summary>
        /// Add menuItem to existing item
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="childLabel"></param>
        /// <param name="childUrl"></param>
        /// <returns>Id of new child item</returns>
        public async Task<string> AddItem(MenuItem newItem)
        {
            return await _repository.AddItem(newItem);
        }

        /// <summary>
        /// Get full menu, where first menu item is the root
        /// </summary>
        /// <returns>The tree of menu-items</returns>    
        public async Task<MenuItem> GetMenu()
        {
            return await _repository.GetMenu();
        }

        public void DeleteAll()
        {
            _repository.DeleteAll();
        }
        #endregion
    }
}
