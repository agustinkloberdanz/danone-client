using danone_client.Models.DTOs;
using danone_client.Models.Entities;
using danone_client.Models.Responses;

namespace danone_client.Services
{
    public interface IProductsService
    {
        public Response GetAll();
        public Response GetAllByBrand();
        public Response GetByBrand(string brand);
        public Response Add(AddProductDTO model);
        public Response Update(ProductDTO model);
        public Response Delete(int id);
    }
}


