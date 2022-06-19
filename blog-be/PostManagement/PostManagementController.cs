using blog_be.PostManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace blog_be.PostManagement
{
    [ApiController]
    [Route("[controller]")]
    public class PostManagementController: ControllerBase
    {
        private readonly IGetPostInfoService getPostInfoService;
        public PostManagementController (IGetPostInfoService getPostInfoService)
        {
            this.getPostInfoService = getPostInfoService;
        }

        [HttpGet ("get-all")]  
        public async Task<IActionResult> GetAllPosts()
          => Ok( await getPostInfoService.GetAllPosts());

        [HttpGet("get-detail/{postId}")]
        public async Task<IActionResult> GetPostDetail(int postId)
        => Ok(await getPostInfoService.GetPostDetail(postId));
    }
}
