namespace FullStackAuth_WebAPI.Models
{
    public class ReviewWithUserDto
    {
        public string Text { get; set; }
        public double Rating { get; set; }
        public User User { get; set; }
    }
}
