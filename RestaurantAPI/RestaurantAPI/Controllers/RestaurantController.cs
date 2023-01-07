using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Entities;

namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly RestaurantDbContext _dbContext;

        public RestaurantController(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ActionResult<IEnumerable<Restaurant>> GetAll()
        {
            var restaurants = _dbContext
                .Restaruants
                .ToList();

            return Ok(restaurants);
        }
    }
}
