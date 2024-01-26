using Lab9.Helpers.JwtUtil;
using Lab9.Repositories.UserRepository;
using Lab9.Services.UserService;
using Proiect.Repositories.ArticoleRepository;
using Proiect.Repositories.ComenziRepository;
using Proiect.Repositories.ProvideriRepository;
using Proiect.Services.ComenziService;
using Proiect.Services.ProvideriService;

namespace Lab9.Helpers.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories (this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IComenziRepository, ComenziRepository>();
            services.AddTransient<IArticoleRepository, ArticoleRepository>();
            services.AddTransient<IProvideriRepository, ProvideriRepository>();


            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IComenziService, ComenziService>();
            services.AddTransient<IProvideriService, ProvideriService>();

            return services;
        }

        public static IServiceCollection AddHelpers(this IServiceCollection services)
        {
            services.AddTransient<IJwtUtils, JwtUtils>();

            return services;
        }
    }
}
