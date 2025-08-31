using Ecommerce_App.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce_App.Models
{
    public class Cinema:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Movie> ?Movies { get; set; }
    }
}
