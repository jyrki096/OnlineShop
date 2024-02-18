using OnlineShop.Db.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public OrderStatus Status { get; set; }
        public string UserName { get; set; }
        public decimal Cost { get; set;  }

        [Required(ErrorMessage = "Не указан email!!!")]
        [EmailAddress(ErrorMessage = "Введите корректный email!!!")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Введите email в правильном формате!!!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указано имя!!!")]
        [StringLength(64, MinimumLength = 2, ErrorMessage = "Имя должно содержать от 2 до 64 символов")]
        [RegularExpression(@"^[а-яА-ЯёЁ\s]+$", ErrorMessage = "Имя должно состоять только из букв русского алфавита")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан адрес!!!")]
        [StringLength(64, MinimumLength = 8, ErrorMessage = "Адрес должен содержать от 8 до 64 символов")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Не указан номер!!!")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Номер телефона должен содержать 11 символов")]
        [RegularExpression(@"^[\d]+$", ErrorMessage = "Введите телефон в формате: 7999-999-99-99 без дефисов")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Не указана дата!!!")]
        public DateTime DeliveryDate { get; set; }
        public DateTime CreatedDate { get; set; }

        [StringLength(150, MinimumLength = 0, ErrorMessage = "Размер комментария не больше 150 символов ")]

        [Required(ErrorMessage = "Введите комментарий!!!")]
        public string Comment { get; set; }

        public OrderViewModel()
        {
            CreatedDate = DateTime.Now;
            Status = OrderStatus.Created;
        }
    }
}
