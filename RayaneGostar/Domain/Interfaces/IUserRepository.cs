namespace RayaneGostar.Domain.Interfaces
{
    public interface IUserRepository
    {
        #region Account
        Task<bool> IsUserExitsPhoneNumbe(string phoneNumber);
        Task CreateUser<User user>;
        Task SaveChange();
        #endregion
    }
}