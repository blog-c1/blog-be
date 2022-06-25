using blog_be.PostManagement.Model;
using blog_be.PostManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace blog_be.PostManagement
{
    [ApiController]
    [Route("[controller]")]
    public class PostManagementController : ControllerBase
    {
        private readonly IGetPostInfoService getPostInfoService;
        private readonly ICreatePostService createPostService;

        public PostManagementController(IGetPostInfoService postService, ICreatePostService createPostService)
        {
            this.getPostInfoService = postService;
            this.createPostService = createPostService;
        }

        [HttpGet("api/get-all")]
        public async Task<IActionResult> GetAllPosts()
          => Ok(await getPostInfoService.GetAllPosts());

        [HttpGet("api/get-detail/{postId}")]
        public async Task<IActionResult> GetPostDetail(int postId)
        => Ok(await getPostInfoService.GetPostDetail(postId));

        [HttpPost("api/create-post")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreatePost(PostCreation post)
        {
            var result = await createPostService.CreatePost(post);
            return Ok(result);
        }
    }
}