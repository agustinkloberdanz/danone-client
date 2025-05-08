using danone_client.Models.Entities;

namespace danone_client.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        User GetById(int id);
        User GetByEmail(string email);
        ICollection<User> GetAll();
        void Save(User user);
        void Remove(User user);
    }
}
