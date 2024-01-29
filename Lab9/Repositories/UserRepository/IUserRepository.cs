using Lab9.Models;
using Lab9.Repositories.GenericRepository;

namespace Lab9.Repositories.UserRepository
{
    public interface IUserRepository: IGenericRepository<User>
    {
        User FindByUsername(string username);
        //Task<User> FindByUsernameAndPassword(string username, string password);
        Task<List<User>> GetUsersAsync();

        Task<List<User>> FindAll();

        Task UpdateAsync(User user);
        Task<User> GetUserById(Guid id);
        User GetUserByIdA(Guid id);

        Task<User> FindByUsernameAsync(string username);
        Task<User> DeleteUser(string name);


    }
}
