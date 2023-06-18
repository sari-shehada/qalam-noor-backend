using QalamAndNoor.DataManager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Manager
{
    public abstract class SemesterManager
    {
        public static List<Semester> GetSemesters()
        {
            return SemesterDataManager.GetSemesters().ToList();
        }
        public static int InsertSemester(Semester semester)
        {
            semester.PreviousSemesterId = GetPreviousSemesterId();
            return SemesterDataManager.InsertSemester(semester);
        }
        public static int UpdateSemester(Semester semester)
        {
            return SemesterDataManager.UpdateSemester(semester);
        }
        public static int DeleteSemester(Semester semester)
        {
            return SemesterDataManager.DeleteSemester(semester);
        }
        public static Semester? GetSemesterById(int id)
        {
            List<Semester> semesters = GetSemesters();
            foreach (Semester semester in semesters)
            {
                if (semester.ID == id)
                {
                    return semester;
                }
            }
            return null;
        }


        public static List<Semester> GetSemestersBySchoolYearId(int schoolYearId)
        {
            List<Semester> semesters = GetSemesters();
            List<Semester> result = new List<Semester>();
            foreach (Semester item in semesters)
            {
                if (item.SchoolYearId == schoolYearId)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        private static Semester? GetSemesterByPreviousSemesterId(int? previousSemsterId)
        {
            List<Semester> semesters = GetSemesters();
            foreach (Semester semester in semesters)
            {
                if (semester.PreviousSemesterId == previousSemsterId)
                {
                    return semester;
                }
            }
            return null;
        }

        public static int? GetPreviousSemesterId(int? id = null)
        {
            try
            {
                Semester? result = GetSemesterByPreviousSemesterId(id);
                if (result == null)
                {
                    return id!.Value;
                }
                return GetPreviousSemesterId(result!.ID);
            }
            catch
            {
                return null;
            }
        }

        public static List<Semester> GetSemestersInCurrentSchoolYear()
        {
            int schoolYearId = SchoolYearManager.GetCurrentSchoolYear().ID;
            List<Semester> semesters = GetSemesters();
            List<Semester> result = new List<Semester>();
            foreach (Semester item in semesters)
            {
                if (item.SchoolYearId==schoolYearId)
                {
                    result.Add(item);
                }
            }
            return result;
        }
        public static Semester GetCurrentSemesterInCurrentSchoolYear()
        {
            return GetSemesterById(GetCurrentSemesterIdInCurrentSchoolYear());
        }
       
        
        
        
        
        
        
        
        private static int GetCurrentSemesterIdInCurrentSchoolYear()
        {
            List<Semester> semesters = GetSemestersInCurrentSchoolYear();
            return semesters.Max(x => x.ID);
        }
    }
}