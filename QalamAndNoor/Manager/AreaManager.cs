using QalamAndNoor.DataManager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Manager
{
    public abstract class AreaManager
    {
        public static List<Area> GetAreas()
        {
            return AreaDataManager.GetAreas().ToList();
        }
        public static int InsertArea(Area area)
        {

            return AreaDataManager.InsertArea(area);
        }
        public static int UpdateArea(Area area)
        {
            return AreaDataManager.UpdateArea(area);
        }
        public static int DeleteArea(Area area) { 
        return AreaDataManager.DeleteArea(area);
        }
        public static Area GetAreaById(int id)
        {
            List<Area> areas = GetAreas();
            foreach (Area area in areas)
            {
                if (area.ID == id)
                {
                    return area;
                }
            }
            return null;

        }
        public static List<Area> GetAreasByName(string name)
        {
            List<Area> areas = GetAreas();
            List<Area> result = new List<Area>();
            foreach (Area item in areas)
            {
                if (item.Name.ToLower().Trim().Contains(name.ToLower().Trim()))
                {
                    result.Add(item);
                }
            }
            return result;
        }
        public static List<Area> GetAreasByCityId(int cityId) 
        {
        List<Area> areas= GetAreas();
            List<Area> result = new List<Area>();
            foreach (Area area in areas)
            {
                if (area.CityId==cityId)
                {
                    result.Add(area);
                }
            }
            return result;
        }
        public static Area GetAreaByStudentId (int studentId)
        {
            Address address=AddressManager.GetAddressByStudentId(studentId);
            return GetAreaById(address.AreaId);

        }

    }
}
