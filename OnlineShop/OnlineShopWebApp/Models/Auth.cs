using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Auth
    {
        [Required(ErrorMessage = "Введите email!!!")]
        [EmailAddress(ErrorMessage = "Введите корректный email!!!")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Введите корректный email!!!!!!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Введите пароль!!!")]
        [StringLength(64, MinimumLength = 5, ErrorMessage = "Пароль должен быть от 5 до 64 символов")]
        public string Password { get; set; }

        public bool IsRemember { get; set; }

        public string ReturnUrl { get; set; }
    }
}
