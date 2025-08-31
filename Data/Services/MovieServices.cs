using Ecommerce_App.Data.Base;
using Ecommerce_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_App.Data.Services
{
    public class MovieServices : EntityBaseRepository<Movie>, IMovies
    {
        public MovieServices(AppDbContext appDbContext) : base(appDbContext)
        {
        }
        public override IEnumerable<Movie> GetAll()
        {
            return context.Movies.Include(e => e.Cinema).ToList();

        }
        public override Movie GetById(int id)
        {
            return context.Movies.Include(e => e.Cinema).FirstOrDefault(E => E.Id == id);
        }
        public List<Movie> FillterByName(String n)
        {
            return context.Movies
               .Where(x => x.Name.ToLower().Contains(n.ToLower()))
               .Include(v => v.Cinema)
               .ToList();

        }
    }
}
