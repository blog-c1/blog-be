using blog_be.Login;
using blog_be.Login.Services;

namespace blog_be.Extension;
    public static class LoginCollection
    {
        public static IServiceCollection AddLoginCollection ( this IServiceCollection services)
            => services.AddScoped<ILoginRepository, LoginRepositoryImp>()
                       .AddScoped<ILoginService, LoginServiceImp>();
    }

