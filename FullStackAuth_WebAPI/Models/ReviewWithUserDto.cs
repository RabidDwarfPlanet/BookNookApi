namespace FullStackAuth_WebAPI.Models
{
    public class ReviewWithUserDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public double Rating { get; set; }
        public string Username { get; set; }
        public string UserId { get; set; }
    }
}
