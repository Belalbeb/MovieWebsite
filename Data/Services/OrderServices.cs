using Ecommerce_App.Data.Base;
using Ecommerce_App.Models;

namespace Ecommerce_App.Data.Services
{
    public class OrderServices : EntityBaseRepository<Order>,IOrderServices
    {
        public OrderServices(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
