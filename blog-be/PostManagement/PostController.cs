using blog_be.PostManagement.Model;
using blog_be.PostManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace blog_be.PostManagement
{
    [ApiController]
    [Route("[controller]")]
    public class PostController: ControllerBase
    {
        private readonly IPostService postService;
        public PostController (IPostService postService)
        {
            this.postService = postService;
        }

        [HttpGet ("get-all")]  
        public async Task<IActionResult> GetAllPosts()
          => Ok( await postService.GetAllPosts());

        [HttpGet("get-detail/{postId}")]
        public async Task<IActionResult> GetPostDetail(int postId)
        => Ok(await postService.GetPostDetail(postId));

        [HttpPost("create-post")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreatePost(PostCreation post)
        {
            var result = await postService.CreatePost(post);
            return Ok(result);
        }
    }
}
