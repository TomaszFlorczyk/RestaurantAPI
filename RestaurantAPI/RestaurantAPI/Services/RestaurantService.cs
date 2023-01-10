using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Entities;
using RestaurantAPI.Models;

namespace RestaurantAPI.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly RestaurantDbContext _dbContext;
        private readonly IMapper _mapper;

        public RestaurantService(RestaurantDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public RestaurantDto GetById(int id)
        {


            var restaurant = _dbContext
                .Restaruants
                .Include(r => r.Address)
                .Include(r => r.Dishes)
                .FirstOrDefault(x => x.Id == id);

            if (restaurant == null) return null;

            var result = _mapper.Map<RestaurantDto>(restaurant);
            return result;
        }

        public IEnumerable<RestaurantDto> GetAll()
        {
            var restaurants = _dbContext
                .Restaruants
                .Include(r => r.Address)
                .Include(r => r.Dishes)
                .ToList();

            var restaurantsDtos = _mapper.Map<List<RestaurantDto>>(restaurants);
            return restaurantsDtos;
        }

        public bool Delete(int id)
        {
            var restaurant = _dbContext
                .Restaruants
                .FirstOrDefault(x => x.Id == id);

            if (restaurant == null) return false;
            _dbContext.Restaruants.Remove(restaurant);
            _dbContext.SaveChanges();
            return true;
        }

        public int Create(CreateRestaurantDto dto)
        {
            var restaurant = _mapper.Map<Restaurant>(dto);
            _dbContext.Restaruants.Add(restaurant);
            _dbContext.SaveChanges();

            return restaurant.Id;
        }
    }
}
