using System;

namespace danone_client.Models.DTOs;

public class BrandDTO
{

    public string name { get; set; }
    public ICollection<ProductDTO> products { get; set; }

}
