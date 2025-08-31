using Ecommerce_App.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce_App.Models
{
    public class Actor:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Profile Picture Is retquired")]
        public string ProfilePictureUrl { get; set; }
        [Required(ErrorMessage = "Full Name Is retquired")]
        [StringLength(50,MinimumLength =5,ErrorMessage ="Must Be between 5 and 50")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Bio is retquired")]
        public string  Bio { get; set; }
        public List<Actor_Movie>? Actor_Movies { get; set; }
    }
}
