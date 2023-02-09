using simple_crud_net_6.Models;

namespace simple_crud_net_6.Data
{
    public interface IUserRepository
    {
        IEnumerable<User> getAll();
        User getUserById(int id);
        User create(User user);
        void update(User user);
        void delete(int id);
        bool saveChanges();
    }
}