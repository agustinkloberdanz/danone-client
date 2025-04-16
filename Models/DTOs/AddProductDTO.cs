namespace danone_client.Models.DTOs;

using danone_client.Models.Entities;

public class AddProductDTO
{
    public string universalCode { get; set; }
    public string sku { get; set; }
    public string description { get; set; }
    public string imageUrl { get; set; }
    public string brand { get; set; }

    public AddProductDTO() { }

    public AddProductDTO(Product product)
    {
        universalCode = product.universalCode;
        sku = product.sku;
        description = product.description;
        imageUrl = product.imageUrl;
        brand = product.brand;
    }
}
