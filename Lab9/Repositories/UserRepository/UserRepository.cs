using Lab9.Data;
using Lab9.Helpers.Extensions;
using Lab9.Models;
using Lab9.Repositories.GenericRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Lab9.Repositories.UserRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ProjectContext projectContext) : base(projectContext)
        {
        }

        public async Task<List<User>> FindAll()
        {
            return await _table.ToListAsync();
        }

        public async Task<List<User>> FindAllActive()
        {
            return await _table.GetActiveUser().ToListAsync();
        }

        public User FindByUsername(string username)
        {
            return  _table.FirstOrDefault(u => u.Username.Equals(username));
        }

        public async Task<User> FindByUsernameAsync(string username)
        {
            return _table.FirstOrDefault(u => u.Username.Equals(username));
        }

        public async Task UpdateAsync(User user)
        {
            _projectContext.Update(user);
            await _projectContext.SaveChangesAsync();
        }
        public async Task<List<User>> GetUsersAsync()
        {
            return await _projectContext.Users.ToListAsync();
        }
        public async Task<User> GetUserById(string id)
        {
            Guid userIdGuid = Guid.Parse(id);
            return await _projectContext.Users.FirstOrDefaultAsync(u => u.Id == userIdGuid);
        }
        //public  async Task<User> FindByUsernameAndPassword(string username, string password)
        //{
        //    return (await _table.FirstOrDefaultAsync(u => u.Username.Equals(username) && u.Password.Equals(password)))!;
        //}
        public async Task<User> DeleteUser(string name)
        {
            var user = FindByUsername(name);
            
            if (user == null)
            {
                throw new Exception("User not found");
            }
            _projectContext.Users.Remove(user);
            await _projectContext.SaveChangesAsync();
            return user;

                
        }
        

    }
}
