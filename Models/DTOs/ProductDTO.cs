using danone_client.Models.Entities;

namespace danone_client.Models.DTOs;

public class ProductDTO
{
    public int Id { get; set; }
    public string universalCode { get; set; }
    public string sku { get; set; }
    public string description { get; set; }
    public string imageUrl { get; set; }
    public string brand { get; set; }

    public ProductDTO() { }
    public ProductDTO(Product product)
    {
        Id = product.Id;
        universalCode = product.universalCode;
        sku = product.sku;
        description = product.description;
        imageUrl = product.imageUrl;
        brand = product.brand;
    }
}
