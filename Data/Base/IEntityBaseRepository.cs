using Ecommerce_App.Models;

namespace Ecommerce_App.Data.Base
{
    public interface IEntityBaseRepository<t>where t:class,IEntityBase,new()
    {
        IEnumerable<t> GetAll();
       t GetById(int id);
        void Add(t entity);
        Task Update(int id, t entity);
        void Delete(int id);

    }
}
