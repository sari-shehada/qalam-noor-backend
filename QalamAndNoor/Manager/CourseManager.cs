using QalamAndNoor.DataManager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Manager
{
    public abstract class CourseManager
    {
        public static List<Course> GetCourses()
        {
            return CourseDataManager.GetCourses().ToList();
        }
        public static int InsertCourse(Course course)
        {
            return CourseDataManager.InsertCourse(course);
        }
        public static int UpdateCourse(Course course)
        {
            return CourseDataManager.UpdateCourse(course);
        }
        public static int DeleteCourse(Course course)
        {
            return CourseDataManager.DeleteCourse(course);
        }
        public static Course GetCourseById(int id)
        {
            List<Course> courses = GetCourses();
            foreach (Course course in courses)
            {
                if (course.ID==id)
                {
                    return course;
                }
            }
            return null;
        }

        public static List<Course> GetCoursesByClassId(int classId)
        {
            List<Course> courses = GetCourses();
            List<Course> result = new List<Course>();
            foreach (Course course in courses)
            {
                if (course.ClassId==classId)
                {
                    result.Add(course);
                }
            }
            return result;
             
        }

        public static List<Course> GetCoursesByTeacherId(int teacherId)
        {
            List<Course> courses = GetCourses();
            List<Course> result = new List<Course>();
            foreach (Course item in courses)
            {
                if (item.TeacherId==teacherId)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public static List<Course> GetRequiredToPassCurses()
        {
            List<Course> courses = GetCourses();
            List<Course> result=new List<Course>();
            foreach (Course item in courses)
            {
                if (item.RequiredToPass==true)
                {
                    result.Add(item);
                }
            }
            return result;
        }
        public static bool IsOnlyDropByCourseId(int courseId)
        {
            List<Course> courses = GetRequiredToPassCurses();
            
            foreach (Course item in courses)
            {
                if (item.ID==courseId)
                {
                    return true;
                }
            }
            return false;
          
        }
    }
}
