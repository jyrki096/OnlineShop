using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public class ChangeRoleViewModel
    {
        public List<IdentityRole> Roles { get; set; }
        public string UserId { get; set; }
        public string UserRole { get; set; }
    }
}
