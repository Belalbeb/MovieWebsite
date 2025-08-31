using Ecommerce_App.Data.Base;
using Ecommerce_App.Models;

namespace Ecommerce_App.Data.Services
{
    public interface IMovies:IEntityBaseRepository<Movie>
    {
        List<Movie> FillterByName(string s);

    }
}
