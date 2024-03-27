using RayaneGostar.Application.Interfaces;
using RayaneGostar.Domain.Models.Account;
using RayaneGostar.Domain.Models.ViewModels;

namespace RayaneGostar.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserReopsitory _userReopsitory;
        public UserService(IUserReopsitory userReopsitory)
        {
            _userReopsitory = userReopsitory;
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
                    Password = "",
                    PhoneNumber = register.PhoneNumber,
                    Avatar = "Default.Png",
                    IsMobileActive = false,
                    MobileActiveCode = new Random().Next(10000, 99999).ToString(),
                    IsBlocked = false,
                    IsDelete = false,

                };
            }

        }
    }
}