using Domain.Entities;
using System.Linq;

namespace Domain.Abstract
{
   public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
    }
}
