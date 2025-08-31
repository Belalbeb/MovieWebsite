using Ecommerce_App.Data.Base;

namespace Ecommerce_App.Models
{
    public class OrderItem:IEntityBase
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int MovieId { get; set; }
        public int Quantity { get; set; }
        public Movie? Movie { get; set; }
        public Order? Order { get; set; }
    }
}
