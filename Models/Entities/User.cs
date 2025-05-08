using danone_client.Models.DTOs;
using danone_client.Models.Enums;

namespace danone_client.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string email { get; set; }
        public byte[] hash { get; set; }
        public byte[] salt { get; set; }
        public Role role { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
}
