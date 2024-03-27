using RayaneGostar.Application.Interfaces;

namespace RayaneGostar.Infra.Data.Repositories
{
    public class UserRepository : IUserReopsitory

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

    }
    #endregion


}
}