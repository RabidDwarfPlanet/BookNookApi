namespace FullStackAuth_WebAPI.Models
{
    public class BookDetailsDto
    {
        public List<ReviewWithUserDto> Reviews { get; set; }
        public double AvgRating { get; set; }
        public bool Favorite { get; set; }
    }
}
