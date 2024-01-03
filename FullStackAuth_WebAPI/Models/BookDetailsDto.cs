using System.ComponentModel.DataAnnotations;

namespace FullStackAuth_WebAPI.Models
{
    public class BookDetailsDto
    {
        [Key]
        public string BookId { get; set; }
        public ICollection<ReviewWithUserDto>? Reviews { get; set; }
        public double? AvgRating { get; set; }
        public bool Favorite { get; set; }
    }
}
