using Ecommerce_App.Data.Base;

namespace Ecommerce_App.Models
{
    public class Order:IEntityBase
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
