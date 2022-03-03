using AutoMapper;
using Backend.Data;
using Backend.Data.DTO.Post;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class PostService : IPostService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PostService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<int>> CreatePost(Post post)
        {
            ServiceResponse<int> response = new();

            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            response.Data = post.PostId;
            return response;
        }

        public async Task<ServiceResponse<int>> DeletePost(int postId)
        {
            ServiceResponse<int> response = new();

            Post? postToDelete = await _context.Posts.FirstOrDefaultAsync(c => c.PostId == postId);

            if (postToDelete != null)
            {
                _context.Posts.Remove(postToDelete);
                await _context.SaveChangesAsync();

                response.Message = "Post successfully deleted.";
            }
            else
            {

                response.Success = false;
                response.Message = "Post not found.";
            }

            return response;
        }

        public async Task<ServiceResponse<List<GetPostDto>>> GetAllPosts()
        {
            ServiceResponse<List<GetPostDto>> response = new();

            List<Post> allPosts = await _context.Posts.ToListAsync();
            List<User> allUsers = await _context.Users.ToListAsync();

            var query = from post in allPosts
                        join user in allUsers on post.UserId equals user.Id
                        select new GetPostDto { PostId = post.PostId, Text = post.Text, Username = user.Username };


            response.Data = query.ToList();
            return response;
        }

        public async Task<ServiceResponse<List<GetUserPostDto>>> GetUserPosts(int userId)
        {
            ServiceResponse<List<GetUserPostDto>> response = new();

            List<Post> userPosts = await _context.Posts.Where(c => c.UserId == userId).ToListAsync();
            response.Data = _mapper.Map<List<GetUserPostDto>>(userPosts);

            return response;
        }

        public async Task<ServiceResponse<GetUserPostDto>> UpdatePost(UpdatePostDto updatedPost)
        {
            ServiceResponse<GetUserPostDto> serviceResponse = new();
            try
            {
                Post? post = await _context.Posts.FirstOrDefaultAsync(c => c.PostId == updatedPost.PostId);
                if (post!.UserId == updatedPost.UserId)
                {
                    post.Text = updatedPost.Text;
                    _context.Posts.Update(post);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = _mapper.Map<GetUserPostDto>(post);
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Cannot delete other users posts.";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}