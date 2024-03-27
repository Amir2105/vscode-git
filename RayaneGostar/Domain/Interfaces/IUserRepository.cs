using RayaneGostar.Domain.Models.Account;

namespace RayaneGostar.Domain.Interfaces
{
    public interface IUserRepository
    {
        #region Account
        Task<bool> IsUserExitsPhoneNumbe(string phoneNumber);
        Task CreateUser(User user);
        Task SaveChange();
        
        Task<User>GetUserByPhoneNumber(string phoneNumber);

        #endregion
    }
}