using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class ChangePassword
    {
        public string UserId { get; set; }

        [Required(ErrorMessage = "Не указан пароль!!!")]
        [StringLength(64, MinimumLength = 5, ErrorMessage = "Пароль должен быть от 5 до 64 символов")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не указан повторный пароль!!!")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string PasswordConfirmation { get; set; }
    }
}
