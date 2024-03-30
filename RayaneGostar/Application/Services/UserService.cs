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

        public UserService(IUserRepository userReopsitory, IPasswordHelper passwordHelper)
        {
            _userReopsitory = userReopsitory;
            _passwordHelper = passwordHelper;
        }

        public async Task<User> GetUserByPhoneNumber(string phoneNumber)
        {
            return await _userReopsitory.GetUserByPhoneNumber(phoneNumber);
        }


        public async Task<LoginUserResult> LoginUser(LoginUserViewModel login)
        {
            var user = await _userReopsitory.GetUserByPhoneNumber(login.PhoneNumber);
            if (user == null) return LoginUserResult.NotFound;
            if (user.IsBlocked) return LoginUserResult.IsBlocked;
            if (!user.IsMobileActive) return LoginUserResult.NotActive;
            if (user.Password != _passwordHelper.EncodePasswordMd5(login.Password)) return LoginUserResult.NotFound;

            return LoginUserResult.Success;

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
                await _userReopsitory.CreateUser(user);
                await _userReopsitory.SaveChange();
                return RegisterUserResult.Success;
            }

            return RegisterUserResult.MobileExists;
        }

    }
}
