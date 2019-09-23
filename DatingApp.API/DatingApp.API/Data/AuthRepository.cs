using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;

        public AuthRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> DoesUserExist(string username)
        {
            return await _context.Users.AnyAsync(x => x.Username == username);
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);

            if (user == null ||
                !user.ValidatePassword(password))
            {
                return null;
            }
            else
            {
                return user;
            }
        }

        public async Task<User> Register(User user, string password)
        {
            user.SetPassword(password);

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
