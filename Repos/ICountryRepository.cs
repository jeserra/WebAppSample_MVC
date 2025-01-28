using WebAppSample.Models;

namespace WebAppSample.Repos;

public interface ICountryRepository
{
    IEnumerable<Country> GetAllCountries();
    int AddCountry(Country country);
    Country? GetCountry(int id);
    void UpdateCountry (Country country);

}
