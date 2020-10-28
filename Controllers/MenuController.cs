using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Menu.Models;
using Menu.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Menu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : Controller
    {
        #region Fields
        private readonly IMenuService _menuService;
        #endregion

        #region Ctor
        public MenuController(IMenuService menuService)
        {
            _menuService = menuService ?? throw new ArgumentNullException(nameof(menuService));
        }

        #endregion

        #region API Actions

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var menu = await _menuService.GetMenu();

            return new JsonResult(menu);
        }
        [HttpDelete("items")]
        public IActionResult DeleteAll()
        {
            _menuService.DeleteAll();

            return new JsonResult(null);
        }
        [HttpPost("items")]
        public async Task<IActionResult> AddItem(MenuItem childItem)
        {
            var menu = await _menuService.AddItem(childItem);

            return new JsonResult(menu);
        }
      
        #endregion
    }
}
