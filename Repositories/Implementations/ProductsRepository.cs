using danone_client.Models;
using danone_client.Models.Entities;
using danone_client.Repositories.Interfaces;

namespace danone_client.Repositories;

public class ProductsRepository : RepositoryBase<Product>, IProductsRepository
{
    public ProductsRepository(DBContext repositoryContext) : base(repositoryContext) { }

    public Product GetById(int id)
    {
        return FindByCondition(i => i.Id == id)
            .FirstOrDefault();
    }

    public ICollection<Product> GetAll()
    {
        return FindAll()
            .ToList();
    }

    public ICollection<Product> GetByBrand(string brand)
    {
        return FindByCondition(i => i.brand == brand)
            .ToList();
    }

    public void Save(Product product)
    {
        if (product.Id == 0)
            Create(product);
        else
            Update(product);

        SaveChanges();
    }

    public void Remove(Product product)
    {
        Delete(product);
        SaveChanges();
    }

}
