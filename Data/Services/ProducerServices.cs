using Ecommerce_App.Data.Base;
using Ecommerce_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_App.Data.Services
{
    public class ProducerServices : EntityBaseRepository<Producer>,IProducerServices
    {
        public ProducerServices(AppDbContext appDbContext) : base(appDbContext)
        {
        }
     
    }
}
