using blog_be.PostManament.Model;

namespace blog_be.PostManament.Services
{
    public interface IGetPostInfoService
    {
        public Task<List<PostInfo>> GetAllPosts();
    }


    public class GetPostInfoServiceImp: IGetPostInfoService
    {
        private readonly IPostManamentRepository postManamentRepository;

        public GetPostInfoServiceImp( IPostManamentRepository postManamentRepository)
        {
            this.postManamentRepository  = postManamentRepository;
        }

        public async Task<List<PostInfo>> GetAllPosts()
         => await postManamentRepository.GetAllPost();
    }
}
