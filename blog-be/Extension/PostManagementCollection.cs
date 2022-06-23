using blog_be.PostManagement;
using blog_be.PostManagement.Services;

namespace blog_be.Extension
{
    public static class PostManagementCollection
    {
        public static IServiceCollection AddPostManagementCollection(this IServiceCollection services)
           => services.AddScoped<IPostManagementRepository, PostManagementRepositoryImp>()
                      .AddScoped<ICreatePostService,CreatePostServiceImp>()
                      .AddScoped<IGetPostInfoService, GetPostInfoServiceImp>();
    }
}
