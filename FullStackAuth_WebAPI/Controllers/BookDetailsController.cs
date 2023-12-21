using FullStackAuth_WebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public BookDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<BookDetailsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BookDetailsController>/5
        [HttpGet("{bookId}")]
        public IActionResult Get(string bookId)
        {
            try
            {
                var favorited = _context.Favorites.Where(f => f.BookId == bookId && f.UserId == User.FindFirstValue("id")).FirstOrDefault();
                bool favoritedByUser = false;
                if (favorited != null)
                {
                    favoritedByUser = true;
                }
                var bookReviews = _context.Reviews.Include(r => r.User).Where(r => r.BookId == bookId).ToList();

                if (bookReviews.Count == 0)
                {
                    return NotFound();
                }

                var bookDetails = new BookDetailsDto
                {
                    BookId = bookId,
                    AvgRating = bookReviews.Average(r => r.Rating),
                    Favorite = favoritedByUser,
                    Reviews = bookReviews.Select(r => new ReviewWithUserDto
                    {
                        Text = r.Text,
                        Rating = r.Rating,
                        Username = r.User.UserName
                    }).ToList()
                };

                return StatusCode(200, bookDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<BookDetailsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
