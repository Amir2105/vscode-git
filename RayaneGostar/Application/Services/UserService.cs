using RayaneGostar.Application.Interfaces;
using RayaneGostar.Domain.Interfaces;
using RayaneGostar.Domain.Models.Account;
using RayaneGostar.Domain.Models.ViewModels;
using RayaneGostar.Infra.Data.Repositories;

namespace RayaneGostar.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userReopsitory;
        private readonly IPasswordHelper _passwordHelper;

        public UserService(UserRepository userReopsitory, PasswordHelper passwordHelper)
        {
            _userReopsitory = userReopsitory;
            _passwordHelper = passwordHelper;
        }




        public async Task<RegisterUserResult> RegisterUser(RegisterUserViewModel register)
        {
            if (!await _userReopsitory.IsUserExitsPhoneNumbe(register.PhoneNumber))
            {
                var user = new User
                {
                    FirstName = register.FirstName,
                    LastName = register.LastName,
                    UserGender = UserGender.Unknown,
                    Password = _passwordHelper.EncodePasswordMd5(register.Password),
                    PhoneNumber = register.PhoneNumber,
                    Avatar = "Default.Png",
                    IsMobileActive = false,
                    MobileActiveCode = new Random().Next(10000, 99999).ToString(),
                    IsBlocked = false,
                    IsDelete = false,

                };
                return RegisterUserResult.Success;
            }
            await _userReopsitory.CreateUser(user);
            await _userReopsitory.SaveChange();
            return RegisterUserResult.MobileExists;
        }

    }
}
