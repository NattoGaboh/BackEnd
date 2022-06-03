using BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Domain.IServices
{
    public interface IUserServices
    {
        Task SaveUser(User user);
        Task<bool> ValidateExistence(User user);
        Task<User> ValidatePassword(int idUser, string pwdBefore);
        Task UpdatePassword(User user);

    }
}
