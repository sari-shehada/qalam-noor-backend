using Microsoft.AspNetCore.Mvc;
using QalamAndNoor.Manager;
using QalamAndNoor.Models;
using QalamAndNoor.Models.HelperModels;

namespace QalamAndNoor.Controllers
{
    public class CityController : ControllerBase
    {
        [Route("CityController/InsertCity")]
        [HttpPost]
        public int InsertCity([FromBody] City city)
        {
            return CityManager.InsertCity(city);
        }
        [Route("CityController/UpdateCity")]
        [HttpPost]
        public int UpdateCity([FromBody] City city)
        {
            return CityManager.UpdateCity(city);
        }
        [Route("CityController/DeleteCity")]
        [HttpPost]
        public int DeleteCity([FromBody] City city)
        {
            return CityManager.DeleteCity(city);
        }

        [Route("CityController/GetCities")]
        [HttpGet]
        public List<City> GetCities()
        {
            return CityManager.GetCities();

        }
        [Route("CityController/GetCitById")]
        [HttpGet]
        public City GetCityById(int id)
        {
            return CityManager.GetCitById(id);
        }

        [Route("CityController/GetCitiesByName")]
        [HttpGet]
        public List<City> GetCitiesByName(string name)
        {
            return CityManager.GetCitiesByName(name);

        }
        [Route("CityController/GetCitiesToAddressesCount")]
        [HttpGet]

        public List<CityToDescendentCount> GetCitiesToAddressesCount()
        {
            return CityManager.GetCitiesToAddressesCount();

        }
        [Route("CityController/GetCitiesToAreasCount")]
        [HttpGet]

        public List<CityToDescendentCount> GetCitiesToAreasCount()
        {
            return CityManager.GetCitiesToAreasCount();
        }
    }
}
