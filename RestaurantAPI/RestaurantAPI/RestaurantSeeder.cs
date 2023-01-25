using RestaurantAPI.Entities;
using System.Xml.Linq;

namespace RestaurantAPI
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;

        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Restaruants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaruants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }
        }
        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "User"
                },

                new Role()
                {
                    Name = "Manager"
                },

                new Role()
                {
                    Name = "Admin"
                },
            };

            return roles;   

        }
        private IEnumerable<Restaurant> GetRestaurants()
        {
                var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Name = "KFC",
                    Category = "Fast food",
                    Description = "Kentucky fried chicken",
                    ContactEmail = "random@gmail.com",
                    ContactNumber = "5434223332",
                    HasDelivery = true,
                    Dishes = new List<Dish>()
                    {
                            new Dish()
                            {
                                Name = "Hot wings",
                                Price = 14,
                                Description = "123"
                            },

                            new Dish()
                            {
                                Name = "Nuggets",
                                Price = 10,
                                Description = "123"
                            },
                    },

                    Address = new Address()
                    {
                        City = "Wrocław",
                        Street = "Piekna",
                        PostalCode = "56-500"
                    }
                },
                    new Restaurant()
                    {
                        Name = "KFC2",
                        Category = "Fast food2",
                        Description = "Kentucky fried chicken2",
                        ContactEmail = "random@gmail.com",
                        ContactNumber = "5434223332",
                        HasDelivery = true,
                        Dishes = new List<Dish>()
                        {
                            new Dish()
                            {
                                Name = "Kurczaki",
                                Price = 14,
                                Description = "123"
                            },

                            new Dish()
                            {
                                Name = "Hosy wingsy",
                                Price = 10,
                                Description = "123"
                            },
                        },

                        Address = new Address()
                        {
                            City = "Wrocław",
                            Street = "Piekna",
                            PostalCode = "56-500"
                        }
                    }
            };
                return restaurants;
        }
    }
}
