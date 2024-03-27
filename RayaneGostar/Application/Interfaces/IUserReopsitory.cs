namespace RayaneGostar.Application.Interfaces
{
    public interface IUserReopsitory
    {
         #region Account
         Task<bool>IsUserExitsPhoneNumbe(string phoneNumber);            
         #endregion
    }
}