using QalamAndNoor.DataManager;
using QalamAndNoor.DataManager.ViewsDataManager;
using QalamAndNoor.Models;
using QalamAndNoor.Models.HelperModels.DbHelper;

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
                if (item.SchoolYearId == schoolYearId)
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
        public static object FinishedCurrentSemester()
        {
            Semester semester = GetCurrentSemesterInCurrentSchoolYear();
            List<StudentReport> studentReports = StudentReportViewDataManager.GetStudentReports();
            if (studentReports.Count == 0)
            {
                SemesterDataManager.FinishSemester(semester);
                return new
                {
                    Message = "تم انهاء الفصل الحالي بنجاح",
                    Success = true
                };
            }
            return new
            {
                Message = "تعذرت عملية انهاء الفصل الحالي ",
                Success = false,
                Reports = studentReports
            };

        }
        //public static List<ClassReportsDto> GetClassReports()
        //{
        //    List<StudentReport> studentReports = StudentReportViewDataManager.GetStudentReports();
        //    List<ClassReportsDto> classReports = new List<ClassReportsDto>();
        //    studentReports.Sort((a, b) => a.ClassId);
        //    foreach (var item in studentReports)
        //    {

        //    }
          
        //}
    }
}