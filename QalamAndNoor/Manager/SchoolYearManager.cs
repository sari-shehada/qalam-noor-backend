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

        public static object InsertSchoolYear(SchoolYear schoolYear)
        {
            schoolYear.PreviousSchoolYearId = GetPreviousSchoolYearID();
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

        public static SchoolYear? GetSchoolYearById(int id)
        {
            List<SchoolYear> schoolYears = GetSchoolYears();
            foreach (SchoolYear schoolYear in schoolYears)
            {
                if (schoolYear.ID == id)
                {
                    return schoolYear;
                }
            }
            return null;
        }

        private static SchoolYear? GetSchoolByPreviousSchoolYearById(int? previousSchoolYearId)
        {
            List<SchoolYear> schoolYears = GetSchoolYears();
            foreach (SchoolYear schoolYear in schoolYears)
            {
                if (schoolYear.PreviousSchoolYearId == previousSchoolYearId)
                {
                    return schoolYear;
                }
            }
            return null;
        }

        public static int? GetPreviousSchoolYearID(int? id = null)
        {
            try
            {
                SchoolYear? result = GetSchoolByPreviousSchoolYearById(id);
                if (result == null)
                {
                    return id!.Value;
                }
                return GetPreviousSchoolYearID(result!.ID);
            }
            catch
            {
                return null;
            }
        }

        private static int GetMaxSchoolYearID()
        {
            List<SchoolYear> schoolYears = GetSchoolYears();
            return schoolYears.Max(x => x.ID);
        }
        public static SchoolYear GetCurrentSchoolYear()
        {
            return GetSchoolYearById(GetMaxSchoolYearID());
        }
        public static List<SchoolYear> GetSchoolYearsByStudentId(int studentId)
        {
            return SchoolYearDataManager.GetSchoolYearsByStudentId(studentId);
        }

    }
}

