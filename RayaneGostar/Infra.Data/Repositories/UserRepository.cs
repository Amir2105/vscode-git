using Microsoft.EntityFrameworkCore;
using RayaneGostar.Application.Interfaces;
using RayaneGostar.Domain.Interfaces;
using RayaneGostar.Domain.Models.Account;
using RayaneGostar.Infra.Data.Context;

namespace RayaneGostar.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository

    {
        #region Constarctor
        private readonly RDbContext _context;
        public UserRepository(RDbContext context)
        {
            _context = context;
        }

        #endregion
        #region Account
        public async Task<bool> IsUserExitsPhoneNumbe(string phoneNumber)
        {
            return await _context.Users.AsQueryable().AnyAsync(c => c.PhoneNumber == phoneNumber);
        }
        public async Task CreateUser<User user>()
        {
            await _context.Users.AddAsync(user);
        }

        public async Task SaveChange()
        {
            await _context.SaveChangesAsync();
        }

        public Task CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByPhoneNumber(string phoneNumber)
        {
            return await _context.Users.AsQueryable().SingleOrDefaultAsync(c => c.PhoneNumber == phoneNumber);
        }
    }
    #endregion


}
