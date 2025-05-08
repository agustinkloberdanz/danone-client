using danone_client.Models;
using danone_client.Models.Entities;
using danone_client.Repositories.Interfaces;

namespace danone_client.Repositories.Implementations
{
    public class UsersRepository : RepositoryBase<User>, IUsersRepository
    {
        public UsersRepository(DBContext repositoryContext) : base(repositoryContext) { }

        public ICollection<User> GetAll()
        {
            return FindAll()
                .ToList();
        }

        public User GetById(int id)
        {
            return FindByCondition(i => i.Id == id)
                .FirstOrDefault();
        }

        public User GetByEmail(string email)
        {
            return FindByCondition(i => i.email == email)
                .FirstOrDefault();
        }

        public void Remove(User user)
        {
            Delete(user);
            SaveChanges();
        }

        public void Save(User user)
        {
            if (user.Id == 0)
                Create(user);
            else
                Update(user);

            SaveChanges();
        }
    }
}
