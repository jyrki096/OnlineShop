using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class СharacteristicsViewModel
    {

        [Required(ErrorMessage = "Не указан цвет!!!")]
        [RegularExpression(@"^[а-яА-ЯёЁ\s]+$", ErrorMessage = "Цвет должен состоять только из русских букв (кириллицы)")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Не указана мощность!!!")]
        [RegularExpression(@"^[\d]+$", ErrorMessage = "Мощность должна быть числом!")]
        public string Power { get; set; }

        [Required(ErrorMessage = "Не указана полифония!!!")]
        [RegularExpression(@"^[\d]+$", ErrorMessage = "Полифония должна быть числом!")]
        public string Polyphony { get; set; }

        [Required(ErrorMessage = "Не указано количество тембров!!!")]
        [RegularExpression(@"^[\d]+$", ErrorMessage = "Тембры должны быть числом!")]
        public string Timbers { get; set; }

    }
}
