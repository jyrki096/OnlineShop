using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Не указано имя!!!")]
        [StringLength(48, MinimumLength = 3, ErrorMessage = "Имя должно содержать от 3 до 48 символов")]
        [RegularExpression(@"^[A-Za-z0-9\s\-]+$", ErrorMessage = "Имя должно состоять только из английских букв (латиницы) и/или цифр")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан тип!!!")]
        [StringLength(48, MinimumLength = 3, ErrorMessage = "Имя должно содержать от 3 до 48 символов")]
        [RegularExpression(@"^[а-яА-ЯёЁ\s]+$", ErrorMessage = "Тип должен состоять только из русских букв (кириллицы)")]
        public string Type { get; set; }
        public string ImageLink { get; set; }
        public List<string> ImageLinks { get; set; }
        public IFormFile[] UpFiles { get; set; }

        [Required(ErrorMessage = "Не указана стоимость!!!")]
        [Range(1, 10000000, ErrorMessage = "Стоимость должна быть в диапозоне от 1 до 10000000")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Заполните поле описание!!!")]
        public string Description { get; set; }
        public СharacteristicsViewModel Characteristics { get; set; }

        public ProductViewModel()
        {
            Characteristics = new СharacteristicsViewModel();
            ImageLinks = new List<string>();
        }
    }
}
