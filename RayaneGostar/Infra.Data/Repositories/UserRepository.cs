using RayaneGostar.Application.Interfaces;
using RayaneGostar.Domain.Interfaces;

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
        public async Task CreateUser<User, user>()
        {
            await _context.Users.AddAsync(user);
        }

        public async Task SaveChange()
        {
            await _context.SaveChangesAsync();
        }

    }
    #endregion


}
}