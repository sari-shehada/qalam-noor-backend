using QalamAndNoor.DataManager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Manager
{
    public abstract class ClassManager
    {
        public static List<Class> GetClasses()
        {
            return ClassDataManager.GetClasses().ToList();
        }
        public static int InsertClass(Class cls)
        {
            return ClassDataManager.InsertClass(cls);
        }
        public static int UpdateClass(Class cls)
        {
            return ClassDataManager.UpdateClass(cls);
        }
        public static int DeleteClass(Class cls)
        {
            return ClassDataManager.DeleteClass(cls);
        }
        public static Class? GetClassById(int id)
        {
            List<Class> classes = GetClasses();
            foreach (Class cls in classes)
            {
                if (cls.ID == id)
                {
                    return cls;
                }
            }
            return null;
        }
        public static List<Class> GetClassesByName(string name)
        {
            List<Class> classes = GetClasses();
            List<Class> result = new List<Class>();
            foreach (Class item in classes)
            {
                if (item.Name.ToLower().Trim().Contains(name.ToLower().Trim()))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public static Class GetPreceedingClassByClassId(int classID)
        {
            Class thisClass = GetClassById(classID);
            if (thisClass.PreviousClassId == null)
            {
                return thisClass;
            }
            return GetClassById(thisClass.PreviousClassId.Value);
        }

        public static Class? GetCurrentClassInCurrentSchoolYearByStudentId(int studentId)
        {
            YearRecord yearRecord = YearRecordManager.GetYearRecordsinCurrentSchoolYearByStudentId(studentId);
            if (yearRecord is null)
            {
                return null;
            }
            return GetClassById(yearRecord.ClassId);
        }
        public static Class GetClassByCoureseId(int coureseId)
        {
            Course course = CourseManager.GetCourseById(coureseId);
            return GetClassById(course.ClassId)!;
        }
        public static Class GetClassByExamId(int examId)
        {
            Exam exam = ExamManager.GetExamById(examId);
            return GetClassById(exam.ClassId)!;
        }
        
      
    }
}
