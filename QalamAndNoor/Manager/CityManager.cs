using QalamAndNoor.DataManager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Manager
{
    public abstract class CityManager
    {
        public static List<City> GetCities()
        {
            return CityDataManager.GetCities().ToList();

        }
        public static int InsertCity(City city)
        {
            return CityDataManager.InsertCity(city);
        }
        public static int UpdateCity(City city)
        {
            return CityDataManager.UpdateCity(city);
        }
        public static int DeleteCity(City city)
        {
            return CityDataManager.DeleteCity(city);
        }
        public static City GetCitById(int id)
        {
            List<City> cities = GetCities();
            foreach (City city in cities)
            {
                if (city.ID==id)
                {
                    return city;
                }

            }
                return null;
        }

        public static List<City> GetCitiesByName(string name)
        {
            List<City> cities = GetCities();
            List<City> result= new List<City>();
            foreach (City city in cities)
            {
                if (city.Name.ToLower().Trim().Contains(name.ToLower().Trim()))
                {
                    result.Add(city);
                }
            }
            return result;
        }
    }
}
