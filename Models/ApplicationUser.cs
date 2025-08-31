using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce_App.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Length(1,100)]
        public int Age { get; set; }
    }
}
