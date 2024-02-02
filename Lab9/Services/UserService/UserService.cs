using AutoMapper;
using Lab9.Data.DTOs;
using Lab9.Helpers.JwtUtil;
using Lab9.Models;
using Lab9.Models.Enums;
using Lab9.Repositories.UserRepository;
using BCryptNet = BCrypt.Net.BCrypt;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Proiect.Data.DTOs;

namespace Lab9.Services.UserService
{
    public class UserService : IUserService
    {
        public IUserRepository _userRepository;
        private readonly IJwtUtils _jwtUtils;
        public IMapper _mapper;

        public UserService(IUserRepository userRepository, IJwtUtils jwtUtils, IMapper mapper)
        {
            _userRepository = userRepository;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
        }

        public User GetByIdUser(Guid id)
        {
            return _userRepository.FindById(id);
        }
        public Task<User> GetById(Guid id)
        {
            return _userRepository.GetUserById(id);
        }
        public Task<User> GetByName(string name)
        {
            return _userRepository.FindByUsernameAsync(name);
        }
        public async Task<List<User>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            if (users == null) throw new Exception("No users found.");
            List<User> result = _mapper.Map<List<User>>(users);

            return result;

        }
        public async Task<UserLoginResponse> Login(UserLoginDto userDto)
        {
            var user = _userRepository.FindByUsername(userDto.UserName);

            if (user == null || !BCryptNet.Verify(userDto.Password, user.Password))
            {
                return null; 
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

        public async Task<bool> UpdateUserRole(Guid userId, Role model)
        {
            var user = await _userRepository.GetUserById(userId);
            if (user != null)
            {
                user.Role = model;
                user.DateModified = DateTime.UtcNow;

                await _userRepository.UpdateAsync(user);
                return true; 
            }
            return false; 
        }

        public async Task<User> Delete(string name)
        {
           return await _userRepository.DeleteUser(name);

        }

        public async Task Update(UserUpdateDTO user) 
        {
            var existingUser = await _userRepository.GetUserById(user.Id);
            if(existingUser == null)
            {
                throw new Exception("User not found");
            }
            else
            {
                existingUser.Username = user.Username;
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Email = user.Email;
                existingUser.Role = user.Role;
                existingUser.Password = BCryptNet.HashPassword(user.Password);
            }
            await _userRepository.UpdateAsync(_mapper.Map<User>(existingUser));



        }

    }
}
