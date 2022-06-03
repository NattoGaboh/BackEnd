using BackEnd.Domain.IRepositories;
using BackEnd.Domain.IServices;
using BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Services
{
    public class UserServices: IUserServices
    {
        private readonly IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task SaveUser(User user)
        {
            await _userRepository.SaveUser(user);
        }
        public async Task<bool> ValidateExistence(User user)
        {
            return await _userRepository.ValidateExistence(user);
        }
        public async Task<User> ValidatePassword(int idUser, string pwdBefore)
        {
            return await _userRepository.ValidatePassword(idUser, pwdBefore);
        }
        public async Task UpdatePassword(User user)
        {
            await _userRepository.UpdatePassword(user);
        }
    }
}
