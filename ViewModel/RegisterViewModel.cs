using System.ComponentModel.DataAnnotations;

namespace Ecommerce_App.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, Range(1, 120)]
        public int Age { get; set; }

        [Required, MinLength(6)]
        public string Password { get; set; }
    }
}
