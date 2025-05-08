using danone_client.Models.Entities;
using danone_client.Models.Enums;

namespace danone_client.Models.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public Role role { get; set; }
        
        public UserDTO() { }

        public UserDTO(User model)
        {
            Id = model.Id;
            email = model.email;
            role = model.role;
            firstName = model.firstName;
            lastName = model.lastName;
        }

    }
}
