using WebAppSample.Models;

namespace WebAppSample.Repos;

public class CitiesRepository : ICitiesRepository
{
    public List<City> GetAll()
    {
        return new List<City>
        {
            new City { Id = 1, Name = "Tokyo" },
            new City { Id = 2, Name = "Paris" },
            new City { Id = 3, Name = "London" },
            new City { Id = 4, Name = "New York" },
            new City { Id = 5, Name = "Beijing" }
            // Agrega más ciudades según necesites
        };
    }
}
