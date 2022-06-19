using blog_be.PostManament.Services;
using Microsoft.AspNetCore.Mvc;

namespace blog_be.PostManament
{
    [ApiController]
    [Route("[controller]")]
    public class PostManamentController: ControllerBase
    {
        private readonly IGetPostInfoService getPostInfoService;
        public PostManamentController (IGetPostInfoService getPostInfoService)
        {
            this.getPostInfoService = getPostInfoService;
        }

        [HttpGet ("get-all")]  
        public async Task<IActionResult> GetAllPosts()
          => Ok( await getPostInfoService.GetAllPosts());
    }
}
