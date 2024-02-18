using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Role
    {

        [Required(ErrorMessage = "Введите название роли")]
        [RegularExpression(@"^[а-яА-ЯёЁA-Za-z\s]+$", ErrorMessage = "Имя должно состоять только из букв русского или английского алфавита")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Имя должно содержать от 3 до 15 символов")]
        public string Name { get; set; }

    }
}
