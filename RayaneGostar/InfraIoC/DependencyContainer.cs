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
            Builder.Services.AddScoped<IPasswordHelper, PasswordHelper>();
            Builder.Services.AddScoped<IUserService, UserService>();
            Builder.Services.AddScoped<IUserRepository, UserRepository>();
        }
    }