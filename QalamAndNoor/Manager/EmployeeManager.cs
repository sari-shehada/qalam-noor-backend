using QalamAndNoor.DataManager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Manager
{
    public abstract class EmployeeManager
    {
        public static List<Employee> GetEmployees()
        {
            return EmployeeDataManager.GetEmployees().ToList();
        }
        public static int InsertEmployee(Employee employee)
        {
            return EmployeeDataManager.InsertEmployee(employee);
        }
        public static int UpdateEmployee(Employee employee)
        {
            return EmployeeDataManager.UpdateEmployee(employee);
        }
        public static int DeleteEmployee(Employee employee)
        {
            return EmployeeDataManager.DeleteEmployee(employee);
        }
        public static Employee GetEmployeeById(int id)
        {
            List<Employee> employees = GetEmployees();
            foreach (Employee employee in employees)
            {
                if (employee.ID == id)
                {
                    return employee;
                }
            }
            return null;
        }

        public static List<Employee> GetEmployeesByJobTitleId(int jobTitleId)
        {
            List<Employee> employees = GetEmployees();
            List<Employee> result = new List<Employee>();
            foreach (Employee employee in employees)
            {
                if (employee.JobTitleId == jobTitleId)
                {
                    result.Add(employee);
                }
            }
            return result;
        }

        public static List<Employee> GetTeachers()
        {
            List<Employee> employees = GetEmployees();
            List<JobTitle> jobTitles = JobTitleManager.GetTeachersJobTitles();
            List<Employee> result = new List<Employee>();
            foreach (var item in jobTitles)
            {
                result.Add(employees.First((x) => x.JobTitleId == item.ID));
            }
            return result;
        }
        public static List<Employee> GetTeachersByJobTitleId(int jobTitleId)
        {
            List<Employee> employees = GetTeachers();
            List<Employee> result = new List<Employee>();
            foreach (Employee employee in employees)
            {
                if (employee.JobTitleId == jobTitleId)
                {
                    result.Add(employee);
                }
            }
            return result;

        }

        public static List<Employee> GetEmployeesByName(string name)
        {
            List<Employee> employees = GetEmployees();
            List<Employee> result = new List<Employee>();
            foreach (Employee employee in employees)
            {
                if (employee.FirstName.ToLower().Trim().Contains(name.ToLower().Trim()))

                {
                    result.Add(employee);
                }
            }
            return result;
        }
        public static Employee GetEmployeeByCourseId(int courseId)
        {
            Course course = CourseManager.GetCourseById(courseId);
            return GetEmployeeById(course.TeacherId);

        }

    }
}
