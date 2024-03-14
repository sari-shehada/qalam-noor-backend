using QalamAndNoor.DataManager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Manager
{
    public abstract class StudentPreviousSchoolManager
    {
        public static List<StudentPreviousSchool> GetStudentPreviousSchools()
        {
            return StudentPreviousSchoolDataManager.GetStudentPreviousSchools().ToList();
        }
        public static int InsertStudentPreviousSchool(StudentPreviousSchool studentPreviousSchool)
        {
            return StudentPreviousSchoolDataManager.InsertStudentPreviousSchool(studentPreviousSchool);
        }
        public static int UpdateStudentPreviousSchool(StudentPreviousSchool studentPreviousSchool)
        {
            return StudentPreviousSchoolDataManager.UpdateStudentPreviousSchool(studentPreviousSchool);
        }
        public static int DeleteStudentPreviousSchool(StudentPreviousSchool studentPreviousSchool)
        {
            return StudentPreviousSchoolDataManager.DeleteStudentPreviousSchool(studentPreviousSchool);
        }
        public static StudentPreviousSchool GetStudentPreviousSchoolById(int id)
        {
            List<StudentPreviousSchool> studentPreviousSchools = GetStudentPreviousSchools();
            foreach (StudentPreviousSchool item in studentPreviousSchools)
            {
                if (item.ID == id)

                {
                    return item;
                }
            }
            return null;
        }

        public static List<StudentPreviousSchool> GetStudentPreviousSchoolsByStudentId(int studentId)
        {
            List<StudentPreviousSchool> studentPreviousSchools = GetStudentPreviousSchools();
            List<StudentPreviousSchool> result = new List<StudentPreviousSchool>();
            foreach (StudentPreviousSchool item in studentPreviousSchools)
            {
                if (item.StudentId==studentId)
                {
                    result.Add(item);

                }
            }
            return result;

        }
    }
}
