using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStoreCore.Application.Services.Orders.Queries.GetOrdersForAdmin;
using WebStoreCore.Domain.Entities.Orders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin,Operator")]
    public class OrdersController : Controller
    {
        private readonly IGetOrdersForAdminService _getOrdersForAdminService;
        public OrdersController(IGetOrdersForAdminService getOrdersForAdminService)
        {
            _getOrdersForAdminService = getOrdersForAdminService;
        }
        public IActionResult Index(OrderState orderState)
        {
            return View(_getOrdersForAdminService.Execute(orderState).Data);
        }
    }
}
