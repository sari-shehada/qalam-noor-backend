using QalamAndNoor.DataManager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Manager
{
    public abstract class FamilyManager
    {
        public static List<Family> GetFamilies()
        {
            return FamilyDataManager.GetFamilies().ToList();
        }
        public static int InsertFamily(Family family)
        {
          return  FamilyDataManager.InsertFamily(family);
        }
        public static int UpdateFamily(Family family) 
        {
            return FamilyDataManager.UpdateFamily(family);
        }
        public static int DeleteFamily(Family family)
        {
            return FamilyDataManager.DeleteFamily(family);
        }
        public static Family GetFamilyById(int id)
        {
            List<Family> families = GetFamilies();
            foreach (Family family in families)
            {
                if (family.ID==id)
                {
                    return family;
                }

            }
            return null;
        }
    }
}
