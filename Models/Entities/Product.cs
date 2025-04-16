using danone_client.Models.DTOs;

namespace danone_client.Models.Entities;

public class Product
{
    public int Id { get; set; }
    public string universalCode { get; set; }
    public string sku { get; set; }
    public string description { get; set; }
    public string imageUrl { get; set; }
    public string brand { get; set; }

    public Product() { }

    public Product(AddProductDTO addProductDTO)
    {
        universalCode = addProductDTO.universalCode;
        sku = addProductDTO.sku;
        description = addProductDTO.description;
        imageUrl = addProductDTO.imageUrl;
        brand = addProductDTO.brand;
    }
    public Product(ProductDTO ProductDTO)
    {
        Id = ProductDTO.Id;
        universalCode = ProductDTO.universalCode;
        sku = ProductDTO.sku;
        description = ProductDTO.description;
        imageUrl = ProductDTO.imageUrl;
        brand = ProductDTO.brand;
    }

}