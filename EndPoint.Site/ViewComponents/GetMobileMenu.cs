using WebStoreCore.Application.Services.Common.Queries.GetMenuItem;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.ViewComponents
{
    public class GetMobileMenu:ViewComponent
    {
        private readonly IGetMenuItemService _getMenuItemService;
        public GetMobileMenu(IGetMenuItemService getMenuItemService)
        {
            _getMenuItemService = getMenuItemService;
        }


        public IViewComponentResult Invoke()
        {
            var menuItem = _getMenuItemService.Execute();
            return View(viewName: "GetMobileMenu", menuItem.Data);
        }

    }
}
