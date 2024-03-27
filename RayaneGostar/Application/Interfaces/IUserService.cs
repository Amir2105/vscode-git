using RayaneGostar.Domain.Models.ViewModels;

namespace RayaneGostar.Application.Interfaces
{
    public interface IUserService
    {
        #region Account
        Task<RegisterUserResult> RegisterUser(RegisterUserViewModel register);
        Task<LoginUserResult> LoginUser(LoginUserViewModel login);

        #endregion

    }
}