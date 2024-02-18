using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;
using System;
using OnlineShop.Db.Models;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using System.Collections.Generic;
using OnlineShopWebApp.Models;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class OrderController : Controller
    {
        private readonly IOrderStorage orderStorage;
        private readonly IMapper mapper;

        public OrderController(IOrderStorage orderStorage, IMapper mapper)
        {
            this.orderStorage = orderStorage;
            this.mapper = mapper;   
        }

        public async Task<ActionResult> GetOrdersAsync()
        {
            var orders = await orderStorage.TryGetAllAsync();
			return View(mapper.Map<List<OrderViewModel>>(orders));
        }

        public async Task<ActionResult> GetOrderDetailsAsync(Guid orderId)
        {
            var order = await orderStorage.TryGetOrderByIdAsync(orderId);
			return View(mapper.Map<OrderViewModel>(order));
        }

        public async Task<IActionResult> UpdateOrderStatusAsync(Guid orderId, OrderStatus status)
        {
            await orderStorage.UpdateStatusAsync(orderId, status);
            return RedirectToAction("GetOrders");
        }
    }
}
