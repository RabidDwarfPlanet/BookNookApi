using FullStackAuth_WebAPI.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public FavoritesController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<FavoritesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/<FavoritesController>
        [HttpPost, Authorize]
        public IActionResult Post([FromBody] Models.Favorite review)
        {
            _context.Favorites.Add(review);
            _context.SaveChanges();
            return StatusCode(201, review);
        }

        // DELETE api/<FavoritesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
