using Microsoft.EntityFrameworkCore;
using RayaneGostar.Application.Interfaces;
using RayaneGostar.Domain.Interfaces;
using RayaneGostar.Domain.Models.Account;
using RayaneGostar.Infra.Data.Context;
using System;
using System.Threading.Tasks;

namespace RayaneGostar.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region Constructor
        private readonly RDbContext _context;
        public UserRepository(RDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Account
        public async Task<bool> IsUserExistsPhoneNumber(string phoneNumber)
        {
            return await _context.Users.AsQueryable().AnyAsync(c => c.PhoneNumber == phoneNumber);
        }

        public async Task CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserByPhoneNumber(string phoneNumber)
        {
            return await _context.Users.AsQueryable().SingleOrDefaultAsync(c => c.PhoneNumber == phoneNumber);
        }

        public Task<bool> IsUserExitsPhoneNumbe(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public Task SaveChange()
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}