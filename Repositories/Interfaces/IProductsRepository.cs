using danone_client.Models.Entities;

namespace danone_client.Repositories.Interfaces
{
    public interface IProductsRepository
    {
        Product GetById(int id);
        ICollection<Product> GetByBrand(string brand);
        ICollection<Product> GetAll();
        void Save(Product product);
        void Remove(Product product);
    }
}


