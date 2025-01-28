using WebAppSample.Models;

namespace WebAppSample.Repos;
public interface ICitiesRepository
{
    public List<City> GetAll();
}
