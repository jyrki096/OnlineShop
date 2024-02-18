using System;
using System.Collections.Generic;
using System.Linq;


namespace OnlineShopWebApp.Models
{
    public class BasketViewModel
    {
        public Guid Id;
        public string UserName;
        public List<BasketItemViewModel> BasketItems { get; set;  } 
        public int Amount
        {
            get
            {
                return BasketItems.Sum(x => x.Amount);
            }
        }       

        public decimal Total()
        {
            return BasketItems.Sum(x => x.Total());
        }

        public bool isEmpty()
        {
            return !BasketItems.Any();
        }
    }
}
