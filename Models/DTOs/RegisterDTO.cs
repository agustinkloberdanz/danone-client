

namespace danone_client.Models.DTOs
{
    public class RegisterDTO
    {
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string password { get; set; }

        public RegisterDTO() { }

        public RegisterDTO(AddProductDTO model) {
            email = model.universalCode;
            firstName = model.sku;
            lastName = model.description;
            password = model.imageUrl;
        }
    }
}
