using BackEnd.Domain.IRepositories;
using BackEnd.Domain.Models;
using BackEnd.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Persistence.Repositories
{
    public class LoginRepository: ILoginRepository
    {
        private readonly ApplicationDbContext _context;
        public LoginRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User> ValidateUser(User user)
        {
            var usr = _context.User.Where(x => x.NameUser == user.NameUser 
                        && x.Password == user.Password).FirstOrDefaultAsync();
            return await usr;
        } 
    }
}
