using QalamAndNoor.DataManager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Manager
{
    public abstract class SchoolYearManager
    {
        public static List<SchoolYear> GetSchoolYears()
        {
            return SchoolYearDataManager.GetSchoolYears().ToList();
        }
        public static int InsertSchoolYear(SchoolYear schoolYear)
        {
            return SchoolYearDataManager.InsertSchoolYear(schoolYear);
        }
        public static int UpdateSchoolYear(SchoolYear schoolYear)
        {
            return SchoolYearDataManager.UpdateSchoolYear(schoolYear);
        }
        public static int DeleteSchoolYear(SchoolYear schoolYear)
        {
            return SchoolYearDataManager.DeleteSchoolYear(schoolYear);  
        }
        public static SchoolYear GetSchoolYearById(int id)
        {
            List<SchoolYear> schoolYears = GetSchoolYears();
            foreach (SchoolYear schoolYear in schoolYears)
            {
                if (schoolYear.ID==id)
                {
                    return schoolYear;
                }
            }
            return null;
        }
    }
}
