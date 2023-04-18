using QalamAndNoor.DataManager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Manager
{
    public abstract class StudentManager
    {
        public static List<Student> GetStudents()
        {
            return StudentDataManager.GetStudents().ToList();
        }
        public static int InsertStudent(Student student)
        {
         return   StudentDataManager.InsertStudent(student);
        }
        public static int UpdateStudent(Student student)
        {
            return StudentDataManager.UpdateStudent(student);
        }
        public static int DeleteStudent(Student student)
        {
            return StudentDataManager.DeleteStudent(student);
        }
        public static Student GetStudentById(int id)
        {
            List<Student> students = GetStudents();
            foreach (Student student in students)
            {
                if (student.ID==id)
                {
                    return student;
                }

            }
            return null;
        }

        public static List<Student> GetStudentByName(string name)
        {
            List<Student> students = GetStudents();
            List<Student> result = new List<Student>();
            foreach (Student item in students)
            {
                if (item.FirstName.ToLower().Trim().Contains(name.ToLower().Trim()))
                {
                    result.Add(item);
                }
            }
            return result;
        }
        public static List<Student> GetStudentsByIsMale()
        {
            List<Student> students = GetStudents();
            List<Student> result = new List<Student>();
            foreach (Student item in students)
            {
                if (item.IsMale == true)
                {
                    result.Add(item);
                }
            }
            return result;
        }
        public static List<Student> GetStudentsByIsFemale()
        {
            List<Student> students = GetStudents();
            List<Student> result = new List<Student>();
            foreach (Student item in students)
            {
                if (item.IsMale == false)
                {
                    result.Add(item);
                }
            }
            return result;
        }
      
        public static List<Student> GetStudentsByFamilyId(int familyId)
        {
            List<Student> students = GetStudents();
            List<Student> result=new List<Student>();
            foreach (Student item in students)
            {
                if (item.FamilyId==familyId)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public static List<Student> GetStudentsByAddressId(int addressId)
        {
            List<Student> students = GetStudents();
            List<Student> result = new List<Student>();
            foreach (Student item in students)
            {
                if (item.AddressId==addressId)
                {
                    result.Add(item);
                }
            }
            return result;
        }

       

    }
}
