using Ecommerce_App.Data.Base;
using Ecommerce_App.Models;

namespace Ecommerce_App.Data.Services
{
    public class ActorsServices :EntityBaseRepository<Actor>, IActorsServices
    {
     
        public ActorsServices(AppDbContext context):base(context)
        {
            
        }
      
    }
}
