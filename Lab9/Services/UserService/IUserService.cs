using Lab9.Data.DTOs;
using Lab9.Models;
using Lab9.Models.Enums;
using Proiect.Data.DTOs;

namespace Lab9.Services.UserService
{
    public interface IUserService
    {
        Task<UserLoginResponse> Login(UserLoginDto user);
        Task<User> GetById(Guid id);
        User GetByIdUser(Guid id);

        Task<bool> Register(UserRegisterDto userRegisterDto, Role userRole);
        Task<bool> UpdateUserRole(Guid userId, Role model);
        Task<List<User>> GetAllAsync();
        Task<User> Delete(string name);
        Task<User> GetByName(string name);

        Task Update(UserUpdateDTO user);

    }
}
