using AutoMapper;
using Lab9.Data.DTOs;
using Lab9.Helpers.JwtUtil;
using Lab9.Models;
using Lab9.Models.Enums;
using Lab9.Repositories.UserRepository;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Lab9.Services.UserService
{
    public class UserService : IUserService
    {
        public IUserRepository _userRepository;
        private readonly IJwtUtils _jwtUtils;

        public UserService(IUserRepository userRepository, IJwtUtils jwtUtils)
        {
            _userRepository = userRepository;
            _jwtUtils = jwtUtils;
        }

        public User GetById(Guid id)
        {
            return _userRepository.FindById(id);
        }

        public async Task<UserLoginResponse> Login(UserLoginDto userDto)
        {
            var user = _userRepository.FindByUsername(userDto.UserName);

            if (user == null || !BCryptNet.Verify(userDto.Password, user.Password))
            {
                return null; // or throw exception
            }
            if (user == null) return null;

            var token = _jwtUtils.GenerateJwtToken(user);
            return new UserLoginResponse(user, token);
        }

        public async Task<bool> Register(UserRegisterDto userRegisterDto, Role userRole)
        {
            var userToCreate = new User
            {
                Username = userRegisterDto.UserName,
                FirstName = userRegisterDto.FirstName,
                LastName = userRegisterDto.LastName,
                Email = userRegisterDto.Email,
                Role = userRole,
                Password = BCryptNet.HashPassword(userRegisterDto.Password)
            };
            

            _userRepository.Create(userToCreate);
           return await _userRepository.SaveAsync();
        }
        public async Task AssignRoleToUser(string username, Role role)
        {
            var user = _userRepository.FindByUsername(username);
            if (user != null)
            {
                user.Role = role;
                user.DateModified = DateTime.Now;
                await _userRepository.UpdateAsync(user);
            }
            else
            {
                throw new Exception("Utilizatorul nu a fost găsit.");
            }
        }

        public async Task<bool> UpdateUserRole(string userId, Role model)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user != null)
            {
                // Actualizează doar câmpurile care nu sunt nule în DTO
                user.Role = model;
                user.DateModified = DateTime.UtcNow;

                await _userRepository.UpdateAsync(user);
                return true; // Returnează true dacă actualizarea a fost un succes
            }
            return false; // Returnează false dacă utilizatorul nu a fost găsit
        }
    }
}
