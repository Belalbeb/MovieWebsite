using Ecommerce_App.Data.Base;
using Ecommerce_App.Models;

namespace Ecommerce_App.Data.Services
{
    public class CinemaServices : EntityBaseRepository<Cinema>,ICinema
    {
        public CinemaServices(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
