using System.Collections.Immutable;
using RayaneGostar.Application.Interfaces;
using RayaneGostar.Application.Services;
using RayaneGostar.Domain.Interfaces;
using RayaneGostar.InfraData.Repositories;
using static System.Collections.Immutable.ImmutableArray<T>;

namespace RayaneGostar.InfraIoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region services
            Builder.Services.AddScoped<IUserService, UserService>();
            #endregion

            #region repositories
            Builder.Services.AddScoped<IUserRepository, UserRepository>();
            #endregion

            #region tools
            Builder.Services.AddScoped<IPasswordHelper, PasswordHelper>();
            #endregion

        }
    }