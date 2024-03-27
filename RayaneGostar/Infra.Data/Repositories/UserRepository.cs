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
        public Task<bool> IsUserExitsPhoneNumbe(string phoneNumber)
        {

        }

    }
}