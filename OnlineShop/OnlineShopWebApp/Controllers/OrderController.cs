using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;
using OnlineShopWebApp.Models;
using System;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using OnlineShop.Db.Models;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IBasketStorage basketStorage;
        private readonly IOrderStorage orderStorage;
        private readonly IMapper mapper;

        public OrderController(IBasketStorage basketStorage, IOrderStorage orderStorage, IMapper mapper)
        {
            this.basketStorage = basketStorage;
            this.orderStorage = orderStorage;
            this.mapper = mapper;
        }

        public IActionResult Buy()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Buy(OrderViewModel order)
        {
            if (order.DeliveryDate <= DateTime.Now)
                ModelState.AddModelError("", "Дата доставки не может меньше или равна текущей");

            if (ModelState.IsValid)
            {
                order.UserName = User.Identity.Name;
                order.Cost = basketStorage.GetCostAsync(User.Identity.Name).Result;
                var orderDB = mapper.Map<Order>(order);
                await orderStorage.AddAsync(orderDB);
                await basketStorage.ClearAsync(User.Identity.Name);
                return RedirectToAction("Success");
            }
            return View(order);      
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
