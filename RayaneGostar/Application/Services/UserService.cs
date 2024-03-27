using RayaneGostar.Application.Interfaces;

namespace RayaneGostar.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserReopsitory _userReopsitory;
        public UserService(IUserReopsitory userReopsitory)
        {
           _userReopsitory = userReopsitory; 
        }

    }
}