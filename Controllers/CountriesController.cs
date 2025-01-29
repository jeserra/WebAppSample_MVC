using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;
using WebAppSample.Models;
using WebAppSample.Repos;

namespace WebAppSample.Controllers;
public class CountriesController : Controller
{
    private readonly ICountryRepository _countryRepository;
    private readonly ICitiesRepository _cityRepository;

    public CountriesController(ICountryRepository countryRepository, ICitiesRepository cityRepository)
    {
        _countryRepository = countryRepository;
        _cityRepository=cityRepository;
    }

    public IActionResult Index()
    {
        var countries = _countryRepository.GetAllCountries();
       
        return View(countries);
    }

    [HttpGet]
    public IActionResult Create()
    {
        Country country = new Country();
        country.Id = 0;

        // Si estás usando Entity Framework:
        ViewBag.Cities = _cityRepository.GetAll();
        return View(country);
    }

    [HttpPost]
    public IActionResult Create(Country country)
    {

        if (ModelState.IsValid)
        {
            _countryRepository.AddCountry(country);
            // Aquí tu lógica para guardar el country
            return RedirectToAction("Index");
        }
        return View(country);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var country = _countryRepository.GetCountry(id);
        return View(country);
    }

    [HttpPost]
    public IActionResult Edit(Country country) 
    {
        if (ModelState.IsValid) 
        {           
            _countryRepository.UpdateCountry(country);           
            return RedirectToAction("Index");
        }
        else 
            return View("Edit", country);
    }

    [HttpDelete]
    public IActionResult Delete(int id) 
    {
         var result = _countryRepository.Delete(id);
        return Json(new { success = result });
    }
}