using WebAppSample.Models;

namespace WebAppSample.Repos;
 

public class CountryRepository : ICountryRepository
{
    private readonly List<Country> _countries;

    public CountryRepository()
    {
        _countries = new List<Country>
        {
            new Country
            {
                Id = 1,
                Name = "United States",
                Population = 331002651,
                SizeInSquareMeters = 9833517,
                IndependenceYear = 1776,
                Language = "English",
                Currency = "USD"
            },
            new Country
            {
                Id = 2,
                Name = "France",
                Population = 67391582,
                SizeInSquareMeters = 551695,
                IndependenceYear = 486,
                Language = "French",
                Currency = "EUR"
            },
            new Country
            {
                Id = 3,
                Name = "Japan",
                Population = 125836021,
                SizeInSquareMeters = 377975,
                IndependenceYear = null,
                Language = "Japanese",
                Currency = "JPY"
            },
            new Country
            {
                Id = 4,
                Name = "Brazil",
                Population = 212559417,
                SizeInSquareMeters = 8515770,
                IndependenceYear = 1822,
                Language = "Portuguese",
                Currency = "BRL"
            },
            new Country
            {
                Id = 5,
                Name = "Australia",
                Population = 25499884,
                SizeInSquareMeters = 7692024,
                IndependenceYear = 1901,
                Language = "English",
                Currency = "AUD"
            }
        };
    }

    public IEnumerable<Country> GetAllCountries()
    {
        return _countries;
    }

    public int AddCountry(Country country)
    {
        var idCountry = _countries.Max(x => x.Id) + 1;
        country.Id = idCountry;
        _countries.Add(country);
        return idCountry;
    }

    public Country? GetCountry(int id)
    {
        return _countries.Where(x=>x.Id == id).FirstOrDefault();
    }

    public void UpdateCountry(Country country)
    {
        var existingCountry = _countries.Where(x => x.Id == country.Id).FirstOrDefault();
        if(existingCountry != null) 
        {
            existingCountry.SizeInSquareMeters = country.SizeInSquareMeters;
            existingCountry.Population = country.Population;
            existingCountry.Currency = country.Currency;
        }
    }
}