using RayaneGostar.Domain.Models.Account;
using RayaneGostar.Domain.Models.ViewModels.Account;

namespace RayaneGostar.Application.Interfaces
{
    public interface IUserService
    {
        #region Account
        Task<RegisterUserResult> RegisterUser(RegisterUserViewModel register);
        Task<LoginUserResult> LoginUser(LoginUserViewModel login);
        Task<User> GetUserByPhoneNumber (string phoneNumber);

        #endregion

    }
}