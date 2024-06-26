﻿using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TAB.Library.Backend.Core.Constants;
using TAB.Library.Backend.Core.Entities;
using TAB.Library.Backend.Core.Exceptions;
using TAB.Library.Backend.Core.Models.DTO;
using TAB.Library.Backend.Infrastructure.Repositories.Abstractions;
using TAB.Library.Backend.Infrastructure.Services.Abstractions;

namespace TAB.Library.Backend.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public UserService(IMapper mapper, IUserRepository repository)
        {
            _mapper = mapper;
            _userRepository = repository;
        }

        public async Task<bool> UsernameExistsInDb(string username)
        {
            var user = await _userRepository.GetAsync(x => x.Username == username);

            return user != null;
        }

        public async Task<bool> EmailExistsInDb(string email)
        {
            var user = await _userRepository.GetAsync(x => x.Email == email);

            return user != null;
        }

        public async Task<bool> RegisterUser(string username, string password, string email, string firstname, string lastname, string phoneNumber)
        {
            User newUser = new()
            {
                Username = username,
                PasswordHash = HashPassword(password),
                Email = email,
                FirstName = firstname,
                LastName = lastname,
                PhoneNumber = phoneNumber,
                RoleId = DefaultSettings.UserRoleId
            };

            await _userRepository.AddAsync(newUser);

            bool result = await _userRepository.SaveChangesAsync();

            return result;
        }

        public async Task<bool> Login(string username, string password)
        {
            string hashPassword = HashPassword(password);

            bool correctCredentials = (await _userRepository.GetAsync(x => x.Username == username && x.PasswordHash == hashPassword)) != null;

            if (!correctCredentials)
            {
                throw new EntityNotFoundException(typeof(User));
            }

            return correctCredentials;
        }

        public async Task<ClaimsIdentity> GetClaimsIdentity(string username)
        {
            var user = await _userRepository.GetAsync(x => x.Username == username, x => x.Role) ?? throw new EntityNotFoundException(typeof(User));

            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, user.Role.Name)

            };

            ClaimsIdentity claimsIdentity = new(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            return claimsIdentity;
        }

        public async Task<int> GetUserIdByName(string username)
        {
            var user = await _userRepository.GetAsync(x => x.Username == username) ?? throw new EntityNotFoundException(typeof(User));

            return user.Id;
        }

        public async Task<bool> CheckAdminPermissions(string username)
        {
            var user = await _userRepository.GetAsync(x => x.Username == username, x => x.Role) ?? throw new EntityNotFoundException(typeof(User));

            return user.Role.Name == "Administrator";
        }

        public async Task<PaginatedListDTO<UserDTO>> GetPaginatedUserList(int pageNumber, int pageSize)
        {
            var paginatedList = await _userRepository.GetPaginatedListAsync(pageNumber, pageSize, x => x.UsersRentals, x => x.Role);

            var mappedPaginatedList = _mapper.Map<PaginatedListDTO<UserDTO>>(paginatedList);

            return mappedPaginatedList;
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
    }
}
