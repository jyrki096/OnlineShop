

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Не указан email!!!")]
        [EmailAddress(ErrorMessage = "Введите корректный email!!!")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Введите корректный email!!!!!!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не указано имя!!!")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Имя должно содержать от 2 до 25 символов")]
        [RegularExpression(@"^[A-Za-zА-Яа-яЁё\s]+$", ErrorMessage = "Имя должно состоять из букв русского или английского алфавита")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан номер!!!")]
        [StringLength(12, MinimumLength = 11, ErrorMessage = "Номер телефона должен состоять из 11 цифр")]
        [RegularExpression(@"^[0-9\s]+$", ErrorMessage = "Номер телефона должен состоять из цифр")]
        public string PhoneNumber { get; set; }

        public IFormFile UpPhoto { get; set; }

        [Required(ErrorMessage = "Не указан пароль!!!")]
        [StringLength(64, MinimumLength = 5, ErrorMessage = "Пароль должен быть от 5 до 64 символов")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не указан повторный пароль!!!")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string PasswordConfirmation { get; set; }

        public string ReturnUrl { get; set; }
    }
}
