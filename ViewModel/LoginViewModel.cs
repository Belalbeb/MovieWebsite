using System.ComponentModel.DataAnnotations;

namespace Ecommerce_App.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public string UserName{ get; set; }
        [Required]
        public string Password { get; set; }
    }
}
