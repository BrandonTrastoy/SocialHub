using Backend.Data.DTO.Post;
using Backend.Models;
using Backend.Services;

namespace Backend.Interfaces
{
    public interface IPostService
    {
        Task<ServiceResponse<int>> CreatePost(Post post);
        Task<ServiceResponse<int>> DeletePost(int postId);
        Task<ServiceResponse<List<GetPostDto>>> GetAllPosts();
        Task<ServiceResponse<List<GetUserPostDto>>> GetUserPosts(int userId);
        Task<ServiceResponse<GetUserPostDto>> UpdatePost(UpdatePostDto updatedPost);
    }
}