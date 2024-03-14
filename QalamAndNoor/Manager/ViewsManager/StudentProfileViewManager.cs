using QalamAndNoor.DataManager.ViewsDataManager;
using QalamAndNoor.MyViews;

namespace QalamAndNoor.Manager.ViewsManager
{
    public abstract class StudentProfileViewManager
    {
        public static List<StudentProfileView> GetStudentProfileViews()
        {
            return StudentProfileDataManager.GetStudentProfileViews();
        }
        public static StudentProfileView GetStudentProfileViewByStudentId(int studentId)
        {
            List<StudentProfileView> studentProfileViews = GetStudentProfileViews();
            foreach(StudentProfileView studentProfileView in studentProfileViews)
            {
                if (studentProfileView.StudentId==studentId)
                {
                    return studentProfileView;
                }
            }
            return null;
        }
    }
}
