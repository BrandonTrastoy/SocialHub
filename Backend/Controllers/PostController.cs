using Backend.Data.DTO.Post;
using Backend.Interfaces;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _repo;
        public PostController(IPostService repo)
        {
            _repo = repo;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreatePost(CreatePostDto request)
        {
            Console.WriteLine(request.UserId);
            Console.WriteLine(request.Text);

            ServiceResponse<int> response = await _repo.CreatePost(new Post { Text = request.Text, UserId = request.UserId });
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            ServiceResponse<int> response = await _repo.DeletePost(id);
            return Ok(response);
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllPosts()
        {
            ServiceResponse<List<GetPostDto>> response = await _repo.GetAllPosts();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserPosts(int id)
        {
            ServiceResponse<List<GetUserPostDto>> response = await _repo.GetUserPosts(id);
            return Ok(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdatePost(UpdatePostDto updatedPost)
        {
            ServiceResponse<GetUserPostDto> response = await _repo.UpdatePost(updatedPost);
            return Ok(response);
        }
    }
}