using QalamAndNoor.DataManager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Manager
{
    public abstract class PreviousSchoolManager
    {
        public static List<PreviousSchool> GetPreviousSchools()
        {
            return PreviousSchoolDataManager.GetPreviousSchools().ToList();

        }
        public static int InsertPreviousSchool(PreviousSchool previousSchool)
        {
            return PreviousSchoolDataManager.InsertPreviousSchool(previousSchool);
        }
        public static int UpdatePreviousSchool(PreviousSchool previousSchool)
        {
            return PreviousSchoolDataManager.UpdatePreviousSchool(previousSchool);
        }
        public static int DeletePreviousSchool(PreviousSchool previousSchool)
        {
            return PreviousSchoolDataManager.DeletePreviousSchool(previousSchool);
        }
        public static PreviousSchool GetPreviousSchoolById(int id)
        {
            List<PreviousSchool> previousSchools = GetPreviousSchools();
            foreach (PreviousSchool previousSchool in previousSchools)
            {
                if (previousSchool.ID==id)
                {
                    return previousSchool;
                }
            }
            return null;
        }

    }
}
