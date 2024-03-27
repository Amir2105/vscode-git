using RayaneGostar.Application.Interfaces;
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

        public Task<RegisterUserResult> RegisterUser(RegisterUserViewModel register)
        {

        }
    }
}