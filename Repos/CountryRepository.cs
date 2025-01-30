using Microsoft.AspNetCore.Hosting;
using System.Text.Json;
using WebAppSample.Models;

namespace WebAppSample.Repos;

public class CountriesData
{
    public List<Country> Countries { get; set; }
}

public class CountryRepository : ICountryRepository
{
    private readonly List<Country> _countries;

    public CountryRepository()
    {
        var jsonPath = Path.Combine(@"C:\\Users\\joser\\source\\repos\\WebAppSample\\wwwroot\\", "data", "countries.json");
        var jsonText = System.IO.File.ReadAllText(jsonPath);
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true // This allows case-insensitive property matching
        };

        var jsonData = JsonSerializer.Deserialize<JsonDocument>(jsonText);
        var countriesArray = jsonData.RootElement.GetProperty("countries");
        _countries = JsonSerializer.Deserialize<List<Country>>(countriesArray.GetRawText(), options);

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

    public bool Delete(int countryId)
    {
        var countryToDelete = _countries.Where(x=> x.Id == countryId).FirstOrDefault();
        if(countryToDelete != null) 
        {
            _countries.Remove(countryToDelete);
            return true;
        }
        return false;
    }
}