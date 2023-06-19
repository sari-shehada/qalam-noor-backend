using QalamAndNoor.DataManager;
using QalamAndNoor.Models;
using QalamAndNoor.Models.HelperModels;

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

        public static List<CityToDescendentCount> GetCitiesToAreasCount()
        {
            List<CityToDescendentCount> cityToDescendentCounts = new List<CityToDescendentCount>();
            List<City> cities = GetCities();
            foreach (City city in cities)
            {
                int count = AreaManager.GetAreasByCityId(city.ID).Count;
                cityToDescendentCounts.Add(new CityToDescendentCount() {City=city,DescendentCount=count });
            }
            return cityToDescendentCounts;
        }

        public static List<CityToDescendentCount> GetCitiesToAddressesCount()
        {
            List<CityToDescendentCount> cityToDescendentCounts = new List<CityToDescendentCount>();
            List<City> cities = GetCities();
            foreach (City city in cities)
            {
                int count = AddressManager.GetAddresesCountByCityId(city.ID);
                cityToDescendentCounts.Add(new CityToDescendentCount() {City=city,DescendentCount=count });
            }
            return cityToDescendentCounts;
        }
        public static City GetCityByStudentId(int studentId)
        {
            Area area = AreaManager.GetAreaByStudentId(studentId);
            return GetCitById(area.CityId);
        }
    }
}
