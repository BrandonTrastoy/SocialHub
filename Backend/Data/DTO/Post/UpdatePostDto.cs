namespace Backend.Data.DTO.Post
{
    public class UpdatePostDto
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string? Text { get; set; }
    }
}
